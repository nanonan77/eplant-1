using MassTransit;
using Microsoft.Extensions.Logging;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;
using Sketec.Core.Resources.RabbitMQs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Infrastructure.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        RabbitMQOptions option;
        ILogger<RabbitMQService> logger;
        public RabbitMQService(
          RabbitMQOptions option
          , ILogger<RabbitMQService> logger
          )
        {
            this.option = option;
            this.logger = logger;
        }


        public void CeatePRQ()
        {
            try
            {
                var message = new CreatePaymentRequestMessage()
                {
                    UserLogin = option.AllPayUsername,
                    PasswordLogin = option.AllPayPassword,
                };
                message.Status = StandartStatus.Draft;
                message.CreateDate = DateTime.Now;
                message.VendorEmail = "wasan261239@gmail.com";
                #region 1. General Information
                message.FormType = FormType.GRPRQ;
                message.CompanyCode = "0110";
                message.IsOneTimeVendor = false;
                message.VendorCode = "0000000011";
                message.GrApprovalForCode = "7.1.2";
                message.Subject = "Test Draft  IsForeignPayment ";
                #endregion

                #region  2. Payment & Budget Information
                //message.DueDate = DateTimeOffset.Parse("03/29/2021").ToLocalTime();
                message.DueDate = DateTimeOffset.Now;
                message.CurrencyCode = "THB";
                message.VPPaymentTypeCode = "01";
                message.PaymentDescription = "ค่าตอบแทนการทำงานหนัก";
                message.ServiceTeamCode = "04";
                message.IsAlternativePayee = true;
                message.AlternativePayeeList = new List<AlternativePayeeMessage>()
                {
                    new AlternativePayeeMessage()
                    {
                        Amount = 100,
                        VendorCode = "0000000012"
                    }
                };
                message.IsPurchaseOrder = false;
                message.AddinalData = "fs test create data from rabiitmq";
                #endregion

                #region  3. Invoice / Tax Invoice / Other Information
                var item = new List<PaymentRequestItemMessage>();
                item.Add(new PaymentRequestItemMessage()
                {
                    DocumentType = "01",
                    Po = new List<string>() { "po1", "po2" },
                    DocumentNo = "INV-AA-test",
                    DocumentDate = DateTimeOffset.Now,
                    Amount = Convert.ToDecimal(100),
                    Reference1 = "Ref1 Test",
                    VatData = new TaxMessage()
                    {
                        Rate = 7,
                        BaseAmount = Convert.ToDecimal(100),
                        //VatAmount = 7 * (500 / 100)
                    },
                    WHTDataList = new List<TaxMessage>() {
                        new TaxMessage()
                        {
                            Rate = 1,
                            BaseAmount = 100,
                            //VatAmount = 2*(20/100)
                        },
                        new TaxMessage()
                        {
                            Rate = 3,
                            BaseAmount =Convert.ToDecimal( 100),
                            //VatAmount = 2*(500/100)
                        },
                    },
                    VendorCode = message.VendorCode,
                    PaymentRequestSubItemList = new List<PaymentRequestSubItemMessage>()
                    {
                        new PaymentRequestSubItemMessage()
                        {
                            ExpenseCode ="232510",
                            CostCenterCode ="0230-18000",
                            Explanation = "ssa",
                            Assignment = "test"
                            //Amount = 445
                        },
                    }
                });
                message.PaymentRequestItems = item;
                #endregion

                #region 4. User & Approval Information
                message.RequestorUserName = "CHOMYONP";
                message.IsParallelApprove = false;
                message.Approvers.Add(new RequestApproverMessage()
                {
                    Type = RequestApproveType.Approver,
                    Ordinal = 1,
                    UserName = "wasani",
                    ActionDate = DateTimeOffset.Parse("10/22/2020")
                });
                //message.Approvers.Add(new RequestApproverMessage()
                //{
                //    Type = RequestApproveType.Reviewer,
                //    Ordinal = 1,
                //    UserName = "wasanj",
                //    ActionDate = DateTimeOffset.Parse("10/20/2020")
                //});
                //message.Approvers.Add(new RequestApproverMessage()
                //{
                //    Type = RequestApproveType.Reviewer,
                //    Ordinal = 2,
                //    UserName = "wasang",
                //    ActionDate = DateTimeOffset.Parse("10/21/2020")
                //});
                #endregion

                #region Other
                message.CreatorUserName = "wasani";
                //message.CreatorUserName = "CHOMYONP";
                //message.FileReceiptList 
                //message.FileRelationDataList
                message.TotalAmount = message.PaymentRequestItems.Sum(t => t.Amount);
                message.TotalAmountExchangeRete = message.PaymentRequestItems.Sum(t => t.Amount);
                message.RefNo = "PRQ-111";

                message.IsForeignPayment = false;
                #endregion

                IBusControl busControl = CreateBus();
                busControl.StartAsync();
                IRequestClient<CreatePaymentRequestMessage, CreatePaymentResponseMessage> client = CreateRequestClient(busControl);

                Task.Run(async () =>
                {
                    CreatePaymentResponseMessage responseData = await client.Request(message);

                    Console.WriteLine(responseData.IsSuccess);
                    Console.WriteLine("https://allpay-qas2.scg.com/VendorPaymentClient/Modules/VendorPayment/viewPaymentRequestPage#" + responseData.Id);
                    Console.WriteLine(responseData.RequestNo);
                    Console.WriteLine(responseData.Message);

                }).Wait();

                busControl.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        public void CeateGR()
        {
            try
            {
                var message = new CreatePaymentRequestMessage()
                {
                    UserLogin = option.AllPayUsername,
                    PasswordLogin = option.AllPayPassword,
                };
                message.Status = StandartStatus.WaitforApproverApprove;
                message.CreateDate = DateTime.Now;
                #region 1. General Information
                message.FormType = FormType.GR;
                message.CompanyCode = "0110";
                message.IsOneTimeVendor = false;
                message.VendorCode = "0000000011";
                message.GrApprovalForCode = "SC0.1.0";
                message.Subject = "Fs Client Test Create gr form rabbit";
                #endregion

                #region  2. Invoice / Tax Invoice / Other Information
                message.CurrencyCode = "USD";
                message.IsPurchaseOrder = true;
                var item = new List<PaymentRequestItemMessage>();
                item.Add(new PaymentRequestItemMessage()
                {
                    DocumentType = "01",
                    Po = new List<string>() { "po1", "po2" },
                    DocumentNo = "INV-123456",
                    DocumentDate = DateTimeOffset.Now,
                    Amount = 500,
                    Reference1 = "Ref1 Test",
                    VendorCode = message.VendorCode
                });
                message.PaymentRequestItems = item;
                #endregion

                #region 3. User & Approval Information
                message.RequestorUserName = "CHOMYONP";
                message.IsParallelApprove = false;

                message.Approvers.Add(new RequestApproverMessage()
                {
                    Type = RequestApproveType.Reviewer,
                    Ordinal = 1,
                    UserName = "wasanj",
                    ActionDate = DateTime.Parse("10/18/2020")
                });
                message.Approvers.Add(new RequestApproverMessage()
                {
                    Type = RequestApproveType.Cc,
                    Ordinal = 1,
                    UserName = "wasang",
                    //ActionDate = DateTime.Now
                });

                message.Approvers.Add(new RequestApproverMessage()
                {
                    Type = RequestApproveType.Cc,
                    Ordinal = 1,
                    UserName = "WORAKITH",
                });
                message.Approvers.Add(new RequestApproverMessage()
                {
                    Type = RequestApproveType.Approver,
                    Ordinal = 1,
                    UserName = "wasani",
                    ActionDate = DateTime.Parse("10/19/2020")
                });
                #endregion

                #region Other
                message.CreatorUserName = "CHOMYONP";
                //var xx = "D:\\5_AllPay3\\Programs\\AllPay.VendorPaymentServer\\AllPay.VendorPaymentServer\\wwwroot\\Logs\\Trace.txt";

                //message.FileReceiptList = new List<FileInfoData>()
                //{
                //    new FileInfoData()
                //    {
                //        FileName = "file1",
                //        FileByteData = File.ReadAllBytes(xx)
                //    },
                //};
                //message.FileRelationDataList
                message.TotalAmount = message.PaymentRequestItems.Sum(t => t.Amount);
                message.RefNo = "PRQ-111";
                #endregion


                IBusControl busControl = CreateBus();
                busControl.StartAsync();
                IRequestClient<CreatePaymentRequestMessage, CreatePaymentResponseMessage> client = CreateRequestClient(busControl);

                Task.Run(async () =>
                {
                    CreatePaymentResponseMessage responseData = await client.Request(message);

                    Console.WriteLine(responseData.IsSuccess);
                    Console.WriteLine("http://localhost:9906/Modules/VendorPayment/viewPaymentRequestPage#" + responseData.Id);
                    Console.WriteLine(responseData.RequestNo);
                    Console.WriteLine(responseData.Message);

                }).Wait();

                busControl.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


        private IBusControl CreateBus()
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                //Localhost
                //var host = cfg.Host(new Uri("rabbitmq://localhost:5672/AllPay"), hst =>
                //{
                //    hst.Username("guest");
                //    hst.Password("guest");
                //});
                //cfg.ReceiveEndpoint(host, "AllPay.VendorPayment.CreatePaymentRequest", e =>
                //{
                //});

                //QAS
                var host = cfg.Host(new Uri($"{option.Host}:{option.Port}/{option.VirtualHost}"), hst =>
                {
                    hst.Username(option.Username);
                    hst.Password(option.Password);
                    var isUseSsl = option.UseSsl == "true";
                    if (true)
                    {
                        hst.UseSsl(s =>
                        {
                            s.Protocol = SslProtocols.Tls12;
                            s.AllowPolicyErrors(SslPolicyErrors.RemoteCertificateChainErrors |
                                SslPolicyErrors.RemoteCertificateNameMismatch |
                                SslPolicyErrors.RemoteCertificateNotAvailable);
                        });
                    }
                });
                cfg.ReceiveEndpoint(host, option.CreatePaymentQueue, e =>
                {
                });

            });
        }

        private IRequestClient<CreatePaymentRequestMessage, CreatePaymentResponseMessage> CreateRequestClient(IBusControl busControl)
        {
            try
            {
                var serviceAddress = new Uri($"{option.Host}:{option.Port}/{option.VirtualHost}/{option.CreatePaymentQueue}");
                //var serviceAddress = new Uri("rabbitmq://localhost:5672/AllPay/AllPay.VendorPayment.CreatePaymentRequest");
                IRequestClient<CreatePaymentRequestMessage, CreatePaymentResponseMessage> client =
                    busControl.CreateRequestClient<CreatePaymentRequestMessage, CreatePaymentResponseMessage>(serviceAddress, TimeSpan.FromSeconds(10000));

                return client;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
