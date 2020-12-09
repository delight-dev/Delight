#if DELIGHT_MODULE_PLAYFAB

// Internal view logic generated from "PlayFabPlayerProfileDetail.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class PlayFabPlayerProfileDetail : UIView
    {
        #region Constructors

        public PlayFabPlayerProfileDetail(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? PlayFabPlayerProfileDetailTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Group (Group1)
            Group1 = new Group(this, this, "Group1", Group1Template);

            // binding <Group IsVisible="{@PlayFabUser.IsLoggedIn}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "IsLoggedIn" }, new List<Func<object>> { () => Models.PlayFabUser }) }, new BindingPath(new List<string> { "Group1", "IsVisible" }, new List<Func<object>> { () => this, () => Group1 }), () => Group1.IsVisible = Models.PlayFabUser.IsLoggedIn, () => { }, false));
            Label1 = new Label(this, Group1.Content, "Label1", Label1Template);
            Grid1 = new LayoutGrid(this, Group1.Content, "Grid1", Grid1Template);
            Label2 = new Label(this, Grid1.Content, "Label2", Label2Template);
            Grid1.Cell.SetValue(Label2, new CellIndex(0, 0));
            Label3 = new Label(this, Grid1.Content, "Label3", Label3Template);
            Grid1.Cell.SetValue(Label3, new CellIndex(0, 1));

            // binding <Label Text="{@PlayFabUser.PlayerProfile.Id}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "PlayerProfile", "Id" }, new List<Func<object>> { () => Models.PlayFabUser, () => Models.PlayFabUser.PlayerProfile }) }, new BindingPath(new List<string> { "Label3", "Text" }, new List<Func<object>> { () => this, () => Label3 }), () => Label3.Text = Models.PlayFabUser.PlayerProfile.Id, () => { }, false));
            Label4 = new Label(this, Grid1.Content, "Label4", Label4Template);
            Grid1.Cell.SetValue(Label4, new CellIndex(1, 0));
            InputField1 = new InputField(this, Grid1.Content, "InputField1", InputField1Template);
            Grid1.Cell.SetValue(InputField1, new CellIndex(1, 1));

            // binding <InputField Text="{@PlayFabUser.PlayerProfile.DisplayName}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "PlayerProfile", "DisplayName" }, new List<Func<object>> { () => Models.PlayFabUser, () => Models.PlayFabUser.PlayerProfile }) }, new BindingPath(new List<string> { "InputField1", "Text" }, new List<Func<object>> { () => this, () => InputField1 }), () => InputField1.Text = Models.PlayFabUser.PlayerProfile.DisplayName, () => Models.PlayFabUser.PlayerProfile.DisplayName = InputField1.Text, true));
            Group2 = new Group(this, Grid1.Content, "Group2", Group2Template);
            Grid1.Cell.SetValue(Group2, new CellIndex(2, 0));
            Label5 = new Label(this, Group2.Content, "Label5", Label5Template);
            List1 = new List(this, Group2.Content, "List1", List1Template);

            // binding <List Items="{friend in @PlayFabUser.Friends}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Friends" }, new List<Func<object>> { () => Models.PlayFabUser }) }, new BindingPath(new List<string> { "List1", "Items" }, new List<Func<object>> { () => this, () => List1 }), () => List1.Items = Models.PlayFabUser.Friends, () => { }, false));

            // templates for List1
            List1.ContentTemplates.Add(new ContentTemplate(tiFriend => 
            {
                var listItem1 = new ListItem(this, List1.Content, "ListItem1", ListItem1Template);
                var grid2 = new LayoutGrid(this, listItem1.Content, "Grid2", Grid2Template);
                var label6 = new Label(this, grid2.Content, "Label6", Label6Template);
                grid2.Cell.SetValue(label6, new CellIndex(0, 0));
                var label7 = new Label(this, grid2.Content, "Label7", Label7Template);
                grid2.Cell.SetValue(label7, new CellIndex(0, 1));

                // binding <Label Text="{friend.Id}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "Id" }, new List<Func<object>> { () => tiFriend, () => (tiFriend.Item as Delight.PlayFabPlayerProfile) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<object>> { () => label7 }), () => label7.Text = (tiFriend.Item as Delight.PlayFabPlayerProfile).Id, () => { }, false));
                var label8 = new Label(this, grid2.Content, "Label8", Label8Template);
                grid2.Cell.SetValue(label8, new CellIndex(1, 0));
                var label9 = new Label(this, grid2.Content, "Label9", Label9Template);
                grid2.Cell.SetValue(label9, new CellIndex(1, 1));

                // binding <Label Text="{friend.DisplayName}">
                listItem1.Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "Item", "DisplayName" }, new List<Func<object>> { () => tiFriend, () => (tiFriend.Item as Delight.PlayFabPlayerProfile) }) }, new BindingPath(new List<string> { "Text" }, new List<Func<object>> { () => label9 }), () => label9.Text = (tiFriend.Item as Delight.PlayFabPlayerProfile).DisplayName, () => { }, false));
                listItem1.IsDynamic = true;
                listItem1.SetContentTemplateData(tiFriend);
                return listItem1;
            }, typeof(ListItem), "ListItem1"));
            Group3 = new Group(this, Group2.Content, "Group3", Group3Template);
            Button1 = new Button(this, Group3.Content, "Button1", Button1Template);
            Button1.Click.RegisterHandler(this, "AddFriend");
            Button2 = new Button(this, Group3.Content, "Button2", Button2Template);
            Button2.Click.RegisterHandler(this, "RemoveFriend");

            // constructing Region (Region1)
            Region1 = new Region(this, this, "Region1", Region1Template);

            // binding <Region IsActive="{!@PlayFabUser.IsLoggedIn}">
            Bindings.Add(new Binding(new List<BindingPath> { new BindingPath(new List<string> { "IsLoggedIn" }, new List<Func<object>> { () => Models.PlayFabUser }) }, new BindingPath(new List<string> { "Region1", "IsActive" }, new List<Func<object>> { () => this, () => Region1 }), () => Region1.IsActive = !Models.PlayFabUser.IsLoggedIn, () => { }, false));
            Label10 = new Label(this, Region1.Content, "Label10", Label10Template);
            this.AfterInitializeInternal();
        }

        public PlayFabPlayerProfileDetail() : this(null)
        {
        }

        static PlayFabPlayerProfileDetail()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(PlayFabPlayerProfileDetailTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Group1Property);
            dependencyProperties.Add(Group1TemplateProperty);
            dependencyProperties.Add(Label1Property);
            dependencyProperties.Add(Label1TemplateProperty);
            dependencyProperties.Add(Grid1Property);
            dependencyProperties.Add(Grid1TemplateProperty);
            dependencyProperties.Add(Label2Property);
            dependencyProperties.Add(Label2TemplateProperty);
            dependencyProperties.Add(Label3Property);
            dependencyProperties.Add(Label3TemplateProperty);
            dependencyProperties.Add(Label4Property);
            dependencyProperties.Add(Label4TemplateProperty);
            dependencyProperties.Add(InputField1Property);
            dependencyProperties.Add(InputField1TemplateProperty);
            dependencyProperties.Add(Group2Property);
            dependencyProperties.Add(Group2TemplateProperty);
            dependencyProperties.Add(Label5Property);
            dependencyProperties.Add(Label5TemplateProperty);
            dependencyProperties.Add(List1Property);
            dependencyProperties.Add(List1TemplateProperty);
            dependencyProperties.Add(ListItem1Property);
            dependencyProperties.Add(ListItem1TemplateProperty);
            dependencyProperties.Add(Grid2Property);
            dependencyProperties.Add(Grid2TemplateProperty);
            dependencyProperties.Add(Label6Property);
            dependencyProperties.Add(Label6TemplateProperty);
            dependencyProperties.Add(Label7Property);
            dependencyProperties.Add(Label7TemplateProperty);
            dependencyProperties.Add(Label8Property);
            dependencyProperties.Add(Label8TemplateProperty);
            dependencyProperties.Add(Label9Property);
            dependencyProperties.Add(Label9TemplateProperty);
            dependencyProperties.Add(Group3Property);
            dependencyProperties.Add(Group3TemplateProperty);
            dependencyProperties.Add(Button1Property);
            dependencyProperties.Add(Button1TemplateProperty);
            dependencyProperties.Add(Button2Property);
            dependencyProperties.Add(Button2TemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Label10Property);
            dependencyProperties.Add(Label10TemplateProperty);
        }

        #endregion

        #region Properties

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

        public readonly static DependencyProperty<Label> Label2Property = new DependencyProperty<Label>("Label2");
        public Label Label2
        {
            get { return Label2Property.GetValue(this); }
            set { Label2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label2TemplateProperty = new DependencyProperty<Template>("Label2Template");
        public Template Label2Template
        {
            get { return Label2TemplateProperty.GetValue(this); }
            set { Label2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label3Property = new DependencyProperty<Label>("Label3");
        public Label Label3
        {
            get { return Label3Property.GetValue(this); }
            set { Label3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label3TemplateProperty = new DependencyProperty<Template>("Label3Template");
        public Template Label3Template
        {
            get { return Label3TemplateProperty.GetValue(this); }
            set { Label3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label4Property = new DependencyProperty<Label>("Label4");
        public Label Label4
        {
            get { return Label4Property.GetValue(this); }
            set { Label4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label4TemplateProperty = new DependencyProperty<Template>("Label4Template");
        public Template Label4Template
        {
            get { return Label4TemplateProperty.GetValue(this); }
            set { Label4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<InputField> InputField1Property = new DependencyProperty<InputField>("InputField1");
        public InputField InputField1
        {
            get { return InputField1Property.GetValue(this); }
            set { InputField1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> InputField1TemplateProperty = new DependencyProperty<Template>("InputField1Template");
        public Template InputField1Template
        {
            get { return InputField1TemplateProperty.GetValue(this); }
            set { InputField1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Label> Label5Property = new DependencyProperty<Label>("Label5");
        public Label Label5
        {
            get { return Label5Property.GetValue(this); }
            set { Label5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label5TemplateProperty = new DependencyProperty<Template>("Label5Template");
        public Template Label5Template
        {
            get { return Label5TemplateProperty.GetValue(this); }
            set { Label5TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<List> List1Property = new DependencyProperty<List>("List1");
        public List List1
        {
            get { return List1Property.GetValue(this); }
            set { List1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> List1TemplateProperty = new DependencyProperty<Template>("List1Template");
        public Template List1Template
        {
            get { return List1TemplateProperty.GetValue(this); }
            set { List1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ListItem> ListItem1Property = new DependencyProperty<ListItem>("ListItem1");
        public ListItem ListItem1
        {
            get { return ListItem1Property.GetValue(this); }
            set { ListItem1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ListItem1TemplateProperty = new DependencyProperty<Template>("ListItem1Template");
        public Template ListItem1Template
        {
            get { return ListItem1TemplateProperty.GetValue(this); }
            set { ListItem1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<LayoutGrid> Grid2Property = new DependencyProperty<LayoutGrid>("Grid2");
        public LayoutGrid Grid2
        {
            get { return Grid2Property.GetValue(this); }
            set { Grid2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Grid2TemplateProperty = new DependencyProperty<Template>("Grid2Template");
        public Template Grid2Template
        {
            get { return Grid2TemplateProperty.GetValue(this); }
            set { Grid2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label6Property = new DependencyProperty<Label>("Label6");
        public Label Label6
        {
            get { return Label6Property.GetValue(this); }
            set { Label6Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label6TemplateProperty = new DependencyProperty<Template>("Label6Template");
        public Template Label6Template
        {
            get { return Label6TemplateProperty.GetValue(this); }
            set { Label6TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label7Property = new DependencyProperty<Label>("Label7");
        public Label Label7
        {
            get { return Label7Property.GetValue(this); }
            set { Label7Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label7TemplateProperty = new DependencyProperty<Template>("Label7Template");
        public Template Label7Template
        {
            get { return Label7TemplateProperty.GetValue(this); }
            set { Label7TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label8Property = new DependencyProperty<Label>("Label8");
        public Label Label8
        {
            get { return Label8Property.GetValue(this); }
            set { Label8Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label8TemplateProperty = new DependencyProperty<Template>("Label8Template");
        public Template Label8Template
        {
            get { return Label8TemplateProperty.GetValue(this); }
            set { Label8TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label9Property = new DependencyProperty<Label>("Label9");
        public Label Label9
        {
            get { return Label9Property.GetValue(this); }
            set { Label9Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label9TemplateProperty = new DependencyProperty<Template>("Label9Template");
        public Template Label9Template
        {
            get { return Label9TemplateProperty.GetValue(this); }
            set { Label9TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> Region1Property = new DependencyProperty<Region>("Region1");
        public Region Region1
        {
            get { return Region1Property.GetValue(this); }
            set { Region1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region1TemplateProperty = new DependencyProperty<Template>("Region1Template");
        public Template Region1Template
        {
            get { return Region1TemplateProperty.GetValue(this); }
            set { Region1TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Label> Label10Property = new DependencyProperty<Label>("Label10");
        public Label Label10
        {
            get { return Label10Property.GetValue(this); }
            set { Label10Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Label10TemplateProperty = new DependencyProperty<Template>("Label10Template");
        public Template Label10Template
        {
            get { return Label10TemplateProperty.GetValue(this); }
            set { Label10TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class PlayFabPlayerProfileDetailTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return PlayFabPlayerProfileDetail;
            }
        }

        private static Template _playFabPlayerProfileDetail;
        public static Template PlayFabPlayerProfileDetail
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetail == null || _playFabPlayerProfileDetail.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetail == null)
#endif
                {
                    _playFabPlayerProfileDetail = new Template(UIViewTemplates.UIView);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetail.Name = "PlayFabPlayerProfileDetail";
                    _playFabPlayerProfileDetail.LineNumber = 0;
                    _playFabPlayerProfileDetail.LinePosition = 0;
#endif
                    Delight.PlayFabPlayerProfileDetail.Group1TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailGroup1);
                    Delight.PlayFabPlayerProfileDetail.Label1TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel1);
                    Delight.PlayFabPlayerProfileDetail.Grid1TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailGrid1);
                    Delight.PlayFabPlayerProfileDetail.Label2TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel2);
                    Delight.PlayFabPlayerProfileDetail.Label3TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel3);
                    Delight.PlayFabPlayerProfileDetail.Label4TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel4);
                    Delight.PlayFabPlayerProfileDetail.InputField1TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailInputField1);
                    Delight.PlayFabPlayerProfileDetail.Group2TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailGroup2);
                    Delight.PlayFabPlayerProfileDetail.Label5TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel5);
                    Delight.PlayFabPlayerProfileDetail.List1TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailList1);
                    Delight.PlayFabPlayerProfileDetail.ListItem1TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailListItem1);
                    Delight.PlayFabPlayerProfileDetail.Grid2TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailGrid2);
                    Delight.PlayFabPlayerProfileDetail.Label6TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel6);
                    Delight.PlayFabPlayerProfileDetail.Label7TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel7);
                    Delight.PlayFabPlayerProfileDetail.Label8TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel8);
                    Delight.PlayFabPlayerProfileDetail.Label9TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel9);
                    Delight.PlayFabPlayerProfileDetail.Group3TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailGroup3);
                    Delight.PlayFabPlayerProfileDetail.Button1TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailButton1);
                    Delight.PlayFabPlayerProfileDetail.Button2TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailButton2);
                    Delight.PlayFabPlayerProfileDetail.Region1TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailRegion1);
                    Delight.PlayFabPlayerProfileDetail.Label10TemplateProperty.SetDefault(_playFabPlayerProfileDetail, PlayFabPlayerProfileDetailLabel10);
                }
                return _playFabPlayerProfileDetail;
            }
        }

        private static Template _playFabPlayerProfileDetailGroup1;
        public static Template PlayFabPlayerProfileDetailGroup1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailGroup1 == null || _playFabPlayerProfileDetailGroup1.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailGroup1 == null)
#endif
                {
                    _playFabPlayerProfileDetailGroup1 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailGroup1.Name = "PlayFabPlayerProfileDetailGroup1";
                    _playFabPlayerProfileDetailGroup1.LineNumber = 4;
                    _playFabPlayerProfileDetailGroup1.LinePosition = 4;
#endif
                    Delight.Group.SpacingProperty.SetDefault(_playFabPlayerProfileDetailGroup1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.Group.AlignmentProperty.SetDefault(_playFabPlayerProfileDetailGroup1, Delight.ElementAlignment.TopLeft);
                    Delight.Group.MarginProperty.SetDefault(_playFabPlayerProfileDetailGroup1, new ElementMargin(new ElementSize(10f, ElementSizeUnit.Pixels)));
                    Delight.Group.IsVisibleProperty.SetHasBinding(_playFabPlayerProfileDetailGroup1);
                }
                return _playFabPlayerProfileDetailGroup1;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel1;
        public static Template PlayFabPlayerProfileDetailLabel1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel1 == null || _playFabPlayerProfileDetailLabel1.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel1 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel1 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel1.Name = "PlayFabPlayerProfileDetailLabel1";
                    _playFabPlayerProfileDetailLabel1.LineNumber = 5;
                    _playFabPlayerProfileDetailLabel1.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabPlayerProfileDetailLabel1, "Logged in player");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabPlayerProfileDetailLabel1, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabPlayerProfileDetailLabel1, 30f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel1, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_playFabPlayerProfileDetailLabel1, Delight.ElementAlignment.Left);
                }
                return _playFabPlayerProfileDetailLabel1;
            }
        }

        private static Template _playFabPlayerProfileDetailGrid1;
        public static Template PlayFabPlayerProfileDetailGrid1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailGrid1 == null || _playFabPlayerProfileDetailGrid1.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailGrid1 == null)
#endif
                {
                    _playFabPlayerProfileDetailGrid1 = new Template(LayoutGridTemplates.LayoutGrid);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailGrid1.Name = "PlayFabPlayerProfileDetailGrid1";
                    _playFabPlayerProfileDetailGrid1.LineNumber = 6;
                    _playFabPlayerProfileDetailGrid1.LinePosition = 6;
#endif
                    Delight.LayoutGrid.RowsProperty.SetDefault(_playFabPlayerProfileDetailGrid1, new RowDefinitions { new RowDefinition(new ElementSize(30f, ElementSizeUnit.Pixels)), new RowDefinition(new ElementSize(30f, ElementSizeUnit.Pixels)), new RowDefinition(new ElementSize(1f, ElementSizeUnit.Proportional))});
                    Delight.LayoutGrid.ColumnsProperty.SetDefault(_playFabPlayerProfileDetailGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(200f, ElementSizeUnit.Pixels), 20f), new ColumnDefinition(new ElementSize(320f, ElementSizeUnit.Pixels), 20f)});
                    Delight.LayoutGrid.WidthProperty.SetDefault(_playFabPlayerProfileDetailGrid1, new ElementSize(520f, ElementSizeUnit.Pixels));
                    Delight.LayoutGrid.HeightProperty.SetDefault(_playFabPlayerProfileDetailGrid1, new ElementSize(64f, ElementSizeUnit.Pixels));
                    Delight.LayoutGrid.RowSpacingProperty.SetDefault(_playFabPlayerProfileDetailGrid1, new ElementSize(2f, ElementSizeUnit.Pixels));
                    Delight.LayoutGrid.AlignmentProperty.SetDefault(_playFabPlayerProfileDetailGrid1, Delight.ElementAlignment.Left);
                }
                return _playFabPlayerProfileDetailGrid1;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel2;
        public static Template PlayFabPlayerProfileDetailLabel2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel2 == null || _playFabPlayerProfileDetailLabel2.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel2 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel2 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel2.Name = "PlayFabPlayerProfileDetailLabel2";
                    _playFabPlayerProfileDetailLabel2.LineNumber = 7;
                    _playFabPlayerProfileDetailLabel2.LinePosition = 8;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabPlayerProfileDetailLabel2, "Id");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabPlayerProfileDetailLabel2, Delight.AutoSize.Default);
                    Delight.Label.FontStyleProperty.SetDefault(_playFabPlayerProfileDetailLabel2, TMPro.FontStyles.Bold);
                    Delight.Label.OffsetProperty.SetDefault(_playFabPlayerProfileDetailLabel2, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel2, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel2, Assets.TMP_FontAssets["Segoe UI SDF"]);
                }
                return _playFabPlayerProfileDetailLabel2;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel3;
        public static Template PlayFabPlayerProfileDetailLabel3
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel3 == null || _playFabPlayerProfileDetailLabel3.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel3 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel3 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel3.Name = "PlayFabPlayerProfileDetailLabel3";
                    _playFabPlayerProfileDetailLabel3.LineNumber = 8;
                    _playFabPlayerProfileDetailLabel3.LinePosition = 8;
#endif
                    Delight.Label.WidthProperty.SetDefault(_playFabPlayerProfileDetailLabel3, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel3, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel3, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.TextProperty.SetHasBinding(_playFabPlayerProfileDetailLabel3);
                }
                return _playFabPlayerProfileDetailLabel3;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel4;
        public static Template PlayFabPlayerProfileDetailLabel4
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel4 == null || _playFabPlayerProfileDetailLabel4.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel4 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel4 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel4.Name = "PlayFabPlayerProfileDetailLabel4";
                    _playFabPlayerProfileDetailLabel4.LineNumber = 10;
                    _playFabPlayerProfileDetailLabel4.LinePosition = 8;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabPlayerProfileDetailLabel4, "DisplayName");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabPlayerProfileDetailLabel4, Delight.AutoSize.Default);
                    Delight.Label.FontStyleProperty.SetDefault(_playFabPlayerProfileDetailLabel4, TMPro.FontStyles.Bold);
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel4, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel4, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.OffsetProperty.SetDefault(_playFabPlayerProfileDetailLabel4, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _playFabPlayerProfileDetailLabel4;
            }
        }

        private static Template _playFabPlayerProfileDetailInputField1;
        public static Template PlayFabPlayerProfileDetailInputField1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailInputField1 == null || _playFabPlayerProfileDetailInputField1.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailInputField1 == null)
#endif
                {
                    _playFabPlayerProfileDetailInputField1 = new Template(InputFieldTemplates.InputField);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailInputField1.Name = "PlayFabPlayerProfileDetailInputField1";
                    _playFabPlayerProfileDetailInputField1.LineNumber = 11;
                    _playFabPlayerProfileDetailInputField1.LinePosition = 8;
#endif
                    Delight.InputField.WidthProperty.SetDefault(_playFabPlayerProfileDetailInputField1, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.InputField.SetValueOnEndEditProperty.SetDefault(_playFabPlayerProfileDetailInputField1, true);
                    Delight.InputField.TextProperty.SetHasBinding(_playFabPlayerProfileDetailInputField1);
                    Delight.InputField.InputFieldPlaceholderTemplateProperty.SetDefault(_playFabPlayerProfileDetailInputField1, PlayFabPlayerProfileDetailInputField1InputFieldPlaceholder);
                    Delight.InputField.TextAreaTemplateProperty.SetDefault(_playFabPlayerProfileDetailInputField1, PlayFabPlayerProfileDetailInputField1TextArea);
                    Delight.InputField.InputTextTemplateProperty.SetDefault(_playFabPlayerProfileDetailInputField1, PlayFabPlayerProfileDetailInputField1InputText);
                }
                return _playFabPlayerProfileDetailInputField1;
            }
        }

        private static Template _playFabPlayerProfileDetailInputField1InputFieldPlaceholder;
        public static Template PlayFabPlayerProfileDetailInputField1InputFieldPlaceholder
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailInputField1InputFieldPlaceholder == null || _playFabPlayerProfileDetailInputField1InputFieldPlaceholder.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailInputField1InputFieldPlaceholder == null)
#endif
                {
                    _playFabPlayerProfileDetailInputField1InputFieldPlaceholder = new Template(InputFieldTemplates.InputFieldInputFieldPlaceholder);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailInputField1InputFieldPlaceholder.Name = "PlayFabPlayerProfileDetailInputField1InputFieldPlaceholder";
                    _playFabPlayerProfileDetailInputField1InputFieldPlaceholder.LineNumber = 12;
                    _playFabPlayerProfileDetailInputField1InputFieldPlaceholder.LinePosition = 4;
#endif
                }
                return _playFabPlayerProfileDetailInputField1InputFieldPlaceholder;
            }
        }

        private static Template _playFabPlayerProfileDetailInputField1TextArea;
        public static Template PlayFabPlayerProfileDetailInputField1TextArea
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailInputField1TextArea == null || _playFabPlayerProfileDetailInputField1TextArea.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailInputField1TextArea == null)
#endif
                {
                    _playFabPlayerProfileDetailInputField1TextArea = new Template(InputFieldTemplates.InputFieldTextArea);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailInputField1TextArea.Name = "PlayFabPlayerProfileDetailInputField1TextArea";
                    _playFabPlayerProfileDetailInputField1TextArea.LineNumber = 13;
                    _playFabPlayerProfileDetailInputField1TextArea.LinePosition = 4;
#endif
                }
                return _playFabPlayerProfileDetailInputField1TextArea;
            }
        }

        private static Template _playFabPlayerProfileDetailInputField1InputText;
        public static Template PlayFabPlayerProfileDetailInputField1InputText
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailInputField1InputText == null || _playFabPlayerProfileDetailInputField1InputText.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailInputField1InputText == null)
#endif
                {
                    _playFabPlayerProfileDetailInputField1InputText = new Template(InputFieldTemplates.InputFieldInputText);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailInputField1InputText.Name = "PlayFabPlayerProfileDetailInputField1InputText";
                    _playFabPlayerProfileDetailInputField1InputText.LineNumber = 14;
                    _playFabPlayerProfileDetailInputField1InputText.LinePosition = 6;
#endif
                }
                return _playFabPlayerProfileDetailInputField1InputText;
            }
        }

        private static Template _playFabPlayerProfileDetailGroup2;
        public static Template PlayFabPlayerProfileDetailGroup2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailGroup2 == null || _playFabPlayerProfileDetailGroup2.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailGroup2 == null)
#endif
                {
                    _playFabPlayerProfileDetailGroup2 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailGroup2.Name = "PlayFabPlayerProfileDetailGroup2";
                    _playFabPlayerProfileDetailGroup2.LineNumber = 13;
                    _playFabPlayerProfileDetailGroup2.LinePosition = 8;
#endif
                }
                return _playFabPlayerProfileDetailGroup2;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel5;
        public static Template PlayFabPlayerProfileDetailLabel5
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel5 == null || _playFabPlayerProfileDetailLabel5.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel5 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel5 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel5.Name = "PlayFabPlayerProfileDetailLabel5";
                    _playFabPlayerProfileDetailLabel5.LineNumber = 14;
                    _playFabPlayerProfileDetailLabel5.LinePosition = 10;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabPlayerProfileDetailLabel5, "Friends");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabPlayerProfileDetailLabel5, Delight.AutoSize.Default);
                    Delight.Label.FontSizeProperty.SetDefault(_playFabPlayerProfileDetailLabel5, 24f);
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel5, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel5, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.AlignmentProperty.SetDefault(_playFabPlayerProfileDetailLabel5, Delight.ElementAlignment.Left);
                }
                return _playFabPlayerProfileDetailLabel5;
            }
        }

        private static Template _playFabPlayerProfileDetailList1;
        public static Template PlayFabPlayerProfileDetailList1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailList1 == null || _playFabPlayerProfileDetailList1.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailList1 == null)
#endif
                {
                    _playFabPlayerProfileDetailList1 = new Template(ListTemplates.List);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailList1.Name = "PlayFabPlayerProfileDetailList1";
                    _playFabPlayerProfileDetailList1.LineNumber = 15;
                    _playFabPlayerProfileDetailList1.LinePosition = 10;
#endif
                    Delight.List.CanSelectProperty.SetDefault(_playFabPlayerProfileDetailList1, false);
                    Delight.List.BackgroundColorProperty.SetDefault(_playFabPlayerProfileDetailList1, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.List.SpacingProperty.SetDefault(_playFabPlayerProfileDetailList1, new ElementSize(10f, ElementSizeUnit.Pixels));
                    Delight.List.AlignmentProperty.SetDefault(_playFabPlayerProfileDetailList1, Delight.ElementAlignment.Left);
                    Delight.List.ItemsProperty.SetHasBinding(_playFabPlayerProfileDetailList1);
                    Delight.List.ScrollableRegionTemplateProperty.SetDefault(_playFabPlayerProfileDetailList1, PlayFabPlayerProfileDetailList1ScrollableRegion);
                }
                return _playFabPlayerProfileDetailList1;
            }
        }

        private static Template _playFabPlayerProfileDetailList1ScrollableRegion;
        public static Template PlayFabPlayerProfileDetailList1ScrollableRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailList1ScrollableRegion == null || _playFabPlayerProfileDetailList1ScrollableRegion.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailList1ScrollableRegion == null)
#endif
                {
                    _playFabPlayerProfileDetailList1ScrollableRegion = new Template(ListTemplates.ListScrollableRegion);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailList1ScrollableRegion.Name = "PlayFabPlayerProfileDetailList1ScrollableRegion";
                    _playFabPlayerProfileDetailList1ScrollableRegion.LineNumber = 29;
                    _playFabPlayerProfileDetailList1ScrollableRegion.LinePosition = 4;
#endif
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_playFabPlayerProfileDetailList1ScrollableRegion, PlayFabPlayerProfileDetailList1ScrollableRegionContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_playFabPlayerProfileDetailList1ScrollableRegion, PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_playFabPlayerProfileDetailList1ScrollableRegion, PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar);
                }
                return _playFabPlayerProfileDetailList1ScrollableRegion;
            }
        }

        private static Template _playFabPlayerProfileDetailList1ScrollableRegionContentRegion;
        public static Template PlayFabPlayerProfileDetailList1ScrollableRegionContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailList1ScrollableRegionContentRegion == null || _playFabPlayerProfileDetailList1ScrollableRegionContentRegion.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailList1ScrollableRegionContentRegion == null)
#endif
                {
                    _playFabPlayerProfileDetailList1ScrollableRegionContentRegion = new Template(ListTemplates.ListScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailList1ScrollableRegionContentRegion.Name = "PlayFabPlayerProfileDetailList1ScrollableRegionContentRegion";
                    _playFabPlayerProfileDetailList1ScrollableRegionContentRegion.LineNumber = 24;
                    _playFabPlayerProfileDetailList1ScrollableRegionContentRegion.LinePosition = 4;
#endif
                }
                return _playFabPlayerProfileDetailList1ScrollableRegionContentRegion;
            }
        }

        private static Template _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar;
        public static Template PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar == null || _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar == null)
#endif
                {
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar.Name = "PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar";
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar.LineNumber = 26;
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar, PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar, PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle);
                }
                return _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbar;
            }
        }

        private static Template _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar;
        public static Template PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar == null || _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar == null)
#endif
                {
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar.Name = "PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar";
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar.LineNumber = 7;
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarBar;
            }
        }

        private static Template _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle;
        public static Template PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle == null || _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle == null)
#endif
                {
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle.Name = "PlayFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle";
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle.LineNumber = 8;
                    _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _playFabPlayerProfileDetailList1ScrollableRegionHorizontalScrollbarHandle;
            }
        }

        private static Template _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar;
        public static Template PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar == null || _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar == null)
#endif
                {
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar.Name = "PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar";
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar.LineNumber = 27;
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar, PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar, PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle);
                }
                return _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbar;
            }
        }

        private static Template _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar;
        public static Template PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar == null || _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar == null)
#endif
                {
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar.Name = "PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar";
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar.LineNumber = 7;
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarBar;
            }
        }

        private static Template _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle;
        public static Template PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle == null || _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle == null)
#endif
                {
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle = new Template(ListTemplates.ListScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle.Name = "PlayFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle";
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle.LineNumber = 8;
                    _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _playFabPlayerProfileDetailList1ScrollableRegionVerticalScrollbarHandle;
            }
        }

        private static Template _playFabPlayerProfileDetailListItem1;
        public static Template PlayFabPlayerProfileDetailListItem1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailListItem1 == null || _playFabPlayerProfileDetailListItem1.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailListItem1 == null)
#endif
                {
                    _playFabPlayerProfileDetailListItem1 = new Template(ListItemTemplates.ListItem);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailListItem1.Name = "PlayFabPlayerProfileDetailListItem1";
                    _playFabPlayerProfileDetailListItem1.LineNumber = 17;
                    _playFabPlayerProfileDetailListItem1.LinePosition = 12;
#endif
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Highlighted", _playFabPlayerProfileDetailListItem1, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.ListItem.BackgroundColorProperty.SetStateDefault("Selected", _playFabPlayerProfileDetailListItem1, new UnityEngine.Color(0f, 0f, 0f, 0f));
                    Delight.ListItem.WidthProperty.SetDefault(_playFabPlayerProfileDetailListItem1, new ElementSize(400f, ElementSizeUnit.Pixels));
                    Delight.ListItem.HeightProperty.SetDefault(_playFabPlayerProfileDetailListItem1, new ElementSize(64f, ElementSizeUnit.Pixels));
                }
                return _playFabPlayerProfileDetailListItem1;
            }
        }

        private static Template _playFabPlayerProfileDetailGrid2;
        public static Template PlayFabPlayerProfileDetailGrid2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailGrid2 == null || _playFabPlayerProfileDetailGrid2.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailGrid2 == null)
#endif
                {
                    _playFabPlayerProfileDetailGrid2 = new Template(LayoutGridTemplates.LayoutGrid);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailGrid2.Name = "PlayFabPlayerProfileDetailGrid2";
                    _playFabPlayerProfileDetailGrid2.LineNumber = 19;
                    _playFabPlayerProfileDetailGrid2.LinePosition = 14;
#endif
                    Delight.LayoutGrid.RowsProperty.SetDefault(_playFabPlayerProfileDetailGrid2, new RowDefinitions { new RowDefinition(new ElementSize(30f, ElementSizeUnit.Pixels)), new RowDefinition(new ElementSize(30f, ElementSizeUnit.Pixels))});
                    Delight.LayoutGrid.ColumnsProperty.SetDefault(_playFabPlayerProfileDetailGrid2, new ColumnDefinitions { new ColumnDefinition(new ElementSize(200f, ElementSizeUnit.Pixels), 20f), new ColumnDefinition(new ElementSize(320f, ElementSizeUnit.Pixels), 20f)});
                    Delight.LayoutGrid.WidthProperty.SetDefault(_playFabPlayerProfileDetailGrid2, new ElementSize(520f, ElementSizeUnit.Pixels));
                    Delight.LayoutGrid.HeightProperty.SetDefault(_playFabPlayerProfileDetailGrid2, new ElementSize(64f, ElementSizeUnit.Pixels));
                    Delight.LayoutGrid.RowSpacingProperty.SetDefault(_playFabPlayerProfileDetailGrid2, new ElementSize(2f, ElementSizeUnit.Pixels));
                    Delight.LayoutGrid.AlignmentProperty.SetDefault(_playFabPlayerProfileDetailGrid2, Delight.ElementAlignment.Left);
                }
                return _playFabPlayerProfileDetailGrid2;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel6;
        public static Template PlayFabPlayerProfileDetailLabel6
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel6 == null || _playFabPlayerProfileDetailLabel6.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel6 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel6 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel6.Name = "PlayFabPlayerProfileDetailLabel6";
                    _playFabPlayerProfileDetailLabel6.LineNumber = 20;
                    _playFabPlayerProfileDetailLabel6.LinePosition = 16;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabPlayerProfileDetailLabel6, "Id");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabPlayerProfileDetailLabel6, Delight.AutoSize.Default);
                    Delight.Label.FontStyleProperty.SetDefault(_playFabPlayerProfileDetailLabel6, TMPro.FontStyles.Bold);
                    Delight.Label.OffsetProperty.SetDefault(_playFabPlayerProfileDetailLabel6, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel6, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel6, Assets.TMP_FontAssets["Segoe UI SDF"]);
                }
                return _playFabPlayerProfileDetailLabel6;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel7;
        public static Template PlayFabPlayerProfileDetailLabel7
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel7 == null || _playFabPlayerProfileDetailLabel7.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel7 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel7 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel7.Name = "PlayFabPlayerProfileDetailLabel7";
                    _playFabPlayerProfileDetailLabel7.LineNumber = 21;
                    _playFabPlayerProfileDetailLabel7.LinePosition = 16;
#endif
                    Delight.Label.WidthProperty.SetDefault(_playFabPlayerProfileDetailLabel7, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel7, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel7, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.TextProperty.SetHasBinding(_playFabPlayerProfileDetailLabel7);
                }
                return _playFabPlayerProfileDetailLabel7;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel8;
        public static Template PlayFabPlayerProfileDetailLabel8
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel8 == null || _playFabPlayerProfileDetailLabel8.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel8 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel8 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel8.Name = "PlayFabPlayerProfileDetailLabel8";
                    _playFabPlayerProfileDetailLabel8.LineNumber = 23;
                    _playFabPlayerProfileDetailLabel8.LinePosition = 16;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabPlayerProfileDetailLabel8, "DisplayName");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabPlayerProfileDetailLabel8, Delight.AutoSize.Default);
                    Delight.Label.FontStyleProperty.SetDefault(_playFabPlayerProfileDetailLabel8, TMPro.FontStyles.Bold);
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel8, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel8, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.OffsetProperty.SetDefault(_playFabPlayerProfileDetailLabel8, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                }
                return _playFabPlayerProfileDetailLabel8;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel9;
        public static Template PlayFabPlayerProfileDetailLabel9
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel9 == null || _playFabPlayerProfileDetailLabel9.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel9 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel9 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel9.Name = "PlayFabPlayerProfileDetailLabel9";
                    _playFabPlayerProfileDetailLabel9.LineNumber = 24;
                    _playFabPlayerProfileDetailLabel9.LinePosition = 16;
#endif
                    Delight.Label.WidthProperty.SetDefault(_playFabPlayerProfileDetailLabel9, new ElementSize(1f, ElementSizeUnit.Percents));
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel9, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel9, Assets.TMP_FontAssets["Segoe UI SDF"]);
                    Delight.Label.TextProperty.SetHasBinding(_playFabPlayerProfileDetailLabel9);
                }
                return _playFabPlayerProfileDetailLabel9;
            }
        }

        private static Template _playFabPlayerProfileDetailGroup3;
        public static Template PlayFabPlayerProfileDetailGroup3
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailGroup3 == null || _playFabPlayerProfileDetailGroup3.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailGroup3 == null)
#endif
                {
                    _playFabPlayerProfileDetailGroup3 = new Template(GroupTemplates.Group);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailGroup3.Name = "PlayFabPlayerProfileDetailGroup3";
                    _playFabPlayerProfileDetailGroup3.LineNumber = 29;
                    _playFabPlayerProfileDetailGroup3.LinePosition = 10;
#endif
                    Delight.Group.OrientationProperty.SetDefault(_playFabPlayerProfileDetailGroup3, Delight.ElementOrientation.Horizontal);
                    Delight.Group.AlignmentProperty.SetDefault(_playFabPlayerProfileDetailGroup3, Delight.ElementAlignment.Left);
                    Delight.Group.SpacingProperty.SetDefault(_playFabPlayerProfileDetailGroup3, new ElementSize(5f, ElementSizeUnit.Pixels));
                }
                return _playFabPlayerProfileDetailGroup3;
            }
        }

        private static Template _playFabPlayerProfileDetailButton1;
        public static Template PlayFabPlayerProfileDetailButton1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailButton1 == null || _playFabPlayerProfileDetailButton1.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailButton1 == null)
#endif
                {
                    _playFabPlayerProfileDetailButton1 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailButton1.Name = "PlayFabPlayerProfileDetailButton1";
                    _playFabPlayerProfileDetailButton1.LineNumber = 30;
                    _playFabPlayerProfileDetailButton1.LinePosition = 12;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabPlayerProfileDetailButton1, PlayFabPlayerProfileDetailButton1Label);
                }
                return _playFabPlayerProfileDetailButton1;
            }
        }

        private static Template _playFabPlayerProfileDetailButton1Label;
        public static Template PlayFabPlayerProfileDetailButton1Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailButton1Label == null || _playFabPlayerProfileDetailButton1Label.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailButton1Label == null)
#endif
                {
                    _playFabPlayerProfileDetailButton1Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailButton1Label.Name = "PlayFabPlayerProfileDetailButton1Label";
                    _playFabPlayerProfileDetailButton1Label.LineNumber = 15;
                    _playFabPlayerProfileDetailButton1Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabPlayerProfileDetailButton1Label, "Add Friend");
                }
                return _playFabPlayerProfileDetailButton1Label;
            }
        }

        private static Template _playFabPlayerProfileDetailButton2;
        public static Template PlayFabPlayerProfileDetailButton2
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailButton2 == null || _playFabPlayerProfileDetailButton2.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailButton2 == null)
#endif
                {
                    _playFabPlayerProfileDetailButton2 = new Template(ButtonTemplates.Button);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailButton2.Name = "PlayFabPlayerProfileDetailButton2";
                    _playFabPlayerProfileDetailButton2.LineNumber = 31;
                    _playFabPlayerProfileDetailButton2.LinePosition = 12;
#endif
                    Delight.Button.LabelTemplateProperty.SetDefault(_playFabPlayerProfileDetailButton2, PlayFabPlayerProfileDetailButton2Label);
                }
                return _playFabPlayerProfileDetailButton2;
            }
        }

        private static Template _playFabPlayerProfileDetailButton2Label;
        public static Template PlayFabPlayerProfileDetailButton2Label
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailButton2Label == null || _playFabPlayerProfileDetailButton2Label.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailButton2Label == null)
#endif
                {
                    _playFabPlayerProfileDetailButton2Label = new Template(ButtonTemplates.ButtonLabel);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailButton2Label.Name = "PlayFabPlayerProfileDetailButton2Label";
                    _playFabPlayerProfileDetailButton2Label.LineNumber = 15;
                    _playFabPlayerProfileDetailButton2Label.LinePosition = 4;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabPlayerProfileDetailButton2Label, "Remove Friend");
                }
                return _playFabPlayerProfileDetailButton2Label;
            }
        }

        private static Template _playFabPlayerProfileDetailRegion1;
        public static Template PlayFabPlayerProfileDetailRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailRegion1 == null || _playFabPlayerProfileDetailRegion1.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailRegion1 == null)
#endif
                {
                    _playFabPlayerProfileDetailRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailRegion1.Name = "PlayFabPlayerProfileDetailRegion1";
                    _playFabPlayerProfileDetailRegion1.LineNumber = 36;
                    _playFabPlayerProfileDetailRegion1.LinePosition = 4;
#endif
                    Delight.Region.IsActiveProperty.SetHasBinding(_playFabPlayerProfileDetailRegion1);
                }
                return _playFabPlayerProfileDetailRegion1;
            }
        }

        private static Template _playFabPlayerProfileDetailLabel10;
        public static Template PlayFabPlayerProfileDetailLabel10
        {
            get
            {
#if UNITY_EDITOR
                if (_playFabPlayerProfileDetailLabel10 == null || _playFabPlayerProfileDetailLabel10.CurrentVersion != Template.Version)
#else
                if (_playFabPlayerProfileDetailLabel10 == null)
#endif
                {
                    _playFabPlayerProfileDetailLabel10 = new Template(LabelTemplates.Label);
#if UNITY_EDITOR
                    _playFabPlayerProfileDetailLabel10.Name = "PlayFabPlayerProfileDetailLabel10";
                    _playFabPlayerProfileDetailLabel10.LineNumber = 37;
                    _playFabPlayerProfileDetailLabel10.LinePosition = 6;
#endif
                    Delight.Label.TextProperty.SetDefault(_playFabPlayerProfileDetailLabel10, "Player must be logged in to see this view");
                    Delight.Label.AutoSizeProperty.SetDefault(_playFabPlayerProfileDetailLabel10, Delight.AutoSize.Default);
                    Delight.Label.FontStyleProperty.SetDefault(_playFabPlayerProfileDetailLabel10, TMPro.FontStyles.Bold);
                    Delight.Label.OffsetProperty.SetDefault(_playFabPlayerProfileDetailLabel10, new ElementMargin(new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels), new ElementSize(0f, ElementSizeUnit.Pixels)));
                    Delight.Label.FontColorProperty.SetDefault(_playFabPlayerProfileDetailLabel10, new UnityEngine.Color(1f, 1f, 1f, 1f));
                    Delight.Label.FontProperty.SetDefault(_playFabPlayerProfileDetailLabel10, Assets.TMP_FontAssets["Segoe UI SDF"]);
                }
                return _playFabPlayerProfileDetailLabel10;
            }
        }

        #endregion
    }

    #endregion
}

#endif
