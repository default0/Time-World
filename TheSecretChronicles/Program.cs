using OpenTK;
using osu.Framework.Desktop;
using osu.Framework.Platform;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSecretChronicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var host = Host.GetSuitableHost("The Secret Chronicles"))
            {
                host.Window.Cursor = MouseCursor.Default;
                host.Window.CursorVisible = true;

                //var file = Process.GetCurrentProcess().MainModule.FileName;
                //Environment.CurrentDirectory = Path.GetDirectoryName(file);
                host.Run(new TheSecretChroniclesGame());
            }
        }
    }
}
