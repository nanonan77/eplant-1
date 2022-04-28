

using Microsoft.Extensions.Logging;
using Sketec.Core.Interfaces;
using Sketec.Core.Resources;

namespace Sketec.Infrastructure.Services
{
    public class SharePointService : ISharePointService
    {
        SharePointOptions option;


        public SharePointService(
            SharePointOptions option
            , ILogger<SharePointService> logger
            )
        {
            this.option = option;
        }

        public byte[] GetMasterActivityFile()
        {
            var loader = new SharepointLoader(option.Url, option.ClientId, option.ClientSecret);
            string serverRelativeUrl = @$"{option.NewRegistPath}/{option.MasterActivitytFileName}";
            var data = loader.GetFile(serverRelativeUrl);
            if (data == null)
            {
                using (System.IO.MemoryStream mStream = new System.IO.MemoryStream(Resource.Activity_Master))
                {
                    data = mStream.ToArray();
                }
            }
            return data;
        }

        public void ReplaceMasterActivityFile(byte[] file)
        {
            var loader = new SharepointLoader(option.Url, option.ClientId, option.ClientSecret);
            loader.ReplaceFile(file, option.NewRegistPath, option.MasterActivitytFileName);
        }

        public byte[] GetNewRegistFile()
        {
            var loader = new SharepointLoader(option.Url, option.ClientId, option.ClientSecret);
            string serverRelativeUrl = @$"{option.NewRegistPath}/{option.NewRegistFileName}";
            return loader.GetFile(serverRelativeUrl);
        }

        public void ReplaceNewRegistFile()
        {
            var loader = new SharepointLoader(option.Url, option.ClientId, option.ClientSecret);
            loader.ReplaceFile(Resource.New_Regist_01, option.NewRegistPath, option.NewRegistFileName);
        }

        public byte[] GetImage(string url)
        {
            var loader = new SharepointLoader(option.Url, option.ClientId, option.ClientSecret);
            string serverRelativeUrl = url;
            return loader.GetFile(serverRelativeUrl);
        }
    }
}
