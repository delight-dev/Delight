#region Using Statements
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

namespace Delight
{
    /// <summary>
    /// Type value converter.
    /// </summary>
    public class TypeValueConverter : ValueConverter<Type>
    {
        public override string GetInitializer(string stringValue)
        {
            return Type.GetType(stringValue).Name;
        }

        public override Type Convert(string stringValue)
        {
            return Type.GetType(stringValue);            
        }
    }
}