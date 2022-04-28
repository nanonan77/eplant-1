using Microsoft.Extensions.DependencyInjection;
using Sketec.Application.Interfaces;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Interfaces;
using Sketec.Core.Specifications.RunningNumbers;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sketec.Application.Services
{
    public class RunningNumberService : ApplicationService, IRunningNumberService
    {
        private static readonly SemaphoreSlim semaphoreBillDocumentControl = new SemaphoreSlim(1, 1);
        private IServiceProvider serviceProvider;
        public RunningNumberService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<string> GetRunningNumber(string topic, int? year = null, string temp1 = null, string temp2 = null, string temp3 = null)
        {
            await semaphoreBillDocumentControl.WaitAsync();
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var repo = scope.ServiceProvider.GetService<IWCRepository<MasterRunningNumber>>();
                    var uow = scope.ServiceProvider.GetService<IWCUnitOfWork>();
                    var spec = new MasterRunningNumberSpec(topic);
                    var template = await repo.GetBySpecAsync(spec);

                    var repo2 = scope.ServiceProvider.GetService<IWCRepository<RunningNumber>>();
                    var uow2 = scope.ServiceProvider.GetService<IWCUnitOfWork>();
                    var spec2 = new RunningNumberSpec(topic, year, temp1, temp2, temp3);
                    var running = await repo2.GetBySpecAsync(spec2);

                    if (running == null)
                    {
                        running = new RunningNumber(topic)
                        {
                            Year = year,
                            Temp1 = temp1,
                            Temp2 = temp2,
                            Temp3 = temp3
                        };
                        repo2.Add(running);
                    }

                    var runningNumber = ++running.Running;
                    var runningStr = runningNumber.ToString().PadLeft(template.Digit, '0');

                    var transactionNo = template.Template.ToLower().Replace("{year}", year.ToString())
                                                                    .Replace("{temp1}", string.IsNullOrEmpty(temp1) ? string.Empty : temp1)
                                                                    .Replace("{temp2}", string.IsNullOrEmpty(temp2) ? string.Empty : temp2)
                                                                    .Replace("{temp3}", string.IsNullOrEmpty(temp3) ? string.Empty : temp3)
                                                                    .Replace("{running}", runningStr)
                                                                    .ToUpper();

                    await uow.SaveAsync();

                    return transactionNo;
                }
            }
            finally
            {
                semaphoreBillDocumentControl.Release();
            }
        }
        //public async Task<string> BillDocumentControl(string salesOrg, string type, int year)
        //{
        //    await semaphoreBillDocumentControl.WaitAsync();
        //    try
        //    {
        //        using (var scope = serviceProvider.CreateScope())
        //        {
        //            var repo = scope.ServiceProvider.GetService<IWCRepository<RunningNumber>>();
        //            var uow = scope.ServiceProvider.GetService<IWCUnitOfWork>();
        //            var spec = new RunningNumberSpec(RunningTopic.BillDocumentControl, year, type, salesOrg);
        //            var running = await repo.GetBySpecAsync(spec);

        //            if (running == null)
        //            {
        //                running = new RunningNumber(RunningTopic.BillDocumentControl)
        //                {
        //                    Type1 = year.ToString("yy"),
        //                    Type2 = type,
        //                    Type3 = salesOrg
        //                };
        //                repo.Add(running);
        //            }

        //            var runningNumber = ++running.Running;
        //            var runningStr = runningNumber.ToString().PadLeft(5, '0');
        //            var no = $"{type}{salesOrg}-{year}{runningStr}";

        //            await uow.SaveAsync();

        //            return no;
        //        }
        //    }
        //    finally
        //    {
        //        semaphoreBillDocumentControl.Release();
        //    }
        //}
    }
}
