using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Runtime.InteropServices;

namespace GraGadGet.Menv
{

    public static class OutputFormatter
    {
        private static List<String> Split(string text, string spliter)
        {
            var elements = text.Split(spliter);
            return elements.ToList();
        }

        public static List<string> Format(string style, string pluginPath)
        {
            var spliter = ":";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                spliter = ";";
            }

            var elements = new List<string> { };
            if (style == OutputFormat.Plain.GetText())
            {
                elements = Split(pluginPath, spliter);
            }
            else if (style == OutputFormat.JSON.GetText())
            {
                var splited = Split(pluginPath, spliter);
                string jsonString = JsonSerializer.Serialize(splited);
                elements.Add(jsonString);
            }
            else
            {
                elements.Add(pluginPath);
            }

            return elements;
        }
    }
}
