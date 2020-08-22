// Internal view logic generated from "GridExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class GridExample : LayoutRoot
    {
        #region Constructors

        public GridExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? GridExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Grid (Grid1)
            Grid1 = new LayoutGrid(this, this, "Grid1", Grid1Template);
            Cell00 = new Region(this, Grid1.Content, "Cell00", Cell00Template);
            Grid1.Cell.SetValue(Cell00, new CellIndex(0, 0));
            Cell01 = new Region(this, Grid1.Content, "Cell01", Cell01Template);
            Grid1.Cell.SetValue(Cell01, new CellIndex(0, 1));
            Cell02 = new Region(this, Grid1.Content, "Cell02", Cell02Template);
            Grid1.Cell.SetValue(Cell02, new CellIndex(0, 2));
            Cell10 = new Region(this, Grid1.Content, "Cell10", Cell10Template);
            Grid1.Cell.SetValue(Cell10, new CellIndex(1, 0));
            Cell11 = new Region(this, Grid1.Content, "Cell11", Cell11Template);
            Grid1.Cell.SetValue(Cell11, new CellIndex(1, 1));
            Cell12 = new Region(this, Grid1.Content, "Cell12", Cell12Template);
            Grid1.Cell.SetValue(Cell12, new CellIndex(1, 2));
            Cell20 = new Region(this, Grid1.Content, "Cell20", Cell20Template);
            Grid1.Cell.SetValue(Cell20, new CellIndex(2, 0));
            Cell21 = new Region(this, Grid1.Content, "Cell21", Cell21Template);
            Grid1.Cell.SetValue(Cell21, new CellIndex(2, 1));
            Cell22 = new Region(this, Grid1.Content, "Cell22", Cell22Template);
            Grid1.Cell.SetValue(Cell22, new CellIndex(2, 2));
            GridSplitter1 = new GridSplitter(this, Grid1.Content, "GridSplitter1", GridSplitter1Template);
            this.AfterInitializeInternal();
        }

        public GridExample() : this(null)
        {
        }

        static GridExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(GridExampleTemplates.Default, dependencyProperties);

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
            dependencyProperties.Add(GridSplitter1Property);
            dependencyProperties.Add(GridSplitter1TemplateProperty);
        }

        #endregion

        #region Properties

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

        public readonly static DependencyProperty<GridSplitter> GridSplitter1Property = new DependencyProperty<GridSplitter>("GridSplitter1");
        public GridSplitter GridSplitter1
        {
            get { return GridSplitter1Property.GetValue(this); }
            set { GridSplitter1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> GridSplitter1TemplateProperty = new DependencyProperty<Template>("GridSplitter1Template");
        public Template GridSplitter1Template
        {
            get { return GridSplitter1TemplateProperty.GetValue(this); }
            set { GridSplitter1TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class GridExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return GridExample;
            }
        }

        private static Template _gridExample;
        public static Template GridExample
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExample == null || _gridExample.CurrentVersion != Template.Version)
#else
                if (_gridExample == null)
#endif
                {
                    _gridExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _gridExample.Name = "GridExample";
                    _gridExample.LineNumber = 0;
                    _gridExample.LinePosition = 0;
#endif
                    Delight.GridExample.Grid1TemplateProperty.SetDefault(_gridExample, GridExampleGrid1);
                    Delight.GridExample.Cell00TemplateProperty.SetDefault(_gridExample, GridExampleCell00);
                    Delight.GridExample.Cell01TemplateProperty.SetDefault(_gridExample, GridExampleCell01);
                    Delight.GridExample.Cell02TemplateProperty.SetDefault(_gridExample, GridExampleCell02);
                    Delight.GridExample.Cell10TemplateProperty.SetDefault(_gridExample, GridExampleCell10);
                    Delight.GridExample.Cell11TemplateProperty.SetDefault(_gridExample, GridExampleCell11);
                    Delight.GridExample.Cell12TemplateProperty.SetDefault(_gridExample, GridExampleCell12);
                    Delight.GridExample.Cell20TemplateProperty.SetDefault(_gridExample, GridExampleCell20);
                    Delight.GridExample.Cell21TemplateProperty.SetDefault(_gridExample, GridExampleCell21);
                    Delight.GridExample.Cell22TemplateProperty.SetDefault(_gridExample, GridExampleCell22);
                    Delight.GridExample.GridSplitter1TemplateProperty.SetDefault(_gridExample, GridExampleGridSplitter1);
                }
                return _gridExample;
            }
        }

        private static Template _gridExampleGrid1;
        public static Template GridExampleGrid1
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleGrid1 == null || _gridExampleGrid1.CurrentVersion != Template.Version)
#else
                if (_gridExampleGrid1 == null)
#endif
                {
                    _gridExampleGrid1 = new Template(LayoutGridTemplates.LayoutGrid);
#if UNITY_EDITOR
                    _gridExampleGrid1.Name = "GridExampleGrid1";
                    _gridExampleGrid1.LineNumber = 2;
                    _gridExampleGrid1.LinePosition = 4;
#endif
                    Delight.LayoutGrid.RowsProperty.SetDefault(_gridExampleGrid1, new RowDefinitions { new RowDefinition(new ElementSize(200f, ElementSizeUnit.Pixels), 20f), new RowDefinition(new ElementSize(1f, ElementSizeUnit.Proportional), 20f), new RowDefinition(new ElementSize(200f, ElementSizeUnit.Pixels), 20f)});
                    Delight.LayoutGrid.ColumnsProperty.SetDefault(_gridExampleGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(200f, ElementSizeUnit.Pixels), 20f), new ColumnDefinition(new ElementSize(1f, ElementSizeUnit.Proportional), 20f), new ColumnDefinition(new ElementSize(200f, ElementSizeUnit.Pixels), 20f)});
                    Delight.LayoutGrid.WidthProperty.SetDefault(_gridExampleGrid1, new ElementSize(600f, ElementSizeUnit.Pixels));
                    Delight.LayoutGrid.HeightProperty.SetDefault(_gridExampleGrid1, new ElementSize(600f, ElementSizeUnit.Pixels));
                }
                return _gridExampleGrid1;
            }
        }

        private static Template _gridExampleCell00;
        public static Template GridExampleCell00
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleCell00 == null || _gridExampleCell00.CurrentVersion != Template.Version)
#else
                if (_gridExampleCell00 == null)
#endif
                {
                    _gridExampleCell00 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _gridExampleCell00.Name = "GridExampleCell00";
                    _gridExampleCell00.LineNumber = 3;
                    _gridExampleCell00.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_gridExampleCell00, new UnityEngine.Color(0.3254902f, 0.5372549f, 0.8784314f, 1f));
                }
                return _gridExampleCell00;
            }
        }

        private static Template _gridExampleCell01;
        public static Template GridExampleCell01
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleCell01 == null || _gridExampleCell01.CurrentVersion != Template.Version)
#else
                if (_gridExampleCell01 == null)
#endif
                {
                    _gridExampleCell01 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _gridExampleCell01.Name = "GridExampleCell01";
                    _gridExampleCell01.LineNumber = 4;
                    _gridExampleCell01.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_gridExampleCell01, new UnityEngine.Color(0.8901961f, 0.4588235f, 0.9764706f, 1f));
                }
                return _gridExampleCell01;
            }
        }

        private static Template _gridExampleCell02;
        public static Template GridExampleCell02
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleCell02 == null || _gridExampleCell02.CurrentVersion != Template.Version)
#else
                if (_gridExampleCell02 == null)
#endif
                {
                    _gridExampleCell02 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _gridExampleCell02.Name = "GridExampleCell02";
                    _gridExampleCell02.LineNumber = 5;
                    _gridExampleCell02.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_gridExampleCell02, new UnityEngine.Color(0.454902f, 0.9764706f, 0.8352941f, 1f));
                }
                return _gridExampleCell02;
            }
        }

        private static Template _gridExampleCell10;
        public static Template GridExampleCell10
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleCell10 == null || _gridExampleCell10.CurrentVersion != Template.Version)
#else
                if (_gridExampleCell10 == null)
#endif
                {
                    _gridExampleCell10 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _gridExampleCell10.Name = "GridExampleCell10";
                    _gridExampleCell10.LineNumber = 7;
                    _gridExampleCell10.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_gridExampleCell10, new UnityEngine.Color(0.9764706f, 0.7764706f, 0.454902f, 1f));
                }
                return _gridExampleCell10;
            }
        }

        private static Template _gridExampleCell11;
        public static Template GridExampleCell11
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleCell11 == null || _gridExampleCell11.CurrentVersion != Template.Version)
#else
                if (_gridExampleCell11 == null)
#endif
                {
                    _gridExampleCell11 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _gridExampleCell11.Name = "GridExampleCell11";
                    _gridExampleCell11.LineNumber = 8;
                    _gridExampleCell11.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_gridExampleCell11, new UnityEngine.Color(0.9882353f, 0.9294118f, 0.1764706f, 1f));
                }
                return _gridExampleCell11;
            }
        }

        private static Template _gridExampleCell12;
        public static Template GridExampleCell12
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleCell12 == null || _gridExampleCell12.CurrentVersion != Template.Version)
#else
                if (_gridExampleCell12 == null)
#endif
                {
                    _gridExampleCell12 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _gridExampleCell12.Name = "GridExampleCell12";
                    _gridExampleCell12.LineNumber = 9;
                    _gridExampleCell12.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_gridExampleCell12, new UnityEngine.Color(0.172549f, 0.9686275f, 0.1843137f, 1f));
                }
                return _gridExampleCell12;
            }
        }

        private static Template _gridExampleCell20;
        public static Template GridExampleCell20
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleCell20 == null || _gridExampleCell20.CurrentVersion != Template.Version)
#else
                if (_gridExampleCell20 == null)
#endif
                {
                    _gridExampleCell20 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _gridExampleCell20.Name = "GridExampleCell20";
                    _gridExampleCell20.LineNumber = 11;
                    _gridExampleCell20.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_gridExampleCell20, new UnityEngine.Color(0.9372549f, 0.3333333f, 0.1686275f, 1f));
                }
                return _gridExampleCell20;
            }
        }

        private static Template _gridExampleCell21;
        public static Template GridExampleCell21
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleCell21 == null || _gridExampleCell21.CurrentVersion != Template.Version)
#else
                if (_gridExampleCell21 == null)
#endif
                {
                    _gridExampleCell21 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _gridExampleCell21.Name = "GridExampleCell21";
                    _gridExampleCell21.LineNumber = 12;
                    _gridExampleCell21.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_gridExampleCell21, new UnityEngine.Color(0f, 0.5294118f, 1f, 1f));
                }
                return _gridExampleCell21;
            }
        }

        private static Template _gridExampleCell22;
        public static Template GridExampleCell22
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleCell22 == null || _gridExampleCell22.CurrentVersion != Template.Version)
#else
                if (_gridExampleCell22 == null)
#endif
                {
                    _gridExampleCell22 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _gridExampleCell22.Name = "GridExampleCell22";
                    _gridExampleCell22.LineNumber = 13;
                    _gridExampleCell22.LinePosition = 6;
#endif
                    Delight.Region.BackgroundColorProperty.SetDefault(_gridExampleCell22, new UnityEngine.Color(0.5294118f, 0.1882353f, 0.6784314f, 1f));
                }
                return _gridExampleCell22;
            }
        }

        private static Template _gridExampleGridSplitter1;
        public static Template GridExampleGridSplitter1
        {
            get
            {
#if UNITY_EDITOR
                if (_gridExampleGridSplitter1 == null || _gridExampleGridSplitter1.CurrentVersion != Template.Version)
#else
                if (_gridExampleGridSplitter1 == null)
#endif
                {
                    _gridExampleGridSplitter1 = new Template(GridSplitterTemplates.GridSplitter);
#if UNITY_EDITOR
                    _gridExampleGridSplitter1.Name = "GridExampleGridSplitter1";
                    _gridExampleGridSplitter1.LineNumber = 15;
                    _gridExampleGridSplitter1.LinePosition = 6;
#endif
                    Delight.GridSplitter.ThicknessProperty.SetDefault(_gridExampleGridSplitter1, new ElementSize(5f, ElementSizeUnit.Pixels));
                    Delight.GridSplitter.InteractionThicknessProperty.SetDefault(_gridExampleGridSplitter1, new ElementSize(20f, ElementSizeUnit.Pixels));
                    Delight.GridSplitter.SplitterColorProperty.SetDefault(_gridExampleGridSplitter1, new UnityEngine.Color(0.2f, 0.2f, 0.2f, 1f));
                    Delight.GridSplitter.BePushyProperty.SetDefault(_gridExampleGridSplitter1, false);
                    Delight.GridSplitter.SetSizeOnDragEndedProperty.SetDefault(_gridExampleGridSplitter1, false);
                }
                return _gridExampleGridSplitter1;
            }
        }

        #endregion
    }

    #endregion
}
