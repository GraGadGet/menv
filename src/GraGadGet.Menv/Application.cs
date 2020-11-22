using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace GraGadGet.Menv
{
    /// <summary>
    ///
    /// </summary>
    public class MelProcess
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="mel"></param>
        /// <param name="version"></param>
        /// <param name="stdOut"></param>
        /// <param name="stdErr"></param>
        /// <param name="exitCode"></param>
        public static void Run(string mel, string version, out string stdOut, out string stdErr, out int exitCode)
        {
            stdOut = "";
            stdErr = "";
            exitCode = 0;

            try
            {
                using (Process process = new Process())
                {
                    process.StartInfo = MelProcess.Mel(mel, version);
                    process.Start();
                    process.WaitForExit();

                    stdOut = process.StandardOutput.ReadToEnd();
                    stdErr = process.StandardError.ReadToEnd();
                    exitCode = process.ExitCode;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Returns a ProcessStartInfo instance that has executable MEL on command line.
        /// </summary>
        /// <param name="mel"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        private static ProcessStartInfo Mel(string mel, string version)
        {
            var application = string.Empty;
            var command = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                application = Application.Batch(version);
                command = string.Format(@"-command ""{0}"" -noAutoloadPlugins", mel);
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                application = Application.Batch(version);
                command = string.Format(@"-command ""{0}"" -noAutoloadPlugins", mel);
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                application = Application.Batch(version);
                command = string.Format(@"-batch -command ""{0}"" -noAutoloadPlugins", mel);
            }
            // Console.WriteLine($"[DEBUG] {command}");

            var info = new ProcessStartInfo(application, command);
            info.RedirectStandardOutput = true;
            info.RedirectStandardError = true;
            info.CreateNoWindow = true;
            info.UseShellExecute = false;

            return info;
        }
    }

    /// <summary>
    ///
    /// </summary>
    public static class Application
    {
        /// <summary>
        /// Returns Maya batch program path.
        /// <see href="https://knowledge.autodesk.com/support/maya/learn-explore/caas/CloudHelp/cloudhelp/2020/ENU/Maya-GettingStarted/files/GUID-2E5D1D43-DC3D-4CB2-9A35-757598220F22-htm.html">Start Maya from the command line | Maya 2020 | Autodesk Knowledge Network</see>
        /// </summary>
        /// <returns></returns>
        public static string Batch(string version = null)
        {
            var path = string.Empty;

            if (version == null)
            {
                // TODO: Via current maya version config
                version = "2020";
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // e.g. "/Applications/Autodesk/maya2020/Maya.app/Contents/bin/mayabatch"
                var mayaVersion = $"maya{version}";
                path = Path.Join("/", "Applications", "Autodesk", mayaVersion, "Maya.app", "Contents", "bin", "mayabatch");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // e.g. "%PROGRAMFILES%\Autodesk\Maya2020\bin\mayabatch"
                var programFiles = System.Environment.GetEnvironmentVariable("PROGRAMFILES");
                var mayaVersion = $"Maya{version}";
                path = Path.Join(programFiles, "Autodesk", mayaVersion, "bin", "mayabatch");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // e.g. "/usr/local/bin/maya", "/usr/autodesk/maya2018/bin/"
                var mayaVersion = $"maya{version}";
                path = Path.Join("/", "usr", "autodesk", mayaVersion, "bin", "maya");
            }

            return path;
        }
    }
}