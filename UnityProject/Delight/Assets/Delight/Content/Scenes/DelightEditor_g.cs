// Internal view logic generated from "DelightEditor.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class DelightEditor : UIView
    {
        #region Constructors

        public DelightEditor(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? DelightEditorTemplates.Default, initializer)
        {
            this.AfterInitializeInternal();
        }

        public DelightEditor() : this(null)
        {
        }

        static DelightEditor()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(DelightEditorTemplates.Default, dependencyProperties);
        }

        #endregion

        #region Properties

        #endregion
    }

    #region Data Templates

    public static class DelightEditorTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return DelightEditor;
            }
        }

        private static Template _delightEditor;
        public static Template DelightEditor
        {
            get
            {
#if UNITY_EDITOR
                if (_delightEditor == null || _delightEditor.CurrentVersion != Template.Version)
#else
                if (_delightEditor == null)
#endif
                {
                    _delightEditor = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _delightEditor.Name = "DelightEditor";
#endif
                }
                return _delightEditor;
            }
        }

        #endregion
    }

    #endregion
}
