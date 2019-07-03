// Asset data activators generated from parsed views and assets
#region Using Statements
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public static partial class Assets
    {
        static Assets()
        {
            ViewActivators = new Dictionary<string, Func<View, View, Template, View>>();
            ViewActivators.Add("AssetManagementTest", (x, y, z) => new AssetManagementTest(x, y, null, z));
            ViewActivators.Add("LayoutRoot", (x, y, z) => new LayoutRoot(x, y, null, z));
            ViewActivators.Add("BindingTest", (x, y, z) => new BindingTest(x, y, null, z));
            ViewActivators.Add("UIView", (x, y, z) => new UIView(x, y, null, z));
            ViewActivators.Add("ComboBoxExample", (x, y, z) => new ComboBoxExample(x, y, null, z));
            ViewActivators.Add("GridExample", (x, y, z) => new GridExample(x, y, null, z));
            ViewActivators.Add("InputFieldExample", (x, y, z) => new InputFieldExample(x, y, null, z));
            ViewActivators.Add("ListExample", (x, y, z) => new ListExample(x, y, null, z));
            ViewActivators.Add("ModelBindingTest", (x, y, z) => new ModelBindingTest(x, y, null, z));
            ViewActivators.Add("PerformanceTest", (x, y, z) => new PerformanceTest(x, y, null, z));
            ViewActivators.Add("ScrollExample", (x, y, z) => new ScrollExample(x, y, null, z));
            ViewActivators.Add("SliderExample", (x, y, z) => new SliderExample(x, y, null, z));
            ViewActivators.Add("TestScene", (x, y, z) => new TestScene(x, y, null, z));
            ViewActivators.Add("ViewSwitcherTest", (x, y, z) => new ViewSwitcherTest(x, y, null, z));
            ViewActivators.Add("SceneObjectView", (x, y, z) => new SceneObjectView(x, y, null, z));
            ViewActivators.Add("Button", (x, y, z) => new Button(x, y, null, z));
            ViewActivators.Add("UIImageView", (x, y, z) => new UIImageView(x, y, null, z));
            ViewActivators.Add("CheckBox", (x, y, z) => new CheckBox(x, y, null, z));
            ViewActivators.Add("Collection", (x, y, z) => new Collection(x, y, null, z));
            ViewActivators.Add("ComboBox", (x, y, z) => new ComboBox(x, y, null, z));
            ViewActivators.Add("ComboBoxListItem", (x, y, z) => new ComboBoxListItem(x, y, null, z));
            ViewActivators.Add("ListItem", (x, y, z) => new ListItem(x, y, null, z));
            ViewActivators.Add("Frame", (x, y, z) => new Frame(x, y, null, z));
            ViewActivators.Add("LayoutGrid", (x, y, z) => new LayoutGrid(x, y, null, z));
            ViewActivators.Add("Group", (x, y, z) => new Group(x, y, null, z));
            ViewActivators.Add("Image", (x, y, z) => new Image(x, y, null, z));
            ViewActivators.Add("InputField", (x, y, z) => new InputField(x, y, null, z));
            ViewActivators.Add("Label", (x, y, z) => new Label(x, y, null, z));
            ViewActivators.Add("UICanvas", (x, y, z) => new UICanvas(x, y, null, z));
            ViewActivators.Add("List", (x, y, z) => new List(x, y, null, z));
            ViewActivators.Add("Mask", (x, y, z) => new Mask(x, y, null, z));
            ViewActivators.Add("RadioButton", (x, y, z) => new RadioButton(x, y, null, z));
            ViewActivators.Add("RectMask2D", (x, y, z) => new RectMask2D(x, y, null, z));
            ViewActivators.Add("Region", (x, y, z) => new Region(x, y, null, z));
            ViewActivators.Add("ScrollableRegion", (x, y, z) => new ScrollableRegion(x, y, null, z));
            ViewActivators.Add("Scrollbar", (x, y, z) => new Scrollbar(x, y, null, z));
            ViewActivators.Add("Slider", (x, y, z) => new Slider(x, y, null, z));
            ViewActivators.Add("TabPanel", (x, y, z) => new TabPanel(x, y, null, z));
            ViewActivators.Add("ToggleGroup", (x, y, z) => new ToggleGroup(x, y, null, z));
            ViewActivators.Add("ViewSwitcher", (x, y, z) => new ViewSwitcher(x, y, null, z));
            ViewActivators.Add("NewScene", (x, y, z) => new NewScene(x, y, null, z));
            ViewActivators.Add("DelightEditor", (x, y, z) => new DelightEditor(x, y, null, z));
        }
    }
}
