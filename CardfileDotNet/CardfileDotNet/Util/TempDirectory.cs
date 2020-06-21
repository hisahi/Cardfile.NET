using System;
using System.IO;
using System.Windows.Forms;

namespace CardfileDotNet.Util
{
    public class TempDirectory : IDisposable
    {
        private string path;
        private bool created = false;

        public TempDirectory(string header)
        {
            path = FindFreeTempDir(header + "_");
        }

        private string FindFreeTempDir(string header)
        {
            string root = System.IO.Path.GetTempPath(), dir;
            do
            {
                dir = System.IO.Path.Combine(root, header + System.IO.Path.GetRandomFileName());
            } while (Directory.Exists(dir));
            return dir;
        }

        public void Close()
        {
            if (created)
            {
                try
                {
                    Directory.Delete(path, true);
                }
                catch { }
            }
        }

        public void Dispose()
        {
            Close();
        }

        private void MaybeCreate()
        {
            if (!created)
            {
                Directory.CreateDirectory(path);
                created = true;
            }
        }

        public string Path
        {
            get
            {
                MaybeCreate();
                return path;
            }
        }

        public void Create(string fpath)
        {
            MaybeCreate();
            File.Create(fpath).Close();
        }

        public void Create(string fpath, byte[] data)
        {
            MaybeCreate();
            using (FileStream fs = File.Create(fpath))
                fs.Write(data, 0, data.Length);
        }
    }
}