using OfficeOpenXml;
using Sketec.Core.Domains;
using Sketec.Core.Domains.Types;
using Sketec.FileReader.Resources;
using Sketec.FileReader.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.FileReader.Excels
{
    public static class NewRegistFileReader
    {
        public static NewRegistFileReaderResult GetNewRegistDetail(byte[] byteArray)
        {
            using (Stream stream = new MemoryStream(byteArray))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelPackage package = new ExcelPackage(stream);
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                var newRegistFile = new NewRegistFileReaderResult
                {
                    SubNewRegistTestPlot = ReadSubNewRegistTestPlots(package, 0),
                    SubNewRegist = ReadSubNewRegist(package, 1),
                    NewRegist = ReadNewRegist(package, 2),
                    NewRegistImagePath = ReadNewRegistImagePath(package, 3)
                };
                return newRegistFile;
            }
        }

        private static IEnumerable<SubNewRegistTestPlot> ReadSubNewRegistTestPlots(ExcelPackage package, int sheetIndex) 
        {
            var result = new List<SubNewRegistTestPlot>();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(o => o.Index == sheetIndex);
            if (worksheet == null) 
            {
                return result;
            }
            for (var row = 1; row <= worksheet.Dimension.End.Row; row++)
            {
                if (row < SubNewRegistTestPlotColumns.RowDetailStart || worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnSubNewRegistTestId].Value == null)
                {
                    continue;
                }

                var data = new SubNewRegistTestPlot
                {
                    SubRegistId = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnTitle].Value?.ToString(),
                    SubNewRegistTestId = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnSubNewRegistTestId].Value?.ToString(),
                    Latitude = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnLatitude].Value?.ToString(),
                    Longitude = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnLongitude].Value?.ToString(),
                    SoilType = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnSoilType].GetInt(),
                    Depth = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnDepth].Value?.ToString(),
                    SoillFloorDepth = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnSoillFloorDepth].Value?.ToString(),
                    GravelDepth = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnGravelDepth].Value?.ToString(),
                    PH30 = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnPH30].GetDecimal(),
                    PH60 = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnPH60].GetDecimal(),
                    EC30 = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnEC30].GetDecimal(),
                    EC60 = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnEC60].GetDecimal(),
                    Dot = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnDot].Value?.ToString(),
                    ItemType = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnItemType].Value?.ToString(),
                    Path = worksheet.Cells[row, SubNewRegistTestPlotColumns.ColumnPath].Value?.ToString()
                };
                result.Add(data);
            }

            return result;
        }
        private static IEnumerable<SubNewRegist> ReadSubNewRegist(ExcelPackage package, int sheetIndex)
        {
            var result = new List<SubNewRegist>();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(o => o.Index == sheetIndex);
            if (worksheet == null)
            {
                return result;
            }
            for (var row = 1; row <= worksheet.Dimension.End.Row; row++)
            {
                if (row < SubNewRegistColumns.RowDetailStart || worksheet.Cells[row, SubNewRegistColumns.ColumnSubRegistId].Value == null)
                {
                    continue;
                }

                var data = new SubNewRegist
                {
                    Title = worksheet.Cells[row, SubNewRegistColumns.ColumnTitle].Value?.ToString(),
                    RegistId = worksheet.Cells[row, SubNewRegistColumns.ColumnRegistId].Value?.ToString(),
                    SubRegistId = worksheet.Cells[row, SubNewRegistColumns.ColumnSubRegistId].Value?.ToString(),
                    Latitude = worksheet.Cells[row, SubNewRegistColumns.ColumnLatitude].Value?.ToString(),
                    Longitude = worksheet.Cells[row, SubNewRegistColumns.ColumnLongitude].Value?.ToString(),
                    Area = worksheet.Cells[row, SubNewRegistColumns.ColumnArea].GetDecimal(),
                    NumSoilType = worksheet.Cells[row, SubNewRegistColumns.ColumnNumSoilType].GetInt(),
                    SoilType = worksheet.Cells[row, SubNewRegistColumns.ColumnSoilType].Value?.ToString(),
                    LandUse = worksheet.Cells[row, SubNewRegistColumns.ColumnLandUse].Value?.ToString(),
                    Accessibility = worksheet.Cells[row, SubNewRegistColumns.ColumnAccessibility].Value?.ToString(),
                    Water = worksheet.Cells[row, SubNewRegistColumns.ColumnWater].Value?.ToString(),
                    NumSoilTest = worksheet.Cells[row, SubNewRegistColumns.ColumnNumSoilTest].GetInt(),
                    Rainfall = worksheet.Cells[row, SubNewRegistColumns.ColumnRainfall].GetDecimal(),
                    DeedArea = worksheet.Cells[row, SubNewRegistColumns.ColumnDeedArea].GetDecimal(),
                    ItemType = worksheet.Cells[row, SubNewRegistColumns.ColumnItemType].Value?.ToString(),
                    Path = worksheet.Cells[row, SubNewRegistColumns.ColumnPath].Value?.ToString(),
                    PlantYear = worksheet.Cells[row, SubNewRegistColumns.ColumnPlantYear].GetInt(),
                    HarvestingMonth = worksheet.Cells[row, SubNewRegistColumns.ColumnHarvestingMonth].GetInt(),
                    HarvestingYear = worksheet.Cells[row, SubNewRegistColumns.ColumnHarvestingYear].GetInt(),
                    Volume = worksheet.Cells[row, SubNewRegistColumns.ColumnVolume].GetDecimal(),
                    VipPrice = worksheet.Cells[row, SubNewRegistColumns.ColumnVipPrice].GetDecimal(),
                    Remark = worksheet.Cells[row, SubNewRegistColumns.ColumnRemark].Value?.ToString(),
                };
                result.Add(data);
            }

            return result;
        }
        private static IEnumerable<NewRegist> ReadNewRegist(ExcelPackage package, int sheetIndex)
        {
            var result = new List<NewRegist>();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(o => o.Index == sheetIndex);
            if (worksheet == null)
            {
                return result;
            }
            for (var row = 1; row <= worksheet.Dimension.End.Row; row++)
            {
                if (row < SubNewRegistColumns.RowDetailStart || worksheet.Cells[row, NewRegistColumns.ColumnRegistId].Value == null)
                {
                    continue;
                }

                var data = new NewRegist
                {
                    Title = worksheet.Cells[row, NewRegistColumns.ColumnTitle].Value?.ToString(),
                    RegistId = worksheet.Cells[row, NewRegistColumns.ColumnRegistId].Value?.ToString(),
                    Status = worksheet.Cells[row, NewRegistColumns.ColumnStatus].Value?.ToString(),
                    Province = worksheet.Cells[row, NewRegistColumns.ColumnProvince].Value?.ToString(),
                    District = worksheet.Cells[row, NewRegistColumns.ColumnDistrict].Value?.ToString(),
                    SubDistrict = worksheet.Cells[row, NewRegistColumns.ColumnSubDistrict].Value?.ToString(),
                    Village = worksheet.Cells[row, NewRegistColumns.ColumnVillage].Value?.ToString(),
                    Plot = worksheet.Cells[row, NewRegistColumns.ColumnPlot].GetInt(),
                    TotalArea = worksheet.Cells[row, NewRegistColumns.ColumnTotalArea].GetDecimal(),
                    Latitude = worksheet.Cells[row, NewRegistColumns.ColumnLatitude].Value?.ToString(),
                    Longitude = worksheet.Cells[row, NewRegistColumns.ColumnLongitude].Value?.ToString(),
                    Clearing1 = worksheet.Cells[row, NewRegistColumns.ColumnClearing1].Value?.ToString(),
                    Clearing1Area = worksheet.Cells[row, NewRegistColumns.ColumnClearing1Area].GetDecimal(),
                    Clearing2 = worksheet.Cells[row, NewRegistColumns.ColumnClearing2].Value?.ToString(),
                    CreatedFromFile = worksheet.Cells[row, NewRegistColumns.ColumnCreatedFromFile].GetDate("dd/MM/yyyy HH:mm"),
                    Contract = worksheet.Cells[row, NewRegistColumns.ColumnContract].GetInt(),
                    ModifiedFromFile = worksheet.Cells[row, NewRegistColumns.ColumnModifiedFromFile].GetDate("dd/MM/yyyy HH:mm"),
                    PIC = worksheet.Cells[row, NewRegistColumns.ColumnPIC].Value?.ToString(),
                    Generated = worksheet.Cells[row, NewRegistColumns.ColumnGenerated].GetInt(),
                    Interface = worksheet.Cells[row, NewRegistColumns.ColumnInterface].GetInt(),
                    ItemType = worksheet.Cells[row, NewRegistColumns.ColumnItemType].Value?.ToString(),
                    Path = worksheet.Cells[row, NewRegistColumns.ColumnPath].Value?.ToString(),
                    Zone = worksheet.Cells[row, NewRegistColumns.ColumnZone].Value?.ToString(),
                    Verifier = worksheet.Cells[row, NewRegistColumns.ColumnVerifier].Value?.ToString(),
                    MOUType = worksheet.Cells[row, NewRegistColumns.ColumnMOUType].Value?.ToString(),
                    Seedling = worksheet.Cells[row, NewRegistColumns.ColumnSeedling].GetInt(),
                    HarvestingYear1 = worksheet.Cells[row, NewRegistColumns.ColumnHarvestingYear1].GetInt(),
                    HarvestingMonth1 = worksheet.Cells[row, NewRegistColumns.ColumnHarvestingMonth1].GetInt(),
                    HarvestingYear2 = worksheet.Cells[row, NewRegistColumns.ColumnHarvetingYear2].GetInt(),
                    HarvestingMonth2 = worksheet.Cells[row, NewRegistColumns.ColumnHarvestingMonth2].GetInt(),
                    MOUPrice = worksheet.Cells[row, NewRegistColumns.ColumnMOUPrice].GetDecimal(),
                    PlanVolume = worksheet.Cells[row, NewRegistColumns.ColumnPlanVolume].GetDecimal(),
                    Remark = worksheet.Cells[row, NewRegistColumns.ColumnRemark].Value?.ToString(),
                    ContractType = worksheet.Cells[row, NewRegistColumns.ColumnContractType].Value?.ToString(),
                };
                result.Add(data);
            }

            return result;
        }
        private static IEnumerable<NewRegistImagePath> ReadNewRegistImagePath(ExcelPackage package, int sheetIndex)
        {
            var result = new List<NewRegistImagePath>();
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault(o => o.Index == sheetIndex);
            if (worksheet == null)
            {
                return result;
            }
            for (var row = 1; row <= worksheet.Dimension.End.Row; row++)
            {
                if (row < SubNewRegistColumns.RowDetailStart || worksheet.Cells[row, NewRegistImagePathColumns.ColumnSurveyId].Value == null)
                {
                    continue;
                }

                var surveyId = worksheet.Cells[row, NewRegistImagePathColumns.ColumnSurveyId].Value?.ToString();
                var plantationId = worksheet.Cells[row, NewRegistImagePathColumns.ColumnPlantationId].Value?.ToString();
                var imageInfo2 = worksheet.Cells[row, NewRegistImagePathColumns.ColumnImageInfo2].Value?.ToString();
                var imageLevel = !string.IsNullOrEmpty(surveyId) && !string.IsNullOrEmpty(plantationId) && !string.IsNullOrEmpty(imageInfo2)
                                ? NewRegistLevel.SubNewRegistTestPlot
                                : !string.IsNullOrEmpty(surveyId) && !string.IsNullOrEmpty(plantationId)
                                    ? NewRegistLevel.SubNewRegist
                                    : NewRegistLevel.NewRegist;
                var data = new NewRegistImagePath
                {
                    Name = worksheet.Cells[row, NewRegistImagePathColumns.ColumnName].Value?.ToString(),
                    SurveyId = surveyId,
                    PlantationId = plantationId,
                    ImageInfo = worksheet.Cells[row, NewRegistImagePathColumns.ColumnImageInfo].Value?.ToString(),
                    ImageInfo2 = imageInfo2,
                    ImageInfo3 = worksheet.Cells[row, NewRegistImagePathColumns.ColumnImageInfo3].Value?.ToString(),
                    ItemType = worksheet.Cells[row, NewRegistImagePathColumns.ColumnItemType].Value?.ToString(),
                    Path = worksheet.Cells[row, NewRegistImagePathColumns.ColumnPath].Value?.ToString(),
                    ImageLevel = imageLevel
                };
                result.Add(data);
            }

            return result;
        }
    }


    public static class SubNewRegistTestPlotColumns
    {
        public const int RowDetailStart = 2;

        public const int ColumnTitle = 1;
        public const int ColumnSubNewRegistTestId = 2;
        public const int ColumnLatitude = 3;
        public const int ColumnLongitude = 4;
        public const int ColumnSoilType = 5;
        public const int ColumnDepth = 6;
        public const int ColumnSoillFloorDepth = 7;
        public const int ColumnGravelDepth = 8;
        public const int ColumnPH30 = 9;
        public const int ColumnPH60 = 10;
        public const int ColumnEC30 = 11;
        public const int ColumnEC60 = 12;
        public const int ColumnDot = 13;
        public const int ColumnItemType = 14;
        public const int ColumnPath = 15;
    }

    public static class SubNewRegistColumns
    {
        public const int RowDetailStart = 2;

        public const int ColumnTitle = 1;
        public const int ColumnRegistId = 2;
        public const int ColumnSubRegistId = 3;
        public const int ColumnLatitude = 4;
        public const int ColumnLongitude = 5;
        public const int ColumnArea = 6;
        public const int ColumnNumSoilType = 7;
        public const int ColumnSoilType = 8;
        public const int ColumnLandUse = 9;
        public const int ColumnAccessibility = 10;
        public const int ColumnWater = 11;
        public const int ColumnNumSoilTest = 12;
        public const int ColumnRainfall = 13;
        public const int ColumnDeedArea = 14;
        public const int ColumnItemType = 15;
        public const int ColumnPath = 16;
        public const int ColumnPlantYear = 17;
        public const int ColumnHarvestingMonth = 18;
        public const int ColumnHarvestingYear = 19;
        public const int ColumnVolume = 20;
        public const int ColumnVipPrice = 21;
        public const int ColumnRemark = 22;
    }

    public static class NewRegistColumns
    {
        public const int RowDetailStart = 2;

        public const int ColumnTitle = 1;
        public const int ColumnRegistId = 2;
        public const int ColumnStatus = 3;
        public const int ColumnProvince = 4;
        public const int ColumnDistrict = 5;
        public const int ColumnSubDistrict = 6;
        public const int ColumnVillage = 7;
        public const int ColumnPlot = 8;
        public const int ColumnTotalArea = 9;
        public const int ColumnLatitude = 10;
        public const int ColumnLongitude = 11;
        public const int ColumnClearing1 = 12;
        public const int ColumnClearing1Area = 13;
        public const int ColumnClearing2 = 14;
        public const int ColumnCreatedFromFile = 15;
        public const int ColumnContract = 16;
        public const int ColumnModifiedFromFile = 17;
        public const int ColumnPIC = 18;
        public const int ColumnGenerated = 19;
        public const int ColumnInterface = 20;
        public const int ColumnItemType = 21;
        public const int ColumnPath = 22;
        public const int ColumnZone = 23;
        public const int ColumnVerifier = 24;
        public const int ColumnMOUType = 25;
        public const int ColumnSeedling = 26;
        public const int ColumnHarvestingYear1 = 27;
        public const int ColumnHarvestingMonth1 = 28;
        public const int ColumnHarvetingYear2 = 29;
        public const int ColumnHarvestingMonth2 = 30;
        public const int ColumnMOUPrice = 31;
        public const int ColumnPlanVolume = 32;
        public const int ColumnRemark = 33;
        public const int ColumnContractType = 34;
    }

    public static class NewRegistImagePathColumns
    {
        public const int RowDetailStart = 2;

        public const int ColumnName = 1;
        public const int ColumnSurveyId = 2;
        public const int ColumnPlantationId = 3;
        public const int ColumnImageInfo = 4;
        public const int ColumnImageInfo2 = 5;
        public const int ColumnImageInfo3 = 6;
        public const int ColumnItemType = 7;
        public const int ColumnPath = 8;
    }

}
