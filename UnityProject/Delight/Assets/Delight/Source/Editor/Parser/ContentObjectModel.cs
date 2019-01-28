#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using Delight.Editor;
using UnityEngine;
using System.Xml.Serialization;
using ProtoBuf;
#endregion

namespace Delight.Parser
{
    /// <summary>
    /// Contains information about all content objects in the project.
    /// </summary>
    [ProtoContract] 
    public class ContentObjectModel
    {
        #region Fields

        [ProtoMember(1, AsReference = true)]
        public List<ViewObject> ViewObjects;

        [ProtoMember(2, AsReference = true)]
        public List<ModelObject> ModelObjects;

        [ProtoMember(3, AsReference = true)]
        public List<ThemeObject> ThemeObjects;

        private Dictionary<string, ViewObject> _viewObjects;
        private Dictionary<string, ModelObject> _modelObjects;
        private Dictionary<string, ThemeObject> _themeObjects;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ContentObjectModel()
        {
            ViewObjects = new List<ViewObject>();
            ModelObjects = new List<ModelObject>();
            ThemeObjects = new List<ThemeObject>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets view object.
        /// </summary>
        public ViewObject GetViewObject(string viewName)
        {
            if (_viewObjects == null)
            {
                _viewObjects = new Dictionary<string, ViewObject>();
                foreach (var item in ViewObjects)
                {
                    _viewObjects.Add(item.Name, item);
                }
            }

            ViewObject viewObject;
            if (_viewObjects.TryGetValue(viewName, out viewObject))
            {
                return viewObject;
            }

            // create new view object if it doesn't exist
            viewObject = new ViewObject { Name = viewName, TypeName = viewName };
            ViewObjects.Add(viewObject);
            _viewObjects.Add(viewName, viewObject);
            return viewObject;
        }

        /// <summary>
        /// Gets model object.
        /// </summary>
        public ModelObject GetModelObject(string modelName)
        {
            if (_modelObjects == null)
            {
                _modelObjects = new Dictionary<string, ModelObject>();
                foreach (var item in ModelObjects)
                {
                    _modelObjects.Add(item.Name, item);
                }
            }

            ModelObject modelObject;
            if (_modelObjects.TryGetValue(modelName, out modelObject))
            {
                return modelObject;
            }

            // create new model object if it doesn't exist
            modelObject = new ModelObject { Name = modelName };
            ModelObjects.Add(modelObject);
            _modelObjects.Add(modelName, modelObject);
            return modelObject;
        }

        /// <summary>
        /// Gets theme object.
        /// </summary>
        public ThemeObject GetThemeObject(string themeName)
        {
            if (_themeObjects == null)
            {
                _themeObjects = new Dictionary<string, ThemeObject>();
                foreach (var item in ThemeObjects)
                {
                    _themeObjects.Add(item.Name, item);
                }
            }

            ThemeObject themeObject;
            if (_themeObjects.TryGetValue(themeName, out themeObject))
            {
                return themeObject;
            }

            // create new theme object if it doesn't exist
            themeObject = new ThemeObject { Name = themeName };
            ThemeObjects.Add(themeObject);
            _themeObjects.Add(themeName, themeObject);
            return themeObject;
        }

        #endregion
    }

    #region View Object

    [ProtoContract]
    public class ViewObject
    {
        [ProtoMember(1)]
        public string Name;

        [ProtoMember(2)]
        public string TypeName;

        [ProtoMember(3)]
        public string Namespace;

        [ProtoMember(4)]
        public string FilePath;

        [ProtoMember(5, AsReference = true)]
        public ViewObject BasedOn;

        [ProtoMember(6)]
        public bool NeedUpdate;

        [ProtoMember(7)]
        public List<PropertyExpression> PropertyExpressions;

        [ProtoMember(8)]
        public List<ViewDeclaration> ViewDeclarations;

        [ProtoMember(9)]
        public bool HasContentTemplate;

        public List<MappedPropertyDeclaration> MappedPropertyDeclarations;
        public bool HasUpdatedItsMappedProperties;

        public ViewObject()
        {
            PropertyExpressions = new List<PropertyExpression>();
            ViewDeclarations = new List<ViewDeclaration>();
            MappedPropertyDeclarations = new List<MappedPropertyDeclaration>();
        }

        public void Clear()
        {
            Name = null;
            Namespace = null;
            TypeName = null;
            FilePath = null;
            BasedOn = null;
            NeedUpdate = false;
            PropertyExpressions.Clear();
            ViewDeclarations.Clear();
        }

        public List<ViewDeclarationInfo> GetViewDeclarations(bool includeInheritedDeclarations)
        {
            // gets all view declarations in the view
            var viewDeclarations = new List<ViewDeclarationInfo>();
            if (includeInheritedDeclarations && BasedOn != null)
            {
                foreach (var declaration in BasedOn.GetViewDeclarations(true))
                {
                    declaration.IsInherited = true;
                    viewDeclarations.Add(declaration);
                }
            }

            foreach (var viewDeclaration in ViewDeclarations)
            {
                viewDeclarations.AddRange(GetViewDeclarations(viewDeclaration));
            }
            
            return viewDeclarations;
        }

        private List<ViewDeclarationInfo> GetViewDeclarations(ViewDeclaration viewDeclaration)
        {
            var viewDeclarations = new List<ViewDeclarationInfo>();
            viewDeclarations.Add(new ViewDeclarationInfo { Declaration = viewDeclaration });
            
            foreach (var childDeclaration in viewDeclaration.ChildDeclarations)
            {
                viewDeclarations.AddRange(GetViewDeclarations(childDeclaration));
            }

            return viewDeclarations;
        }
    }

    public class PropertyDeclarationInfo
    {
        public PropertyDeclaration Declaration;
        public bool IsInherited;
        public bool IsMapped;
        public string TargetObjectName;
        public string TargetPropertyName;

        public string FullTargetPropertyPath
        {
            get
            {                
                return IsMapped ? String.Format("{0}.{1}", TargetObjectName, TargetPropertyName) : 
                    Declaration.PropertyName;
            }
        }
    }

    public class ViewDeclarationInfo
    {
        public ViewDeclaration Declaration;
        public bool IsInherited;
    }

    /// <summary>
    /// Base class for property expressions.
    /// </summary>
    [ProtoContract]
    [ProtoInclude(1, typeof(PropertyDeclaration))]
    [ProtoInclude(2, typeof(PropertyAssignment))]
    [ProtoInclude(3, typeof(PropertyBinding))]
    [ProtoInclude(4, typeof(PropertyMapping))]
    [ProtoInclude(5, typeof(PropertyRename))]
    [ProtoInclude(6, typeof(InitializerProperty))]
    public class PropertyExpression
    {
        [ProtoMember(101)]
        public int LineNumber;
    }

    /// <summary>
    /// Stores information about a dependency property declaration.
    /// </summary>
    [ProtoContract]
    public class PropertyDeclaration : PropertyExpression
    {
        [ProtoMember(1)]
        public string PropertyName;

        [ProtoMember(2)]
        public string PropertyTypeName;

        [ProtoMember(4)]
        public string AssemblyQualifiedType;

        [ProtoMember(6)]
        public string PropertyTypeFullName;

        [ProtoMember(8)]
        public PropertyDeclarationType DeclarationType;
    }

    /// <summary>
    /// Stores information about a dependency property declaration.
    /// </summary>
    public class MappedPropertyDeclaration
    {
        public bool IsViewReference;
        public string TargetPropertyName;
        public string TargetPropertyTypeFullName;
        public string TargetObjectName;
        public string TargetObjectType;
        public string PropertyName;      
        
        public string FullTargetPropertyPath
        {
            get
            {
                return String.Format("{0}.{1}", TargetObjectName, TargetPropertyName);
            }
        }  
    }

    /// <summary>
    /// Stores information about a mapped view.
    /// </summary>
    [ProtoContract]
    public class PropertyMapping : PropertyExpression
    {
        [ProtoMember(1)]
        public string TargetObjectName;

        [ProtoMember(2)]
        public string MapPattern;
    }

    /// <summary>
    /// Stores information about a renamed property.
    /// </summary>
    [ProtoContract]
    public class PropertyRename : PropertyExpression
    {
        [ProtoMember(1)]
        public string TargetPropertyName;

        [ProtoMember(2)]
        public string NewPropertyName;
    }


    /// <summary>
    /// Stores information about a initializer property.
    /// </summary>
    [ProtoContract]
    public class InitializerProperty : PropertyExpression
    {
        [ProtoMember(1)]
        public string PropertyName;

        [ProtoMember(2)]
        public List<string> Properties;
    }

    /// <summary>
    /// Stores information about a property assignment.
    /// </summary>
    [ProtoContract]
    public class PropertyAssignment : PropertyExpression
    {
        [ProtoMember(1)]
        public string PropertyName;

        [ProtoMember(2)]
        public string PropertyValue;

        public PropertyDeclarationInfo PropertyDeclarationInfo;
    }

    /// <summary>
    /// Stores information about a property binding.
    /// </summary>
    [ProtoContract]
    public class PropertyBinding : PropertyExpression
    {
        [ProtoMember(1)]
        public string PropertyName;

        [ProtoMember(2)]
        public string PropertyBindingString;

        [ProtoMember(3)]
        public BindingType BindingType;

        [ProtoMember(4)]
        public string TransformMethod;

        [ProtoMember(5)]
        public List<PropertyBindingSource> Sources = new List<PropertyBindingSource>();

        [ProtoMember(6)]
        public string FormatString;

        [ProtoMember(7)]
        public string ItemId;
    }

    /// <summary>
    /// Stores information about a property binding source.
    /// </summary>
    [ProtoContract]
    public class PropertyBindingSource
    {
        [ProtoMember(1)]
        public string BindingPath;

        [ProtoMember(2)]
        public BindingSourceTypes SourceTypes;
    }

    /// <summary>
    /// Stores information about a view declaration.
    /// </summary>
    [ProtoContract]
    public class ViewDeclaration
    {
        [ProtoMember(1)]
        public string ViewName;

        [ProtoMember(2)]
        public string Id;

        [ProtoMember(3)]
        public List<PropertyAssignment> PropertyAssignments;

        [ProtoMember(4)]
        public List<PropertyBinding> PropertyBindings;

        [ProtoMember(5)]
        public List<ViewDeclaration> ChildDeclarations;

        [ProtoMember(6)]
        public int LineNumber;

        public ViewDeclaration()
        {
            PropertyAssignments = new List<PropertyAssignment>();
            PropertyBindings = new List<PropertyBinding>();
            ChildDeclarations = new List<ViewDeclaration>();
        }
    }

    /// <summary>
    /// Property binding type.
    /// </summary>
    public enum BindingType
    {
        SingleBinding = 0,
        MultiBindingTransform = 1,
        MultiBindingFormatString = 2
    }

    /// <summary>
    /// Property binding source type.
    /// </summary>        
    [Flags]
    public enum BindingSourceTypes
    {
        Default = 0,
        TwoWay = 1,
        Negated = 2 | TwoWay,
        Model = 4
    }

    /// <summary>
    /// Property declaration type.
    /// </summary>
    public enum PropertyDeclarationType
    {
        Default = 0,
        Action = 1,
        Template = 2,
        View = 3,
        UnityComponent = 4
    }

    #endregion

    #region Model Object

    [ProtoContract]
    public class ModelObject
    {
        [ProtoMember(1)]
        public string Name;

        [ProtoMember(2)]
        public string Namespace;

        [ProtoMember(3)]
        public string FilePath;

        [ProtoMember(4, AsReference = true)]
        public ViewObject BasedOn;

        [ProtoMember(5)]
        public bool NeedUpdate;

        [ProtoMember(6)]
        public List<PropertyExpression> PropertyExpressions;

        [ProtoMember(7)]
        public List<ViewDeclaration> ViewDeclarations;

        public ModelObject()
        {
            PropertyExpressions = new List<PropertyExpression>();
            ViewDeclarations = new List<ViewDeclaration>();
        }

        public void Clear()
        {
            Name = null;
            Namespace = null;
            FilePath = null;
            BasedOn = null;
            NeedUpdate = false;
            PropertyExpressions.Clear();
            ViewDeclarations.Clear();
        }

        public List<ViewDeclarationInfo> GetViewDeclarations(bool includeInheritedDeclarations)
        {
            // gets all view declarations in the view
            var viewDeclarations = new List<ViewDeclarationInfo>();
            if (includeInheritedDeclarations && BasedOn != null)
            {
                foreach (var declaration in BasedOn.GetViewDeclarations(true))
                {
                    declaration.IsInherited = true;
                    viewDeclarations.Add(declaration);
                }
            }

            foreach (var viewDeclaration in ViewDeclarations)
            {
                viewDeclarations.AddRange(GetViewDeclarations(viewDeclaration));
            }

            return viewDeclarations;
        }

        private List<ViewDeclarationInfo> GetViewDeclarations(ViewDeclaration viewDeclaration)
        {
            var viewDeclarations = new List<ViewDeclarationInfo>();
            viewDeclarations.Add(new ViewDeclarationInfo { Declaration = viewDeclaration });

            foreach (var childDeclaration in viewDeclaration.ChildDeclarations)
            {
                viewDeclarations.AddRange(GetViewDeclarations(childDeclaration));
            }

            return viewDeclarations;
        }
    }

    #endregion

    #region Theme Object

    [ProtoContract]
    public class ThemeObject
    {
        [ProtoMember(1)]
        public string Name;

        [ProtoMember(2)]
        public string Namespace;

        [ProtoMember(3)]
        public string FilePath;

        [ProtoMember(4)]
        public string BaseDirectory;

        [ProtoMember(5, AsReference = true)]
        public ThemeObject BasedOn;

        [ProtoMember(6)]
        public bool NeedUpdate;

        [ProtoMember(7)]
        public List<ViewDeclaration> ViewDeclarations;

        public ThemeObject()
        {
            ViewDeclarations = new List<ViewDeclaration>();
        }

        public void Clear()
        {
            Name = null;
            Namespace = null;
            BasedOn = null;
            FilePath = null;
            NeedUpdate = false;
            ViewDeclarations.Clear();
        }
    }

    #endregion
}

