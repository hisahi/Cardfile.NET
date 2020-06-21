using MimeTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardfileDotNet.Util
{
    public static class MimeTypeDetector
    {
        public static string DetectMime(string fileName)
        {
            return MimeTypeMap.GetMimeType(Path.GetExtension(fileName));
        }
    }
}
