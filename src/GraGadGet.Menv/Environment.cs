using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GraGadGet.Menv
{
    public static class Environment
    {
        public static string ReadPluginPath()
        {
            var mel = @"print(getenv(""""MAYA_PLUG_IN_PATH""""))";
            return ExecuteMel(mel);
        }

        public static string ReadModulePath()
        {
            var mel = @"print(getenv(""""MAYA_MODULE_PATH""""))";
            return ExecuteMel(mel);
        }

        public static string ReadScriptPath()
        {
            var mel = @"print(getenv(""""MAYA_SCRIPT_PATH""""))";
            return ExecuteMel(mel);
        }

        public static string ReadPresetPath()
        {
            var mel = @"print(getenv(""""MAYA_PRESET_PATH""""))";
            return ExecuteMel(mel);
        }

        public static string ReadLocationPath()
        {
            var mel = @"print(getenv(""""MAYA_LOCATION""""))";
            return ExecuteMel(mel);
        }

        public static string ReadAppDirPath()
        {
            var mel = @"print(getenv(""""MAYA_APP_DIR""""))";
            return ExecuteMel(mel);
        }

        private static string ExecuteMel(string mel)
        {
            try
            {
                var stdOut = "";
                var stdErr = "";
                var exitCode = 0;

                MelProcess.Run(mel, out stdOut, out stdErr, out exitCode);
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    return stdErr;
                }
                else
                {
                    return stdOut;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.ToString()}");
                return "";
            }
        }
    }
}