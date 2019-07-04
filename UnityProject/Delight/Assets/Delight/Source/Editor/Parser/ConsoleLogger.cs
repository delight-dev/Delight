// add module "ConsolePro" to Config.txt to enable ConsolePro integration, which means XML errors show up in the console
// and double-clicking on the entry takes you to the line in the XML file

#region Using Statements
using Delight.Editor.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Globalization;
using System.IO;
#if DELIGHT_MODULE_CONSOLEPRO
using FlyingWormConsole3;
#endif
#endregion

namespace Delight.Editor
{

    /// <summary>
    /// Logs error messages.
    /// </summary>
    public static class ConsoleLogger
    {
        public delegate void LogDelegate(object message);
        public delegate void ExceptionLogDelegate(Exception e);

#if !DELIGHT_MODULE_CONSOLEPRO
        public static LogDelegate Log = Debug.Log; 
        public static LogDelegate LogError = Debug.LogError; 
        public static LogDelegate LogWarning = Debug.LogWarning; 
        
        public static ExceptionLogDelegate LogException = Debug.LogException;
        public static void UpdateEntries()
        {
        }

        public static void LogParseError(string file, int line, string message)
        {
            Debug.LogException(new XmlParseError(message, String.Format("Delight:XmlError() (at {0}:{1})", file, line)));
        }
#else
        public static Dictionary<string, List<ConsoleProEntry>> _entries = new Dictionary<string, List<ConsoleProEntry>>();

        public static void Log(string message)
        {
            string str1 = message.StartsWith("#Delight# ") ? message.Substring("#Delight# ".Length) : message;
            Debug.Log("#Delight# " + str1);
        }

        public static void LogWarning(string message)
        {
            string str1 = message.StartsWith("#Delight# ") ? message.Substring("#Delight# ".Length) : message;
            Debug.LogWarning("#Delight# " + str1);
        }

        public static void LogError(string message)
        {
            string str1 = message.StartsWith("#Delight# ") ? message.Substring("#Delight# ".Length) : message;
            Debug.LogError("#Delight# " + str1);
        }

        public static void LogException(Exception e)
        {
            Debug.Log("#Delight# " + e.ToString());
        }

        public static void LogParseError(string file, int line, string message)
        {
            string str1 = message.StartsWith("#Delight# ") ? message.Substring("#Delight# ".Length) : message;
            var lineStr = line.ToString();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("[ConsolePro]" + str1);
            sb.AppendLine(String.Format("Delight:XmlError() (at {0}:{1})", file, line));
            sb.AppendLine(filename);
            sb.AppendLine(lineStr);

            Debug.Log(sb.ToString());
        }

        public static void UpdateEntries()
        {
            var sb = new StringBuilder();
            for (int i = ConsoleProLogs.instance.proEntries.Count - 1; i >= 0; --i)
            {
                // update entries
                var entry = ConsoleProLogs.instance.proEntries[i];
                if (entry.logText.StartsWith("[ConsolePro]"))
                {
                    using (var stringReader = new StringReader(entry.logText.Substring("[ConsolePro]".Length)))
                    {
                        string message = stringReader.ReadLine();
                        string stackTrace = stringReader.ReadLine();
                        string filename = stringReader.ReadLine();
                        string lineStr = stringReader.ReadLine();
                        int line = System.Convert.ToInt32(lineStr, CultureInfo.InvariantCulture);
                        sb.AppendLine("#Delight# " + message);
                        sb.AppendLine(stackTrace);
                        sb.AppendLine(stackTrace); // ConsolePro seems to ignore first line in stack-trace so we add it twice
                        ConsoleProLogs.instance.proEntries.RemoveAt(i);
                        ConsoleProLogs.instance.AddEntry(String.Empty, sb.ToString(), ConsoleLogType.Error, 0, 0, 0, null, line, 0);
                        sb.Clear();
                    }
                }
            }
        }
#endif
    }
}
