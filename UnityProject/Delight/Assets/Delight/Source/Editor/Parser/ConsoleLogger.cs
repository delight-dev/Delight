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

        public static LogDelegate Log = Debug.Log; 
        public static LogDelegate LogError = Debug.LogError; 
        public static LogDelegate LogWarning = Debug.LogWarning;         
        public static ExceptionLogDelegate LogException = Debug.LogException;

        public static void LogParseError(string file, int line, string message)
        {
            Debug.LogException(new XmlParseError(message, String.Format("Delight:XmlError() (at {0}:{1})", file, line)));
        }
    }
}
