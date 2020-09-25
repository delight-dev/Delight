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
            ViewActivators = new Dictionary<string, Func<View, View, string, Template, bool, View>>();
            ViewActivators.Add("SceneObjectView", (x, y, z, w, a) => new SceneObjectView(x, y, z, w, a));
            ViewActivators.Add("Button", (x, y, z, w, a) => new Button(x, y, z, w, a));
            ViewActivators.Add("UIImageView", (x, y, z, w, a) => new UIImageView(x, y, z, w, a));
            ViewActivators.Add("Label", (x, y, z, w, a) => new Label(x, y, z, w, a));
            ViewActivators.Add("CanvasRendererView", (x, y, z, w, a) => new CanvasRendererView(x, y, z, w, a));
            ViewActivators.Add("UIView", (x, y, z, w, a) => new UIView(x, y, z, w, a));
            ViewActivators.Add("CheckBox", (x, y, z, w, a) => new CheckBox(x, y, z, w, a));
            ViewActivators.Add("Group", (x, y, z, w, a) => new Group(x, y, z, w, a));
            ViewActivators.Add("Image", (x, y, z, w, a) => new Image(x, y, z, w, a));
            ViewActivators.Add("Collection", (x, y, z, w, a) => new Collection(x, y, z, w, a));
            ViewActivators.Add("ComboBox", (x, y, z, w, a) => new ComboBox(x, y, z, w, a));
            ViewActivators.Add("ComboBoxListItem", (x, y, z, w, a) => new ComboBoxListItem(x, y, z, w, a));
            ViewActivators.Add("UICanvas", (x, y, z, w, a) => new UICanvas(x, y, z, w, a));
            ViewActivators.Add("List", (x, y, z, w, a) => new List(x, y, z, w, a));
            ViewActivators.Add("ListItem", (x, y, z, w, a) => new ListItem(x, y, z, w, a));
            ViewActivators.Add("DefaultExpanderHeader", (x, y, z, w, a) => new DefaultExpanderHeader(x, y, z, w, a));
            ViewActivators.Add("ExpanderHeader", (x, y, z, w, a) => new ExpanderHeader(x, y, z, w, a));
            ViewActivators.Add("Expander", (x, y, z, w, a) => new Expander(x, y, z, w, a));
            ViewActivators.Add("ExpanderContent", (x, y, z, w, a) => new ExpanderContent(x, y, z, w, a));
            ViewActivators.Add("Frame", (x, y, z, w, a) => new Frame(x, y, z, w, a));
            ViewActivators.Add("LayoutGrid", (x, y, z, w, a) => new LayoutGrid(x, y, z, w, a));
            ViewActivators.Add("GridSplitter", (x, y, z, w, a) => new GridSplitter(x, y, z, w, a));
            ViewActivators.Add("GridSplitterHandle", (x, y, z, w, a) => new GridSplitterHandle(x, y, z, w, a));
            ViewActivators.Add("LayoutRoot", (x, y, z, w, a) => new LayoutRoot(x, y, z, w, a));
            ViewActivators.Add("NavigationButton", (x, y, z, w, a) => new NavigationButton(x, y, z, w, a));
            ViewActivators.Add("ScrollableRegion", (x, y, z, w, a) => new ScrollableRegion(x, y, z, w, a));
            ViewActivators.Add("Mask", (x, y, z, w, a) => new Mask(x, y, z, w, a));
            ViewActivators.Add("RadioButton", (x, y, z, w, a) => new RadioButton(x, y, z, w, a));
            ViewActivators.Add("RawImage", (x, y, z, w, a) => new RawImage(x, y, z, w, a));
            ViewActivators.Add("RectMask2D", (x, y, z, w, a) => new RectMask2D(x, y, z, w, a));
            ViewActivators.Add("Region", (x, y, z, w, a) => new Region(x, y, z, w, a));
            ViewActivators.Add("Scrollbar", (x, y, z, w, a) => new Scrollbar(x, y, z, w, a));
            ViewActivators.Add("SelectionIndicator", (x, y, z, w, a) => new SelectionIndicator(x, y, z, w, a));
            ViewActivators.Add("Slider", (x, y, z, w, a) => new Slider(x, y, z, w, a));
            ViewActivators.Add("Tab", (x, y, z, w, a) => new Tab(x, y, z, w, a));
            ViewActivators.Add("TabHeader", (x, y, z, w, a) => new TabHeader(x, y, z, w, a));
            ViewActivators.Add("TabPanel", (x, y, z, w, a) => new TabPanel(x, y, z, w, a));
            ViewActivators.Add("ViewSwitcher", (x, y, z, w, a) => new ViewSwitcher(x, y, z, w, a));
            ViewActivators.Add("ToggleGroup", (x, y, z, w, a) => new ToggleGroup(x, y, z, w, a));
            ViewActivators.Add("InputField", (x, y, z, w, a) => new InputField(x, y, z, w, a));
            ViewActivators.Add("ButtonsExample", (x, y, z, w, a) => new ButtonsExample(x, y, z, w, a));
            ViewActivators.Add("EmbeddedExpressionsExample", (x, y, z, w, a) => new EmbeddedExpressionsExample(x, y, z, w, a));
            ViewActivators.Add("GridExample", (x, y, z, w, a) => new GridExample(x, y, z, w, a));
            ViewActivators.Add("GroupExample", (x, y, z, w, a) => new GroupExample(x, y, z, w, a));
            ViewActivators.Add("InputFieldExample", (x, y, z, w, a) => new InputFieldExample(x, y, z, w, a));
            ViewActivators.Add("LevelSelectExample", (x, y, z, w, a) => new LevelSelectExample(x, y, z, w, a));
            ViewActivators.Add("MainMenuExample", (x, y, z, w, a) => new MainMenuExample(x, y, z, w, a));
            ViewActivators.Add("OnDemandLoadingExample", (x, y, z, w, a) => new OnDemandLoadingExample(x, y, z, w, a));
            ViewActivators.Add("ScrollExample", (x, y, z, w, a) => new ScrollExample(x, y, z, w, a));
            ViewActivators.Add("SliderExample", (x, y, z, w, a) => new SliderExample(x, y, z, w, a));
            ViewActivators.Add("TabPanelExample", (x, y, z, w, a) => new TabPanelExample(x, y, z, w, a));
            ViewActivators.Add("TestExample", (x, y, z, w, a) => new TestExample(x, y, z, w, a));
            ViewActivators.Add("MainMenuDemoScene", (x, y, z, w, a) => new MainMenuDemoScene(x, y, z, w, a));

            ViewTypes = new Dictionary<string, Type>();
            ViewTypes.Add("SceneObjectView", typeof(SceneObjectView));
            ViewTypes.Add("Button", typeof(Button));
            ViewTypes.Add("UIImageView", typeof(UIImageView));
            ViewTypes.Add("Label", typeof(Label));
            ViewTypes.Add("CanvasRendererView", typeof(CanvasRendererView));
            ViewTypes.Add("UIView", typeof(UIView));
            ViewTypes.Add("CheckBox", typeof(CheckBox));
            ViewTypes.Add("Group", typeof(Group));
            ViewTypes.Add("Image", typeof(Image));
            ViewTypes.Add("Collection", typeof(Collection));
            ViewTypes.Add("ComboBox", typeof(ComboBox));
            ViewTypes.Add("ComboBoxListItem", typeof(ComboBoxListItem));
            ViewTypes.Add("UICanvas", typeof(UICanvas));
            ViewTypes.Add("List", typeof(List));
            ViewTypes.Add("ListItem", typeof(ListItem));
            ViewTypes.Add("DefaultExpanderHeader", typeof(DefaultExpanderHeader));
            ViewTypes.Add("ExpanderHeader", typeof(ExpanderHeader));
            ViewTypes.Add("Expander", typeof(Expander));
            ViewTypes.Add("ExpanderContent", typeof(ExpanderContent));
            ViewTypes.Add("Frame", typeof(Frame));
            ViewTypes.Add("LayoutGrid", typeof(LayoutGrid));
            ViewTypes.Add("GridSplitter", typeof(GridSplitter));
            ViewTypes.Add("GridSplitterHandle", typeof(GridSplitterHandle));
            ViewTypes.Add("LayoutRoot", typeof(LayoutRoot));
            ViewTypes.Add("NavigationButton", typeof(NavigationButton));
            ViewTypes.Add("ScrollableRegion", typeof(ScrollableRegion));
            ViewTypes.Add("Mask", typeof(Mask));
            ViewTypes.Add("RadioButton", typeof(RadioButton));
            ViewTypes.Add("RawImage", typeof(RawImage));
            ViewTypes.Add("RectMask2D", typeof(RectMask2D));
            ViewTypes.Add("Region", typeof(Region));
            ViewTypes.Add("Scrollbar", typeof(Scrollbar));
            ViewTypes.Add("SelectionIndicator", typeof(SelectionIndicator));
            ViewTypes.Add("Slider", typeof(Slider));
            ViewTypes.Add("Tab", typeof(Tab));
            ViewTypes.Add("TabHeader", typeof(TabHeader));
            ViewTypes.Add("TabPanel", typeof(TabPanel));
            ViewTypes.Add("ViewSwitcher", typeof(ViewSwitcher));
            ViewTypes.Add("ToggleGroup", typeof(ToggleGroup));
            ViewTypes.Add("InputField", typeof(InputField));
            ViewTypes.Add("ButtonsExample", typeof(ButtonsExample));
            ViewTypes.Add("EmbeddedExpressionsExample", typeof(EmbeddedExpressionsExample));
            ViewTypes.Add("GridExample", typeof(GridExample));
            ViewTypes.Add("GroupExample", typeof(GroupExample));
            ViewTypes.Add("InputFieldExample", typeof(InputFieldExample));
            ViewTypes.Add("LevelSelectExample", typeof(LevelSelectExample));
            ViewTypes.Add("MainMenuExample", typeof(MainMenuExample));
            ViewTypes.Add("OnDemandLoadingExample", typeof(OnDemandLoadingExample));
            ViewTypes.Add("ScrollExample", typeof(ScrollExample));
            ViewTypes.Add("SliderExample", typeof(SliderExample));
            ViewTypes.Add("TabPanelExample", typeof(TabPanelExample));
            ViewTypes.Add("TestExample", typeof(TestExample));
            ViewTypes.Add("MainMenuDemoScene", typeof(MainMenuDemoScene));

            AttachedPropertyActivators = new Dictionary<string, Func<View, string, AttachedProperty>>();
            AttachedPropertyActivators.Add("System.Int32", (x, y) => new AttachedProperty<System.Int32>(x, y));
            AttachedPropertyActivators.Add("System.Boolean", (x, y) => new AttachedProperty<System.Boolean>(x, y));
            AttachedPropertyActivators.Add("Delight.CellIndex", (x, y) => new AttachedProperty<Delight.CellIndex>(x, y));
        }
    }
}
