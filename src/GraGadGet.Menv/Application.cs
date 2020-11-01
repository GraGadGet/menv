using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace GraGadGet.Menv
{
    /// <summary>
    /// Terminal
    /// </summary>
    public static class Terminal
    {
        /// <summary>
        /// Returns bash path on macOS.
        /// </summary>
        public static string Bash
        {
            get
            {
                return "/bin/bash";
            }
        }
    }

    public static class ProcessStartInfoFactory
    {
        /// <summary>
        /// Returns a ProcessStartInfo instance that has executable MEL on command line.
        /// </summary>
        /// <param name="mel"></param>
        /// <returns></returns>
        public static ProcessStartInfo Mel(string mel)
        {
            var application = string.Empty;
            var command = string.Empty;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                application = Application.Batch();
                command = string.Format(@"-command ""{0}"" -noAutoloadPlugins", mel);
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                application = Application.Batch();
                command = string.Format(@"-command ""{0}"" -noAutoloadPlugins", mel);
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                throw new NotImplementedException();
            }
            // Console.WriteLine($"[DEBUG] {command}");

            return new ProcessStartInfo(application, command);
        }
    }

    public static class Application
    {
        /// <summary>
        /// Returns Maya batch program path.
        /// </summary>
        /// <returns></returns>
        public static string Batch()
        {
            var path = string.Empty;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // "/Applications/Autodesk/maya2020/Maya.app/Contents/bin/mayabatch"
                path = "/Applications/Autodesk/maya2020/Maya.app/Contents/bin/mayabatch";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                // "%PROGRAMFILES%\Autodesk\Maya2020\bin\mayabatch"
                var programFiles = System.Environment.GetEnvironmentVariable("PROGRAMFILES");
                path = Path.Join(programFiles, "Autodesk", "Maya2020", "bin", "mayabatch");
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                path = "";
            }

            return path;
        }
    }
}