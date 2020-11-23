using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using ConsoleAppFramework;

namespace GraGadGet.Menv
{
    /// <summary>
    /// menv command interface.
    /// </summary>
    class Menv : ConsoleAppBase
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder().RunConsoleAppFrameworkAsync<Menv>(args);
        }

        /// <summary>
        /// Display MAYA_PLUG_IN_PATH value.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020, 2019, 2018)</param>
        /// <param name="format">Output format style (json or plain or raw)</param>
        [Command("plugin", "Display MAYA_PLUG_IN_PATH.")]
        public void PrintPluginsPath(
            [Option("v", "Maya version (e.g., 2020, 2019, 2018)")] string version,
            [Option("fmt", "Output format style (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadPluginPath(version);

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        /// <summary>
        /// Display MAYA_MODULE_PATH value.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020, 2019, 2018)</param>
        /// <param name="format">Output format style (json or plain or raw)</param>
        [Command("module", "Display MAYA_MODULE_PATH.")]
        public void PrintModulePath(
            [Option("v", "Maya version (e.g., 2020, 2019, 2018)")] string version,
            [Option("fmt", "Output format style (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadModulePath(version);

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        /// <summary>
        /// Display MAYA_SCRIPT_PATH value.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020, 2019, 2018)</param>
        /// <param name="format">Output format style (json or plain or raw)</param>
        [Command("script", "Display MAYA_SCRIPT_PATH.")]
        public void PrintScriptPath(
            [Option("v", "Maya version (e.g., 2020, 2019, 2018)")] string version,
            [Option("fmt", "Output format style (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadScriptPath(version);

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        /// <summary>
        /// Display MAYA_PRESET_PATH value.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020, 2019, 2018)</param>
        /// <param name="format">Output format style (json or plain or raw)</param>
        [Command("preset", "Display MAYA_PRESET_PATH.")]
        public void PrintPresetPath(
            [Option("v", "Maya version (e.g., 2020, 2019, 2018)")] string version,
            [Option("fmt", "Output format style (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadPresetPath(version);

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        /// <summary>
        /// Display MAYA_SHELF_PATH value.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020, 2019, 2018)</param>
        /// <param name="format">Output format style (json or plain or raw)</param>
        [Command("shelf", "Display MAYA_SHELF_PATH.")]
        private void PrintShelfPath(
            [Option("v", "Maya version (e.g., 2020, 2019, 2018)")] string version,
            [Option("fmt", "Output format style (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadShelfPath(version);

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        /// <summary>
        /// Display MAYA_LOCATION value.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020, 2019, 2018)</param>
        /// <param name="format">Output format style (json or plain or raw)</param>
        [Command("location", "Display MAYA_LOCATION.")]
        public void PrintLocationPath(
            [Option("v", "Maya version (e.g., 2020, 2019, 2018)")] string version,
            [Option("fmt", "Output format style (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadLocationPath(version);

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        /// <summary>
        /// Display MAYA_APP_DIR value.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020, 2019, 2018)</param>
        /// <param name="format">Output format style (json or plain or raw)</param>
        [Command("appdir", "Display MAYA_APP_DIR.")]
        public void PrintAppDirPath(
            [Option("v", "Maya version (e.g., 2020, 2019, 2018)")] string version,
            [Option("fmt", "Output format style (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadAppDirPath(version);

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        /// <summary>
        /// Display XBMLANGPATH value.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020, 2019, 2018)</param>
        /// <param name="format">Output format style (json or plain or raw)</param>
        [Command("xbmlang", "Display XBMLANGPATH.")]
        private void PrintXbmlangPath(
            [Option("v", "Maya version (e.g., 2020, 2019, 2018)")] string version,
            [Option("fmt", "Output format style (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadXbmlangPath(version);

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        } 

        /// <summary>
        /// Display PYTHONPATH value.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020, 2019, 2018)</param>
        /// <param name="format">Output format style (json or plain or raw)</param>
        [Command("python", "Display PYTHONPATH.")]
        private void PrintPythonPath(
            [Option("v", "Maya version (e.g., 2020, 2019, 2018)")] string version,
            [Option("fmt", "Output format style (json or plain or raw)")] string format = "json")
        {
            var result = Environment.ReadPythonPath(version);

            List<string> elements = OutputFormatter.Format(format, result);
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }        
    }
}
