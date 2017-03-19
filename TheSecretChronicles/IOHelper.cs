using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecretChronicles
{
    public static class IOHelper
    {
        public static void WriteTextFile(string path, string content)
        {
            ensurePath(Path.GetDirectoryName(path));
            File.WriteAllText(path, content);
        }

        public static string[] GetFiles(string path)
        {
            ensurePath(path);
            return Directory.GetFiles(path);
        }

        private static void ensurePath(string path)
        {
            var index = 0;
            while(true)
            {
                var nextSeparator = path.IndexOfAny(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, index);
                string curSubPath;
                if (nextSeparator == -1)
                {
                    curSubPath = path;
                }
                else
                {
                    curSubPath = path.Substring(0, nextSeparator);
                }

                if(!Directory.Exists(curSubPath))
                {
                    Directory.CreateDirectory(curSubPath);
                }
                if (nextSeparator == -1)
                {
                    break;
                }
            }
        }
    }
}
