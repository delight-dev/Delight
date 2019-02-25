// Internal view logic generated from "ModelBindingTest.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ModelBindingTest : LayoutRoot
    {
        #region Constructors

        public ModelBindingTest(View parent, View layoutParent = null, string id = null, Template template = null, Action<View> initializer = null) :
            base(parent, layoutParent, id, template ?? ModelBindingTestTemplates.Default, initializer)
        {
            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);
            Group2 = new Group(this, Group1.Content, "Group2", Group2Template);
            Button1 = new Button(this, Group2.Content, "Button1", Button1Template);
            Button1.Click += ResolveActionHandler(this, "Test1");
            Button2 = new Button(this, Group2.Content, "Button2", Button2Template);
            Button2.Click += ResolveActionHandler(this, "Test2");
            PlayerList = new List(this, Group1.Content, "PlayerList", PlayerListTemplate);

            // binding <List Items="{player in @Players}">
            Bindings.Add(new Binding(
                new List<string> {  },
                new List<string> { "PlayerList", "Items" },
                new List<Func<BindableObject>> {  },
                new List<Func<BindableObject>> { () => this, () => PlayerList },
                () => PlayerList.Items = Models.Players,
                () => { }
            ));

            // Template for PlayerList
            PlayerList.ContentTemplate = new ContentTemplate(tiPlayer => 
            {
                var playerListContent = new ListItem(this, PlayerList.Content, "PlayerListContent", PlayerListContentTemplate);
                var group3 = new Group(this, playerListContent.Content, "Group3", Group3Template);
                var label1 = new Label(this, group3.Content, "Label1", Label1Template);

                // binding <Label Text="{player.Name}">
                playerListContent.Bindings.Add(new Binding(
                    new List<string> { "Item", "Name" },
                    new List<string> { "Text" },
                    new List<Func<BindableObject>> { () => tiPlayer, () => tiPlayer.Item },
                    new List<Func<BindableObject>> { () => label1 },
                    () => label1.Text = (tiPlayer.Item as Delight.Player).Name,
                    () => { }
                ));
                var grid1 = new LayoutGrid(this, group3.Content, "Grid1", Grid1Template);
                var cell00 = new Region(this, grid1.Content, "Cell00", Cell00Template);
                grid1.Cell.SetValue(cell00, new CellIndex(0, 0));
                var cell01 = new Region(this, grid1.Content, "Cell01", Cell01Template);
                grid1.Cell.SetValue(cell01, new CellIndex(0, 1));
                var cell02 = new Region(this, grid1.Content, "Cell02", Cell02Template);
                grid1.Cell.SetValue(cell02, new CellIndex(0, 2));
                var cell10 = new Region(this, grid1.Content, "Cell10", Cell10Template);
                grid1.Cell.SetValue(cell10, new CellIndex(1, 0));
                var cell11 = new Region(this, grid1.Content, "Cell11", Cell11Template);
                grid1.Cell.SetValue(cell11, new CellIndex(1, 1));
                var cell12 = new Region(this, grid1.Content, "Cell12", Cell12Template);
                grid1.Cell.SetValue(cell12, new CellIndex(1, 2));
                var cell20 = new Region(this, grid1.Content, "Cell20", Cell20Template);
                grid1.Cell.SetValue(cell20, new CellIndex(2, 0));
                var cell21 = new Region(this, grid1.Content, "Cell21", Cell21Template);
                grid1.Cell.SetValue(cell21, new CellIndex(2, 1));
                var cell22 = new Region(this, grid1.Content, "Cell22", Cell22Template);
                grid1.Cell.SetValue(cell22, new CellIndex(2, 2));
                return playerListContent;
            });
            this.AfterInitializeInternal();
        }

        public ModelBindingTest() : this(null)
        {
        }

        static ModelBindingTest()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ModelBindingTestTemplates.Default, dependencyProperties);

            dependencyProperties.Add(SomeParentPropertyProperty);
            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(PlayerListProperty);
            dependencyProperties.Add(PlayerListTemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Grid1Property);
            dependencyProperties.Add(Grid1TemplateProperty);
            dependencyProperties.Add(Cell00Property);
            dependencyProperties.Add(Cell00TemplateProperty);
            dependencyProperties.Add(Cell01Property);
            dependencyProperties.Add(Cell01TemplateProperty);
            dependencyProperties.Add(Cell02Property);
            dependencyProperties.Add(Cell02TemplateProperty);
            dependencyProperties.Add(Cell10Property);
            dependencyProperties.Add(Cell10TemplateProperty);
            dependencyProperties.Add(Cell11Property);
            dependencyProperties.Add(Cell11TemplateProperty);
            dependencyProperties.Add(Cell12Property);
            dependencyProperties.Add(Cell12TemplateProperty);
            dependencyProperties.Add(Cell20Property);
            dependencyProperties.Add(Cell20TemplateProperty);
            dependencyProperties.Add(Cell21Property);
            dependencyProperties.Add(Cell21TemplateProperty);
            dependencyProperties.Add(Cell22Property);
            dependencyProperties.Add(Cell22TemplateProperty);
            dependencyProperties.Add(PlayerListContentProperty);
            dependencyProperties.Add(PlayerListContentTemplateProperty);
        }

        #endregion

        #region Properties

        public readonly static DependencyProperty<System.String> SomeParentPropertyProperty = new DependencyProperty<System.String>("SomeParentProperty");
        public System.String SomeParentProperty
        {
            get { return SomeParentPropertyProperty.GetValue(this); }
            set { SomeParentPropertyProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> Group1Property = new DependencyProperty<Group>("Group1");
        public Group Group1
        {
            get { return Group1Property.GetValue(this); }
            set { Group1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group1TemplateProperty = new DependencyProperty<Template>("Group1Template");
        public Template Group1Template
        {
            get { return Group1TemplateProperty.GetValue(this); }
            set { Group1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> Group2Property = new DependencyProperty<Group>("Group2");
        public Group Group2
        {
            get { return Group2Property.GetValue(this); }
            set { Group2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group2TemplateProperty = new DependencyProperty<Template>("Group2Template");
        public Template Group2Template
        {
            get { return Group2TemplateProperty.GetValue(this); }
            set { Group2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button1Property = new DependencyProperty<Button>("Button1");
        public Button Button1
        {
            get { return Button1Property.GetValue(this); }
            set { Button1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button1TemplateProperty = new DependencyProperty<Template>("Button1Template");
        public Template Button1Template
        {
            get { return Button1TemplateProperty.GetValue(this); }
            set { Button1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Button> Button2Property = new DependencyProperty<Button>("Button2");
        public Button Button2
        {
            get { return Button2Property.GetValue(this); }
            set { Button2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Button2TemplateProperty = new DependencyProperty<Template>("Button2Template");
        public Template Button2Template
        {
            get { return Button2TemplateProperty.GetValue(this); }
            set { Button2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<List> PlayerListProperty = new DependencyProperty<List>("PlayerList");
        public List PlayerList
        {
            get { return PlayerListProperty.GetValue(this); }
            set { PlayerListProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> PlayerListTemplateProperty = new DependencyProperty<Template>("PlayerListTemplate");
        public Template PlayerListTemplate
        {
            get { return PlayerListTemplateProperty.GetValue(this); }
            set { PlayerListTemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Group> Group3Property = new DependencyProperty<Group>("Group3");
        public Group Group3
        {
            get { return Group3Property.GetValue(this); }
            set { Group3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Group3TemplateProperty = new DependencyProperty<Template>("Group3Template");
        public Template Group3Template
        {
            get { return Group3TemplateProperty.GetValue(this); }
            set { Group3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label1Property = new DependencyProperty<Label>("Label1");
        public Label Label1
        {
            get { return Label1Property.GetValue(this); }
            set { Label1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label1TemplateProperty = new DependencyProperty<Template>("Label1Template");
        public Template Label1Template
        {
            get { return Label1TemplateProperty.GetValue(this); }
            set { Label1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<LayoutGrid> Grid1Property = new DependencyProperty<LayoutGrid>("Grid1");
        public LayoutGrid Grid1
        {
            get { return Grid1Property.GetValue(this); }
            set { Grid1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Grid1TemplateProperty = new DependencyProperty<Template>("Grid1Template");
        public Template Grid1Template
        {
            get { return Grid1TemplateProperty.GetValue(this); }
            set { Grid1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell00Property = new DependencyProperty<Region>("Cell00");
        public Region Cell00
        {
            get { return Cell00Property.GetValue(this); }
            set { Cell00Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell00TemplateProperty = new DependencyProperty<Template>("Cell00Template");
        public Template Cell00Template
        {
            get { return Cell00TemplateProperty.GetValue(this); }
            set { Cell00TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell01Property = new DependencyProperty<Region>("Cell01");
        public Region Cell01
        {
            get { return Cell01Property.GetValue(this); }
            set { Cell01Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell01TemplateProperty = new DependencyProperty<Template>("Cell01Template");
        public Template Cell01Template
        {
            get { return Cell01TemplateProperty.GetValue(this); }
            set { Cell01TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell02Property = new DependencyProperty<Region>("Cell02");
        public Region Cell02
        {
            get { return Cell02Property.GetValue(this); }
            set { Cell02Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell02TemplateProperty = new DependencyProperty<Template>("Cell02Template");
        public Template Cell02Template
        {
            get { return Cell02TemplateProperty.GetValue(this); }
            set { Cell02TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell10Property = new DependencyProperty<Region>("Cell10");
        public Region Cell10
        {
            get { return Cell10Property.GetValue(this); }
            set { Cell10Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell10TemplateProperty = new DependencyProperty<Template>("Cell10Template");
        public Template Cell10Template
        {
            get { return Cell10TemplateProperty.GetValue(this); }
            set { Cell10TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell11Property = new DependencyProperty<Region>("Cell11");
        public Region Cell11
        {
            get { return Cell11Property.GetValue(this); }
            set { Cell11Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell11TemplateProperty = new DependencyProperty<Template>("Cell11Template");
        public Template Cell11Template
        {
            get { return Cell11TemplateProperty.GetValue(this); }
            set { Cell11TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell12Property = new DependencyProperty<Region>("Cell12");
        public Region Cell12
        {
            get { return Cell12Property.GetValue(this); }
            set { Cell12Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell12TemplateProperty = new DependencyProperty<Template>("Cell12Template");
        public Template Cell12Template
        {
            get { return Cell12TemplateProperty.GetValue(this); }
            set { Cell12TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell20Property = new DependencyProperty<Region>("Cell20");
        public Region Cell20
        {
            get { return Cell20Property.GetValue(this); }
            set { Cell20Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell20TemplateProperty = new DependencyProperty<Template>("Cell20Template");
        public Template Cell20Template
        {
            get { return Cell20TemplateProperty.GetValue(this); }
            set { Cell20TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell21Property = new DependencyProperty<Region>("Cell21");
        public Region Cell21
        {
            get { return Cell21Property.GetValue(this); }
            set { Cell21Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell21TemplateProperty = new DependencyProperty<Template>("Cell21Template");
        public Template Cell21Template
        {
            get { return Cell21TemplateProperty.GetValue(this); }
            set { Cell21TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Cell22Property = new DependencyProperty<Region>("Cell22");
        public Region Cell22
        {
            get { return Cell22Property.GetValue(this); }
            set { Cell22Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Cell22TemplateProperty = new DependencyProperty<Template>("Cell22Template");
        public Template Cell22Template
        {
            get { return Cell22TemplateProperty.GetValue(this); }
            set { Cell22TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> PlayerListContentProperty = new DependencyProperty<ListItem>("PlayerListContent");
        public ListItem PlayerListContent
        {
            get { return PlayerListContentProperty.GetValue(this); }
            set { PlayerListContentProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> PlayerListContentTemplateProperty = new DependencyProperty<Template>("PlayerListContentTemplate");
        public Template PlayerListContentTemplate
        {
            get { return PlayerListContentTemplateProperty.GetValue(this); }
            set { PlayerListContentTemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ModelBindingTestTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ModelBindingTest;
            }
        }

        private static Template _modelBindingTest;
        public static Template ModelBindingTest
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTest == null || _modelBindingTest.CurrentVersion != Template.Version)
#else
                if (_modelBindingTest == null)
#endif
                {
                    _modelBindingTest = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _modelBindingTest.Name = "ModelBindingTest";
#endif
                    Delight.ModelBindingTest.Group1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGroup1);
                    Delight.ModelBindingTest.Group2TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGroup2);
                    Delight.ModelBindingTest.Button1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestButton1);
                    Delight.ModelBindingTest.Button2TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestButton2);
                    Delight.ModelBindingTest.PlayerListTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestPlayerList);
                    Delight.ModelBindingTest.PlayerListContentTemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestPlayerListContent);
                    Delight.ModelBindingTest.Group3TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGroup3);
                    Delight.ModelBindingTest.Label1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestLabel1);
                    Delight.ModelBindingTest.Grid1TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestGrid1);
                    Delight.ModelBindingTest.Cell00TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestCell00);
                    Delight.ModelBindingTest.Cell01TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestCell01);
                    Delight.ModelBindingTest.Cell02TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestCell02);
                    Delight.ModelBindingTest.Cell10TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestCell10);
                    Delight.ModelBindingTest.Cell11TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestCell11);
                    Delight.ModelBindingTest.Cell12TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestCell12);
                    Delight.ModelBindingTest.Cell20TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestCell20);
                    Delight.ModelBindingTest.Cell21TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestCell21);
                    Delight.ModelBindingTest.Cell22TemplateProperty.SetDefault(_modelBindingTest, ModelBindingTestCell22);
                }
                return _modelBindingTest;
            }
        }

        private static Template _modelBindingTestGroup1;
        public static Template ModelBindingTestGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestGroup1 == null || _modelBindingTestGroup1.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestGroup1 == null)
#endif
                {
                    _modelBindingTestGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _modelBindingTestGroup1.Name = "ModelBindingTestGroup1";
#endif
                    Delight.Group.OrientationProperty.SetDefault(_modelBindingTestGroup1, Delight.ElementOrientation.Horizontal);
                    Delight.Group.SpacingProperty.SetDefault(_modelBindingTestGroup1, new ElementSize(10f, ElementSizeUnit.Pixels));
                }
                return _modelBindingTestGroup1;
            }
        }

        private static Template _modelBindingTestGroup2;
        public static Template ModelBindingTestGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestGroup2 == null || _modelBindingTestGroup2.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestGroup2 == null)
#endif
                {
                    _modelBindingTestGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _modelBindingTestGroup2.Name = "ModelBindingTestGroup2";
#endif
                    Delight.Group.SpacingProperty.SetDefault(_modelBindingTestGroup2, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.Group.WidthProperty.SetDefault(_modelBindingTestGroup2, new ElementSize(500f, ElementSizeUnit.Pixels));
                }
                return _modelBindingTestGroup2;
            }
        }

        private static Template _modelBindingTestButton1;
        public static Template ModelBindingTestButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton1 == null || _modelBindingTestButton1.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton1 == null)
#endif
                {
                    _modelBindingTestButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _modelBindingTestButton1.Name = "ModelBindingTestButton1";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_modelBindingTestButton1, ModelBindingTestButton1Label);
                }
                return _modelBindingTestButton1;
            }
        }

        private static Template _modelBindingTestButton1Label;
        public static Template ModelBindingTestButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton1Label == null || _modelBindingTestButton1Label.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton1Label == null)
#endif
                {
                    _modelBindingTestButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _modelBindingTestButton1Label.Name = "ModelBindingTestButton1Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_modelBindingTestButton1Label, "Test 1");
                }
                return _modelBindingTestButton1Label;
            }
        }

        private static Template _modelBindingTestButton2;
        public static Template ModelBindingTestButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton2 == null || _modelBindingTestButton2.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton2 == null)
#endif
                {
                    _modelBindingTestButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _modelBindingTestButton2.Name = "ModelBindingTestButton2";
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_modelBindingTestButton2, ModelBindingTestButton2Label);
                }
                return _modelBindingTestButton2;
            }
        }

        private static Template _modelBindingTestButton2Label;
        public static Template ModelBindingTestButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestButton2Label == null || _modelBindingTestButton2Label.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestButton2Label == null)
#endif
                {
                    _modelBindingTestButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _modelBindingTestButton2Label.Name = "ModelBindingTestButton2Label";
#endif
                    Delight.Label.TextProperty.SetDefault(_modelBindingTestButton2Label, "Test 2");
                }
                return _modelBindingTestButton2Label;
            }
        }

        private static Template _modelBindingTestPlayerList;
        public static Template ModelBindingTestPlayerList
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerList == null || _modelBindingTestPlayerList.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerList == null)
#endif
                {
                    _modelBindingTestPlayerList = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _modelBindingTestPlayerList.Name = "ModelBindingTestPlayerList";
#endif
                    Delight.List.WidthProperty.SetDefault(_modelBindingTestPlayerList, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.List.HeightProperty.SetDefault(_modelBindingTestPlayerList, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.List.BackgroundColorProperty.SetDefault(_modelBindingTestPlayerList, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.List.SpacingProperty.SetDefault(_modelBindingTestPlayerList, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.List.IsScrollableProperty.SetDefault(_modelBindingTestPlayerList, true);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_modelBindingTestPlayerList, ModelBindingTestPlayerListScrollableRegion);
                }
                return _modelBindingTestPlayerList;
            }
        }

        private static Template _modelBindingTestPlayerListScrollableRegion;
        public static Template ModelBindingTestPlayerListScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListScrollableRegion == null || _modelBindingTestPlayerListScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListScrollableRegion == null)
#endif
                {
                    _modelBindingTestPlayerListScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListScrollableRegion.Name = "ModelBindingTestPlayerListScrollableRegion";
#endif
                }
                return _modelBindingTestPlayerListScrollableRegion;
            }
        }

        private static Template _modelBindingTestPlayerListContent;
        public static Template ModelBindingTestPlayerListContent
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestPlayerListContent == null || _modelBindingTestPlayerListContent.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestPlayerListContent == null)
#endif
                {
                    _modelBindingTestPlayerListContent = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _modelBindingTestPlayerListContent.Name = "ModelBindingTestPlayerListContent";
#endif
                }
                return _modelBindingTestPlayerListContent;
            }
        }

        private static Template _modelBindingTestGroup3;
        public static Template ModelBindingTestGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestGroup3 == null || _modelBindingTestGroup3.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestGroup3 == null)
#endif
                {
                    _modelBindingTestGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _modelBindingTestGroup3.Name = "ModelBindingTestGroup3";
#endif
                }
                return _modelBindingTestGroup3;
            }
        }

        private static Template _modelBindingTestLabel1;
        public static Template ModelBindingTestLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestLabel1 == null || _modelBindingTestLabel1.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestLabel1 == null)
#endif
                {
                    _modelBindingTestLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _modelBindingTestLabel1.Name = "ModelBindingTestLabel1";
#endif
                }
                return _modelBindingTestLabel1;
            }
        }

        private static Template _modelBindingTestGrid1;
        public static Template ModelBindingTestGrid1
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestGrid1 == null || _modelBindingTestGrid1.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestGrid1 == null)
#endif
                {
                    _modelBindingTestGrid1 = new Template(LayoutGridTemplates.LayoutGrid);
#if UNITY_EDITOR
                    _modelBindingTestGrid1.Name = "ModelBindingTestGrid1";
#endif
                    Delight.LayoutGrid.WidthProperty.SetDefault(_modelBindingTestGrid1, new ElementSize(70f, ElementSizeUnit.Pixels));
                    Delight.LayoutGrid.HeightProperty.SetDefault(_modelBindingTestGrid1, new ElementSize(70f, ElementSizeUnit.Pixels));
                    Delight.LayoutGrid.RowDefinitionsProperty.SetDefault(_modelBindingTestGrid1, new RowDefinitions { new RowDefinition(new ElementSize(1f, ElementSizeUnit.Proportional)), new RowDefinition(new ElementSize(1f, ElementSizeUnit.Proportional)), new RowDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                    Delight.LayoutGrid.ColumnDefinitionsProperty.SetDefault(_modelBindingTestGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional)), new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional)), new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                }
                return _modelBindingTestGrid1;
            }
        }

        private static Template _modelBindingTestCell00;
        public static Template ModelBindingTestCell00
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestCell00 == null || _modelBindingTestCell00.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestCell00 == null)
#endif
                {
                    _modelBindingTestCell00 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _modelBindingTestCell00.Name = "ModelBindingTestCell00";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_modelBindingTestCell00, new UnityEngine.Color(0.3254902f, 0.5372549f, 0.8784314f, 1f));
                }
                return _modelBindingTestCell00;
            }
        }

        private static Template _modelBindingTestCell01;
        public static Template ModelBindingTestCell01
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestCell01 == null || _modelBindingTestCell01.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestCell01 == null)
#endif
                {
                    _modelBindingTestCell01 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _modelBindingTestCell01.Name = "ModelBindingTestCell01";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_modelBindingTestCell01, new UnityEngine.Color(0.8901961f, 0.4588235f, 0.9764706f, 1f));
                }
                return _modelBindingTestCell01;
            }
        }

        private static Template _modelBindingTestCell02;
        public static Template ModelBindingTestCell02
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestCell02 == null || _modelBindingTestCell02.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestCell02 == null)
#endif
                {
                    _modelBindingTestCell02 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _modelBindingTestCell02.Name = "ModelBindingTestCell02";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_modelBindingTestCell02, new UnityEngine.Color(0.454902f, 0.9764706f, 0.8352941f, 1f));
                }
                return _modelBindingTestCell02;
            }
        }

        private static Template _modelBindingTestCell10;
        public static Template ModelBindingTestCell10
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestCell10 == null || _modelBindingTestCell10.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestCell10 == null)
#endif
                {
                    _modelBindingTestCell10 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _modelBindingTestCell10.Name = "ModelBindingTestCell10";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_modelBindingTestCell10, new UnityEngine.Color(0.9764706f, 0.7764706f, 0.454902f, 1f));
                }
                return _modelBindingTestCell10;
            }
        }

        private static Template _modelBindingTestCell11;
        public static Template ModelBindingTestCell11
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestCell11 == null || _modelBindingTestCell11.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestCell11 == null)
#endif
                {
                    _modelBindingTestCell11 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _modelBindingTestCell11.Name = "ModelBindingTestCell11";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_modelBindingTestCell11, new UnityEngine.Color(0.9882353f, 0.9294118f, 0.1764706f, 1f));
                }
                return _modelBindingTestCell11;
            }
        }

        private static Template _modelBindingTestCell12;
        public static Template ModelBindingTestCell12
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestCell12 == null || _modelBindingTestCell12.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestCell12 == null)
#endif
                {
                    _modelBindingTestCell12 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _modelBindingTestCell12.Name = "ModelBindingTestCell12";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_modelBindingTestCell12, new UnityEngine.Color(0.172549f, 0.9686275f, 0.1843137f, 1f));
                }
                return _modelBindingTestCell12;
            }
        }

        private static Template _modelBindingTestCell20;
        public static Template ModelBindingTestCell20
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestCell20 == null || _modelBindingTestCell20.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestCell20 == null)
#endif
                {
                    _modelBindingTestCell20 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _modelBindingTestCell20.Name = "ModelBindingTestCell20";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_modelBindingTestCell20, new UnityEngine.Color(0.9372549f, 0.3333333f, 0.1686275f, 1f));
                }
                return _modelBindingTestCell20;
            }
        }

        private static Template _modelBindingTestCell21;
        public static Template ModelBindingTestCell21
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestCell21 == null || _modelBindingTestCell21.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestCell21 == null)
#endif
                {
                    _modelBindingTestCell21 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _modelBindingTestCell21.Name = "ModelBindingTestCell21";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_modelBindingTestCell21, new UnityEngine.Color(0f, 0.5294118f, 1f, 1f));
                }
                return _modelBindingTestCell21;
            }
        }

        private static Template _modelBindingTestCell22;
        public static Template ModelBindingTestCell22
        {
            get
            {
#if UNITY_EDITOR
                if (_modelBindingTestCell22 == null || _modelBindingTestCell22.CurrentVersion != Template.Version)
#else
                if (_modelBindingTestCell22 == null)
#endif
                {
                    _modelBindingTestCell22 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _modelBindingTestCell22.Name = "ModelBindingTestCell22";
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_modelBindingTestCell22, new UnityEngine.Color(0.5294118f, 0.1882353f, 0.6784314f, 1f));
                }
                return _modelBindingTestCell22;
            }
        }

        #endregion
    }

    #endregion
}
