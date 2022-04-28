namespace Sketec.ConsoleApp
{
    class SapMigration
    {
        //string rootFolder = @"d:\webcredit\sap";
        //WebCreditContext db;
        //IMapper mapper;
        //public SapMigration(WebCreditContext db)
        //{
        //    this.db = db;

        //    var config = new MapperConfiguration(cf =>
        //    {
        //        cf.CreateMap<FileReader.Sap.Resources.DeliveryFlowDomestic, Core.Domains.Sap.DeliveryFlowDomestic>();
        //        cf.CreateMap<FileReader.Sap.Resources.CustomerMaster, Core.Domains.Sap.CustomerMaster>();
        //        cf.CreateMap<FileReader.Sap.Resources.ArOutstanding, Core.Domains.Sap.ArOutstanding>();
        //        cf.CreateMap<FileReader.Sap.Resources.BillingSdHeader, Core.Domains.Sap.BillingSdHeader>();
        //        cf.CreateMap<FileReader.Sap.Resources.BillingSdItem, Core.Domains.Sap.BillingSdItem>();
        //        cf.CreateMap<FileReader.Sap.Resources.CreditMaster, Core.Domains.Sap.CreditMaster>();
        //        cf.CreateMap<FileReader.Sap.Resources.DeliveryFlowExport, Core.Domains.Sap.DeliveryFlowExport>();
        //        cf.CreateMap<FileReader.Sap.Resources.ExportOrder, Core.Domains.Sap.ExportOrder>();
        //        cf.CreateMap<FileReader.Sap.Resources.FiCashSale, Core.Domains.Sap.FiCashSale>();
        //        cf.CreateMap<FileReader.Sap.Resources.OpenGl, Core.Domains.Sap.OpenGl>();
        //        cf.CreateMap<FileReader.Sap.Resources.PartnerFunction, Core.Domains.Sap.PartnerFunction>();
        //    });

        //    mapper = new Mapper(config);
        //}

        //private IEnumerable<T> ReadFile<T>(string folder, IFileReader<T> fileReader) where T : class
        //{
        //    var path = Path.Combine(rootFolder, folder);
        //    Console.WriteLine($"Path : {path}");
        //    var files = Directory.GetFiles(path);
        //    Console.WriteLine($"Files : {files.Length}");
        //    var list = new List<T>();
        //    foreach (var file in files)
        //    {
        //        Console.WriteLine($"Begin Read {Path.GetFileName(file)}");

        //        using (var st = File.OpenRead(file))
        //        {
        //            var rows = fileReader.Read(st);
        //            Console.WriteLine($"{rows.Count()} Rows");
        //            list.AddRange(rows);
        //        }

        //    }

        //    return list;
        //}

        //public void DeliveryFlowDomestic()
        //{
        //    Console.WriteLine($"DeliveryFlowDomestic");
        //    var folder = "deliveryFlowDomestic";

        //    try
        //    {
        //        var rows = ReadFile(folder, new DeliveryFlowDomesticFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.DeliveryFlowDomestic>>(rows);
        //        db.DeliveryFlowDomestics.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //public void CustomerMaster()
        //{
        //    Console.WriteLine($"CustomerMaster");
        //    var folder = "customerMaster";

        //    try
        //    {
        //        var rows = ReadFile(folder, new CustomerMasterFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.CustomerMaster>>(rows);
        //        db.CustomerMasters.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //public void ArOutstanding()
        //{
        //    Console.WriteLine($"ArOutstanding");
        //    var folder = "arOutstanding";

        //    try
        //    {
        //        var rows = ReadFile(folder, new ArOutstandingFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.ArOutstanding>>(rows);
        //        db.ArOutstandings.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //public void BillingSdHeader()
        //{
        //    Console.WriteLine($"Billing SD Header");
        //    var folder = "billingSdHeader";

        //    try
        //    {
        //        var rows = ReadFile(folder, new BillingSdHeaderFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.BillingSdHeader>>(rows);
        //        db.BillingSdHeaders.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //public void BillingSdItem()
        //{
        //    Console.WriteLine($"Billing SD Item");
        //    var folder = "billingSdItem";

        //    try
        //    {
        //        var rows = ReadFile(folder, new BillingSdItemFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.BillingSdItem>>(rows);
        //        db.BillingSdItems.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //public void CreditMaster()
        //{
        //    Console.WriteLine($"CreditMaster");
        //    var folder = "creditMaster";

        //    try
        //    {
        //        var rows = ReadFile(folder, new CreditMasterFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.CreditMaster>>(rows);
        //        db.CreditMasters.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //public void ExportOrder()
        //{
        //    Console.WriteLine($"ExportOrder");
        //    var folder = "exportOrder";

        //    try
        //    {
        //        var rows = ReadFile(folder, new ExportOrderFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.ExportOrder>>(rows);
        //        db.ExportOrders.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //public void FiCashSale()
        //{
        //    Console.WriteLine($"FiCashSale");
        //    var folder = "fiCashSale";

        //    try
        //    {
        //        var rows = ReadFile(folder, new FiCashSaleFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.FiCashSale>>(rows);
        //        db.FiCashSales.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //public void OpenGl()
        //{
        //    Console.WriteLine($"Open GL");
        //    var folder = "openGl";

        //    try
        //    {
        //        var rows = ReadFile(folder, new OpenGlFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.OpenGl>>(rows);
        //        db.OpenGls.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        //public void PartnerFunction()
        //{
        //    Console.WriteLine($"PartnerFunction");
        //    var folder = "partnerFunction";

        //    try
        //    {
        //        var rows = ReadFile(folder, new PartnerFunctionFileReader());
        //        var entities = mapper.Map<IEnumerable<Core.Domains.Sap.PartnerFunction>>(rows);
        //        db.PartnerFunctions.AddRange(entities);
        //        db.SaveChanges();
        //        Console.WriteLine($"Success.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}
    }
}
