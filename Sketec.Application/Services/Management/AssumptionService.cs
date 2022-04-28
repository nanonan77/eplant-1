using AutoMapper;
using EnsureThat;
using Sketec.Application.Interfaces;
using Sketec.Application.Interfaces.Management;
using Sketec.Application.Resources;
using Sketec.Application.Resources.Management.Assumptions;
using Sketec.Application.Resources.Users;
using Sketec.Application.Utils;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Extensions;
using Sketec.Core.Interfaces;
using Sketec.Core.Specifications;
using Sketec.Core.Specifications.Management.Assumptions;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Services
{
    public class AssumptionService : ApplicationService, IAssumptionService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        IWCRepository<Assumption> assumptionRepo;
        IWCRepository<NewRegist> newRegistRepo;
        IMasterConfigurationService masterConfigService;
        IMasterActivityService masterActivityService;
        IUserService userService;
        public AssumptionService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            IWCRepository<Assumption> assumptionRepo,
            IWCRepository<NewRegist> newRegistRepo,
            IMasterConfigurationService masterConfigService,
            IMasterActivityService masterActivityService,
            IUserService userService,
            IWCQueryRepository queryRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.assumptionRepo = assumptionRepo;
            this.newRegistRepo = newRegistRepo;
            this.masterConfigService = masterConfigService;
            this.masterActivityService = masterActivityService;
            this.userService = userService;
        }

        public async Task<AssumptionDto> GetAssumption(Guid newRegistId)
        {
            var assumption = new AssumptionDto();
            var spec = new AssumptionSearchByNewRegistIdSpec(newRegistId).IncludeAll();
            var result = await assumptionRepo.GetBySpecAsync(spec);

            var config = (await masterConfigService.GetMasterConfiguration(new MasterConfigurationFilter { ConfigurationKey = "Inflation Rate" })).FirstOrDefault();
            var inflationRate = (decimal)0;
            if (config != null) 
            {
                decimal.TryParse(config.Value, out inflationRate);
            }
            if (result != null)
            {
                assumption = mapper.Map<Assumption, AssumptionDto>(result);

            }
            else 
            {
                assumption = await GetDefaultAssuption(newRegistId);
            }
            assumption.InflationRate = inflationRate;
            assumption.CostIncreaseYear = GetDefaultCostIncrease(assumption.ContractYear, inflationRate);


            if (assumption.ContractType == ContractType.Rental.GetStringValue())
            {
                var vol = assumption.AssumptionYields.Sum(o => (o.Yield ?? 0) * (assumption.ProductiveArea ?? 0));
                assumption.PlanVolume = Math.Round(vol);
            }


            var picData = await userService.GetUserData(new UserFilter { Email = assumption.NewRegist.PIC });
            var user = new UserResultDto();
            if (picData.Any())
            {
                var pic = picData.FirstOrDefault();
                user = pic;
            }
            assumption.NewRegist.IsCanEdit = SketecUtils.IsCanEdit(assumption.NewRegist.Team, user.ManagerEmail, user.ReportToEmail2, user.ReportToEmail3, assumption.NewRegist.PIC, assumption.NewRegist.Verifier
                                                    , user.Sec_Name, Role, Team, Email, Section, Department, user.Dep_Name);

            return assumption;
        }

        public async Task CreateAssumption(AssumptionDto request)
        {
            Ensure.Any.IsNotNull(request, "AssumptionRequest"); 
            var spec = new AssumptionSearchByNewRegistIdSpec(request.NewRegistId).IncludeAll();
            var result = await assumptionRepo.GetBySpecAsync(spec);
            if (result != null) 
            {
                throw new ApplicationException($"Already assumption for new regist id {request.NewRegistId}");
            }

            ValidateNewRegist(request);
            if (request.ContractType == ContractType.Rental.GetStringValue()) 
            {
                ValidateAssumptionClone(request.AssumptionClones);
                ValidateAssumptionYield(request.AssumptionYields);
            }
            var assumption = new Assumption
            {
                NewRegistId = request.NewRegistId,
                ContractYear = request.ContractYear,
                RentalArea = request.RentalArea,
                ProductiveAreaPercent = request.ProductiveAreaPercent,
                ProductiveArea = request.ProductiveArea,
                CuttingRound = request.CuttingRound,
                DistanceToPlant = request.DistanceToPlant,
                Mill = request.Mill,
                AveragePrice = request.AveragePrice,
                MtpPrice =request.MtpPrice,
                FcPrice = request.FcPrice,
                CuttingCostTypeId = request.CuttingCostTypeId,
                CuttingCost = request.CuttingCost,
                FreightTypeId = request.FreightTypeId,
                Freight = request.Freight,
                IsActive = true
            };
            foreach (var item in request.AssumptionYields) 
            {
                assumption.AddAssumptionYield(new AssumptionYield
                {
                    Id = Guid.NewGuid(),
                    Round = item.Round,
                    Yield = item.Yield,
                    IsActive = true
                });
            }
            foreach (var item in request.AssumptionClones)
            {
                assumption.AddAssumptionClone(new AssumptionClone
                {
                    Id = Guid.NewGuid(),
                    Clone = item.Clone,
                    Portion = item.Portion,
                    Area = item.Area,
                    ProductTon = item.ProductTon,
                    IsActive = true
                });
            }
            foreach (var item in request.ExpenseGroupA)
            {
                assumption.AddExpense(GetExpenseFromDto(item));
            }
            foreach (var item in request.ExpenseGroupB)
            {
                assumption.AddExpense(GetExpenseFromDto(item));
            }
            foreach (var item in request.ExpenseGroupC)
            {
                assumption.AddExpense(GetExpenseFromDto(item));
            }
            foreach (var item in request.ExpenseGroupD)
            {
                assumption.AddExpense(GetExpenseFromDto(item));
            }
            foreach (var item in request.ExpenseGroupF)
            {
                assumption.AddExpense(GetExpenseFromDto(item));
            }
            foreach (var item in request.CostIncreaseYear)
            {
                assumption.AddExpense(GetExpenseFromDto(item));
            }


            await assumptionRepo.AddAsync(assumption);
            await uow.SaveAsync();
            await CalData(request.NewRegistId);
        }

        public async Task UpdateAssumption(Guid newRegistId, AssumptionDto request)
        {
            Ensure.Any.IsNotNull(request, "AssumptionRequest");
            var spec = new AssumptionSearchByIdSpec(request.Id).IncludeAll();
            var assumption = await assumptionRepo.GetBySpecAsync(spec);
            if (assumption == null)
            {
                return;
            }

            ValidateNewRegist(request);
            if (request.ContractType == ContractType.Rental.GetStringValue())
            {
                ValidateAssumptionClone(request.AssumptionClones);
                ValidateAssumptionYield(request.AssumptionYields);
            }
            assumption.NewRegistId = request.NewRegistId;
            assumption.ContractYear = request.ContractYear;
            assumption.RentalArea = request.RentalArea;
            assumption.ProductiveAreaPercent = request.ProductiveAreaPercent;
            assumption.ProductiveArea = request.ProductiveArea;
            assumption.CuttingRound = request.CuttingRound;
            assumption.DistanceToPlant = request.DistanceToPlant;
            assumption.Mill = request.Mill;
            assumption.AveragePrice = request.AveragePrice;
            assumption.MtpPrice = request.MtpPrice;
            assumption.FcPrice = request.FcPrice;
            assumption.CuttingCostTypeId = request.CuttingCostTypeId;
            assumption.CuttingCost = request.CuttingCost;
            assumption.FreightTypeId = request.FreightTypeId;
            assumption.Freight = request.Freight;
            assumption.IsActive = true;

            #region Assumption Yield
            foreach (var item in assumption.AssumptionYields)
            {
                item.IsActive = false;
            }
            foreach (var item in request.AssumptionYields)
            {
                var detail = assumption.AssumptionYields.FirstOrDefault(f => f.Id == item.Id);
                if (detail == null)
                {
                    detail = new AssumptionYield
                    {
                        //Id = Guid.NewGuid(),
                        Round = item.Round,
                        Yield = item.Yield,
                        IsActive = true
                    };
                    assumption.AddAssumptionYield(detail);
                }
                else
                {
                    detail.Round = item.Round;
                    detail.Yield = item.Yield;
                }

                detail.IsActive = true;
            }
            foreach (var item in assumption.AssumptionYields.Where(r => r.IsActive == false).ToList())
            {
                assumption.RemoveAssumptionYield(item);
            }
            #endregion

            #region Assumption Clone
            foreach (var item in assumption.AssumptionClones)
            {
                item.IsActive = false;
            }
            foreach (var item in request.AssumptionClones)
            {
                var detail = assumption.AssumptionClones.FirstOrDefault(f => f.Id == item.Id);
                if (detail == null)
                {
                    detail = new AssumptionClone
                    {
                        //Id = Guid.NewGuid(),
                        Clone = item.Clone,
                        Portion = item.Portion,
                        Area = item.Area,
                        ProductTon = item.ProductTon,
                        IsActive = true
                    };
                    assumption.AddAssumptionClone(detail);
                }
                else
                {
                    detail.Clone = item.Clone;
                    detail.Portion = item.Portion;
                    detail.Area = item.Area;
                    detail.ProductTon = item.ProductTon;
                }

                detail.IsActive = true;
            }
            foreach (var item in assumption.AssumptionClones.Where(r => r.IsActive == false).ToList())
            {
                assumption.RemoveAssumptionClone(item);
            }
            #endregion

            #region Expense
            foreach (var item in assumption.Expenses.Where(o => o.ExpenseType != ExpenseType.CostIncrease).ToList())
            {
                item.IsActive = false;
            }
            var expenseRequestList = request.ExpenseGroupA.Union(request.ExpenseGroupB).Union(request.ExpenseGroupC).Union(request.ExpenseGroupD).Union(request.ExpenseGroupF);

            foreach (var item in expenseRequestList)
            {
                var detail = assumption.Expenses.FirstOrDefault(f => f.Id == item.Id);
                if (detail == null)
                {
                    detail = GetExpenseFromDto(item);
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
            #endregion

            await uow.SaveAsync();
            await CalData(request.NewRegistId);
        }

        public async Task ReCalData()
        {
            var spec = new StatusTrackingLinqSearchSpec(new StatusTrackingFilter());
            var list = await queryRepo.ListAsync(spec);
            foreach(var item in list)
            {
                await CalData(item.Id ?? new Guid());
            }
        }


        #region private method

        private async Task<AssumptionDto> GetDefaultAssuption(Guid newRegistId)
        {
            var newRegisSpec = new NewRegistSearchByIdSpec(newRegistId).InCludeSubNewRegists();
            var newRegis = await newRegistRepo.GetBySpecAsync(newRegisSpec);
            
            if (newRegis == null)
            {
                throw new ApplicationException("Invalid new registration data");
            }
            var newRegisData = mapper.Map<NewRegist, NewRegistDto>(newRegis);

            var feasibilityPrice = await masterConfigService.GetFeasibilityPrice();
            var contractYear = newRegis.ContractType == ContractType.MOU.GetStringValue() ? 10 : (newRegis.Contract ?? 0);
            var assumption = new AssumptionDto
            {
                NewRegistId = newRegistId,
                ContractYear = contractYear,
                ContractType = newRegis.ContractType,
                RentalArea = newRegis.TotalArea,
                ProductiveAreaPercent = 100,
                ProductiveArea = (newRegis.TotalArea * 100) / 100, // (RentalArea * ProductiveAreaPercent)/100
                Rainfall = string.Join("/", newRegis.SubNewRegists.Where(o => o.Rainfall.HasValue && o.Rainfall != 0).Select(o => o.Rainfall.Value.ToString("#,##0.00")).Distinct()),
                SoilType = string.Join(",", newRegis.SubNewRegists.Where(o => !string.IsNullOrEmpty(o.SoilType)).Select(o => o.SoilType).Distinct()),
                CuttingRound = contractYear / 5,
                NewRegist = newRegisData,
                CuttingCost = 180
            };
            var assumptionYield = new List<AssumptionYieldDto>();
            
            if (assumption.ContractType == ContractType.Rental.GetDescription())
            {
                var rainFall = newRegis.SubNewRegists.Select(o => o.Rainfall).FirstOrDefault(o => o.HasValue && o != 0) ?? 0;
                var soilType = newRegis.SubNewRegists.Select(o => o.SoilType).FirstOrDefault(o => !string.IsNullOrEmpty(o));
                assumptionYield = await GetDefaultAssumptionYield(assumption.CuttingRound, rainFall, soilType);
                //assumption.Mill = feasibilityPrice.FirstOrDefault().Mill;
                assumption.AveragePrice = feasibilityPrice.FirstOrDefault(o => o.Mill == assumption.Mill && o.PriceType == "Current")?.Price;
                assumption.MtpPrice = feasibilityPrice.FirstOrDefault(o => o.Mill == assumption.Mill && o.PriceType == "MTP Agent")?.Price;
                assumption.FcPrice = feasibilityPrice.FirstOrDefault(o => o.Mill == assumption.Mill && o.PriceType == "FC Target")?.Price;
            }
            var expenseList = await GetDefaultExpense(assumption.ContractType, contractYear);
            assumption.AssumptionYields = assumptionYield;
            assumption.AssumptionClones = new List<AssumptionCloneDto>();
            assumption.ExpenseGroupA = expenseList.Where(o => o.ActivityGroup == "A");
            assumption.ExpenseGroupB = expenseList.Where(o => o.ActivityGroup == "B");
            assumption.ExpenseGroupC = expenseList.Where(o => o.ActivityGroup == "C");
            assumption.ExpenseGroupD = expenseList.Where(o => o.ActivityGroup == "D");
            assumption.ExpenseGroupF = expenseList.Where(o => o.ActivityGroup == "F");
            assumption.PlanVolume = newRegis.PlanVolume;


            return assumption;
        }

        private async Task<List<AssumptionYieldDto>> GetDefaultAssumptionYield(int cuttingRound, decimal rainFall, string soilType)
        {
            var assumptionYield = new List<AssumptionYieldDto>();
            var feasibilityYield = await masterConfigService.GetFeasibilityYield();
            decimal firstYield = 0;
            var firstSoilType = string.IsNullOrEmpty(soilType) ? string.Empty : soilType.Split(",").Where(o => !string.IsNullOrEmpty(o) && !string.IsNullOrWhiteSpace(o)).FirstOrDefault();
            for (var i = 1; i <= cuttingRound; i++)
            {
                decimal yield = 0;
                if (i == 1)
                {
                    var feas = feasibilityYield.FirstOrDefault(o => o.IsActive && o.SoilType == firstSoilType && (o.RainfallStart ?? 0) <= rainFall && (o.RainfallEnd ?? 99999) >= rainFall);
                    yield = feas?.Yield ?? 0;
                    firstYield = yield;
                }
                else
                {
                    yield = (firstYield * 110) / 100;
                }
                assumptionYield.Add(new AssumptionYieldDto { Round = i, Yield = yield });
            }
            return assumptionYield;
        }

        private async Task<List<ExpenseDto>> GetDefaultExpense(string contractType,int contractYear) 
        {
            var expenseDtoList = new List<ExpenseDto>();
            var configKey = contractType == ContractType.Rental.GetDescription() ? "Activity Rentral" : "Activity MOU";
            var configList = await masterConfigService.GetMasterConfiguration(new MasterConfigurationFilter { ConfigurationKey = configKey });
            var masterActivity = await masterActivityService.GetMasterActivitys(new MasterActivityFilter { IsActive = true, IsDelete = false });


            foreach (var item in configList)
            {
                var activity = masterActivity.FirstOrDefault(o => o.ActivityCode == item.Value);
                if (activity != null)
                {
                    expenseDtoList.Add(new ExpenseDto
                    {
                        ActivityId = activity.Id,
                        ActivityName = activity.ActivityTH,
                        ActivityTypeId = activity.MasterActivityTypeId ?? 0,
                        ActivityTypeName = activity.TitleTH,
                        ActivityGroup = activity.ActivityGroup,
                        ExpenseType = activity.ActivityGroup == "A"
                                        ? ExpenseType.ActivityGroupA
                                        : activity.ActivityGroup == "B"
                                            ? ExpenseType.ActivityGroupB
                                            : activity.ActivityGroup == "C"
                                                ? ExpenseType.ActivityGroupC
                                                : activity.ActivityGroup == "D"
                                                    ? ExpenseType.ActivityGroupD
                                                    : ExpenseType.ActivityGroupF,
                        IsUnplan = false
                    });
                }
            }
            return expenseDtoList;
        }
        private List<ExpenseDto> GetDefaultCostIncrease(int contractYear, decimal inflationRate)
        {
            var expenseDto = new ExpenseDto { ExpenseType = ExpenseType.CostIncrease };
            decimal latestCost = 0;
            for (var i = 1; i <= contractYear; i++)
            {
                var cost = i == 1 ? 1 : latestCost * (inflationRate / 100);
                latestCost += cost;
                switch (i)
                {
                    case 1: expenseDto.YearCost1 = Math.Round(latestCost, 2); break;
                    case 2: expenseDto.YearCost2 = Math.Round(latestCost, 2); break;
                    case 3: expenseDto.YearCost3 = Math.Round(latestCost, 2); break;
                    case 4: expenseDto.YearCost4 = Math.Round(latestCost, 2); break;
                    case 5: expenseDto.YearCost5 = Math.Round(latestCost, 2); break;
                    case 6: expenseDto.YearCost6 = Math.Round(latestCost, 2); break;
                    case 7: expenseDto.YearCost7 = Math.Round(latestCost, 2); break;
                    case 8: expenseDto.YearCost8 = Math.Round(latestCost, 2); break;
                    case 9: expenseDto.YearCost9 = Math.Round(latestCost, 2); break;
                    case 10: expenseDto.YearCost10 = Math.Round(latestCost, 2); break;
                    case 11: expenseDto.YearCost11 = Math.Round(latestCost, 2); break;
                    case 12: expenseDto.YearCost12 = Math.Round(latestCost, 2); break;
                    case 13: expenseDto.YearCost13 = Math.Round(latestCost, 2); break;
                    case 14: expenseDto.YearCost14 = Math.Round(latestCost, 2); break;
                    case 15: expenseDto.YearCost15 = Math.Round(latestCost, 2); break;
                }
            }

            return new List<ExpenseDto> { expenseDto };
        }

        private Expense GetExpenseFromDto(ExpenseDto expenseDto) 
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
                IsUnplan = expenseDto.IsUnplan
            };
        }

        private void ValidateAssumptionClone(IEnumerable<AssumptionCloneDto> assumptionClones) 
        {
            if (assumptionClones != null && assumptionClones.Count() > 0) 
            {
                if (assumptionClones.Any(o => string.IsNullOrEmpty(o.Clone)))
                {
                    throw new ApplicationException("สายพันธุ์ is required.");
                }
                if (assumptionClones.GroupBy(o => o.Clone).Select(o => o.Count()).Any(o => o > 1))
                {
                    throw new ApplicationException("ไม่สามารถเลือกสายพันธุ์ที่ซ้ำกันได้");
                }
                if (assumptionClones.Sum(o=> (o.Portion ?? 0)) != 100)
                {
                    throw new ApplicationException("ผลรวมของ Portion ต้องได้เท่ากับ 100");
                }
            }
        }

        private void ValidateAssumptionYield(IEnumerable<AssumptionYieldDto> assumptionYields)
        {
            if (assumptionYields != null && assumptionYields.Count() > 0)
            {
                foreach(var item in assumptionYields)
                {
                    if((item.Yield ?? 0) == 0)
                    {
                        throw new ApplicationException("กรุณากรอกผลผลิตที่ได้รับเฉลี่ย-รอบตัดฟันที่ " + item.Round.ToString() + " มากกว่า 0");
                    }
                }
            }
        }

        private void ValidateNewRegist(AssumptionDto request)
        {
            if(string.IsNullOrWhiteSpace(request.Mill))
            {
                throw new ApplicationException("Mill is require.");
            }
            else if (request.DistanceToPlant == null)
            {
                throw new ApplicationException("ระยะทางจากแปลงไม้ถึงโรงงาน is require.");
            }
            else if (request.DistanceToPlant > 600)
            {
                throw new ApplicationException("ระยะทางจากแปลงไม้ถึงโรงงาน ไม่สามารถเกิน 600.");
            }
            else if (request.CuttingCostTypeId == null)
            {
                throw new ApplicationException("ค่าตัด is require.");
            }
            else if (request.CuttingCost == null)
            {
                throw new ApplicationException("ราคาค่าตัด is require.");
            }
            else if (request.FreightTypeId == null)
            {
                throw new ApplicationException("ค่าขนส่ง is require.");
            }
            else if (request.Freight == null)
            {
                throw new ApplicationException("ราคาค่าขนส่ง is require.");
            }
        }

        private async Task CalData(Guid newRegistId)
        {
            var assumpion = await GetAssumption(newRegistId);
            if (assumpion != null)
            {
                List<string> activityGroup = new List<string>(new string[] { "B", "C", "D", "F" });
                decimal cost = assumpion.ExpenseGroupA.Sum(x => (x.YearCost1 ?? 0) + (x.YearCost2 ?? 0) + (x.YearCost3 ?? 0) + (x.YearCost4 ?? 0) + (x.YearCost5 ?? 0) + (x.YearCost6 ?? 0) + (x.YearCost7 ?? 0) + (x.YearCost8 ?? 0) + (x.YearCost9 ?? 0) + (x.YearCost10 ?? 0) + (x.YearCost11 ?? 0) + (x.YearCost12 ?? 0) + (x.YearCost13 ?? 0) + (x.YearCost14 ?? 0) + (x.YearCost15 ?? 0) * (assumpion.RentalArea ?? 0))
                            + assumpion.ExpenseGroupB.Sum(x => (x.YearCost1 ?? 0) + (x.YearCost2 ?? 0) + (x.YearCost3 ?? 0) + (x.YearCost4 ?? 0) + (x.YearCost5 ?? 0) + (x.YearCost6 ?? 0) + (x.YearCost7 ?? 0) + (x.YearCost8 ?? 0) + (x.YearCost9 ?? 0) + (x.YearCost10 ?? 0) + (x.YearCost11 ?? 0) + (x.YearCost12 ?? 0) + (x.YearCost13 ?? 0) + (x.YearCost14 ?? 0) + (x.YearCost15 ?? 0) * (assumpion.ProductiveArea ?? 0))
                            + assumpion.ExpenseGroupC.Sum(x => (x.YearCost1 ?? 0) + (x.YearCost2 ?? 0) + (x.YearCost3 ?? 0) + (x.YearCost4 ?? 0) + (x.YearCost5 ?? 0) + (x.YearCost6 ?? 0) + (x.YearCost7 ?? 0) + (x.YearCost8 ?? 0) + (x.YearCost9 ?? 0) + (x.YearCost10 ?? 0) + (x.YearCost11 ?? 0) + (x.YearCost12 ?? 0) + (x.YearCost13 ?? 0) + (x.YearCost14 ?? 0) + (x.YearCost15 ?? 0) * (assumpion.ProductiveArea ?? 0))
                            + assumpion.ExpenseGroupD.Sum(x => (x.YearCost1 ?? 0) + (x.YearCost2 ?? 0) + (x.YearCost3 ?? 0) + (x.YearCost4 ?? 0) + (x.YearCost5 ?? 0) + (x.YearCost6 ?? 0) + (x.YearCost7 ?? 0) + (x.YearCost8 ?? 0) + (x.YearCost9 ?? 0) + (x.YearCost10 ?? 0) + (x.YearCost11 ?? 0) + (x.YearCost12 ?? 0) + (x.YearCost13 ?? 0) + (x.YearCost14 ?? 0) + (x.YearCost15 ?? 0) * (assumpion.ProductiveArea ?? 0))
                            + assumpion.ExpenseGroupF.Sum(x => (x.YearCost1 ?? 0) + (x.YearCost2 ?? 0) + (x.YearCost3 ?? 0) + (x.YearCost4 ?? 0) + (x.YearCost5 ?? 0) + (x.YearCost6 ?? 0) + (x.YearCost7 ?? 0) + (x.YearCost8 ?? 0) + (x.YearCost9 ?? 0) + (x.YearCost10 ?? 0) + (x.YearCost11 ?? 0) + (x.YearCost12 ?? 0) + (x.YearCost13 ?? 0) + (x.YearCost14 ?? 0) + (x.YearCost15 ?? 0) * (assumpion.ProductiveArea ?? 0))
                            ;

                decimal yield = Math.Round(assumpion.AssumptionYields.Sum(x => (x.Yield ?? 0) * (assumpion.ProductiveArea ?? 0)) / 10) * 10;
                if (yield != 0)
                {
                    var priceAtPlant = Math.Round(((cost / yield) + (assumpion.CuttingCost ?? 0)) / 10) * 10;

                    var newRegist = await newRegistRepo.GetByIdAsync(newRegistId);
                    if (newRegist != null)
                    {
                        newRegist.PriceAtPlant = priceAtPlant;
                        await uow.SaveAsync();
                    }
                }
            }
        }
        #endregion
    }
}
