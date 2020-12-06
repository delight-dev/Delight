#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Demonstrates how UI can adapt to screen size and orientation.
    /// </summary>
    public partial class ResponsiveUIExample
    {
        public override void Update()
        {
            base.Update();
            // check landscape
        }

        public override void AfterInitialize()
        {
            base.AfterInitialize();
        }

        protected override void AfterLoad()
        {
            base.AfterLoad();
        }

        protected override void AfterUnload()
        {
            base.AfterUnload();
        }

        public void RegisterConstraints()
        {
            //foreach (var propertyConstraint in PropertyConstraints)
            //{
            //    LayoutRoot?.RegisterUpdateable(propertyConstraint);
            //}
        }
    }

    public class PropertyConstraint<T> : IUpdateable
    {
        public void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
