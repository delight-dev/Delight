#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class UIImageView : UIView
    {
        #region Methods

        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            if (IsBackgroundVisible())
            {
                Image = GameObject.AddComponent<UnityEngine.UI.Image>();
            }
        }

        public bool IsBackgroundVisible()
        {
            return true;
            // TODO implement checking if background sprite is visible, we might want to do this every time
            // a property changing the background visibility is changed, and dynamically add the component if needed
        }

        #endregion
    }
}
