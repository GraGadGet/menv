using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using ConsoleAppFramework;

namespace GraGadGet.Menv
{
    /// <summary>
    /// menv command interface
    /// </summary>
    class Menv : ConsoleAppBase
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder().RunConsoleAppFrameworkAsync<Menv>(args);
        }

        [Command("plugin", "Display MAYA_PLUG_IN_PATH.")]
        public void PrintPluginsPath(string hoge = "", [Option("fmt", "Output format (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadPluginPath();

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        [Command("module", "Display MAYA_MODULE_PATH.")]
        public void PrintModulePath([Option("fmt", "Output format (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadModulePath();

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        [Command("script", "Display MAYA_SCRIPT_PATH.")]
        public void PrintScriptPath([Option("fmt", "Output format (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadScriptPath();

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        [Command("preset", "Display MAYA_PRESET_PATH.")]
        public void PrintPresetPath([Option("fmt", "Output format (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadPresetPath();

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        [Command("location", "Display MAYA_LOCATION.")]
        public void PrintLocationPath([Option("fmt", "Output format (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadLocationPath();

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        [Command("appdir", "Display MAYA_APP_DIR.")]
        public void PrintAppDirPath([Option("fmt", "Output format (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadAppDirPath();

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }
    }
}
