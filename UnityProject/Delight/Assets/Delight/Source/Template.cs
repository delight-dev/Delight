#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
#endregion

namespace Delight
{
    /// <summary>
    /// View data template.
    /// </summary>
    public class Template
    {
        #region Fields

        public Template BasedOn;

#if UNITY_EDITOR
        public string Name; 
        public static int Version = 0;
        public int CurrentVersion;
#endif

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Template(Template basedOn)
        {
            BasedOn = basedOn;
#if UNITY_EDITOR
            CurrentVersion = Version;
#endif
        }

        #endregion
    }
}
