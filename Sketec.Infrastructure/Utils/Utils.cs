using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;

namespace Sketec.Infrastructure
{
    public abstract class Utils
    {
        public static byte[] GetResources(string filename)
        {
            var embeddedFileProvider = new EmbeddedFileProvider(typeof(Utils).Assembly);
            var file = embeddedFileProvider.GetFileInfo($@"Resources\{filename}");
            byte[] fileByes = new byte[file.Length];
            using (var stream = file.CreateReadStream())
            {
                stream.Read(fileByes, 0, fileByes.Length);
            }
            return fileByes;
        }
    }
}
