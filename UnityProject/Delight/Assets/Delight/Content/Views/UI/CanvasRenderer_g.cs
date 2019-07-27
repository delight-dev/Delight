// Internal view logic generated from "CanvasRenderer.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class CanvasRendererView : UIView
    {
        #region Constructors

        public CanvasRendererView(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? CanvasRendererViewTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public CanvasRendererView() : this(null)
        {
        }

        static CanvasRendererView()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(CanvasRendererViewTemplates.Default, dependencyProperties);

            dependencyProperties.Add(CanvasRendererComponentProperty);
            dependencyProperties.Add(HasPopInstructionProperty);
            dependencyProperties.Add(MaterialCountProperty);
            dependencyProperties.Add(PopMaterialCountProperty);
            dependencyProperties.Add(CullTransparentMeshProperty);
            dependencyProperties.Add(CullProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<UnityEngine.CanvasRenderer> CanvasRendererComponentProperty = new DependencyProperty<UnityEngine.CanvasRenderer>("CanvasRendererComponent");
        public UnityEngine.CanvasRenderer CanvasRendererComponent
        {
            get { return CanvasRendererComponentProperty.GetValue(this); }
            set { CanvasRendererComponentProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.CanvasRenderer, CanvasRendererView> HasPopInstructionProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.CanvasRenderer, CanvasRendererView>("HasPopInstruction", x => x.CanvasRendererComponent, x => x.hasPopInstruction, (x, y) => x.hasPopInstruction = y);
        public System.Boolean HasPopInstruction
        {
            get { return HasPopInstructionProperty.GetValue(this); }
            set { HasPopInstructionProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.CanvasRenderer, CanvasRendererView> MaterialCountProperty = new MappedDependencyProperty<System.Int32, UnityEngine.CanvasRenderer, CanvasRendererView>("MaterialCount", x => x.CanvasRendererComponent, x => x.materialCount, (x, y) => x.materialCount = y);
        public System.Int32 MaterialCount
        {
            get { return MaterialCountProperty.GetValue(this); }
            set { MaterialCountProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Int32, UnityEngine.CanvasRenderer, CanvasRendererView> PopMaterialCountProperty = new MappedDependencyProperty<System.Int32, UnityEngine.CanvasRenderer, CanvasRendererView>("PopMaterialCount", x => x.CanvasRendererComponent, x => x.popMaterialCount, (x, y) => x.popMaterialCount = y);
        public System.Int32 PopMaterialCount
        {
            get { return PopMaterialCountProperty.GetValue(this); }
            set { PopMaterialCountProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.CanvasRenderer, CanvasRendererView> CullTransparentMeshProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.CanvasRenderer, CanvasRendererView>("CullTransparentMesh", x => x.CanvasRendererComponent, x => x.cullTransparentMesh, (x, y) => x.cullTransparentMesh = y);
        public System.Boolean CullTransparentMesh
        {
            get { return CullTransparentMeshProperty.GetValue(this); }
            set { CullTransparentMeshProperty.SetValue(this, value); }
        }

        public readonly static MappedDependencyProperty<System.Boolean, UnityEngine.CanvasRenderer, CanvasRendererView> CullProperty = new MappedDependencyProperty<System.Boolean, UnityEngine.CanvasRenderer, CanvasRendererView>("Cull", x => x.CanvasRendererComponent, x => x.cull, (x, y) => x.cull = y);
        public System.Boolean Cull
        {
            get { return CullProperty.GetValue(this); }
            set { CullProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class CanvasRendererViewTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return CanvasRendererView;
            }
        }

        private static Template _canvasRendererView;
        public static Template CanvasRendererView
        {
            get
            {
#if UNITY_EDITOR
                if (_canvasRendererView == null || _canvasRendererView.CurrentVersion != Template.Version)
#else
                if (_canvasRendererView == null)
#endif
                {
                    _canvasRendererView = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _canvasRendererView.Name = "CanvasRendererView";
#endif
                }
                return _canvasRendererView;
            }
        }

        #endregion
    }

    #endregion
}
