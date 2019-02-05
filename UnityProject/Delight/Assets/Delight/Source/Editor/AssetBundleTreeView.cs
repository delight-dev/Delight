#region Using Statements
using Delight.Editor.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight.Editor
{
    /// <summary>
    /// Displays asset bundles in a tree view.
    /// </summary>
    public class AssetBundleTreeView : TreeView
    {
        public AssetBundleTreeView(TreeViewState treeViewState) :
            base (treeViewState)
        {
            Reload();
        }

        protected override TreeViewItem BuildRoot()
        {
            return null;
        }
    }

    [Serializable]
    public class AssetBundleTreeElement
    {
        public string Name;
        public StorageMode StorageMode;
    }

    [CreateAssetMenu(fileName = "TreeDataAsset", menuName = "Tree Asset", order = 1)]
    public class MyTreeAsset : ScriptableObject
    {
        [SerializeField] List<AssetBundleTreeElement> m_TreeElements = new List<AssetBundleTreeElement>();

        internal List<AssetBundleTreeElement> treeElements
        {
            get { return m_TreeElements; }
            set { m_TreeElements = value; }
        }
    }
}
