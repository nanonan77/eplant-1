using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Client;
using System.Net;
using PnP.Framework;
using AuthenticationManager = PnP.Framework.AuthenticationManager;
using System.IO;

namespace Sketec.Infrastructure.Services
{
    public class SharepointLoader
    {
        private string _url;
        private string _clientId;
        private string _clientSecret;
        public ClientContext Context;

        private SharepointLoader()
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

        public SharepointLoader(string url, string clientId, string clientSecret)
            : this()
        {
            _url = url;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        public byte[] GetFile(string serverRelativeUrl)
        {
            try
            {
                using (ClientContext cc = new AuthenticationManager().GetACSAppOnlyContext(_url, _clientId, _clientSecret))
                {
                    Uri uri = new Uri(serverRelativeUrl);
                    string serverRelativeURL = uri.AbsolutePath;
                    Microsoft.SharePoint.Client.File file = cc.Web.GetFileByServerRelativeUrl(serverRelativeURL);
                    ClientResult<System.IO.Stream> data = file.OpenBinaryStream();

                    cc.Load(file);
                    cc.ExecuteQuery();
                    using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
                    {
                        if (data != null)
                        {
                            data.Value.CopyTo(mStream);
                            return mStream.ToArray();
                        }
                    }
                    return null;
                }
            }
            catch (Exception exp)
            {
                return null;
            }
        }

        public void ReplaceFile(byte[] file, string serverRelativeUrl, string fileName)
        {
            try
            {
                using (ClientContext cc = new AuthenticationManager().GetACSAppOnlyContext(_url, _clientId, _clientSecret))
                {
                    using (var st = new MemoryStream(file))
                    {
                        Uri uri = new Uri(serverRelativeUrl);
                        string serverRelativeURL = uri.AbsolutePath;
                        Folder folderToUpload = cc.Web.GetFolderByServerRelativeUrl(serverRelativeURL);
                        folderToUpload.UploadFile(fileName, st, true);
                        folderToUpload.Update();
                        cc.Load(folderToUpload);
                        cc.ExecuteQueryRetry();
                    }
                }
            }
            catch (Exception exp)
            {

            }
        }

        public byte[] GetFileFromFolder(ClientContext context, string uri)
        {
            try
            {
                var files = context.Web.GetFolderByServerRelativeUrl(uri).Files;
                context.Load(files);
                context.ExecuteQuery();
                foreach (Microsoft.SharePoint.Client.File file in files)
                {
                    ClientResult<System.IO.Stream> data = file.OpenBinaryStream();
                    context.Load(file);
                    context.ExecuteQuery();
                    using (System.IO.MemoryStream mStream = new System.IO.MemoryStream())
                    {
                        if (data != null)
                        {
                            data.Value.CopyTo(mStream);
                            byte[] imageArray = mStream.ToArray();
                            string b64String = Convert.ToBase64String(imageArray);
                            return mStream.ToArray();
                        }
                    }
                }
                return null;
            }
            catch (Exception exp)
            {
                return null;
            }
        }
    }
}
