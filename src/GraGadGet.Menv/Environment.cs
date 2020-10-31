using System;
using System.Diagnostics;

namespace GraGadGet.Menv
{
    public static class Environment
    {
        public static int ReadPluginsPath(out string stdOut, out string stdErr, out int exitCode)
        {
            // Windows 
            // "%PROGRAMFILES%\Autodesk\Maya2020\bin\mayabatch" -batch -command "print(getenv(\"MAYA_PLUG_IN_PATH\"))" -noAutoloadPlugins
            // "/c \"%PROGRAMFILES%\\Autodesk\\Maya2020\\bin\\mayabatch\" -batch -command 'print(getenv(\\\"MAYA_PLUG_IN_PATH\\\"))' -noAutoloadPlugins" 
            //
            // macOS
            // /bin/bash -c '/Applications/Autodesk/maya2020/Maya.app/Contents/bin/mayabatch -command "print(getenv(\"MAYA_PLUG_IN_PATH\"))" -noAutoloadPlugins';            
            // var application = "/bin/bash";
            // var command = $"-c \"/Applications/Autodesk/maya2020/Maya.app/Contents/bin/mayabatch -command {mel}\"";

            stdOut = "";
            stdErr = "";
            exitCode = 0;

            // var mel = "'print(getenv(\\\"MAYA_PLUG_IN_PATH\\\"))' -noAutoloadPlugins";
            var mel = @"print(getenv(""""MAYA_PLUG_IN_PATH""""))";

            try
            {
                ProcessStartInfo processStartInfo = ProcessStartInfoFactory.Mel(mel);               
                processStartInfo.RedirectStandardOutput = true;
                processStartInfo.RedirectStandardError = true;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.UseShellExecute = false;

                Process process = new Process();
                process = Process.Start(processStartInfo);
                process.WaitForExit();

                stdOut = process.StandardOutput.ReadToEnd();
                stdErr = process.StandardError.ReadToEnd();
                exitCode = process.ExitCode;

                process.Close();

                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] {ex.ToString()}");
                return -1;
            }
        }
    }
}