#region Using Statements
using System;
using UnityEngine.UI;
#endregion

namespace Delight
{
    /// <summary>
    /// Non-drawing graphic to provide raycast target without drawing anything.
    /// </summary>
    public class RaycastTargetGraphic : Graphic
    {
        public override void SetMaterialDirty() { return; }
        public override void SetVerticesDirty() { return; }

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
            return;
        }
    }
}
