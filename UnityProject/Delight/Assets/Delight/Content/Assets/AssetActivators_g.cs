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
            ViewActivators = new Dictionary<string, Func<View, View, string, Template, View>>();
            ViewActivators.Add("SceneObjectView", (x, y, z, w) => new SceneObjectView(x, y, z, w));
            ViewActivators.Add("Button", (x, y, z, w) => new Button(x, y, z, w));
            ViewActivators.Add("UIImageView", (x, y, z, w) => new UIImageView(x, y, z, w));
            ViewActivators.Add("Label", (x, y, z, w) => new Label(x, y, z, w));
            ViewActivators.Add("CanvasRendererView", (x, y, z, w) => new CanvasRendererView(x, y, z, w));
            ViewActivators.Add("UIView", (x, y, z, w) => new UIView(x, y, z, w));
            ViewActivators.Add("CheckBox", (x, y, z, w) => new CheckBox(x, y, z, w));
            ViewActivators.Add("Group", (x, y, z, w) => new Group(x, y, z, w));
            ViewActivators.Add("Image", (x, y, z, w) => new Image(x, y, z, w));
            ViewActivators.Add("Collection", (x, y, z, w) => new Collection(x, y, z, w));
            ViewActivators.Add("ComboBox", (x, y, z, w) => new ComboBox(x, y, z, w));
            ViewActivators.Add("ComboBoxListItem", (x, y, z, w) => new ComboBoxListItem(x, y, z, w));
            ViewActivators.Add("UICanvas", (x, y, z, w) => new UICanvas(x, y, z, w));
            ViewActivators.Add("List", (x, y, z, w) => new List(x, y, z, w));
            ViewActivators.Add("ListItem", (x, y, z, w) => new ListItem(x, y, z, w));
            ViewActivators.Add("Frame", (x, y, z, w) => new Frame(x, y, z, w));
            ViewActivators.Add("LayoutGrid", (x, y, z, w) => new LayoutGrid(x, y, z, w));
            ViewActivators.Add("GridSplitter", (x, y, z, w) => new GridSplitter(x, y, z, w));
            ViewActivators.Add("GridSplitterHandle", (x, y, z, w) => new GridSplitterHandle(x, y, z, w));
            ViewActivators.Add("LayoutRoot", (x, y, z, w) => new LayoutRoot(x, y, z, w));
            ViewActivators.Add("ScrollableRegion", (x, y, z, w) => new ScrollableRegion(x, y, z, w));
            ViewActivators.Add("Mask", (x, y, z, w) => new Mask(x, y, z, w));
            ViewActivators.Add("RadioButton", (x, y, z, w) => new RadioButton(x, y, z, w));
            ViewActivators.Add("RectMask2D", (x, y, z, w) => new RectMask2D(x, y, z, w));
            ViewActivators.Add("Region", (x, y, z, w) => new Region(x, y, z, w));
            ViewActivators.Add("Scrollbar", (x, y, z, w) => new Scrollbar(x, y, z, w));
            ViewActivators.Add("SelectionIndicator", (x, y, z, w) => new SelectionIndicator(x, y, z, w));
            ViewActivators.Add("Slider", (x, y, z, w) => new Slider(x, y, z, w));
            ViewActivators.Add("Tab", (x, y, z, w) => new Tab(x, y, z, w));
            ViewActivators.Add("TabHeader", (x, y, z, w) => new TabHeader(x, y, z, w));
            ViewActivators.Add("TabPanel", (x, y, z, w) => new TabPanel(x, y, z, w));
            ViewActivators.Add("ViewSwitcher", (x, y, z, w) => new ViewSwitcher(x, y, z, w));
            ViewActivators.Add("ToggleGroup", (x, y, z, w) => new ToggleGroup(x, y, z, w));
            ViewActivators.Add("XmlEditor", (x, y, z, w) => new XmlEditor(x, y, z, w));
            ViewActivators.Add("InputField", (x, y, z, w) => new InputField(x, y, z, w));
            ViewActivators.Add("Aa", (x, y, z, w) => new Aa(x, y, z, w));
            ViewActivators.Add("TitleView", (x, y, z, w) => new TitleView(x, y, z, w));
            ViewActivators.Add("AssetManagementTest", (x, y, z, w) => new AssetManagementTest(x, y, z, w));
            ViewActivators.Add("BindingTest", (x, y, z, w) => new BindingTest(x, y, z, w));
            ViewActivators.Add("ComboBoxExample", (x, y, z, w) => new ComboBoxExample(x, y, z, w));
            ViewActivators.Add("GridExample", (x, y, z, w) => new GridExample(x, y, z, w));
            ViewActivators.Add("GroupExamples", (x, y, z, w) => new GroupExamples(x, y, z, w));
            ViewActivators.Add("HighscoreTest", (x, y, z, w) => new HighscoreTest(x, y, z, w));
            ViewActivators.Add("InputFieldExample", (x, y, z, w) => new InputFieldExample(x, y, z, w));
            ViewActivators.Add("LevelSelect", (x, y, z, w) => new LevelSelect(x, y, z, w));
            ViewActivators.Add("ListExample", (x, y, z, w) => new ListExample(x, y, z, w));
            ViewActivators.Add("MainMenu", (x, y, z, w) => new MainMenu(x, y, z, w));
            ViewActivators.Add("Options", (x, y, z, w) => new Options(x, y, z, w));
            ViewActivators.Add("ModelBindingTest", (x, y, z, w) => new ModelBindingTest(x, y, z, w));
            ViewActivators.Add("PerformanceTest", (x, y, z, w) => new PerformanceTest(x, y, z, w));
            ViewActivators.Add("ScrollExample", (x, y, z, w) => new ScrollExample(x, y, z, w));
            ViewActivators.Add("SliderExample", (x, y, z, w) => new SliderExample(x, y, z, w));
            ViewActivators.Add("TabPanelExample", (x, y, z, w) => new TabPanelExample(x, y, z, w));
            ViewActivators.Add("TestScene", (x, y, z, w) => new TestScene(x, y, z, w));
            ViewActivators.Add("ViewSwitcherTest", (x, y, z, w) => new ViewSwitcherTest(x, y, z, w));
            ViewActivators.Add("InventoryItemView", (x, y, z, w) => new InventoryItemView(x, y, z, w));
            ViewActivators.Add("InventoryView", (x, y, z, w) => new InventoryView(x, y, z, w));
            ViewActivators.Add("MainMenuScene", (x, y, z, w) => new MainMenuScene(x, y, z, w));
            ViewActivators.Add("NewScene", (x, y, z, w) => new NewScene(x, y, z, w));
            ViewActivators.Add("InventoryTestScene", (x, y, z, w) => new InventoryTestScene(x, y, z, w));

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
            ViewTypes.Add("Frame", typeof(Frame));
            ViewTypes.Add("LayoutGrid", typeof(LayoutGrid));
            ViewTypes.Add("GridSplitter", typeof(GridSplitter));
            ViewTypes.Add("GridSplitterHandle", typeof(GridSplitterHandle));
            ViewTypes.Add("LayoutRoot", typeof(LayoutRoot));
            ViewTypes.Add("ScrollableRegion", typeof(ScrollableRegion));
            ViewTypes.Add("Mask", typeof(Mask));
            ViewTypes.Add("RadioButton", typeof(RadioButton));
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
            ViewTypes.Add("XmlEditor", typeof(XmlEditor));
            ViewTypes.Add("InputField", typeof(InputField));
            ViewTypes.Add("Aa", typeof(Aa));
            ViewTypes.Add("TitleView", typeof(TitleView));
            ViewTypes.Add("AssetManagementTest", typeof(AssetManagementTest));
            ViewTypes.Add("BindingTest", typeof(BindingTest));
            ViewTypes.Add("ComboBoxExample", typeof(ComboBoxExample));
            ViewTypes.Add("GridExample", typeof(GridExample));
            ViewTypes.Add("GroupExamples", typeof(GroupExamples));
            ViewTypes.Add("HighscoreTest", typeof(HighscoreTest));
            ViewTypes.Add("InputFieldExample", typeof(InputFieldExample));
            ViewTypes.Add("LevelSelect", typeof(LevelSelect));
            ViewTypes.Add("ListExample", typeof(ListExample));
            ViewTypes.Add("MainMenu", typeof(MainMenu));
            ViewTypes.Add("Options", typeof(Options));
            ViewTypes.Add("ModelBindingTest", typeof(ModelBindingTest));
            ViewTypes.Add("PerformanceTest", typeof(PerformanceTest));
            ViewTypes.Add("ScrollExample", typeof(ScrollExample));
            ViewTypes.Add("SliderExample", typeof(SliderExample));
            ViewTypes.Add("TabPanelExample", typeof(TabPanelExample));
            ViewTypes.Add("TestScene", typeof(TestScene));
            ViewTypes.Add("ViewSwitcherTest", typeof(ViewSwitcherTest));
            ViewTypes.Add("InventoryItemView", typeof(InventoryItemView));
            ViewTypes.Add("InventoryView", typeof(InventoryView));
            ViewTypes.Add("MainMenuScene", typeof(MainMenuScene));
            ViewTypes.Add("NewScene", typeof(NewScene));
            ViewTypes.Add("InventoryTestScene", typeof(InventoryTestScene));
        }
    }
}
