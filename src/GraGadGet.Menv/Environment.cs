using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;

namespace GraGadGet.Menv
{
    /// <summary>
    /// Provide values for Maya environment variables.
    /// </summary>
    public static class Environment
    {
        /// <summary>
        /// Read value of MAYA_PLUG_IN_PATH.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020)</param>
        /// <returns></returns>
        public static string ReadPluginPath(string version)
        {
            var mel = @"print(getenv(""""MAYA_PLUG_IN_PATH""""))";
            return ExecuteMel(mel, version);
        }

        /// <summary>
        /// Read value of MAYA_MODULE_PATH.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020)</param>
        /// <returns></returns>
        public static string ReadModulePath(string version)
        {
            var mel = @"print(getenv(""""MAYA_MODULE_PATH""""))";
            return ExecuteMel(mel, version);
        }

        /// <summary>
        /// Read value of MAYA_SCRIPT_PATH.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020)</param>
        /// <returns></returns>
        public static string ReadScriptPath(string version)
        {
            var mel = @"print(getenv(""""MAYA_SCRIPT_PATH""""))";
            return ExecuteMel(mel, version);
        }

        /// <summary>
        /// Read value of MAYA_PRESET_PATH.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020)</param>
        /// <returns></returns>
        public static string ReadPresetPath(string version)
        {
            var mel = @"print(getenv(""""MAYA_PRESET_PATH""""))";
            return ExecuteMel(mel, version);
        }

        /// <summary>
        /// Read value of MAYA_LOCATION.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020)</param>
        /// <returns></returns>
        public static string ReadLocationPath(string version)
        {
            var mel = @"print(getenv(""""MAYA_LOCATION""""))";
            return ExecuteMel(mel, version);
        }

        /// <summary>
        /// Read value of MAYA_APP_DIR.
        /// </summary>
        /// <param name="version">Maya version (e.g., 2020)</param>
        /// <returns></returns>
        public static string ReadAppDirPath(string version)
        {
            var mel = @"print(getenv(""""MAYA_APP_DIR""""))";
            return ExecuteMel(mel, version);
        }

        /// <summary>
        /// Execute the MEL command.
        /// </summary>
        /// <param name="mel"></param>
        /// <param name="version">Maya version (e.g., 2020)</param>
        /// <returns></returns>
        private static string ExecuteMel(string mel, string version)
        {
            try
            {
                var stdOut = string.Empty;
                var stdErr = string.Empty;
                var exitCode = 0;

                MelProcess.Run(mel, version, out stdOut, out stdErr, out exitCode);

                var result = string.Empty;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    result = stdErr;
                }
                else
                {
                    result = stdOut;
                }

                // Cutting RETURN CODE on first line.
                var lines = new List<string> { };
                using (StringReader reader = new StringReader(result))
                {
                    while (reader.Peek() > -1)
                    {
                        var line = reader.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            lines.Add(line);
                        }
                    }
                }

                // Cutting "Result: untitled" text.
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    return lines.LastOrDefault();
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.ToString()}");
                return "";
            }
        }
    }
}