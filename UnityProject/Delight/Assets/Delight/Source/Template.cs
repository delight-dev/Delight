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
    /// View data template. A data template is associated with a view type and allows for the framework to keep track of an hierarchy of default values. It allows for values in dependenc properties to be stored per type rather than instance.
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
