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
            ViewActivators.Add("Frame", (x, y, z, w, a) => new Frame(x, y, z, w, a));
            ViewActivators.Add("LayoutGrid", (x, y, z, w, a) => new LayoutGrid(x, y, z, w, a));
            ViewActivators.Add("GridSplitter", (x, y, z, w, a) => new GridSplitter(x, y, z, w, a));
            ViewActivators.Add("GridSplitterHandle", (x, y, z, w, a) => new GridSplitterHandle(x, y, z, w, a));
            ViewActivators.Add("LayoutRoot", (x, y, z, w, a) => new LayoutRoot(x, y, z, w, a));
            ViewActivators.Add("ScrollableRegion", (x, y, z, w, a) => new ScrollableRegion(x, y, z, w, a));
            ViewActivators.Add("Mask", (x, y, z, w, a) => new Mask(x, y, z, w, a));
            ViewActivators.Add("RadioButton", (x, y, z, w, a) => new RadioButton(x, y, z, w, a));
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
            ViewActivators.Add("XmlEditor", (x, y, z, w, a) => new XmlEditor(x, y, z, w, a));
            ViewActivators.Add("InputField", (x, y, z, w, a) => new InputField(x, y, z, w, a));
            ViewActivators.Add("HighscoreDemo", (x, y, z, w, a) => new HighscoreDemo(x, y, z, w, a));
            ViewActivators.Add("AssetManagementTest", (x, y, z, w, a) => new AssetManagementTest(x, y, z, w, a));
            ViewActivators.Add("ATest13", (x, y, z, w, a) => new ATest13(x, y, z, w, a));
            ViewActivators.Add("BindingTest", (x, y, z, w, a) => new BindingTest(x, y, z, w, a));
            ViewActivators.Add("ComboBoxExample", (x, y, z, w, a) => new ComboBoxExample(x, y, z, w, a));
            ViewActivators.Add("GridExample", (x, y, z, w, a) => new GridExample(x, y, z, w, a));
            ViewActivators.Add("GroupExamples", (x, y, z, w, a) => new GroupExamples(x, y, z, w, a));
            ViewActivators.Add("HighscoreTest", (x, y, z, w, a) => new HighscoreTest(x, y, z, w, a));
            ViewActivators.Add("InputFieldExample", (x, y, z, w, a) => new InputFieldExample(x, y, z, w, a));
            ViewActivators.Add("LevelSelect", (x, y, z, w, a) => new LevelSelect(x, y, z, w, a));
            ViewActivators.Add("ListExample", (x, y, z, w, a) => new ListExample(x, y, z, w, a));
            ViewActivators.Add("MainMenu", (x, y, z, w, a) => new MainMenu(x, y, z, w, a));
            ViewActivators.Add("Options", (x, y, z, w, a) => new Options(x, y, z, w, a));
            ViewActivators.Add("ModelBindingTest", (x, y, z, w, a) => new ModelBindingTest(x, y, z, w, a));
            ViewActivators.Add("PerformanceTest", (x, y, z, w, a) => new PerformanceTest(x, y, z, w, a));
            ViewActivators.Add("ScrollExample", (x, y, z, w, a) => new ScrollExample(x, y, z, w, a));
            ViewActivators.Add("SliderExample", (x, y, z, w, a) => new SliderExample(x, y, z, w, a));
            ViewActivators.Add("TabPanelExample", (x, y, z, w, a) => new TabPanelExample(x, y, z, w, a));
            ViewActivators.Add("TestScene", (x, y, z, w, a) => new TestScene(x, y, z, w, a));
            ViewActivators.Add("TitleView", (x, y, z, w, a) => new TitleView(x, y, z, w, a));
            ViewActivators.Add("ViewSwitcherTest", (x, y, z, w, a) => new ViewSwitcherTest(x, y, z, w, a));
            ViewActivators.Add("InventoryItemView", (x, y, z, w, a) => new InventoryItemView(x, y, z, w, a));
            ViewActivators.Add("InventoryView", (x, y, z, w, a) => new InventoryView(x, y, z, w, a));
            ViewActivators.Add("Audionaut", (x, y, z, w, a) => new Audionaut(x, y, z, w, a));
            ViewActivators.Add("MainMenuScene", (x, y, z, w, a) => new MainMenuScene(x, y, z, w, a));
            ViewActivators.Add("NewScene", (x, y, z, w, a) => new NewScene(x, y, z, w, a));
            ViewActivators.Add("InventoryTestScene", (x, y, z, w, a) => new InventoryTestScene(x, y, z, w, a));

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
            ViewTypes.Add("HighscoreDemo", typeof(HighscoreDemo));
            ViewTypes.Add("AssetManagementTest", typeof(AssetManagementTest));
            ViewTypes.Add("ATest13", typeof(ATest13));
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
            ViewTypes.Add("TitleView", typeof(TitleView));
            ViewTypes.Add("ViewSwitcherTest", typeof(ViewSwitcherTest));
            ViewTypes.Add("InventoryItemView", typeof(InventoryItemView));
            ViewTypes.Add("InventoryView", typeof(InventoryView));
            ViewTypes.Add("Audionaut", typeof(Audionaut));
            ViewTypes.Add("MainMenuScene", typeof(MainMenuScene));
            ViewTypes.Add("NewScene", typeof(NewScene));
            ViewTypes.Add("InventoryTestScene", typeof(InventoryTestScene));

            AttachedPropertyActivators = new Dictionary<string, Func<View, string, AttachedProperty>>();
            AttachedPropertyActivators.Add("System.Int32", (x, y) => new AttachedProperty<System.Int32>(x, y));
            AttachedPropertyActivators.Add("System.Boolean", (x, y) => new AttachedProperty<System.Boolean>(x, y));
            AttachedPropertyActivators.Add("Delight.CellIndex", (x, y) => new AttachedProperty<Delight.CellIndex>(x, y));
        }
    }
}
