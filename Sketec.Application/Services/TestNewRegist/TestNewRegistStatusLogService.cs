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
using Sketec.Core.Resources.Email;
using System.Text;
using Sketec.Application.Shared;
using Microsoft.Extensions.Options;

namespace Sketec.Application.Services
{
    public class TestNewRegistStatusLogService : ApplicationService, ITestNewRegistStatusLogService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        ISharePointService sharePointService;
        IWCRepository<NewRegistStatusLog> dataNewRegStaLogRepo;
        IWCRepository<NewRegist> dataNewRegistRepo;
        IEmailService emailService;
        ApplicationSettings applicationSettings;
        IUserService userService;
        //IWCRepository<NewRegistImagePath> imgRepo;
        public TestNewRegistStatusLogService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            ISharePointService sharePointService,
            IWCRepository<NewRegistStatusLog> dataNewRegStaLogRepo,
            IWCRepository<NewRegist> dataNewRegistRepo,
            //IWCRepository<NewRegistImagePath> imgRepo,
            IWCQueryRepository queryRepo,
            IEmailService emailService
            , IOptions<ApplicationSettings> appOptions
            , IUserService userService)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.sharePointService = sharePointService;
            this.queryRepo = queryRepo;
            this.dataNewRegStaLogRepo = dataNewRegStaLogRepo;
            this.dataNewRegistRepo = dataNewRegistRepo;
            this.emailService = emailService;
            applicationSettings = appOptions.Value;
            this.userService = userService;
            //this.imgRepo = imgRepo;
        }

        public async Task<IEnumerable<NewRegistStatusLogResultDto>> GetNewRegistStatusLogs(NewRegistStatusLogFilter filter)
        {
            var spec = new NewRegistStatusLogLinqSearchSpec(filter ?? new NewRegistStatusLogFilter());
            var list = await queryRepo.ListAsync(spec);

            return list;
        }


        public async Task CreateNewRegistStatusLog(IEnumerable<NewRegistStatusLogCreateRequest> request)
        {
            if (request != null && request.Any(q => q.NewRegistId.HasValue && q.Action != null && q.Action != ""))
            {
                string baseUrl = applicationSettings.BaseUrl;
                foreach (var item in request.Where(q => q.NewRegistId.HasValue))
                {
                    string emailSubject = "";
                    StringBuilder emailBody = new StringBuilder();
                    var spec = new NewRegistSearchByIdSpec(item.NewRegistId.Value).InCludeNewRegistStatusLogs();
                    var newRegModel = await dataNewRegistRepo.GetBySpecAsync(spec);

                    IEnumerable<string> emailTo = request.Where(q => q.NewRegistId.HasValue).Select(q => q.AssignTo);
                    string emailCC = "";

                    #region Change Status
                    if (newRegModel != null)
                    {
                        string assignToFullname = "";
                        string updateByFullname = "";
                        if (!string.IsNullOrWhiteSpace(item.AssignTo))
                        {
                            var userInSystem = await userService.GetUserData(new Core.Specifications.UserFilter { Email = item.AssignTo.Trim() });
                            if (userInSystem != null && userInSystem.Any())
                            {
                                assignToFullname = userInSystem.First().E_FullName ?? userInSystem.First().Username;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(UserName))
                        {
                            var userInSystem = await userService.GetUserData(new Core.Specifications.UserFilter { Username = UserName });
                            if (userInSystem != null && userInSystem.Any())
                            {
                                updateByFullname = userInSystem.First().E_FullName ?? userInSystem.First().Username;
                                emailCC += userInSystem.First().Email;
                            }
                        }

                        emailSubject = "[New Registration] {0} " + newRegModel.ContractType.ToString().Trim() + " " + newRegModel.Title.ToString().Trim();

                        #region Email CC
                        //if (!string.IsNullOrWhiteSpace(newRegModel.UpdatedBy))
                        //{
                        //    var userInSystem = await userService.GetUserData(new Core.Specifications.UserFilter { Email = newRegModel.UpdatedBy.Trim() });
                        //    if (userInSystem != null && userInSystem.Any())
                        //    {
                        //        emailCC += userInSystem.First().E_FullName ?? userInSystem.First().Username;
                        //    }
                        //}
                        emailCC += "," + newRegModel.PIC;
                        if (!string.IsNullOrWhiteSpace(request.First(q => q.NewRegistId.HasValue).CcTo))
                        {
                            emailCC += "," + request.First(q => q.NewRegistId.HasValue).CcTo;
                        }
                        #endregion Email CC

                        #region Update NewRegist
                        if (item.Action == ActionType.ChangePIC.GetStringValue())
                        {
                            //Change PIC only
                            newRegModel.PIC = item.AssignTo;
                            emailSubject = emailSubject.Replace("{0}", "อัพเดทผู้รับผิดชอบแปลง");
                            #region Email Body
                            emailBody.Append("เรียน : " + assignToFullname);//เรียน ชื่อของ[dbo].[NewRegistStatusLog].[AssignTo]
                            emailBody.Append("<br>คุณได้รับมอบหมายให้ดูแลแปลงสวนไม้");//คุณได้รับมอบหมายให้ดูแลแปลงสวนไม้
                            emailBody.Append("<br>ชื่อแปลง : " + newRegModel.Title);//ชื่อแปลง : [dbo].[NewRegist].[Title]
                            emailBody.Append("<br>ประเภทสวนไม้ : " + newRegModel.ContractType);//ประเภทสวนไม้:[dbo].[NewRegist].[ContractType]
                            emailBody.Append("<br>พื้นที่(ไร่) : " + newRegModel.TotalArea.GetValueOrDefault().ToString("#,###"));//พื้นที่(ไร่) : [dbo].[NewRegist].[TotalArea]
                            emailBody.Append("<br>สถานที่ : " + newRegModel.Province + " / " + newRegModel.District + " / " + newRegModel.SubDistrict);//สถานที่:[dbo].[NewRegist].[Province] / [dbo].[NewRegist].[District] / [dbo].[NewRegist].[SubDistrict]
                            emailBody.Append("<br>พิกัด : " + newRegModel.Latitude + " , " + newRegModel.Longitude);//พิกัด:[dbo].[NewRegist].[Latitude] , [dbo].[NewRegist].[Longitude]
                            emailBody.Append("<br>จำนวนแปลงย่อย : " + newRegModel.Plot.GetValueOrDefault().ToString("#,###"));//จำนวนแปลงย่อย: NewRegist.Plot
                            emailBody.Append("<br>คลิกเพื่อพิจารณาแปลง : " + "<a href='" + baseUrl + "/new-regist/rental/" + newRegModel.Id.ToString() + "' target='_blank'>รายละเอียดแปลงหลัก</a>");//คลิกเพื่อพิจารณาแปลง : Link(รายละเอียดแปลงหลัก)
                            emailBody.Append("<br><br><br>Best regards,");//Best regards,
                            emailBody.Append("<br>" + updateByFullname);//ชื่อ นามกสุลของ[dbo].[NewRegist].[UpdatedBy]
                            #endregion Email Body
                        }
                        else if (item.Action == ActionType.AssignTo.GetStringValue() || item.Action == ActionType.SendBack.GetStringValue())
                        {
                            //Change Verifier, Team, Status
                            newRegModel.Team = item.Team;
                            newRegModel.Verifier = item.AssignTo;
                            newRegModel.Status = item.Status;
                            newRegModel.AssignToDate = DateTime.Now;

                            string picFullname = "";
                            if (!string.IsNullOrWhiteSpace(newRegModel.PIC))
                            {
                                var userInSystem = await userService.GetUserData(new Core.Specifications.UserFilter { Email = newRegModel.PIC });
                                if (userInSystem != null && userInSystem.Any())
                                {
                                    picFullname = userInSystem.First().E_FullName ?? userInSystem.First().Username;
                                }
                            }

                            emailSubject = emailSubject.Replace("{0}", "พิจารณาแปลง");
                            #region Email Body
                            emailBody.Append("เรียน " + assignToFullname);//เรียน ชื่อของ[dbo].[NewRegistStatusLog].[AssignTo]
                            emailBody.Append("<br>ข้อมูลแปลงสวนไม้ดังนี้");//ข้อมูลแปลงสวนไม้ดังนี้
                            emailBody.Append("<br>ชื่อแปลง : " + newRegModel.Title);//ชื่อแปลง : [dbo].[NewRegist].[Title]
                            emailBody.Append("<br>สถานะแปลง : " + newRegModel.Status);//สถานะแปลง:[dbo].[NewRegist].[Status]
                            emailBody.Append("<br>สถานที่ : " + newRegModel.Province + " / " + newRegModel.District + " / " + newRegModel.SubDistrict);//สถานที่:[dbo].[NewRegist].[Province] / [dbo].[NewRegist].[District] / [dbo].[NewRegist].[SubDistrict]
                            emailBody.Append("<br>พิกัด : " + newRegModel.Latitude + " , " + newRegModel.Longitude);//พิกัด:[dbo].[NewRegist].[Latitude] , [dbo].[NewRegist].[Longitude]
                            emailBody.Append("<br>จำนวนแปลงย่อย : " + newRegModel.Plot.GetValueOrDefault().ToString("#,###"));//จำนวนแปลงย่อย: NewRegist.Plot
                            emailBody.Append("<br>ผู้รับผิดชอบแปลง : " + picFullname);//ผู้รับผิดชอบแปลง :  ชื่อของ[dbo].[NewRegist].[PIC]
                            emailBody.Append("<br>Comment : " + item.Comment);//Comment:[dbo].[NewRegistStatusLog].[Comment]
                            emailBody.Append("<br>คลิกเพื่อพิจารณาแปลง : " + "<a href='" + baseUrl + "/new-regist/rental/" + newRegModel.Id.ToString() + "' target='_blank'>รายละเอียดแปลงหลัก</a>");//คลิกเพื่อพิจารณาแปลง: Link(รายละเอียดแปลงหลัก)
                            emailBody.Append("<br><br><br>Best regards,");//Best regards,
                            emailBody.Append("<br>" + updateByFullname);//ชื่อ นามกสุลของ[dbo].[NewRegist].[UpdatedBy]
                            #endregion Email Body
                        }
                        #endregion Update NewRegist
                        #region Insert New StatusLog
                        newRegModel.AddNewRegistStatusLog(new NewRegistStatusLog
                        {
                            AssignTo = item.AssignTo,
                            CCTo = item.CcTo,
                            Status = item.Status,
                            Action = item.Action,
                            Comment = item.Comment,
                            NewRegistId = item.NewRegistId,
                            IsActive = true,
                            IsDelete = false
                        });

                        #endregion Insert New StatusLog
                        #region Update Last StatusLog
                        var lastNewRegStaLogModel = newRegModel.NewRegistStatusLogs.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
                        if (lastNewRegStaLogModel != null && lastNewRegStaLogModel.CreatedDate.HasValue)
                        {
                            lastNewRegStaLogModel.InboxDay = (DateTime.Now - lastNewRegStaLogModel.CreatedDate.GetValueOrDefault()).Days;
                        }
                        else
                        {
                            lastNewRegStaLogModel.InboxDay = 0;
                        }
                        #endregion Update Last StatusLog
                    }
                    #endregion Change Status

                    #region Send mail
                    if (emailTo != null && emailTo.Any())
                    {
                        //IEnumerable<string> emailCC = !string.IsNullOrWhiteSpace(request.First(q => q.NewRegistId.HasValue).CcTo) ? request.First(q => q.NewRegistId.HasValue).CcTo.Split(',') : null;
                        //string emailSubject = request.First(q => q.NewRegistId.HasValue).Action;

                        await emailService.SendEmailAsync(new SendEmailRequest
                        {
                            //EmailsTo = new string[] { item.AssignTo },
                            //EmailsCC = !string.IsNullOrWhiteSpace(item.CcTo) ? item.CcTo.Split(',') : null,
                            EmailsTo = emailTo,
                            EmailsCC = emailCC.Split(','),
                            Subject = emailSubject,// + "Assign To xxxxx",
                            Content = emailBody.ToString()//"Assign To xxxxx"
                        });
                    }
                    #endregion Send mail
                }
                //await newRegStaLogRepo.AddAsync(insertModel);


            }

            await uow.SaveAsync();
        }


    }
}
