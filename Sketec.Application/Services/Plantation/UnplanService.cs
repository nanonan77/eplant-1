using AutoMapper;
using EnsureThat;
using Sketec.Application.Filters;
using Sketec.Application.Interfaces;
using Sketec.Application.Utils;
using Sketec.Core.Domains;
using Sketec.Core.Extensions;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using Sketec.FileWriter.Excels;
using Sketec.FileWriter.Resources;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sketec.Application.Resources;
using Sketec.Core.Specifications;
using Sketec.Core.Domains.Types;
using Sketec.FileWriter.Pdf;
using System.Globalization;
using Sketec.Application.Interfaces.Plantation;
using Sketec.Application.Resources.Management;
using Sketec.Application.Resources.Management.Assumptions;

namespace Sketec.Application.Services
{
    public class UnplanService : ApplicationService, IUnplanService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<Plantation> plantRepo;
        IWCRepository<Assumption> assumRepo;
        IUserService userService;
        IRunningNumberService runningNumberService;
        public UnplanService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<Plantation> plantRepo,
            IWCQueryRepository queryRepo,
            IWCRepository<Assumption> assumRepo,
            IUserService userService,
            IRunningNumberService runningNumberService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.plantRepo = plantRepo;
            this.assumRepo = assumRepo;
            this.userService = userService;
            this.runningNumberService = runningNumberService;
        }

        private (string, string) GetPermissionFilter()
        {
            var pic = string.Empty;
            var sectionName = string.Empty;
            if (SketecUtils.RoleOperation.Contains(Role))
            {
                pic = UserName;
            }
            else if (SketecUtils.RoleDocument.Contains(Role))
            {
                sectionName = Section;
            }
            return (pic, sectionName);
        }


        public async Task<List<UnplanSearchResult>> GetUnplan(UnplanSearchFilter filter)
        {
            var approver = Email;
            var (pic, sectionName) = GetPermissionFilter();
            var spec = new UnplanLinqSearchSpec(filter ?? new UnplanSearchFilter(), pic, sectionName, approver);
            var data = await queryRepo.ListAsync(spec);
            data.ForEach(o => o.IsMyTask = o.PIC == Email || o.Approver1 == Email || o.Approver2 == Email || o.Approver3 == Email);
            return data;
        }

        public async Task<UnplanDetailDto> GetUnplanDetail(Guid plantationId)
        {
            //var (pic, sectionName) = GetPermissionFilter();
            var spec = new NewPlantationSearchByIdSpec(plantationId).NoTracking().InCludeUnplans().InCludeNewRegist();
            var plantation = await plantRepo.GetBySpecAsync(spec);
            if (plantation == null) 
            {
                throw new ApplicationException("Invalid plant Id");
            }
            var newRegistId = plantation.NewRegistId;
            var specAssump = new AssumptionSearchByNewRegistIdSpec(newRegistId).NoTracking().IncludeExpenses();
            var assumption = await assumRepo.GetBySpecAsync(specAssump);

            if (assumption == null)
            {
                throw new ApplicationException("Invalid data");
            }
            var picData = await userService.GetUserInfo(plantation.PIC);
            if (picData == null)
            {
                picData = new Resources.Users.UserResultDto();
            }
            var sectionName = picData.Sec_Name;
            var latestUnplan = plantation.Unplans.LastOrDefault();

            var startYear = plantation.ContractStartDate.Value;
            var currentYear = (int)(DateTime.Now.Subtract(startYear).TotalDays / 365.25) + 1;

            var unplanHistory = mapper.Map<List<Unplan>, List<UnplanHistoryDto>>(plantation.Unplans.ToList());
            
            var mode = latestUnplan?.Approver1 == Email || latestUnplan?.Approver2 == Email || latestUnplan?.Approver3 == Email
                            ? "approver" : plantation.PIC == Email || sectionName == Section || Role == "A" ? "creator" : "viewer";
            var result = new UnplanDetailDto
            {
                UserMode = mode,
                CurrentYear = currentYear,
                EmpUserName = UserName,
                PicUserName = plantation.PIC,
                UnplanId = latestUnplan == null ? Guid.Empty : latestUnplan.Id,
                PlantationId = plantation.Id,
                NewRegistId = plantation.NewRegistId,
                UnplanNo = latestUnplan?.UnplanNo,
                Reason = latestUnplan?.Reason,
                PlantationNo = plantation.PlantationNo,
                ContractStartYear = plantation.ContractYear ?? 0,
                ContractStartMonth = plantation.ContractMonth ?? 0,
                ContractYear = plantation.NewRegist.Contract ?? 0,
                ContractType = plantation.ContractType,
                RentalArea = plantation.NewRegist.TotalArea,
                ProductiveAreaPercent = assumption?.ProductiveAreaPercent,
                ProductiveArea = assumption?.ProductiveArea,
                ApproveStatus = latestUnplan?.Approver1 == Email
                                ? latestUnplan?.StatusApprover1
                                : latestUnplan?.Approver2 == Email
                                    ? latestUnplan?.StatusApprover2
                                    : latestUnplan?.Approver3 == Email
                                        ? latestUnplan?.StatusApprover3
                                        : string.Empty,
                ApproveRemark = latestUnplan?.Approver1 == Email
                                ? latestUnplan?.Remark1
                                : latestUnplan?.Approver2 == Email
                                    ? latestUnplan?.Remark2
                                    : latestUnplan?.Approver3 == Email
                                        ? latestUnplan?.Remark3
                                        : string.Empty,
                HistoryLog = unplanHistory,
                UnplanSummary = GetUnplanSummary(mode, latestUnplan?.Id ?? Guid.Empty, assumption),
                ExpenseGroupA = GetExpenseDtos(ExpenseType.ActivityGroupA, assumption.Expenses),
                ExpenseGroupB = GetExpenseDtos(ExpenseType.ActivityGroupB, assumption.Expenses),
                ExpenseGroupC = GetExpenseDtos(ExpenseType.ActivityGroupC, assumption.Expenses),
                ExpenseGroupD = GetExpenseDtos(ExpenseType.ActivityGroupD, assumption.Expenses),
                ExpenseGroupF = GetExpenseDtos(ExpenseType.ActivityGroupF, assumption.Expenses),
            };
            return result;
        }

        public async Task UpdateUnplan(string action, UnplanDetailDto request)
        {
            Ensure.Any.IsNotNull(request, "AssumptionRequest");
            // ดึงข้อมูล plantation
            var spec = new NewPlantationSearchByIdSpec(request.PlantationId).InCludeUnplans();
            var plantation = await plantRepo.GetBySpecAsync(spec);
            if (plantation == null)
            {
                throw new ApplicationException("Invalid plant Id");
            }
            // ดึงข้อมูล Expense เพราะที่ Expense เก็บกิจกรรม
            var newRegistId = plantation.NewRegistId;
            var specAssump = new AssumptionSearchByNewRegistIdSpec(newRegistId).IncludeExpenses();
            var assumption = await assumRepo.GetBySpecAsync(specAssump);
            if (assumption == null)
            {
                throw new ApplicationException("Invalid data");
            }
            var contractYear = assumption.ContractYear;
            var rentalArea = assumption.RentalArea ?? 0;
            var plantArea = assumption.ProductiveArea ?? 0;
            // DTO กระจายย่อยแต่ละ group เลยต้องเอามา union กันก่อน โดยเอาเฉพาะ unplan ล่าสุด
            // Unplan Id ที่ส่งไปตอนดึงข้อมูล จะเป็นอันล่าสุด ถ้า UI มีการกดสร้าง Unplan ใหม่ ต้องส่งมาเป็น Guid.Empty
            var expenseRequestList = request.ExpenseGroupA.Union(request.ExpenseGroupB).Union(request.ExpenseGroupC).Union(request.ExpenseGroupD).Union(request.ExpenseGroupF).Where(o => o.UnplanId == request.UnplanId).ToList();
            // ดึงข้อมูล กิจกรรมที่ add มาใหม่ ว่ายอดรวมเท่าไหร่ เพื่อใช้ใน flow Approve
            var summaryCurrentUnplan = GetSummaryAllYear(contractYear, rentalArea, plantArea, string.Empty, expenseRequestList);
            // ดูว่าใน DB มีข้อมูล Unplan นี้รึยัง
            var latestUnplan = plantation.Unplans.FirstOrDefault(o => o.Id == request.UnplanId);
            // ดึงข้อมูล User เพื่อใช้ใน flow approve
            var pic = await userService.GetUserInfo(UserName);
            if (latestUnplan == null)
            {
                foreach (var item in plantation.Unplans.Where(o => o.IsLatest)) 
                {
                    item.IsLatest = false;
                }
                var runningNumber = await runningNumberService.GetRunningNumber("Unplan", DateTime.Now.Year);
                latestUnplan = new Unplan
                {
                    PlantationId = request.PlantationId,
                    NewRegistId = request.NewRegistId,
                    UnplanNo = runningNumber,
                    Reason = request.Reason,
                    OverAllStatus = action == UnplanStatusType.Draft.GetStringValue() ? UnplanStatusType.Draft.GetStringValue() : UnplanStatusType.WaitforApprove.GetStringValue(),
                    Approver1 = pic.ManagerEmail,
                    StatusApprover1 = UnplanApproveStatusType.WaitforApprove.GetStringValue(),
                    Approver2 = summaryCurrentUnplan.TotalCost > 70000 ? pic.ReportToEmail2 : null,
                    StatusApprover2 = summaryCurrentUnplan.TotalCost > 70000 ? UnplanApproveStatusType.WaitforApprove.GetStringValue() : null,
                    Approver3 = summaryCurrentUnplan.TotalCost > 700000 ? pic.ReportToEmail3 : null,
                    StatusApprover3 = summaryCurrentUnplan.TotalCost > 700000 ? UnplanApproveStatusType.WaitforApprove.GetStringValue() : null,
                    IsLatest = true,
                    TotalCost = summaryCurrentUnplan.TotalCost
                };
                plantation.AddUnplan(latestUnplan);
                await uow.SaveAsync();
                foreach (var item in expenseRequestList)
                {
                    var detail = GetExpenseFromDto(latestUnplan.Id, item);
                    assumption.AddExpense(detail);
                }

                await uow.SaveAsync();
            }
            else
            {
                latestUnplan.TotalCost = summaryCurrentUnplan.TotalCost;
                latestUnplan.Reason = request.Reason;
                latestUnplan.OverAllStatus = action == UnplanStatusType.Draft.GetStringValue() ? UnplanStatusType.Draft.GetStringValue() : UnplanStatusType.WaitforApprove.GetStringValue();
                latestUnplan.Approver1 = pic.ManagerEmail;
                latestUnplan.StatusApprover1 = UnplanApproveStatusType.WaitforApprove.GetStringValue();
                latestUnplan.Approver2 = summaryCurrentUnplan.TotalCost > 70000 ? pic.ReportToEmail2 : null;
                latestUnplan.StatusApprover2 = summaryCurrentUnplan.TotalCost > 70000 ? UnplanApproveStatusType.WaitforApprove.GetStringValue() : null;
                latestUnplan.Approver3 = summaryCurrentUnplan.TotalCost > 700000 ? pic.ReportToEmail3 : null;
                latestUnplan.StatusApprover3 = summaryCurrentUnplan.TotalCost > 700000 ? UnplanApproveStatusType.WaitforApprove.GetStringValue() : null;
                var expenseList = assumption.Expenses.Where(o => o.IsUnplan && o.UnplanId == request.UnplanId).ToList();
                foreach (var item in expenseList) 
                {
                    item.IsActive = false;
                }

                foreach (var item in expenseRequestList) 
                {
                    var detail = assumption.Expenses.FirstOrDefault(f => f.Id == item.Id);
                    if (detail == null)
                    {
                        detail = GetExpenseFromDto(request.UnplanId, item);
                        assumption.AddExpense(detail);
                    }
                    else
                    {
                        detail.ActivityId = item.ActivityId;
                        detail.BahtPerRai = item.BahtPerRai;
                        detail.YearCost1 = item.YearCost1;
                        detail.YearCost2 = item.YearCost2;
                        detail.YearCost3 = item.YearCost3;
                        detail.YearCost4 = item.YearCost4;
                        detail.YearCost5 = item.YearCost5;
                        detail.YearCost6 = item.YearCost6;
                        detail.YearCost7 = item.YearCost7;
                        detail.YearCost8 = item.YearCost8;
                        detail.YearCost9 = item.YearCost9;
                        detail.YearCost10 = item.YearCost10;
                        detail.YearCost11 = item.YearCost11;
                        detail.YearCost12 = item.YearCost12;
                        detail.YearCost13 = item.YearCost13;
                        detail.YearCost14 = item.YearCost14;
                        detail.YearCost15 = item.YearCost15;
                    }

                    detail.IsActive = true;
                }
                foreach (var item in assumption.Expenses.Where(r => r.IsActive == false).ToList())
                {
                    assumption.RemoveExpense(item);
                }
                await uow.SaveAsync();
            }


        }

        public async Task ApproveUnplan(UnplanUpdateRequest request)
        {
            Ensure.Any.IsNotNull(request, "AssumptionRequest");

            var spec = new NewPlantationSearchByIdSpec(request.PlantationId).NoTracking().InCludeUnplans().InCludeNewRegist();
            var plantation = await plantRepo.GetBySpecAsync(spec);
            if (plantation == null)
            {
                throw new ApplicationException("Invalid plant Id");
            }
            plantation.ApproveUnplan(request.UnplanId, request.Approver, request.Status, request.Remark);

            await uow.SaveAsync();
        }

        public async Task DeleteeUnplan(UnplanUpdateRequest request)
        {
            Ensure.Any.IsNotNull(request, "AssumptionRequest");

            var spec = new NewPlantationSearchByIdSpec(request.PlantationId).NoTracking().InCludeUnplans().InCludeNewRegist();
            var plantation = await plantRepo.GetBySpecAsync(spec);
            if (plantation == null)
            {
                throw new ApplicationException("Invalid plant Id");
            }
            // update status ของ unplan ให้เป็น deleted และ islatest เป็น false
            var deletedUnplan = plantation.Unplans.FirstOrDefault(o => o.Id == request.UnplanId);
            if (deletedUnplan != null) 
            {
                deletedUnplan.OverAllStatus = UnplanStatusType.Deleted.GetStringValue();
                deletedUnplan.IsLatest = false;
            }
            // หา unplan ล่าสุดแล้ว update islatest เป็น true
            var latestUnplan = plantation.Unplans.OrderByDescending(o => o.CreatedDate).FirstOrDefault();
            if (latestUnplan != null) 
            {
                latestUnplan.IsLatest = true;
            }
            // delete กิจกรรม
            var newRegistId = plantation.NewRegistId;
            var specAssump = new AssumptionSearchByNewRegistIdSpec(newRegistId).IncludeExpenses();
            var assumption = await assumRepo.GetBySpecAsync(specAssump);
            if (assumption == null)
            {
                throw new ApplicationException("Invalid data");
            }
            var removeItem = assumption.Expenses.Where(o => o.IsUnplan && o.UnplanId == request.UnplanId).ToList();
            foreach (var item in removeItem) 
            {
                assumption.RemoveExpense(item);
            }
            
            await uow.SaveAsync();
        }

        #region private method

        private List<UnplanSummary> GetUnplanSummary(string role, Guid unplanId, Assumption assumption)
        {
            var result = new List<UnplanSummary>();
            if (role != "approver")
            {
                return result;
            }
            var contractYear = assumption.ContractYear;
            var rentalArea = assumption.RentalArea ?? 0;
            var plantArea = assumption.ProductiveArea ?? 0;
            var expenseList = mapper.Map<IEnumerable<Expense>, List<ExpenseDto>>(assumption.Expenses);
            var masterPlanList = expenseList.Where(o => o.ExpenseType != ExpenseType.CostIncrease && o.IsActive && !o.IsDelete && o.IsDelete && !o.IsUnplan).ToList();
            var preveiousUnplanList = expenseList.Where(o => o.ExpenseType != ExpenseType.CostIncrease && o.IsActive && !o.IsDelete && o.IsDelete && o.IsUnplan && o.UnplanId != unplanId).ToList();
            var latestUnplan = expenseList.Where(o => o.ExpenseType != ExpenseType.CostIncrease && o.IsActive && !o.IsDelete && o.IsDelete && o.IsUnplan && o.UnplanId == unplanId).ToList();

            var masterPlanCost = GetSummaryAllYear(contractYear, rentalArea, plantArea,"ค่าใช้จ่าย (Master Plan)", masterPlanList);
            result.Add(masterPlanCost);
            var previousUnplanCost = GetSummaryAllYear(contractYear, rentalArea, plantArea, "ค่าใช้จ่าย (Unplan ก่อนหน้า)", preveiousUnplanList);
            result.Add(previousUnplanCost);
            decimal latestUnplanCost = 0;
            foreach (var item in latestUnplan) 
            {
                var cost = GetSummaryAllYear(contractYear, rentalArea, plantArea, item.ActivityName, masterPlanList);
                result.Add(cost);
                latestUnplanCost += cost.TotalCost ?? 0;
            }

            result.Add(new UnplanSummary { ActivityName = "รวมค่าใช้จ่าย (Unplan)", TotalCost = latestUnplanCost });
            return result;
        }

        private List<ExpenseDto> GetExpenseDtos(ExpenseType type, IEnumerable<Expense> expenseList) 
        {
            var expenses = expenseList.Where(o => o.IsActive && !o.IsDelete && o.ExpenseType == type).ToList();
            return mapper.Map<List<Expense>, List<ExpenseDto>>(expenses);
        }

        private UnplanSummary GetSummaryAllYear(int contractYear, decimal rentalArea, decimal plantArea, string activityName, List<ExpenseDto> expenseList)
        {
            decimal totalCost = 0;
            foreach (var expense in expenseList)
            {
                var multiplier = expense.ActivityId == 1 ? rentalArea : plantArea; // ActivityId = 1 คือ ค่าเช่าที่ดิน
                totalCost += (multiplier * (expense.YearCost1 ?? 0)) + (multiplier * (expense.YearCost2 ?? 0)) + (multiplier * (expense.YearCost3 ?? 0)) + (multiplier * (expense.YearCost4 ?? 0)) + (multiplier * (expense.YearCost5 ?? 0))
                                + (multiplier * (expense.YearCost6 ?? 0)) + (multiplier * (expense.YearCost7 ?? 0)) + (multiplier * (expense.YearCost8 ?? 0)) + (multiplier * (expense.YearCost9 ?? 0)) + (multiplier * (expense.YearCost10 ?? 0))
                                + (multiplier * (expense.YearCost11 ?? 0)) + (multiplier * (expense.YearCost12 ?? 0)) + (multiplier * (expense.YearCost13 ?? 0)) + (multiplier * (expense.YearCost14 ?? 0)) + (multiplier * (expense.YearCost15 ?? 0));
            }

            return new UnplanSummary
            {
                ActivityName = activityName,
                TotalCost = totalCost
            };
        }

        private Expense GetExpenseFromDto(Guid unplanId, ExpenseDto expenseDto)
        {
            return new Expense
            {
                //Id = Guid.NewGuid(),
                ActivityId = expenseDto.ActivityId == 0 ? null : expenseDto.ActivityId,
                ExpenseType = expenseDto.ExpenseType,
                BahtPerRai = expenseDto.BahtPerRai,
                YearCost1 = expenseDto.YearCost1,
                YearCost2 = expenseDto.YearCost2,
                YearCost3 = expenseDto.YearCost3,
                YearCost4 = expenseDto.YearCost4,
                YearCost5 = expenseDto.YearCost5,
                YearCost6 = expenseDto.YearCost6,
                YearCost7 = expenseDto.YearCost7,
                YearCost8 = expenseDto.YearCost8,
                YearCost9 = expenseDto.YearCost9,
                YearCost10 = expenseDto.YearCost10,
                YearCost11 = expenseDto.YearCost11,
                YearCost12 = expenseDto.YearCost12,
                YearCost13 = expenseDto.YearCost13,
                YearCost14 = expenseDto.YearCost14,
                YearCost15 = expenseDto.YearCost15,
                IsUnplan = true,
                UnplanId = unplanId,
                IsActive = true
            };
        }

        #endregion
    }
}
