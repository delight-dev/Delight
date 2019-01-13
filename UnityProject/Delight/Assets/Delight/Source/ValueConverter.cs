#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
#endregion

namespace Delight
{
    /// <summary>
    /// Base class for value converters.
    /// </summary
    public class ValueConverter
    {
        public virtual string GetInitializer(string stringValue)
        {
            return null;
        }
    }

    /// <summary>
    /// Generic base class for value converters.
    /// </summary>
    public class ValueConverter<T> : ValueConverter
    {
        #region Fields

        public static readonly ValueConverter<T> Empty = new ValueConverter<T>();
                    
        #endregion

        #region Methods

        /// <summary>
        /// Converts value from string.
        /// </summary>
        public virtual T Convert(string stringValue)
        {
            return default(T);
        }

        /// <summary>
        /// Converts value from object.
        /// </summary>
        public virtual T Convert(object objectValue)
        {
            return default(T);
        }

        #endregion

        #region Constructor
        #endregion
    }
}
