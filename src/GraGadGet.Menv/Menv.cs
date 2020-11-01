using System;
using System.Threading.Tasks;
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

        [Command("plugin", "Display MAYA_PLUG_IN_PATH.")]
        public void PrintPluginsPath()
        {            
            var result = Environment.ReadPluginPath();

            // TODO: Output style
            // Raw, Plain, JSON 

            Console.WriteLine($"{result}");    
        }

        [Command("module", "Display MAYA_MODULE_PATH.")]
        public void PrintModulePath()
        {
            var result = Environment.ReadModulePath();

            // TODO: Output style
            // Raw, Plain, JSON 

            Console.WriteLine($"{result}");
        }

        [Command("script", "Display MAYA_SCRIPT_PATH.")]
        public void PrintScriptPath()
        {
            var result = Environment.ReadScriptPath();

            // TODO: Output style
            // Raw, Plain, JSON 

            Console.WriteLine($"{result}");
        }

        [Command("preset", "Display MAYA_PRESET_PATH.")]
        public void PrintPresetPath()
        {
            var result = Environment.ReadPresetPath();

            // TODO: Output style
            // Raw, Plain, JSON 

            Console.WriteLine($"{result}");
        }

        [Command("location", "Display MAYA_LOCATION.")]
        public void PrintLocationPath()
        {
            var result = Environment.ReadLocationPath();

            // TODO: Output style
            // Raw, Plain, JSON 

            Console.WriteLine($"{result}");
        }

        [Command("appdir", "Display MAYA_APP_DIR.")]
        public void PrintAppDirPath()
        {
            var result = Environment.ReadAppDirPath();

            // TODO: Output style
            // Raw, Plain, JSON 

            Console.WriteLine($"{result}");
        }
    }
}
