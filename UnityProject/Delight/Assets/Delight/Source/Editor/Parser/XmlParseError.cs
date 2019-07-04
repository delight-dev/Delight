// add module "ConsolePro" to Config.txt to enable ConsolePro integration, which means XML errors show up in the console
// and double-clicking on the entry takes you to the line in the XML file

#region Using Statements
using System;
#if DELIGHT_MODULE_CONSOLEPRO
using FlyingWormConsole3;
#endif
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Makes sure stacktrace points to XML file. 
    /// </summary>
    public class XmlParseError : Exception
    {
        public XmlParseError(string message, string stackTrace) : base(message)
        {
            _stackTrace = stackTrace;
        }
        string _stackTrace = string.Empty;
        public override string StackTrace => _stackTrace;
    }
}
