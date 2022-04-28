using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Sketec.FileWriter.Resources
{
    public class NewRegistPdfDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string RegistId { get; set; }
        public string Status { get; set; }
        public string OwnerName { get; set; }
        public string OwnerLastName { get; set; }
        public string OwnerTel { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Village { get; set; }
        public int? Plot { get; set; }
        public decimal? TotalArea { get; set; }
        public decimal? Rai { get; set; }
        public decimal? Ngan { get; set; }
        public decimal? Meter { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Clearing1 { get; set; }
        public decimal? Clearing1Area { get; set; }
        public string Clearing2 { get; set; }
        public DateTime? CreatedFromFile { get; set; }
        public int? Contract { get; set; }
        public DateTime? ModifiedFromFile { get; set; }

        public string PIC { get; set; }
        public int? Generated { get; set; }
        public int? Interface { get; set; }
        public string ItemType { get; set; }
        public string Path { get; set; }
        public string Zone { get; set; }
        public string Verifier { get; set; }
        public string MOUType { get; set; }
        public int? Seedling { get; set; }
        public int? HarvestingYear1 { get; set; }
        public int? HarvestingMonth1 { get; set; }
        public int? HarvestingYear2 { get; set; }
        public int? HarvestingMonth2 { get; set; }
        public decimal? MOUPrice { get; set; }
        public decimal? PlanVolume { get; set; }
        public string Remark { get; set; }
        public string ContractType { get; set; }
        public bool IsActive { get; set; }
        //public IEnumerable<SubNewRegistDto> SubNewRegists { get; set; }
        public IEnumerable<NewRegistImagePathPdfDto> NewRegistImagePaths { get; set; }
        public IEnumerable<FileInfoPdfDto> NewRegistImageOther { get; set; }
        public string Team { get; set; }
        public bool IsCanEdit { get; set; }
        public DateTime? ContractStart { get; set; }
        public DateTime? ContractEnd { get; set; }
        public string PhysicalArea { get; set; }
        public DateTime? AssignToDate { get; set; }
    }

    public class FileInfoPdfDto
    {
        public Guid Id { get; set; }
        public int? Sequence { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
        public Guid? RefId { get; set; }
        public string Path { get; set; }
        public byte[] Base64 { get; set; }
    }

    public class NewRegistImagePathPdfDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurveyId { get; set; }
        public string PlantationId { get; set; }
        public string ImageInfo { get; set; }
        public string ImageInfo2 { get; set; }
        public string ImageInfo3 { get; set; }
        public string ItemType { get; set; }
        public string Path { get; set; }
        public Guid NewRegistId { get; set; }
        public Guid? SubNewRegistId { get; set; }
        public Guid? SubNewRegistTestPlotId { get; set; }
        public NewRegistLevel ImageLevel { get; set; }
        public byte[] Base64 { get; set; }
        public bool IsActive { get; set; }
        public bool IsSelectedStep2 { get; set; }
        public bool IsSelectedStep3 { get; set; }
    }
    public class AssumptionPdfDto
    {
        public Guid Id { get; set; }
        public Guid NewRegistId { get; set; }
        public int ContractYear { get; set; }
        public string ContractType { get; set; }
        public decimal? RentalArea { get; set; }
        public int? ProductiveAreaPercent { get; set; }
        public decimal? ProductiveArea { get; set; }
        public string Rainfall { get; set; }
        public string SoilType { get; set; }
        public int CuttingRound { get; set; }
        public decimal? DistanceToPlant { get; set; }
        public string Mill { get; set; }
        public decimal? AveragePrice { get; set; }
        public decimal? MtpPrice { get; set; }
        public decimal? FcPrice { get; set; }
        public int? CuttingCostTypeId { get; set; }
        public decimal? CuttingCost { get; set; }
        public int? FreightTypeId { get; set; }
        public decimal? Freight { get; set; }
        public decimal? InflationRate { get; set; }
        public decimal? PlanVolume { get; set; }
        public decimal? AverageRate { get; set; }
        public decimal? MtpRate { get; set; }
        public decimal? FcRate { get; set; }
        public decimal? PriceAtPlant { get; set; }

        public NewRegistPdfDto NewRegist { get; set; }
        public List<AssumptionYieldPdfDto> AssumptionYield { get; set; }
        public List<AssumptionClonePdfDto> AssumptionClone { get; set; }
        public List<ExpensePdfDto> Expense { get; set; }
        public List<FileInfoPdfDto> FileInfo { get; set; }

    }

    public class AssumptionClonePdfDto
    {
        public Guid Id { get; set; }
        public Guid AssumptionId { get; set; }
        public string Clone { get; set; }
        public decimal? Portion { get; set; }
        public decimal? Area { get; set; }
        public decimal? ProductTon { get; set; }

    }
    public class ExpensePdfDto
    {
        public Guid Id { get; set; }
        public Guid AssumptionId { get; set; }
        public int ActivityId { get; set; }
        public string ActivityGroup { get; set; }
        public string ActivityName { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public string ExpenseTypeValues => ExpenseType.GetStringValue();
        public string ExpenseTypeDescription => ExpenseType.GetDescription();
        public decimal? BahtPerRai { get; set; }
        public decimal? YearCost1 { get; set; }
        public decimal? YearCost2 { get; set; }
        public decimal? YearCost3 { get; set; }
        public decimal? YearCost4 { get; set; }
        public decimal? YearCost5 { get; set; }
        public decimal? YearCost6 { get; set; }
        public decimal? YearCost7 { get; set; }
        public decimal? YearCost8 { get; set; }
        public decimal? YearCost9 { get; set; }
        public decimal? YearCost10 { get; set; }
        public decimal? YearCost11 { get; set; }
        public decimal? YearCost12 { get; set; }
        public decimal? YearCost13 { get; set; }
        public decimal? YearCost14 { get; set; }
        public decimal? YearCost15 { get; set; }
    }

    public class AssumptionYieldPdfDto
    {
        public Guid Id { get; set; }
        public Guid AssumptionId { get; set; }
        public int Round { get; set; }
        public int Year { get; set; }
        public decimal? Yield { get; set; }
        public decimal? RentalFee { get; set; }

        public int YearStart { get; set; }
        public int YearEnd { get; set; }
    }

}
