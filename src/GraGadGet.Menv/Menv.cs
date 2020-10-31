using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Hosting;
using ConsoleAppFramework;

namespace GraGadGet.Menv
{
    class Menv : ConsoleAppBase
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder().RunConsoleAppFrameworkAsync<Menv>(args);
        }

        [Command("plugin", "Print MAYA_PLUG_IN_PATH.")]
        public void PrintPluginsPath()
        {
            string batchStdOut = string.Empty;
            string batchStdErr = string.Empty;
            int batchExitCode = 0;
            
            Environment.ReadPluginsPath(out batchStdOut, out batchStdErr, out batchExitCode);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //Console.WriteLine($"{batchStdErr}");
            } 
            else
            {
                Console.WriteLine($"{batchStdOut}");
            }
            Console.WriteLine($"{batchStdErr}");
            // Console.WriteLine($"[DEBUG] StdOut {batchStdOut}");
            // Console.WriteLine($"[DEBUG] StdErr {batchStdErr}");
            // Console.WriteLine($"[DEBUG] Status {batchExitCode}");            

            // TODO: Output style
            // Raw, Plain, JSON 
        }
    }
}
