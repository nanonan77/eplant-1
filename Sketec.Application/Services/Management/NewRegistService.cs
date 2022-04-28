using AutoMapper;
using Sketec.Application.Interfaces;
using Sketec.Core.Domains;
using Sketec.Core.Interfaces;
using Sketec.Core.Specifications;
using Sketec.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Services
{
    public class NewRegistService : ApplicationService, INewRegistService
    {
        IMapper mapper;
        IWCUnitOfWork uow;
        IWCDapperRepository dapper;
        IWCQueryRepository queryRepo;
        ISharePointService sharePointService;
        IWCAzureBlobStorageService azureBlobStorageService;
        IWCRepository<NewRegist> newRegistRepo;
        IWCRepository<NewRegistImagePath> newRegistImageRepo;
        public NewRegistService(
            IMapper mapper,
            IWCUnitOfWork uow,
            IWCDapperRepository dapper,
            ISharePointService sharePointService,
            IWCAzureBlobStorageService azureBlobStorageService,
            IWCRepository<NewRegist> newRegistRepo,
            IWCRepository<NewRegistImagePath> newRegistImageRepo,
            IWCQueryRepository queryRepo)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.dapper = dapper;
            this.queryRepo = queryRepo;
            this.newRegistRepo = newRegistRepo;
            this.newRegistImageRepo = newRegistImageRepo;
            this.sharePointService = sharePointService;
            this.azureBlobStorageService = azureBlobStorageService;
        }

        public async Task ImportNewRegist(IEnumerable<NewRegist> newRegists) 
        {
            if (newRegists.Any()) 
            {
                foreach (var item in newRegists)
                {
                    var spec = new NewRegistSearchByRegistIdSpec(item.RegistId);
                    var data = await newRegistRepo.GetBySpecAsync(spec);
                    if (data == null)
                    {
                        data = item;
                        data.IsActive = true;
                        data.AssignToDate = item.CreatedFromFile;
                        data.CreatedBy = "Job Import";
                        data.CreatedDate = DateTime.Now;
                        data.UpdatedBy = string.IsNullOrEmpty(item.PIC) ? null : item.PIC.Split(',')[0];
                        data.UpdatedDate = item.ModifiedFromFile;
                        data.Team = "ทีมหาพื้นที่";
                        await newRegistRepo.AddAsync(data);
                    }
                    else 
                    {
                        data.Title = item.Title;
                        data.Status = item.Status;
                        data.Province = item.Province;
                        data.District = item.District;
                        data.SubDistrict = item.SubDistrict;
                        data.Village = item.Village;
                        data.Plot = item.Plot;
                        data.TotalArea = item.TotalArea;
                        data.Latitude = item.Latitude;
                        data.Longitude = item.Longitude;
                        data.Clearing1 = item.Clearing1;
                        data.Clearing1Area = item.Clearing1Area;
                        data.Clearing2 = item.Clearing2;
                        data.CreatedFromFile = item.CreatedFromFile;
                        data.Contract = item.Contract;
                        data.ModifiedFromFile = item.ModifiedFromFile;
                        data.PIC = string.IsNullOrEmpty(item.PIC) ? null : item.PIC.ToLower();
                        data.Generated = item.Generated;
                        data.Interface = item.Interface;
                        data.ItemType = item.ItemType;
                        data.Path = item.Path;
                        data.Zone = item.Zone;
                        data.Verifier = string.IsNullOrEmpty(item.Verifier) ? null : item.Verifier.ToLower();
                        data.MOUType = item.MOUType;
                        data.Seedling = item.Seedling;
                        data.HarvestingMonth1 = item.HarvestingMonth1;
                        data.HarvestingMonth2 = item.HarvestingMonth2;
                        data.HarvestingYear1 = item.HarvestingYear1;
                        data.HarvestingYear2 = item.HarvestingYear2;
                        data.MOUPrice = item.MOUPrice;
                        data.PlanVolume = item.PlanVolume;
                        data.Remark = item.Remark;
                        data.ContractType = item.ContractType;
                        data.UpdatedBy = string.IsNullOrEmpty(item.PIC) ? null : item.PIC.Split(',')[0];
                        data.UpdatedDate = item.ModifiedFromFile;
                    }
                }
                await uow.SaveAsyncNoStampDate();
            }
        }

        public async Task ImportSubNewRegist(IEnumerable<SubNewRegist> subNewRegists)
        {
            if (subNewRegists.Any())
            {
                foreach (var item in subNewRegists)
                {
                    var spec = new NewRegistSearchByRegistIdSpec(item.RegistId).InCludeSubNewRegists();
                    var data = await newRegistRepo.GetBySpecAsync(spec);
                    if (data == null)
                    {
                        continue;
                    }
                    var subRegis = data.SubNewRegists.FirstOrDefault(o => o.SubRegistId == item.SubRegistId);

                    var soilType = item.SoilType;
                    if (soilType != null && soilType.Substring(soilType.Length - 1) == ",")
                    {
                        soilType = soilType.Substring(0, soilType.Length - 1);
                    }

                    if (subRegis == null)
                    {
                        data.AddSubNewRegist(new SubNewRegist
                        {
                            Title = item.Title,
                            RegistId = item.RegistId,
                            SubRegistId = item.SubRegistId,
                            Latitude = item.Latitude,
                            Longitude = item.Longitude,
                            Area = item.Area,
                            NumSoilType = item.NumSoilType,
                            SoilType = soilType,
                            LandUse = item.LandUse,
                            Accessibility = item.Accessibility,
                            Water = item.Water,
                            NumSoilTest = item.NumSoilTest,
                            Rainfall = item.Rainfall,
                            DeedArea = item.DeedArea,
                            ItemType = item.ItemType,
                            Path = item.Path,
                            PlantYear = item.PlantYear,
                            HarvestingMonth = item.HarvestingMonth,
                            HarvestingYear = item.HarvestingYear,
                            Volume = item.Volume,
                            VipPrice = item.VipPrice,
                            Remark = item.Remark,
                            IsActive = true
                        });
                    }
                    else
                    {
                        subRegis.Title = item.Title;
                        subRegis.RegistId = item.RegistId;
                        subRegis.Latitude = item.Latitude;
                        subRegis.Longitude = item.Longitude;
                        subRegis.Area = item.Area;
                        subRegis.NumSoilType = item.NumSoilType;
                        subRegis.SoilType = soilType;
                        subRegis.LandUse = item.LandUse;
                        subRegis.Accessibility = item.Accessibility;
                        subRegis.Water = item.Water;
                        subRegis.NumSoilTest = item.NumSoilTest;
                        subRegis.Rainfall = item.Rainfall;
                        subRegis.DeedArea = item.DeedArea;
                        subRegis.ItemType = item.ItemType;
                        subRegis.Path = item.Path;
                        subRegis.PlantYear = item.PlantYear;
                        subRegis.HarvestingMonth = item.HarvestingMonth;
                        subRegis.HarvestingYear = item.HarvestingYear;
                        subRegis.Volume = item.Volume;
                        subRegis.VipPrice = item.VipPrice;
                        subRegis.Remark = item.Remark;
                    }
                }
                await uow.SaveAsync();
            }
        }

        public async Task ImportSubNewRegistTestPlot(IEnumerable<SubNewRegistTestPlot> subNewRegistTestPlots)
        {
            if (subNewRegistTestPlots.Any())
            {
                foreach (var item in subNewRegistTestPlots)
                {
                    var spec = new NewRegistSearchBySubRegistIdSpec(item.SubRegistId).InCludeSubNewRegists().InCludeSubNewRegistTestPlots();
                    var data = await newRegistRepo.GetBySpecAsync(spec);
                    if (data == null)
                    {
                        continue;
                    }
                    var subRegis = data.SubNewRegists.FirstOrDefault(o => o.SubRegistId == item.SubRegistId);
                    if (subRegis == null)
                    {
                        continue;
                    }
                    var subTestPlot = subRegis.SubNewRegistTestPlots.FirstOrDefault(o => o.SubNewRegistTestId == item.SubNewRegistTestId);
                    if (subTestPlot == null)
                    {
                        subRegis.AddSubNewRegistTestPlot(new SubNewRegistTestPlot
                        {
                            SubRegistId = item.SubRegistId,
                            SubNewRegistTestId = item.SubNewRegistTestId,
                            Latitude = item.Latitude,
                            Longitude = item.Longitude,
                            SoilType = item.SoilType,
                            Depth = item.Depth,
                            SoillFloorDepth = item.SoillFloorDepth,
                            GravelDepth = item.GravelDepth,
                            PH30 = item.PH30,
                            PH60 = item.PH60,
                            EC30 = item.EC30,
                            EC60 = item.EC60,
                            Dot = item.Dot,
                            ItemType = item.ItemType,
                            Path = item.Path,
                            IsActive = true
                        });
                    }
                    else
                    {
                        subTestPlot.SubRegistId = item.SubRegistId;
                        subTestPlot.SubNewRegistTestId = item.SubNewRegistTestId;
                        subTestPlot.Latitude = item.Latitude;
                        subTestPlot.Longitude = item.Longitude;
                        subTestPlot.SoilType = item.SoilType;
                        subTestPlot.Depth = item.Depth;
                        subTestPlot.SoillFloorDepth = item.SoillFloorDepth;
                        subTestPlot.GravelDepth = item.GravelDepth;
                        subTestPlot.PH30 = item.PH30;
                        subTestPlot.PH60 = item.PH60;
                        subTestPlot.EC30 = item.EC30;
                        subTestPlot.EC60 = item.EC60;
                        subTestPlot.Dot = item.Dot;
                        subTestPlot.ItemType = item.ItemType;
                        subTestPlot.Path = item.Path;
                        subTestPlot.UpdatedBy = string.IsNullOrEmpty(data.PIC) ? null :data.PIC.Split(',')[0];
                        subTestPlot.UpdatedDate = DateTime.Now;
                    }
                }
                await uow.SaveAsync();
            }
        }

        public async Task ImportNewRegistImagePath(IEnumerable<NewRegistImagePath> imagePaths)
        {
            if (imagePaths.Any())
            {
                foreach (var item in imagePaths)
                {
                    var spec = new NewRegistImagePathByNameSpec(item.Name);
                    var data = await newRegistImageRepo.GetBySpecAsync(spec);
                    if (data == null)
                    {
                        data = item;
                        data.IsActive = true;
                        await newRegistImageRepo.AddAsync(data);
                    }
                    else
                    {
                        data.Name = item.Name;
                        data.SurveyId = item.SurveyId;
                        data.PlantationId = item.PlantationId;
                        data.ImageInfo = item.ImageInfo;
                        data.ImageInfo2 = item.ImageInfo2;
                        data.ImageInfo3 = item.ImageInfo3;
                        data.ItemType = item.ItemType;
                        data.Path = item.Path;
                        data.ImageLevel = item.ImageLevel;
                    }

                    try
                    {
                        var img = sharePointService.GetImage(item.ImageInfo);
                        if (img != null)
                        {
                            var fileName = $"{item.Name}.jpg";
                            var path = $"eplantation/NewRegist/{item.SurveyId}/{fileName}";
                            //var imgResize = Utils.GenerateFile.ResizeImage50K(img);
                            await azureBlobStorageService.Upload(path, img);
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                }
                await uow.SaveAsync();
            }
        }

        public async Task UploadNewRegistImagePath()
        {
            var data = await newRegistImageRepo.ListAsync();
            if(data.Any())
            {
                foreach (var item in data)
                {
                    try
                    {
                        var img = sharePointService.GetImage(item.ImageInfo);
                        if (img != null)
                        {
                            var fileName = $"{item.Name}.jpg";
                            var path = $"eplantation/NewRegist/{item.SurveyId}/{fileName}";
                            //var imgResize = Utils.GenerateFile.ResizeImage50K(img);
                            await azureBlobStorageService.Upload(path, img);
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                }
            }
        }
    }
}
