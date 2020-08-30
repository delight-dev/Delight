// Internal view logic generated from "ScrollExample.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class ScrollExample : LayoutRoot
    {
        #region Constructors

        public ScrollExample(View parent, View layoutParent = null, string id = null, Template template = null, bool deferInitialization = false) :
            base(parent, layoutParent, id, template ?? ScrollExampleTemplates.Default, deferInitialization)
        {
            if (deferInitialization)
                return;

            // constructing Grid (Grid1)
            Grid1 = new LayoutGrid(this, this, "Grid1", Grid1Template);
            ScrollableRegion1 = new ScrollableRegion(this, Grid1.Content, "ScrollableRegion1", ScrollableRegion1Template);
            Grid1.Cell.SetValue(ScrollableRegion1, new CellIndex(0, 0));
            Region1 = new Region(this, ScrollableRegion1.Content, "Region1", Region1Template);
            Region2 = new Region(this, Region1.Content, "Region2", Region2Template);
            Region3 = new Region(this, Region1.Content, "Region3", Region3Template);
            Region4 = new Region(this, Region1.Content, "Region4", Region4Template);
            Region5 = new Region(this, Region1.Content, "Region5", Region5Template);
            ScrollableRegion2 = new ScrollableRegion(this, Grid1.Content, "ScrollableRegion2", ScrollableRegion2Template);
            Grid1.Cell.SetValue(ScrollableRegion2, new CellIndex(0, 1));
            Region6 = new Region(this, ScrollableRegion2.Content, "Region6", Region6Template);
            Region7 = new Region(this, Region6.Content, "Region7", Region7Template);
            Region8 = new Region(this, Region6.Content, "Region8", Region8Template);
            Region9 = new Region(this, Region6.Content, "Region9", Region9Template);
            Region10 = new Region(this, Region6.Content, "Region10", Region10Template);
            ScrollableRegion3 = new ScrollableRegion(this, Grid1.Content, "ScrollableRegion3", ScrollableRegion3Template);
            Grid1.Cell.SetValue(ScrollableRegion3, new CellIndex(0, 2));
            Region11 = new Region(this, ScrollableRegion3.Content, "Region11", Region11Template);
            Region12 = new Region(this, Region11.Content, "Region12", Region12Template);
            Region13 = new Region(this, Region11.Content, "Region13", Region13Template);
            Region14 = new Region(this, Region11.Content, "Region14", Region14Template);
            Region15 = new Region(this, Region11.Content, "Region15", Region15Template);
            ScrollableRegion4 = new ScrollableRegion(this, Grid1.Content, "ScrollableRegion4", ScrollableRegion4Template);
            Grid1.Cell.SetValue(ScrollableRegion4, new CellIndex(1, 0));
            Region16 = new Region(this, ScrollableRegion4.Content, "Region16", Region16Template);
            Region17 = new Region(this, Region16.Content, "Region17", Region17Template);
            Region18 = new Region(this, Region16.Content, "Region18", Region18Template);
            Region19 = new Region(this, Region16.Content, "Region19", Region19Template);
            Region20 = new Region(this, Region16.Content, "Region20", Region20Template);
            ScrollableRegion5 = new ScrollableRegion(this, Grid1.Content, "ScrollableRegion5", ScrollableRegion5Template);
            Grid1.Cell.SetValue(ScrollableRegion5, new CellIndex(1, 1));
            Region21 = new Region(this, ScrollableRegion5.Content, "Region21", Region21Template);
            Region22 = new Region(this, Region21.Content, "Region22", Region22Template);
            Region23 = new Region(this, Region21.Content, "Region23", Region23Template);
            Region24 = new Region(this, Region21.Content, "Region24", Region24Template);
            Region25 = new Region(this, Region21.Content, "Region25", Region25Template);
            ScrollableRegion6 = new ScrollableRegion(this, Grid1.Content, "ScrollableRegion6", ScrollableRegion6Template);
            Grid1.Cell.SetValue(ScrollableRegion6, new CellIndex(1, 2));
            Region26 = new Region(this, ScrollableRegion6.Content, "Region26", Region26Template);
            Region27 = new Region(this, Region26.Content, "Region27", Region27Template);
            Region28 = new Region(this, Region26.Content, "Region28", Region28Template);
            Region29 = new Region(this, Region26.Content, "Region29", Region29Template);
            Region30 = new Region(this, Region26.Content, "Region30", Region30Template);
            ScrollableRegion7 = new ScrollableRegion(this, Grid1.Content, "ScrollableRegion7", ScrollableRegion7Template);
            Grid1.Cell.SetValue(ScrollableRegion7, new CellIndex(2, 0));
            Region31 = new Region(this, ScrollableRegion7.Content, "Region31", Region31Template);
            Region32 = new Region(this, Region31.Content, "Region32", Region32Template);
            Region33 = new Region(this, Region31.Content, "Region33", Region33Template);
            Region34 = new Region(this, Region31.Content, "Region34", Region34Template);
            Region35 = new Region(this, Region31.Content, "Region35", Region35Template);
            ScrollableRegion8 = new ScrollableRegion(this, Grid1.Content, "ScrollableRegion8", ScrollableRegion8Template);
            Grid1.Cell.SetValue(ScrollableRegion8, new CellIndex(2, 1));
            Region36 = new Region(this, ScrollableRegion8.Content, "Region36", Region36Template);
            Region37 = new Region(this, Region36.Content, "Region37", Region37Template);
            Region38 = new Region(this, Region36.Content, "Region38", Region38Template);
            Region39 = new Region(this, Region36.Content, "Region39", Region39Template);
            Region40 = new Region(this, Region36.Content, "Region40", Region40Template);
            ScrollableRegion9 = new ScrollableRegion(this, Grid1.Content, "ScrollableRegion9", ScrollableRegion9Template);
            Grid1.Cell.SetValue(ScrollableRegion9, new CellIndex(2, 2));
            Region41 = new Region(this, ScrollableRegion9.Content, "Region41", Region41Template);
            Region42 = new Region(this, Region41.Content, "Region42", Region42Template);
            Region43 = new Region(this, Region41.Content, "Region43", Region43Template);
            Region44 = new Region(this, Region41.Content, "Region44", Region44Template);
            Region45 = new Region(this, Region41.Content, "Region45", Region45Template);
            this.AfterInitializeInternal();
        }

        public ScrollExample() : this(null)
        {
        }

        static ScrollExample()
        {
            var dependencyProperties = new List<DependencyProperty>();
            DependencyProperties.Add(ScrollExampleTemplates.Default, dependencyProperties);

            dependencyProperties.Add(Grid1Property);
            dependencyProperties.Add(Grid1TemplateProperty);
            dependencyProperties.Add(ScrollableRegion1Property);
            dependencyProperties.Add(ScrollableRegion1TemplateProperty);
            dependencyProperties.Add(Region1Property);
            dependencyProperties.Add(Region1TemplateProperty);
            dependencyProperties.Add(Region2Property);
            dependencyProperties.Add(Region2TemplateProperty);
            dependencyProperties.Add(Region3Property);
            dependencyProperties.Add(Region3TemplateProperty);
            dependencyProperties.Add(Region4Property);
            dependencyProperties.Add(Region4TemplateProperty);
            dependencyProperties.Add(Region5Property);
            dependencyProperties.Add(Region5TemplateProperty);
            dependencyProperties.Add(ScrollableRegion2Property);
            dependencyProperties.Add(ScrollableRegion2TemplateProperty);
            dependencyProperties.Add(Region6Property);
            dependencyProperties.Add(Region6TemplateProperty);
            dependencyProperties.Add(Region7Property);
            dependencyProperties.Add(Region7TemplateProperty);
            dependencyProperties.Add(Region8Property);
            dependencyProperties.Add(Region8TemplateProperty);
            dependencyProperties.Add(Region9Property);
            dependencyProperties.Add(Region9TemplateProperty);
            dependencyProperties.Add(Region10Property);
            dependencyProperties.Add(Region10TemplateProperty);
            dependencyProperties.Add(ScrollableRegion3Property);
            dependencyProperties.Add(ScrollableRegion3TemplateProperty);
            dependencyProperties.Add(Region11Property);
            dependencyProperties.Add(Region11TemplateProperty);
            dependencyProperties.Add(Region12Property);
            dependencyProperties.Add(Region12TemplateProperty);
            dependencyProperties.Add(Region13Property);
            dependencyProperties.Add(Region13TemplateProperty);
            dependencyProperties.Add(Region14Property);
            dependencyProperties.Add(Region14TemplateProperty);
            dependencyProperties.Add(Region15Property);
            dependencyProperties.Add(Region15TemplateProperty);
            dependencyProperties.Add(ScrollableRegion4Property);
            dependencyProperties.Add(ScrollableRegion4TemplateProperty);
            dependencyProperties.Add(Region16Property);
            dependencyProperties.Add(Region16TemplateProperty);
            dependencyProperties.Add(Region17Property);
            dependencyProperties.Add(Region17TemplateProperty);
            dependencyProperties.Add(Region18Property);
            dependencyProperties.Add(Region18TemplateProperty);
            dependencyProperties.Add(Region19Property);
            dependencyProperties.Add(Region19TemplateProperty);
            dependencyProperties.Add(Region20Property);
            dependencyProperties.Add(Region20TemplateProperty);
            dependencyProperties.Add(ScrollableRegion5Property);
            dependencyProperties.Add(ScrollableRegion5TemplateProperty);
            dependencyProperties.Add(Region21Property);
            dependencyProperties.Add(Region21TemplateProperty);
            dependencyProperties.Add(Region22Property);
            dependencyProperties.Add(Region22TemplateProperty);
            dependencyProperties.Add(Region23Property);
            dependencyProperties.Add(Region23TemplateProperty);
            dependencyProperties.Add(Region24Property);
            dependencyProperties.Add(Region24TemplateProperty);
            dependencyProperties.Add(Region25Property);
            dependencyProperties.Add(Region25TemplateProperty);
            dependencyProperties.Add(ScrollableRegion6Property);
            dependencyProperties.Add(ScrollableRegion6TemplateProperty);
            dependencyProperties.Add(Region26Property);
            dependencyProperties.Add(Region26TemplateProperty);
            dependencyProperties.Add(Region27Property);
            dependencyProperties.Add(Region27TemplateProperty);
            dependencyProperties.Add(Region28Property);
            dependencyProperties.Add(Region28TemplateProperty);
            dependencyProperties.Add(Region29Property);
            dependencyProperties.Add(Region29TemplateProperty);
            dependencyProperties.Add(Region30Property);
            dependencyProperties.Add(Region30TemplateProperty);
            dependencyProperties.Add(ScrollableRegion7Property);
            dependencyProperties.Add(ScrollableRegion7TemplateProperty);
            dependencyProperties.Add(Region31Property);
            dependencyProperties.Add(Region31TemplateProperty);
            dependencyProperties.Add(Region32Property);
            dependencyProperties.Add(Region32TemplateProperty);
            dependencyProperties.Add(Region33Property);
            dependencyProperties.Add(Region33TemplateProperty);
            dependencyProperties.Add(Region34Property);
            dependencyProperties.Add(Region34TemplateProperty);
            dependencyProperties.Add(Region35Property);
            dependencyProperties.Add(Region35TemplateProperty);
            dependencyProperties.Add(ScrollableRegion8Property);
            dependencyProperties.Add(ScrollableRegion8TemplateProperty);
            dependencyProperties.Add(Region36Property);
            dependencyProperties.Add(Region36TemplateProperty);
            dependencyProperties.Add(Region37Property);
            dependencyProperties.Add(Region37TemplateProperty);
            dependencyProperties.Add(Region38Property);
            dependencyProperties.Add(Region38TemplateProperty);
            dependencyProperties.Add(Region39Property);
            dependencyProperties.Add(Region39TemplateProperty);
            dependencyProperties.Add(Region40Property);
            dependencyProperties.Add(Region40TemplateProperty);
            dependencyProperties.Add(ScrollableRegion9Property);
            dependencyProperties.Add(ScrollableRegion9TemplateProperty);
            dependencyProperties.Add(Region41Property);
            dependencyProperties.Add(Region41TemplateProperty);
            dependencyProperties.Add(Region42Property);
            dependencyProperties.Add(Region42TemplateProperty);
            dependencyProperties.Add(Region43Property);
            dependencyProperties.Add(Region43TemplateProperty);
            dependencyProperties.Add(Region44Property);
            dependencyProperties.Add(Region44TemplateProperty);
            dependencyProperties.Add(Region45Property);
            dependencyProperties.Add(Region45TemplateProperty);
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

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegion1Property = new DependencyProperty<ScrollableRegion>("ScrollableRegion1");
        public ScrollableRegion ScrollableRegion1
        {
            get { return ScrollableRegion1Property.GetValue(this); }
            set { ScrollableRegion1Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegion1TemplateProperty = new DependencyProperty<Template>("ScrollableRegion1Template");
        public Template ScrollableRegion1Template
        {
            get { return ScrollableRegion1TemplateProperty.GetValue(this); }
            set { ScrollableRegion1TemplateProperty.SetValue(this, value); }
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

        public readonly static DependencyProperty<Region> Region2Property = new DependencyProperty<Region>("Region2");
        public Region Region2
        {
            get { return Region2Property.GetValue(this); }
            set { Region2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region2TemplateProperty = new DependencyProperty<Template>("Region2Template");
        public Template Region2Template
        {
            get { return Region2TemplateProperty.GetValue(this); }
            set { Region2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region3Property = new DependencyProperty<Region>("Region3");
        public Region Region3
        {
            get { return Region3Property.GetValue(this); }
            set { Region3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region3TemplateProperty = new DependencyProperty<Template>("Region3Template");
        public Template Region3Template
        {
            get { return Region3TemplateProperty.GetValue(this); }
            set { Region3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region4Property = new DependencyProperty<Region>("Region4");
        public Region Region4
        {
            get { return Region4Property.GetValue(this); }
            set { Region4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region4TemplateProperty = new DependencyProperty<Template>("Region4Template");
        public Template Region4Template
        {
            get { return Region4TemplateProperty.GetValue(this); }
            set { Region4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region5Property = new DependencyProperty<Region>("Region5");
        public Region Region5
        {
            get { return Region5Property.GetValue(this); }
            set { Region5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region5TemplateProperty = new DependencyProperty<Template>("Region5Template");
        public Template Region5Template
        {
            get { return Region5TemplateProperty.GetValue(this); }
            set { Region5TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegion2Property = new DependencyProperty<ScrollableRegion>("ScrollableRegion2");
        public ScrollableRegion ScrollableRegion2
        {
            get { return ScrollableRegion2Property.GetValue(this); }
            set { ScrollableRegion2Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegion2TemplateProperty = new DependencyProperty<Template>("ScrollableRegion2Template");
        public Template ScrollableRegion2Template
        {
            get { return ScrollableRegion2TemplateProperty.GetValue(this); }
            set { ScrollableRegion2TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region6Property = new DependencyProperty<Region>("Region6");
        public Region Region6
        {
            get { return Region6Property.GetValue(this); }
            set { Region6Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region6TemplateProperty = new DependencyProperty<Template>("Region6Template");
        public Template Region6Template
        {
            get { return Region6TemplateProperty.GetValue(this); }
            set { Region6TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region7Property = new DependencyProperty<Region>("Region7");
        public Region Region7
        {
            get { return Region7Property.GetValue(this); }
            set { Region7Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region7TemplateProperty = new DependencyProperty<Template>("Region7Template");
        public Template Region7Template
        {
            get { return Region7TemplateProperty.GetValue(this); }
            set { Region7TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region8Property = new DependencyProperty<Region>("Region8");
        public Region Region8
        {
            get { return Region8Property.GetValue(this); }
            set { Region8Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region8TemplateProperty = new DependencyProperty<Template>("Region8Template");
        public Template Region8Template
        {
            get { return Region8TemplateProperty.GetValue(this); }
            set { Region8TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region9Property = new DependencyProperty<Region>("Region9");
        public Region Region9
        {
            get { return Region9Property.GetValue(this); }
            set { Region9Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region9TemplateProperty = new DependencyProperty<Template>("Region9Template");
        public Template Region9Template
        {
            get { return Region9TemplateProperty.GetValue(this); }
            set { Region9TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region10Property = new DependencyProperty<Region>("Region10");
        public Region Region10
        {
            get { return Region10Property.GetValue(this); }
            set { Region10Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region10TemplateProperty = new DependencyProperty<Template>("Region10Template");
        public Template Region10Template
        {
            get { return Region10TemplateProperty.GetValue(this); }
            set { Region10TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegion3Property = new DependencyProperty<ScrollableRegion>("ScrollableRegion3");
        public ScrollableRegion ScrollableRegion3
        {
            get { return ScrollableRegion3Property.GetValue(this); }
            set { ScrollableRegion3Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegion3TemplateProperty = new DependencyProperty<Template>("ScrollableRegion3Template");
        public Template ScrollableRegion3Template
        {
            get { return ScrollableRegion3TemplateProperty.GetValue(this); }
            set { ScrollableRegion3TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region11Property = new DependencyProperty<Region>("Region11");
        public Region Region11
        {
            get { return Region11Property.GetValue(this); }
            set { Region11Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region11TemplateProperty = new DependencyProperty<Template>("Region11Template");
        public Template Region11Template
        {
            get { return Region11TemplateProperty.GetValue(this); }
            set { Region11TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region12Property = new DependencyProperty<Region>("Region12");
        public Region Region12
        {
            get { return Region12Property.GetValue(this); }
            set { Region12Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region12TemplateProperty = new DependencyProperty<Template>("Region12Template");
        public Template Region12Template
        {
            get { return Region12TemplateProperty.GetValue(this); }
            set { Region12TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region13Property = new DependencyProperty<Region>("Region13");
        public Region Region13
        {
            get { return Region13Property.GetValue(this); }
            set { Region13Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region13TemplateProperty = new DependencyProperty<Template>("Region13Template");
        public Template Region13Template
        {
            get { return Region13TemplateProperty.GetValue(this); }
            set { Region13TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region14Property = new DependencyProperty<Region>("Region14");
        public Region Region14
        {
            get { return Region14Property.GetValue(this); }
            set { Region14Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region14TemplateProperty = new DependencyProperty<Template>("Region14Template");
        public Template Region14Template
        {
            get { return Region14TemplateProperty.GetValue(this); }
            set { Region14TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region15Property = new DependencyProperty<Region>("Region15");
        public Region Region15
        {
            get { return Region15Property.GetValue(this); }
            set { Region15Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region15TemplateProperty = new DependencyProperty<Template>("Region15Template");
        public Template Region15Template
        {
            get { return Region15TemplateProperty.GetValue(this); }
            set { Region15TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegion4Property = new DependencyProperty<ScrollableRegion>("ScrollableRegion4");
        public ScrollableRegion ScrollableRegion4
        {
            get { return ScrollableRegion4Property.GetValue(this); }
            set { ScrollableRegion4Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegion4TemplateProperty = new DependencyProperty<Template>("ScrollableRegion4Template");
        public Template ScrollableRegion4Template
        {
            get { return ScrollableRegion4TemplateProperty.GetValue(this); }
            set { ScrollableRegion4TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region16Property = new DependencyProperty<Region>("Region16");
        public Region Region16
        {
            get { return Region16Property.GetValue(this); }
            set { Region16Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region16TemplateProperty = new DependencyProperty<Template>("Region16Template");
        public Template Region16Template
        {
            get { return Region16TemplateProperty.GetValue(this); }
            set { Region16TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region17Property = new DependencyProperty<Region>("Region17");
        public Region Region17
        {
            get { return Region17Property.GetValue(this); }
            set { Region17Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region17TemplateProperty = new DependencyProperty<Template>("Region17Template");
        public Template Region17Template
        {
            get { return Region17TemplateProperty.GetValue(this); }
            set { Region17TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region18Property = new DependencyProperty<Region>("Region18");
        public Region Region18
        {
            get { return Region18Property.GetValue(this); }
            set { Region18Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region18TemplateProperty = new DependencyProperty<Template>("Region18Template");
        public Template Region18Template
        {
            get { return Region18TemplateProperty.GetValue(this); }
            set { Region18TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region19Property = new DependencyProperty<Region>("Region19");
        public Region Region19
        {
            get { return Region19Property.GetValue(this); }
            set { Region19Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region19TemplateProperty = new DependencyProperty<Template>("Region19Template");
        public Template Region19Template
        {
            get { return Region19TemplateProperty.GetValue(this); }
            set { Region19TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region20Property = new DependencyProperty<Region>("Region20");
        public Region Region20
        {
            get { return Region20Property.GetValue(this); }
            set { Region20Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region20TemplateProperty = new DependencyProperty<Template>("Region20Template");
        public Template Region20Template
        {
            get { return Region20TemplateProperty.GetValue(this); }
            set { Region20TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegion5Property = new DependencyProperty<ScrollableRegion>("ScrollableRegion5");
        public ScrollableRegion ScrollableRegion5
        {
            get { return ScrollableRegion5Property.GetValue(this); }
            set { ScrollableRegion5Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegion5TemplateProperty = new DependencyProperty<Template>("ScrollableRegion5Template");
        public Template ScrollableRegion5Template
        {
            get { return ScrollableRegion5TemplateProperty.GetValue(this); }
            set { ScrollableRegion5TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region21Property = new DependencyProperty<Region>("Region21");
        public Region Region21
        {
            get { return Region21Property.GetValue(this); }
            set { Region21Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region21TemplateProperty = new DependencyProperty<Template>("Region21Template");
        public Template Region21Template
        {
            get { return Region21TemplateProperty.GetValue(this); }
            set { Region21TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region22Property = new DependencyProperty<Region>("Region22");
        public Region Region22
        {
            get { return Region22Property.GetValue(this); }
            set { Region22Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region22TemplateProperty = new DependencyProperty<Template>("Region22Template");
        public Template Region22Template
        {
            get { return Region22TemplateProperty.GetValue(this); }
            set { Region22TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region23Property = new DependencyProperty<Region>("Region23");
        public Region Region23
        {
            get { return Region23Property.GetValue(this); }
            set { Region23Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region23TemplateProperty = new DependencyProperty<Template>("Region23Template");
        public Template Region23Template
        {
            get { return Region23TemplateProperty.GetValue(this); }
            set { Region23TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region24Property = new DependencyProperty<Region>("Region24");
        public Region Region24
        {
            get { return Region24Property.GetValue(this); }
            set { Region24Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region24TemplateProperty = new DependencyProperty<Template>("Region24Template");
        public Template Region24Template
        {
            get { return Region24TemplateProperty.GetValue(this); }
            set { Region24TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region25Property = new DependencyProperty<Region>("Region25");
        public Region Region25
        {
            get { return Region25Property.GetValue(this); }
            set { Region25Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region25TemplateProperty = new DependencyProperty<Template>("Region25Template");
        public Template Region25Template
        {
            get { return Region25TemplateProperty.GetValue(this); }
            set { Region25TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegion6Property = new DependencyProperty<ScrollableRegion>("ScrollableRegion6");
        public ScrollableRegion ScrollableRegion6
        {
            get { return ScrollableRegion6Property.GetValue(this); }
            set { ScrollableRegion6Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegion6TemplateProperty = new DependencyProperty<Template>("ScrollableRegion6Template");
        public Template ScrollableRegion6Template
        {
            get { return ScrollableRegion6TemplateProperty.GetValue(this); }
            set { ScrollableRegion6TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region26Property = new DependencyProperty<Region>("Region26");
        public Region Region26
        {
            get { return Region26Property.GetValue(this); }
            set { Region26Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region26TemplateProperty = new DependencyProperty<Template>("Region26Template");
        public Template Region26Template
        {
            get { return Region26TemplateProperty.GetValue(this); }
            set { Region26TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region27Property = new DependencyProperty<Region>("Region27");
        public Region Region27
        {
            get { return Region27Property.GetValue(this); }
            set { Region27Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region27TemplateProperty = new DependencyProperty<Template>("Region27Template");
        public Template Region27Template
        {
            get { return Region27TemplateProperty.GetValue(this); }
            set { Region27TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region28Property = new DependencyProperty<Region>("Region28");
        public Region Region28
        {
            get { return Region28Property.GetValue(this); }
            set { Region28Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region28TemplateProperty = new DependencyProperty<Template>("Region28Template");
        public Template Region28Template
        {
            get { return Region28TemplateProperty.GetValue(this); }
            set { Region28TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region29Property = new DependencyProperty<Region>("Region29");
        public Region Region29
        {
            get { return Region29Property.GetValue(this); }
            set { Region29Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region29TemplateProperty = new DependencyProperty<Template>("Region29Template");
        public Template Region29Template
        {
            get { return Region29TemplateProperty.GetValue(this); }
            set { Region29TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region30Property = new DependencyProperty<Region>("Region30");
        public Region Region30
        {
            get { return Region30Property.GetValue(this); }
            set { Region30Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region30TemplateProperty = new DependencyProperty<Template>("Region30Template");
        public Template Region30Template
        {
            get { return Region30TemplateProperty.GetValue(this); }
            set { Region30TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegion7Property = new DependencyProperty<ScrollableRegion>("ScrollableRegion7");
        public ScrollableRegion ScrollableRegion7
        {
            get { return ScrollableRegion7Property.GetValue(this); }
            set { ScrollableRegion7Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegion7TemplateProperty = new DependencyProperty<Template>("ScrollableRegion7Template");
        public Template ScrollableRegion7Template
        {
            get { return ScrollableRegion7TemplateProperty.GetValue(this); }
            set { ScrollableRegion7TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region31Property = new DependencyProperty<Region>("Region31");
        public Region Region31
        {
            get { return Region31Property.GetValue(this); }
            set { Region31Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region31TemplateProperty = new DependencyProperty<Template>("Region31Template");
        public Template Region31Template
        {
            get { return Region31TemplateProperty.GetValue(this); }
            set { Region31TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region32Property = new DependencyProperty<Region>("Region32");
        public Region Region32
        {
            get { return Region32Property.GetValue(this); }
            set { Region32Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region32TemplateProperty = new DependencyProperty<Template>("Region32Template");
        public Template Region32Template
        {
            get { return Region32TemplateProperty.GetValue(this); }
            set { Region32TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region33Property = new DependencyProperty<Region>("Region33");
        public Region Region33
        {
            get { return Region33Property.GetValue(this); }
            set { Region33Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region33TemplateProperty = new DependencyProperty<Template>("Region33Template");
        public Template Region33Template
        {
            get { return Region33TemplateProperty.GetValue(this); }
            set { Region33TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region34Property = new DependencyProperty<Region>("Region34");
        public Region Region34
        {
            get { return Region34Property.GetValue(this); }
            set { Region34Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region34TemplateProperty = new DependencyProperty<Template>("Region34Template");
        public Template Region34Template
        {
            get { return Region34TemplateProperty.GetValue(this); }
            set { Region34TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region35Property = new DependencyProperty<Region>("Region35");
        public Region Region35
        {
            get { return Region35Property.GetValue(this); }
            set { Region35Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region35TemplateProperty = new DependencyProperty<Template>("Region35Template");
        public Template Region35Template
        {
            get { return Region35TemplateProperty.GetValue(this); }
            set { Region35TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegion8Property = new DependencyProperty<ScrollableRegion>("ScrollableRegion8");
        public ScrollableRegion ScrollableRegion8
        {
            get { return ScrollableRegion8Property.GetValue(this); }
            set { ScrollableRegion8Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegion8TemplateProperty = new DependencyProperty<Template>("ScrollableRegion8Template");
        public Template ScrollableRegion8Template
        {
            get { return ScrollableRegion8TemplateProperty.GetValue(this); }
            set { ScrollableRegion8TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region36Property = new DependencyProperty<Region>("Region36");
        public Region Region36
        {
            get { return Region36Property.GetValue(this); }
            set { Region36Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region36TemplateProperty = new DependencyProperty<Template>("Region36Template");
        public Template Region36Template
        {
            get { return Region36TemplateProperty.GetValue(this); }
            set { Region36TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region37Property = new DependencyProperty<Region>("Region37");
        public Region Region37
        {
            get { return Region37Property.GetValue(this); }
            set { Region37Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region37TemplateProperty = new DependencyProperty<Template>("Region37Template");
        public Template Region37Template
        {
            get { return Region37TemplateProperty.GetValue(this); }
            set { Region37TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region38Property = new DependencyProperty<Region>("Region38");
        public Region Region38
        {
            get { return Region38Property.GetValue(this); }
            set { Region38Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region38TemplateProperty = new DependencyProperty<Template>("Region38Template");
        public Template Region38Template
        {
            get { return Region38TemplateProperty.GetValue(this); }
            set { Region38TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region39Property = new DependencyProperty<Region>("Region39");
        public Region Region39
        {
            get { return Region39Property.GetValue(this); }
            set { Region39Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region39TemplateProperty = new DependencyProperty<Template>("Region39Template");
        public Template Region39Template
        {
            get { return Region39TemplateProperty.GetValue(this); }
            set { Region39TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region40Property = new DependencyProperty<Region>("Region40");
        public Region Region40
        {
            get { return Region40Property.GetValue(this); }
            set { Region40Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region40TemplateProperty = new DependencyProperty<Template>("Region40Template");
        public Template Region40Template
        {
            get { return Region40TemplateProperty.GetValue(this); }
            set { Region40TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<ScrollableRegion> ScrollableRegion9Property = new DependencyProperty<ScrollableRegion>("ScrollableRegion9");
        public ScrollableRegion ScrollableRegion9
        {
            get { return ScrollableRegion9Property.GetValue(this); }
            set { ScrollableRegion9Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> ScrollableRegion9TemplateProperty = new DependencyProperty<Template>("ScrollableRegion9Template");
        public Template ScrollableRegion9Template
        {
            get { return ScrollableRegion9TemplateProperty.GetValue(this); }
            set { ScrollableRegion9TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region41Property = new DependencyProperty<Region>("Region41");
        public Region Region41
        {
            get { return Region41Property.GetValue(this); }
            set { Region41Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region41TemplateProperty = new DependencyProperty<Template>("Region41Template");
        public Template Region41Template
        {
            get { return Region41TemplateProperty.GetValue(this); }
            set { Region41TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region42Property = new DependencyProperty<Region>("Region42");
        public Region Region42
        {
            get { return Region42Property.GetValue(this); }
            set { Region42Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region42TemplateProperty = new DependencyProperty<Template>("Region42Template");
        public Template Region42Template
        {
            get { return Region42TemplateProperty.GetValue(this); }
            set { Region42TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region43Property = new DependencyProperty<Region>("Region43");
        public Region Region43
        {
            get { return Region43Property.GetValue(this); }
            set { Region43Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region43TemplateProperty = new DependencyProperty<Template>("Region43Template");
        public Template Region43Template
        {
            get { return Region43TemplateProperty.GetValue(this); }
            set { Region43TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region44Property = new DependencyProperty<Region>("Region44");
        public Region Region44
        {
            get { return Region44Property.GetValue(this); }
            set { Region44Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region44TemplateProperty = new DependencyProperty<Template>("Region44Template");
        public Template Region44Template
        {
            get { return Region44TemplateProperty.GetValue(this); }
            set { Region44TemplateProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Region> Region45Property = new DependencyProperty<Region>("Region45");
        public Region Region45
        {
            get { return Region45Property.GetValue(this); }
            set { Region45Property.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Template> Region45TemplateProperty = new DependencyProperty<Template>("Region45Template");
        public Template Region45Template
        {
            get { return Region45TemplateProperty.GetValue(this); }
            set { Region45TemplateProperty.SetValue(this, value); }
        }

        #endregion
    }

    #region Data Templates

    public static class ScrollExampleTemplates
    {
        #region Properties

        public static Template Default
        {
            get
            {
                return ScrollExample;
            }
        }

        private static Template _scrollExample;
        public static Template ScrollExample
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExample == null || _scrollExample.CurrentVersion != Template.Version)
#else
                if (_scrollExample == null)
#endif
                {
                    _scrollExample = new Template(LayoutRootTemplates.LayoutRoot);
#if UNITY_EDITOR
                    _scrollExample.Name = "ScrollExample";
                    _scrollExample.LineNumber = 0;
                    _scrollExample.LinePosition = 0;
#endif
                    Delight.ScrollExample.Grid1TemplateProperty.SetDefault(_scrollExample, ScrollExampleGrid1);
                    Delight.ScrollExample.ScrollableRegion1TemplateProperty.SetDefault(_scrollExample, ScrollExampleScrollableRegion1);
                    Delight.ScrollExample.Region1TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion1);
                    Delight.ScrollExample.Region2TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion2);
                    Delight.ScrollExample.Region3TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion3);
                    Delight.ScrollExample.Region4TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion4);
                    Delight.ScrollExample.Region5TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion5);
                    Delight.ScrollExample.ScrollableRegion2TemplateProperty.SetDefault(_scrollExample, ScrollExampleScrollableRegion2);
                    Delight.ScrollExample.Region6TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion6);
                    Delight.ScrollExample.Region7TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion7);
                    Delight.ScrollExample.Region8TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion8);
                    Delight.ScrollExample.Region9TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion9);
                    Delight.ScrollExample.Region10TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion10);
                    Delight.ScrollExample.ScrollableRegion3TemplateProperty.SetDefault(_scrollExample, ScrollExampleScrollableRegion3);
                    Delight.ScrollExample.Region11TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion11);
                    Delight.ScrollExample.Region12TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion12);
                    Delight.ScrollExample.Region13TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion13);
                    Delight.ScrollExample.Region14TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion14);
                    Delight.ScrollExample.Region15TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion15);
                    Delight.ScrollExample.ScrollableRegion4TemplateProperty.SetDefault(_scrollExample, ScrollExampleScrollableRegion4);
                    Delight.ScrollExample.Region16TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion16);
                    Delight.ScrollExample.Region17TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion17);
                    Delight.ScrollExample.Region18TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion18);
                    Delight.ScrollExample.Region19TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion19);
                    Delight.ScrollExample.Region20TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion20);
                    Delight.ScrollExample.ScrollableRegion5TemplateProperty.SetDefault(_scrollExample, ScrollExampleScrollableRegion5);
                    Delight.ScrollExample.Region21TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion21);
                    Delight.ScrollExample.Region22TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion22);
                    Delight.ScrollExample.Region23TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion23);
                    Delight.ScrollExample.Region24TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion24);
                    Delight.ScrollExample.Region25TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion25);
                    Delight.ScrollExample.ScrollableRegion6TemplateProperty.SetDefault(_scrollExample, ScrollExampleScrollableRegion6);
                    Delight.ScrollExample.Region26TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion26);
                    Delight.ScrollExample.Region27TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion27);
                    Delight.ScrollExample.Region28TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion28);
                    Delight.ScrollExample.Region29TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion29);
                    Delight.ScrollExample.Region30TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion30);
                    Delight.ScrollExample.ScrollableRegion7TemplateProperty.SetDefault(_scrollExample, ScrollExampleScrollableRegion7);
                    Delight.ScrollExample.Region31TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion31);
                    Delight.ScrollExample.Region32TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion32);
                    Delight.ScrollExample.Region33TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion33);
                    Delight.ScrollExample.Region34TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion34);
                    Delight.ScrollExample.Region35TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion35);
                    Delight.ScrollExample.ScrollableRegion8TemplateProperty.SetDefault(_scrollExample, ScrollExampleScrollableRegion8);
                    Delight.ScrollExample.Region36TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion36);
                    Delight.ScrollExample.Region37TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion37);
                    Delight.ScrollExample.Region38TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion38);
                    Delight.ScrollExample.Region39TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion39);
                    Delight.ScrollExample.Region40TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion40);
                    Delight.ScrollExample.ScrollableRegion9TemplateProperty.SetDefault(_scrollExample, ScrollExampleScrollableRegion9);
                    Delight.ScrollExample.Region41TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion41);
                    Delight.ScrollExample.Region42TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion42);
                    Delight.ScrollExample.Region43TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion43);
                    Delight.ScrollExample.Region44TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion44);
                    Delight.ScrollExample.Region45TemplateProperty.SetDefault(_scrollExample, ScrollExampleRegion45);
                }
                return _scrollExample;
            }
        }

        private static Template _scrollExampleGrid1;
        public static Template ScrollExampleGrid1
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleGrid1 == null || _scrollExampleGrid1.CurrentVersion != Template.Version)
#else
                if (_scrollExampleGrid1 == null)
#endif
                {
                    _scrollExampleGrid1 = new Template(LayoutGridTemplates.LayoutGrid);
#if UNITY_EDITOR
                    _scrollExampleGrid1.Name = "ScrollExampleGrid1";
                    _scrollExampleGrid1.LineNumber = 2;
                    _scrollExampleGrid1.LinePosition = 4;
#endif
                    Delight.LayoutGrid.ColumnsProperty.SetDefault(_scrollExampleGrid1, new ColumnDefinitions { new ColumnDefinition(new ElementSize(0.5f, ElementSizeUnit.Percents)), new ColumnDefinition(new ElementSize(0.5f, ElementSizeUnit.Percents)), new ColumnDefinition(new ElementSize(0.5f, ElementSizeUnit.Percents))});
                    Delight.LayoutGrid.RowsProperty.SetDefault(_scrollExampleGrid1, new RowDefinitions { new RowDefinition(new ElementSize(0.5f, ElementSizeUnit.Percents)), new RowDefinition(new ElementSize(0.5f, ElementSizeUnit.Percents)), new RowDefinition(new ElementSize(0.5f, ElementSizeUnit.Percents))});
                    Delight.LayoutGrid.SpacingProperty.SetDefault(_scrollExampleGrid1, new ElementSize(20f, ElementSizeUnit.Pixels));
                }
                return _scrollExampleGrid1;
            }
        }

        private static Template _scrollExampleScrollableRegion1;
        public static Template ScrollExampleScrollableRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion1 == null || _scrollExampleScrollableRegion1.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion1 == null)
#endif
                {
                    _scrollExampleScrollableRegion1 = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion1.Name = "ScrollExampleScrollableRegion1";
                    _scrollExampleScrollableRegion1.LineNumber = 3;
                    _scrollExampleScrollableRegion1.LinePosition = 6;
#endif
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_scrollExampleScrollableRegion1, Delight.ElementAlignment.TopLeft);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollExampleScrollableRegion1, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollExampleScrollableRegion1, Delight.ScrollBounds.Elastic);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollExampleScrollableRegion1, ScrollExampleScrollableRegion1ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion1, ScrollExampleScrollableRegion1HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion1, ScrollExampleScrollableRegion1VerticalScrollbar);
                }
                return _scrollExampleScrollableRegion1;
            }
        }

        private static Template _scrollExampleScrollableRegion1ContentRegion;
        public static Template ScrollExampleScrollableRegion1ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion1ContentRegion == null || _scrollExampleScrollableRegion1ContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion1ContentRegion == null)
#endif
                {
                    _scrollExampleScrollableRegion1ContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion1ContentRegion.Name = "ScrollExampleScrollableRegion1ContentRegion";
                    _scrollExampleScrollableRegion1ContentRegion.LineNumber = 24;
                    _scrollExampleScrollableRegion1ContentRegion.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion1ContentRegion;
            }
        }

        private static Template _scrollExampleScrollableRegion1HorizontalScrollbar;
        public static Template ScrollExampleScrollableRegion1HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion1HorizontalScrollbar == null || _scrollExampleScrollableRegion1HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion1HorizontalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion1HorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion1HorizontalScrollbar.Name = "ScrollExampleScrollableRegion1HorizontalScrollbar";
                    _scrollExampleScrollableRegion1HorizontalScrollbar.LineNumber = 26;
                    _scrollExampleScrollableRegion1HorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion1HorizontalScrollbar, ScrollExampleScrollableRegion1HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion1HorizontalScrollbar, ScrollExampleScrollableRegion1HorizontalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion1HorizontalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion1HorizontalScrollbarBar;
        public static Template ScrollExampleScrollableRegion1HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion1HorizontalScrollbarBar == null || _scrollExampleScrollableRegion1HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion1HorizontalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion1HorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion1HorizontalScrollbarBar.Name = "ScrollExampleScrollableRegion1HorizontalScrollbarBar";
                    _scrollExampleScrollableRegion1HorizontalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion1HorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion1HorizontalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion1HorizontalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion1HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion1HorizontalScrollbarHandle == null || _scrollExampleScrollableRegion1HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion1HorizontalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion1HorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion1HorizontalScrollbarHandle.Name = "ScrollExampleScrollableRegion1HorizontalScrollbarHandle";
                    _scrollExampleScrollableRegion1HorizontalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion1HorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion1HorizontalScrollbarHandle;
            }
        }

        private static Template _scrollExampleScrollableRegion1VerticalScrollbar;
        public static Template ScrollExampleScrollableRegion1VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion1VerticalScrollbar == null || _scrollExampleScrollableRegion1VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion1VerticalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion1VerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion1VerticalScrollbar.Name = "ScrollExampleScrollableRegion1VerticalScrollbar";
                    _scrollExampleScrollableRegion1VerticalScrollbar.LineNumber = 27;
                    _scrollExampleScrollableRegion1VerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion1VerticalScrollbar, ScrollExampleScrollableRegion1VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion1VerticalScrollbar, ScrollExampleScrollableRegion1VerticalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion1VerticalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion1VerticalScrollbarBar;
        public static Template ScrollExampleScrollableRegion1VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion1VerticalScrollbarBar == null || _scrollExampleScrollableRegion1VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion1VerticalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion1VerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion1VerticalScrollbarBar.Name = "ScrollExampleScrollableRegion1VerticalScrollbarBar";
                    _scrollExampleScrollableRegion1VerticalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion1VerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion1VerticalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion1VerticalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion1VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion1VerticalScrollbarHandle == null || _scrollExampleScrollableRegion1VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion1VerticalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion1VerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion1VerticalScrollbarHandle.Name = "ScrollExampleScrollableRegion1VerticalScrollbarHandle";
                    _scrollExampleScrollableRegion1VerticalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion1VerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion1VerticalScrollbarHandle;
            }
        }

        private static Template _scrollExampleRegion1;
        public static Template ScrollExampleRegion1
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion1 == null || _scrollExampleRegion1.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion1 == null)
#endif
                {
                    _scrollExampleRegion1 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion1.Name = "ScrollExampleRegion1";
                    _scrollExampleRegion1.LineNumber = 5;
                    _scrollExampleRegion1.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion1, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion1, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion1, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _scrollExampleRegion1;
            }
        }

        private static Template _scrollExampleRegion2;
        public static Template ScrollExampleRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion2 == null || _scrollExampleRegion2.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion2 == null)
#endif
                {
                    _scrollExampleRegion2 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion2.Name = "ScrollExampleRegion2";
                    _scrollExampleRegion2.LineNumber = 6;
                    _scrollExampleRegion2.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion2, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion2, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion2, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion2, Delight.ElementAlignment.TopLeft);
                }
                return _scrollExampleRegion2;
            }
        }

        private static Template _scrollExampleRegion3;
        public static Template ScrollExampleRegion3
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion3 == null || _scrollExampleRegion3.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion3 == null)
#endif
                {
                    _scrollExampleRegion3 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion3.Name = "ScrollExampleRegion3";
                    _scrollExampleRegion3.LineNumber = 7;
                    _scrollExampleRegion3.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion3, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion3, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion3, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion3, Delight.ElementAlignment.TopRight);
                }
                return _scrollExampleRegion3;
            }
        }

        private static Template _scrollExampleRegion4;
        public static Template ScrollExampleRegion4
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion4 == null || _scrollExampleRegion4.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion4 == null)
#endif
                {
                    _scrollExampleRegion4 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion4.Name = "ScrollExampleRegion4";
                    _scrollExampleRegion4.LineNumber = 8;
                    _scrollExampleRegion4.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion4, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion4, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion4, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion4, Delight.ElementAlignment.BottomLeft);
                }
                return _scrollExampleRegion4;
            }
        }

        private static Template _scrollExampleRegion5;
        public static Template ScrollExampleRegion5
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion5 == null || _scrollExampleRegion5.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion5 == null)
#endif
                {
                    _scrollExampleRegion5 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion5.Name = "ScrollExampleRegion5";
                    _scrollExampleRegion5.LineNumber = 9;
                    _scrollExampleRegion5.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion5, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion5, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion5, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion5, Delight.ElementAlignment.BottomRight);
                }
                return _scrollExampleRegion5;
            }
        }

        private static Template _scrollExampleScrollableRegion2;
        public static Template ScrollExampleScrollableRegion2
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion2 == null || _scrollExampleScrollableRegion2.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion2 == null)
#endif
                {
                    _scrollExampleScrollableRegion2 = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion2.Name = "ScrollExampleScrollableRegion2";
                    _scrollExampleScrollableRegion2.LineNumber = 13;
                    _scrollExampleScrollableRegion2.LinePosition = 6;
#endif
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_scrollExampleScrollableRegion2, Delight.ElementAlignment.Top);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollExampleScrollableRegion2, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollExampleScrollableRegion2, Delight.ScrollBounds.Elastic);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollExampleScrollableRegion2, ScrollExampleScrollableRegion2ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion2, ScrollExampleScrollableRegion2HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion2, ScrollExampleScrollableRegion2VerticalScrollbar);
                }
                return _scrollExampleScrollableRegion2;
            }
        }

        private static Template _scrollExampleScrollableRegion2ContentRegion;
        public static Template ScrollExampleScrollableRegion2ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion2ContentRegion == null || _scrollExampleScrollableRegion2ContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion2ContentRegion == null)
#endif
                {
                    _scrollExampleScrollableRegion2ContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion2ContentRegion.Name = "ScrollExampleScrollableRegion2ContentRegion";
                    _scrollExampleScrollableRegion2ContentRegion.LineNumber = 24;
                    _scrollExampleScrollableRegion2ContentRegion.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion2ContentRegion;
            }
        }

        private static Template _scrollExampleScrollableRegion2HorizontalScrollbar;
        public static Template ScrollExampleScrollableRegion2HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion2HorizontalScrollbar == null || _scrollExampleScrollableRegion2HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion2HorizontalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion2HorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion2HorizontalScrollbar.Name = "ScrollExampleScrollableRegion2HorizontalScrollbar";
                    _scrollExampleScrollableRegion2HorizontalScrollbar.LineNumber = 26;
                    _scrollExampleScrollableRegion2HorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion2HorizontalScrollbar, ScrollExampleScrollableRegion2HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion2HorizontalScrollbar, ScrollExampleScrollableRegion2HorizontalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion2HorizontalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion2HorizontalScrollbarBar;
        public static Template ScrollExampleScrollableRegion2HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion2HorizontalScrollbarBar == null || _scrollExampleScrollableRegion2HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion2HorizontalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion2HorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion2HorizontalScrollbarBar.Name = "ScrollExampleScrollableRegion2HorizontalScrollbarBar";
                    _scrollExampleScrollableRegion2HorizontalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion2HorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion2HorizontalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion2HorizontalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion2HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion2HorizontalScrollbarHandle == null || _scrollExampleScrollableRegion2HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion2HorizontalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion2HorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion2HorizontalScrollbarHandle.Name = "ScrollExampleScrollableRegion2HorizontalScrollbarHandle";
                    _scrollExampleScrollableRegion2HorizontalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion2HorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion2HorizontalScrollbarHandle;
            }
        }

        private static Template _scrollExampleScrollableRegion2VerticalScrollbar;
        public static Template ScrollExampleScrollableRegion2VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion2VerticalScrollbar == null || _scrollExampleScrollableRegion2VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion2VerticalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion2VerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion2VerticalScrollbar.Name = "ScrollExampleScrollableRegion2VerticalScrollbar";
                    _scrollExampleScrollableRegion2VerticalScrollbar.LineNumber = 27;
                    _scrollExampleScrollableRegion2VerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion2VerticalScrollbar, ScrollExampleScrollableRegion2VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion2VerticalScrollbar, ScrollExampleScrollableRegion2VerticalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion2VerticalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion2VerticalScrollbarBar;
        public static Template ScrollExampleScrollableRegion2VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion2VerticalScrollbarBar == null || _scrollExampleScrollableRegion2VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion2VerticalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion2VerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion2VerticalScrollbarBar.Name = "ScrollExampleScrollableRegion2VerticalScrollbarBar";
                    _scrollExampleScrollableRegion2VerticalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion2VerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion2VerticalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion2VerticalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion2VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion2VerticalScrollbarHandle == null || _scrollExampleScrollableRegion2VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion2VerticalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion2VerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion2VerticalScrollbarHandle.Name = "ScrollExampleScrollableRegion2VerticalScrollbarHandle";
                    _scrollExampleScrollableRegion2VerticalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion2VerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion2VerticalScrollbarHandle;
            }
        }

        private static Template _scrollExampleRegion6;
        public static Template ScrollExampleRegion6
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion6 == null || _scrollExampleRegion6.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion6 == null)
#endif
                {
                    _scrollExampleRegion6 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion6.Name = "ScrollExampleRegion6";
                    _scrollExampleRegion6.LineNumber = 15;
                    _scrollExampleRegion6.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion6, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion6, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion6, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _scrollExampleRegion6;
            }
        }

        private static Template _scrollExampleRegion7;
        public static Template ScrollExampleRegion7
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion7 == null || _scrollExampleRegion7.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion7 == null)
#endif
                {
                    _scrollExampleRegion7 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion7.Name = "ScrollExampleRegion7";
                    _scrollExampleRegion7.LineNumber = 16;
                    _scrollExampleRegion7.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion7, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion7, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion7, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion7, Delight.ElementAlignment.TopLeft);
                }
                return _scrollExampleRegion7;
            }
        }

        private static Template _scrollExampleRegion8;
        public static Template ScrollExampleRegion8
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion8 == null || _scrollExampleRegion8.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion8 == null)
#endif
                {
                    _scrollExampleRegion8 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion8.Name = "ScrollExampleRegion8";
                    _scrollExampleRegion8.LineNumber = 17;
                    _scrollExampleRegion8.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion8, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion8, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion8, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion8, Delight.ElementAlignment.TopRight);
                }
                return _scrollExampleRegion8;
            }
        }

        private static Template _scrollExampleRegion9;
        public static Template ScrollExampleRegion9
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion9 == null || _scrollExampleRegion9.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion9 == null)
#endif
                {
                    _scrollExampleRegion9 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion9.Name = "ScrollExampleRegion9";
                    _scrollExampleRegion9.LineNumber = 18;
                    _scrollExampleRegion9.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion9, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion9, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion9, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion9, Delight.ElementAlignment.BottomLeft);
                }
                return _scrollExampleRegion9;
            }
        }

        private static Template _scrollExampleRegion10;
        public static Template ScrollExampleRegion10
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion10 == null || _scrollExampleRegion10.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion10 == null)
#endif
                {
                    _scrollExampleRegion10 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion10.Name = "ScrollExampleRegion10";
                    _scrollExampleRegion10.LineNumber = 19;
                    _scrollExampleRegion10.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion10, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion10, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion10, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion10, Delight.ElementAlignment.BottomRight);
                }
                return _scrollExampleRegion10;
            }
        }

        private static Template _scrollExampleScrollableRegion3;
        public static Template ScrollExampleScrollableRegion3
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion3 == null || _scrollExampleScrollableRegion3.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion3 == null)
#endif
                {
                    _scrollExampleScrollableRegion3 = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion3.Name = "ScrollExampleScrollableRegion3";
                    _scrollExampleScrollableRegion3.LineNumber = 23;
                    _scrollExampleScrollableRegion3.LinePosition = 6;
#endif
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_scrollExampleScrollableRegion3, Delight.ElementAlignment.TopRight);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollExampleScrollableRegion3, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollExampleScrollableRegion3, Delight.ScrollBounds.Elastic);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollExampleScrollableRegion3, ScrollExampleScrollableRegion3ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion3, ScrollExampleScrollableRegion3HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion3, ScrollExampleScrollableRegion3VerticalScrollbar);
                }
                return _scrollExampleScrollableRegion3;
            }
        }

        private static Template _scrollExampleScrollableRegion3ContentRegion;
        public static Template ScrollExampleScrollableRegion3ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion3ContentRegion == null || _scrollExampleScrollableRegion3ContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion3ContentRegion == null)
#endif
                {
                    _scrollExampleScrollableRegion3ContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion3ContentRegion.Name = "ScrollExampleScrollableRegion3ContentRegion";
                    _scrollExampleScrollableRegion3ContentRegion.LineNumber = 24;
                    _scrollExampleScrollableRegion3ContentRegion.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion3ContentRegion;
            }
        }

        private static Template _scrollExampleScrollableRegion3HorizontalScrollbar;
        public static Template ScrollExampleScrollableRegion3HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion3HorizontalScrollbar == null || _scrollExampleScrollableRegion3HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion3HorizontalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion3HorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion3HorizontalScrollbar.Name = "ScrollExampleScrollableRegion3HorizontalScrollbar";
                    _scrollExampleScrollableRegion3HorizontalScrollbar.LineNumber = 26;
                    _scrollExampleScrollableRegion3HorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion3HorizontalScrollbar, ScrollExampleScrollableRegion3HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion3HorizontalScrollbar, ScrollExampleScrollableRegion3HorizontalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion3HorizontalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion3HorizontalScrollbarBar;
        public static Template ScrollExampleScrollableRegion3HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion3HorizontalScrollbarBar == null || _scrollExampleScrollableRegion3HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion3HorizontalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion3HorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion3HorizontalScrollbarBar.Name = "ScrollExampleScrollableRegion3HorizontalScrollbarBar";
                    _scrollExampleScrollableRegion3HorizontalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion3HorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion3HorizontalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion3HorizontalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion3HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion3HorizontalScrollbarHandle == null || _scrollExampleScrollableRegion3HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion3HorizontalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion3HorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion3HorizontalScrollbarHandle.Name = "ScrollExampleScrollableRegion3HorizontalScrollbarHandle";
                    _scrollExampleScrollableRegion3HorizontalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion3HorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion3HorizontalScrollbarHandle;
            }
        }

        private static Template _scrollExampleScrollableRegion3VerticalScrollbar;
        public static Template ScrollExampleScrollableRegion3VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion3VerticalScrollbar == null || _scrollExampleScrollableRegion3VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion3VerticalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion3VerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion3VerticalScrollbar.Name = "ScrollExampleScrollableRegion3VerticalScrollbar";
                    _scrollExampleScrollableRegion3VerticalScrollbar.LineNumber = 27;
                    _scrollExampleScrollableRegion3VerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion3VerticalScrollbar, ScrollExampleScrollableRegion3VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion3VerticalScrollbar, ScrollExampleScrollableRegion3VerticalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion3VerticalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion3VerticalScrollbarBar;
        public static Template ScrollExampleScrollableRegion3VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion3VerticalScrollbarBar == null || _scrollExampleScrollableRegion3VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion3VerticalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion3VerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion3VerticalScrollbarBar.Name = "ScrollExampleScrollableRegion3VerticalScrollbarBar";
                    _scrollExampleScrollableRegion3VerticalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion3VerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion3VerticalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion3VerticalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion3VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion3VerticalScrollbarHandle == null || _scrollExampleScrollableRegion3VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion3VerticalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion3VerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion3VerticalScrollbarHandle.Name = "ScrollExampleScrollableRegion3VerticalScrollbarHandle";
                    _scrollExampleScrollableRegion3VerticalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion3VerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion3VerticalScrollbarHandle;
            }
        }

        private static Template _scrollExampleRegion11;
        public static Template ScrollExampleRegion11
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion11 == null || _scrollExampleRegion11.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion11 == null)
#endif
                {
                    _scrollExampleRegion11 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion11.Name = "ScrollExampleRegion11";
                    _scrollExampleRegion11.LineNumber = 25;
                    _scrollExampleRegion11.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion11, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion11, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion11, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _scrollExampleRegion11;
            }
        }

        private static Template _scrollExampleRegion12;
        public static Template ScrollExampleRegion12
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion12 == null || _scrollExampleRegion12.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion12 == null)
#endif
                {
                    _scrollExampleRegion12 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion12.Name = "ScrollExampleRegion12";
                    _scrollExampleRegion12.LineNumber = 26;
                    _scrollExampleRegion12.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion12, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion12, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion12, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion12, Delight.ElementAlignment.TopLeft);
                }
                return _scrollExampleRegion12;
            }
        }

        private static Template _scrollExampleRegion13;
        public static Template ScrollExampleRegion13
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion13 == null || _scrollExampleRegion13.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion13 == null)
#endif
                {
                    _scrollExampleRegion13 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion13.Name = "ScrollExampleRegion13";
                    _scrollExampleRegion13.LineNumber = 27;
                    _scrollExampleRegion13.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion13, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion13, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion13, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion13, Delight.ElementAlignment.TopRight);
                }
                return _scrollExampleRegion13;
            }
        }

        private static Template _scrollExampleRegion14;
        public static Template ScrollExampleRegion14
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion14 == null || _scrollExampleRegion14.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion14 == null)
#endif
                {
                    _scrollExampleRegion14 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion14.Name = "ScrollExampleRegion14";
                    _scrollExampleRegion14.LineNumber = 28;
                    _scrollExampleRegion14.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion14, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion14, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion14, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion14, Delight.ElementAlignment.BottomLeft);
                }
                return _scrollExampleRegion14;
            }
        }

        private static Template _scrollExampleRegion15;
        public static Template ScrollExampleRegion15
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion15 == null || _scrollExampleRegion15.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion15 == null)
#endif
                {
                    _scrollExampleRegion15 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion15.Name = "ScrollExampleRegion15";
                    _scrollExampleRegion15.LineNumber = 29;
                    _scrollExampleRegion15.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion15, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion15, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion15, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion15, Delight.ElementAlignment.BottomRight);
                }
                return _scrollExampleRegion15;
            }
        }

        private static Template _scrollExampleScrollableRegion4;
        public static Template ScrollExampleScrollableRegion4
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion4 == null || _scrollExampleScrollableRegion4.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion4 == null)
#endif
                {
                    _scrollExampleScrollableRegion4 = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion4.Name = "ScrollExampleScrollableRegion4";
                    _scrollExampleScrollableRegion4.LineNumber = 33;
                    _scrollExampleScrollableRegion4.LinePosition = 6;
#endif
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_scrollExampleScrollableRegion4, Delight.ElementAlignment.Left);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollExampleScrollableRegion4, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollExampleScrollableRegion4, Delight.ScrollBounds.None);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollExampleScrollableRegion4, ScrollExampleScrollableRegion4ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion4, ScrollExampleScrollableRegion4HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion4, ScrollExampleScrollableRegion4VerticalScrollbar);
                }
                return _scrollExampleScrollableRegion4;
            }
        }

        private static Template _scrollExampleScrollableRegion4ContentRegion;
        public static Template ScrollExampleScrollableRegion4ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion4ContentRegion == null || _scrollExampleScrollableRegion4ContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion4ContentRegion == null)
#endif
                {
                    _scrollExampleScrollableRegion4ContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion4ContentRegion.Name = "ScrollExampleScrollableRegion4ContentRegion";
                    _scrollExampleScrollableRegion4ContentRegion.LineNumber = 24;
                    _scrollExampleScrollableRegion4ContentRegion.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion4ContentRegion;
            }
        }

        private static Template _scrollExampleScrollableRegion4HorizontalScrollbar;
        public static Template ScrollExampleScrollableRegion4HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion4HorizontalScrollbar == null || _scrollExampleScrollableRegion4HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion4HorizontalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion4HorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion4HorizontalScrollbar.Name = "ScrollExampleScrollableRegion4HorizontalScrollbar";
                    _scrollExampleScrollableRegion4HorizontalScrollbar.LineNumber = 26;
                    _scrollExampleScrollableRegion4HorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion4HorizontalScrollbar, ScrollExampleScrollableRegion4HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion4HorizontalScrollbar, ScrollExampleScrollableRegion4HorizontalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion4HorizontalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion4HorizontalScrollbarBar;
        public static Template ScrollExampleScrollableRegion4HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion4HorizontalScrollbarBar == null || _scrollExampleScrollableRegion4HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion4HorizontalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion4HorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion4HorizontalScrollbarBar.Name = "ScrollExampleScrollableRegion4HorizontalScrollbarBar";
                    _scrollExampleScrollableRegion4HorizontalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion4HorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion4HorizontalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion4HorizontalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion4HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion4HorizontalScrollbarHandle == null || _scrollExampleScrollableRegion4HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion4HorizontalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion4HorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion4HorizontalScrollbarHandle.Name = "ScrollExampleScrollableRegion4HorizontalScrollbarHandle";
                    _scrollExampleScrollableRegion4HorizontalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion4HorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion4HorizontalScrollbarHandle;
            }
        }

        private static Template _scrollExampleScrollableRegion4VerticalScrollbar;
        public static Template ScrollExampleScrollableRegion4VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion4VerticalScrollbar == null || _scrollExampleScrollableRegion4VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion4VerticalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion4VerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion4VerticalScrollbar.Name = "ScrollExampleScrollableRegion4VerticalScrollbar";
                    _scrollExampleScrollableRegion4VerticalScrollbar.LineNumber = 27;
                    _scrollExampleScrollableRegion4VerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion4VerticalScrollbar, ScrollExampleScrollableRegion4VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion4VerticalScrollbar, ScrollExampleScrollableRegion4VerticalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion4VerticalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion4VerticalScrollbarBar;
        public static Template ScrollExampleScrollableRegion4VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion4VerticalScrollbarBar == null || _scrollExampleScrollableRegion4VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion4VerticalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion4VerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion4VerticalScrollbarBar.Name = "ScrollExampleScrollableRegion4VerticalScrollbarBar";
                    _scrollExampleScrollableRegion4VerticalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion4VerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion4VerticalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion4VerticalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion4VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion4VerticalScrollbarHandle == null || _scrollExampleScrollableRegion4VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion4VerticalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion4VerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion4VerticalScrollbarHandle.Name = "ScrollExampleScrollableRegion4VerticalScrollbarHandle";
                    _scrollExampleScrollableRegion4VerticalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion4VerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion4VerticalScrollbarHandle;
            }
        }

        private static Template _scrollExampleRegion16;
        public static Template ScrollExampleRegion16
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion16 == null || _scrollExampleRegion16.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion16 == null)
#endif
                {
                    _scrollExampleRegion16 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion16.Name = "ScrollExampleRegion16";
                    _scrollExampleRegion16.LineNumber = 35;
                    _scrollExampleRegion16.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion16, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion16, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion16, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _scrollExampleRegion16;
            }
        }

        private static Template _scrollExampleRegion17;
        public static Template ScrollExampleRegion17
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion17 == null || _scrollExampleRegion17.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion17 == null)
#endif
                {
                    _scrollExampleRegion17 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion17.Name = "ScrollExampleRegion17";
                    _scrollExampleRegion17.LineNumber = 36;
                    _scrollExampleRegion17.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion17, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion17, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion17, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion17, Delight.ElementAlignment.TopLeft);
                }
                return _scrollExampleRegion17;
            }
        }

        private static Template _scrollExampleRegion18;
        public static Template ScrollExampleRegion18
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion18 == null || _scrollExampleRegion18.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion18 == null)
#endif
                {
                    _scrollExampleRegion18 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion18.Name = "ScrollExampleRegion18";
                    _scrollExampleRegion18.LineNumber = 37;
                    _scrollExampleRegion18.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion18, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion18, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion18, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion18, Delight.ElementAlignment.TopRight);
                }
                return _scrollExampleRegion18;
            }
        }

        private static Template _scrollExampleRegion19;
        public static Template ScrollExampleRegion19
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion19 == null || _scrollExampleRegion19.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion19 == null)
#endif
                {
                    _scrollExampleRegion19 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion19.Name = "ScrollExampleRegion19";
                    _scrollExampleRegion19.LineNumber = 38;
                    _scrollExampleRegion19.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion19, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion19, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion19, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion19, Delight.ElementAlignment.BottomLeft);
                }
                return _scrollExampleRegion19;
            }
        }

        private static Template _scrollExampleRegion20;
        public static Template ScrollExampleRegion20
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion20 == null || _scrollExampleRegion20.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion20 == null)
#endif
                {
                    _scrollExampleRegion20 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion20.Name = "ScrollExampleRegion20";
                    _scrollExampleRegion20.LineNumber = 39;
                    _scrollExampleRegion20.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion20, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion20, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion20, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion20, Delight.ElementAlignment.BottomRight);
                }
                return _scrollExampleRegion20;
            }
        }

        private static Template _scrollExampleScrollableRegion5;
        public static Template ScrollExampleScrollableRegion5
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion5 == null || _scrollExampleScrollableRegion5.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion5 == null)
#endif
                {
                    _scrollExampleScrollableRegion5 = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion5.Name = "ScrollExampleScrollableRegion5";
                    _scrollExampleScrollableRegion5.LineNumber = 43;
                    _scrollExampleScrollableRegion5.LinePosition = 6;
#endif
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_scrollExampleScrollableRegion5, Delight.ElementAlignment.Center);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollExampleScrollableRegion5, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollExampleScrollableRegion5, Delight.ScrollBounds.None);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollExampleScrollableRegion5, ScrollExampleScrollableRegion5ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion5, ScrollExampleScrollableRegion5HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion5, ScrollExampleScrollableRegion5VerticalScrollbar);
                }
                return _scrollExampleScrollableRegion5;
            }
        }

        private static Template _scrollExampleScrollableRegion5ContentRegion;
        public static Template ScrollExampleScrollableRegion5ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion5ContentRegion == null || _scrollExampleScrollableRegion5ContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion5ContentRegion == null)
#endif
                {
                    _scrollExampleScrollableRegion5ContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion5ContentRegion.Name = "ScrollExampleScrollableRegion5ContentRegion";
                    _scrollExampleScrollableRegion5ContentRegion.LineNumber = 24;
                    _scrollExampleScrollableRegion5ContentRegion.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion5ContentRegion;
            }
        }

        private static Template _scrollExampleScrollableRegion5HorizontalScrollbar;
        public static Template ScrollExampleScrollableRegion5HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion5HorizontalScrollbar == null || _scrollExampleScrollableRegion5HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion5HorizontalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion5HorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion5HorizontalScrollbar.Name = "ScrollExampleScrollableRegion5HorizontalScrollbar";
                    _scrollExampleScrollableRegion5HorizontalScrollbar.LineNumber = 26;
                    _scrollExampleScrollableRegion5HorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion5HorizontalScrollbar, ScrollExampleScrollableRegion5HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion5HorizontalScrollbar, ScrollExampleScrollableRegion5HorizontalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion5HorizontalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion5HorizontalScrollbarBar;
        public static Template ScrollExampleScrollableRegion5HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion5HorizontalScrollbarBar == null || _scrollExampleScrollableRegion5HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion5HorizontalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion5HorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion5HorizontalScrollbarBar.Name = "ScrollExampleScrollableRegion5HorizontalScrollbarBar";
                    _scrollExampleScrollableRegion5HorizontalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion5HorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion5HorizontalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion5HorizontalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion5HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion5HorizontalScrollbarHandle == null || _scrollExampleScrollableRegion5HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion5HorizontalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion5HorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion5HorizontalScrollbarHandle.Name = "ScrollExampleScrollableRegion5HorizontalScrollbarHandle";
                    _scrollExampleScrollableRegion5HorizontalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion5HorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion5HorizontalScrollbarHandle;
            }
        }

        private static Template _scrollExampleScrollableRegion5VerticalScrollbar;
        public static Template ScrollExampleScrollableRegion5VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion5VerticalScrollbar == null || _scrollExampleScrollableRegion5VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion5VerticalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion5VerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion5VerticalScrollbar.Name = "ScrollExampleScrollableRegion5VerticalScrollbar";
                    _scrollExampleScrollableRegion5VerticalScrollbar.LineNumber = 27;
                    _scrollExampleScrollableRegion5VerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion5VerticalScrollbar, ScrollExampleScrollableRegion5VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion5VerticalScrollbar, ScrollExampleScrollableRegion5VerticalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion5VerticalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion5VerticalScrollbarBar;
        public static Template ScrollExampleScrollableRegion5VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion5VerticalScrollbarBar == null || _scrollExampleScrollableRegion5VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion5VerticalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion5VerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion5VerticalScrollbarBar.Name = "ScrollExampleScrollableRegion5VerticalScrollbarBar";
                    _scrollExampleScrollableRegion5VerticalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion5VerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion5VerticalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion5VerticalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion5VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion5VerticalScrollbarHandle == null || _scrollExampleScrollableRegion5VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion5VerticalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion5VerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion5VerticalScrollbarHandle.Name = "ScrollExampleScrollableRegion5VerticalScrollbarHandle";
                    _scrollExampleScrollableRegion5VerticalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion5VerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion5VerticalScrollbarHandle;
            }
        }

        private static Template _scrollExampleRegion21;
        public static Template ScrollExampleRegion21
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion21 == null || _scrollExampleRegion21.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion21 == null)
#endif
                {
                    _scrollExampleRegion21 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion21.Name = "ScrollExampleRegion21";
                    _scrollExampleRegion21.LineNumber = 45;
                    _scrollExampleRegion21.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion21, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion21, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion21, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _scrollExampleRegion21;
            }
        }

        private static Template _scrollExampleRegion22;
        public static Template ScrollExampleRegion22
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion22 == null || _scrollExampleRegion22.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion22 == null)
#endif
                {
                    _scrollExampleRegion22 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion22.Name = "ScrollExampleRegion22";
                    _scrollExampleRegion22.LineNumber = 46;
                    _scrollExampleRegion22.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion22, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion22, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion22, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion22, Delight.ElementAlignment.TopLeft);
                }
                return _scrollExampleRegion22;
            }
        }

        private static Template _scrollExampleRegion23;
        public static Template ScrollExampleRegion23
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion23 == null || _scrollExampleRegion23.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion23 == null)
#endif
                {
                    _scrollExampleRegion23 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion23.Name = "ScrollExampleRegion23";
                    _scrollExampleRegion23.LineNumber = 47;
                    _scrollExampleRegion23.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion23, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion23, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion23, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion23, Delight.ElementAlignment.TopRight);
                }
                return _scrollExampleRegion23;
            }
        }

        private static Template _scrollExampleRegion24;
        public static Template ScrollExampleRegion24
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion24 == null || _scrollExampleRegion24.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion24 == null)
#endif
                {
                    _scrollExampleRegion24 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion24.Name = "ScrollExampleRegion24";
                    _scrollExampleRegion24.LineNumber = 48;
                    _scrollExampleRegion24.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion24, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion24, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion24, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion24, Delight.ElementAlignment.BottomLeft);
                }
                return _scrollExampleRegion24;
            }
        }

        private static Template _scrollExampleRegion25;
        public static Template ScrollExampleRegion25
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion25 == null || _scrollExampleRegion25.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion25 == null)
#endif
                {
                    _scrollExampleRegion25 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion25.Name = "ScrollExampleRegion25";
                    _scrollExampleRegion25.LineNumber = 49;
                    _scrollExampleRegion25.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion25, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion25, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion25, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion25, Delight.ElementAlignment.BottomRight);
                }
                return _scrollExampleRegion25;
            }
        }

        private static Template _scrollExampleScrollableRegion6;
        public static Template ScrollExampleScrollableRegion6
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion6 == null || _scrollExampleScrollableRegion6.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion6 == null)
#endif
                {
                    _scrollExampleScrollableRegion6 = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion6.Name = "ScrollExampleScrollableRegion6";
                    _scrollExampleScrollableRegion6.LineNumber = 53;
                    _scrollExampleScrollableRegion6.LinePosition = 6;
#endif
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_scrollExampleScrollableRegion6, Delight.ElementAlignment.Right);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollExampleScrollableRegion6, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollExampleScrollableRegion6, Delight.ScrollBounds.None);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollExampleScrollableRegion6, ScrollExampleScrollableRegion6ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion6, ScrollExampleScrollableRegion6HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion6, ScrollExampleScrollableRegion6VerticalScrollbar);
                }
                return _scrollExampleScrollableRegion6;
            }
        }

        private static Template _scrollExampleScrollableRegion6ContentRegion;
        public static Template ScrollExampleScrollableRegion6ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion6ContentRegion == null || _scrollExampleScrollableRegion6ContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion6ContentRegion == null)
#endif
                {
                    _scrollExampleScrollableRegion6ContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion6ContentRegion.Name = "ScrollExampleScrollableRegion6ContentRegion";
                    _scrollExampleScrollableRegion6ContentRegion.LineNumber = 24;
                    _scrollExampleScrollableRegion6ContentRegion.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion6ContentRegion;
            }
        }

        private static Template _scrollExampleScrollableRegion6HorizontalScrollbar;
        public static Template ScrollExampleScrollableRegion6HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion6HorizontalScrollbar == null || _scrollExampleScrollableRegion6HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion6HorizontalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion6HorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion6HorizontalScrollbar.Name = "ScrollExampleScrollableRegion6HorizontalScrollbar";
                    _scrollExampleScrollableRegion6HorizontalScrollbar.LineNumber = 26;
                    _scrollExampleScrollableRegion6HorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion6HorizontalScrollbar, ScrollExampleScrollableRegion6HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion6HorizontalScrollbar, ScrollExampleScrollableRegion6HorizontalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion6HorizontalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion6HorizontalScrollbarBar;
        public static Template ScrollExampleScrollableRegion6HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion6HorizontalScrollbarBar == null || _scrollExampleScrollableRegion6HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion6HorizontalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion6HorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion6HorizontalScrollbarBar.Name = "ScrollExampleScrollableRegion6HorizontalScrollbarBar";
                    _scrollExampleScrollableRegion6HorizontalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion6HorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion6HorizontalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion6HorizontalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion6HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion6HorizontalScrollbarHandle == null || _scrollExampleScrollableRegion6HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion6HorizontalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion6HorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion6HorizontalScrollbarHandle.Name = "ScrollExampleScrollableRegion6HorizontalScrollbarHandle";
                    _scrollExampleScrollableRegion6HorizontalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion6HorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion6HorizontalScrollbarHandle;
            }
        }

        private static Template _scrollExampleScrollableRegion6VerticalScrollbar;
        public static Template ScrollExampleScrollableRegion6VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion6VerticalScrollbar == null || _scrollExampleScrollableRegion6VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion6VerticalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion6VerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion6VerticalScrollbar.Name = "ScrollExampleScrollableRegion6VerticalScrollbar";
                    _scrollExampleScrollableRegion6VerticalScrollbar.LineNumber = 27;
                    _scrollExampleScrollableRegion6VerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion6VerticalScrollbar, ScrollExampleScrollableRegion6VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion6VerticalScrollbar, ScrollExampleScrollableRegion6VerticalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion6VerticalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion6VerticalScrollbarBar;
        public static Template ScrollExampleScrollableRegion6VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion6VerticalScrollbarBar == null || _scrollExampleScrollableRegion6VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion6VerticalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion6VerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion6VerticalScrollbarBar.Name = "ScrollExampleScrollableRegion6VerticalScrollbarBar";
                    _scrollExampleScrollableRegion6VerticalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion6VerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion6VerticalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion6VerticalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion6VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion6VerticalScrollbarHandle == null || _scrollExampleScrollableRegion6VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion6VerticalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion6VerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion6VerticalScrollbarHandle.Name = "ScrollExampleScrollableRegion6VerticalScrollbarHandle";
                    _scrollExampleScrollableRegion6VerticalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion6VerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion6VerticalScrollbarHandle;
            }
        }

        private static Template _scrollExampleRegion26;
        public static Template ScrollExampleRegion26
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion26 == null || _scrollExampleRegion26.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion26 == null)
#endif
                {
                    _scrollExampleRegion26 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion26.Name = "ScrollExampleRegion26";
                    _scrollExampleRegion26.LineNumber = 55;
                    _scrollExampleRegion26.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion26, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion26, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion26, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _scrollExampleRegion26;
            }
        }

        private static Template _scrollExampleRegion27;
        public static Template ScrollExampleRegion27
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion27 == null || _scrollExampleRegion27.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion27 == null)
#endif
                {
                    _scrollExampleRegion27 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion27.Name = "ScrollExampleRegion27";
                    _scrollExampleRegion27.LineNumber = 56;
                    _scrollExampleRegion27.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion27, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion27, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion27, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion27, Delight.ElementAlignment.TopLeft);
                }
                return _scrollExampleRegion27;
            }
        }

        private static Template _scrollExampleRegion28;
        public static Template ScrollExampleRegion28
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion28 == null || _scrollExampleRegion28.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion28 == null)
#endif
                {
                    _scrollExampleRegion28 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion28.Name = "ScrollExampleRegion28";
                    _scrollExampleRegion28.LineNumber = 57;
                    _scrollExampleRegion28.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion28, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion28, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion28, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion28, Delight.ElementAlignment.TopRight);
                }
                return _scrollExampleRegion28;
            }
        }

        private static Template _scrollExampleRegion29;
        public static Template ScrollExampleRegion29
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion29 == null || _scrollExampleRegion29.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion29 == null)
#endif
                {
                    _scrollExampleRegion29 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion29.Name = "ScrollExampleRegion29";
                    _scrollExampleRegion29.LineNumber = 58;
                    _scrollExampleRegion29.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion29, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion29, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion29, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion29, Delight.ElementAlignment.BottomLeft);
                }
                return _scrollExampleRegion29;
            }
        }

        private static Template _scrollExampleRegion30;
        public static Template ScrollExampleRegion30
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion30 == null || _scrollExampleRegion30.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion30 == null)
#endif
                {
                    _scrollExampleRegion30 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion30.Name = "ScrollExampleRegion30";
                    _scrollExampleRegion30.LineNumber = 59;
                    _scrollExampleRegion30.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion30, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion30, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion30, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion30, Delight.ElementAlignment.BottomRight);
                }
                return _scrollExampleRegion30;
            }
        }

        private static Template _scrollExampleScrollableRegion7;
        public static Template ScrollExampleScrollableRegion7
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion7 == null || _scrollExampleScrollableRegion7.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion7 == null)
#endif
                {
                    _scrollExampleScrollableRegion7 = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion7.Name = "ScrollExampleScrollableRegion7";
                    _scrollExampleScrollableRegion7.LineNumber = 63;
                    _scrollExampleScrollableRegion7.LinePosition = 6;
#endif
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_scrollExampleScrollableRegion7, Delight.ElementAlignment.BottomLeft);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollExampleScrollableRegion7, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollExampleScrollableRegion7, Delight.ScrollBounds.Clamped);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollExampleScrollableRegion7, ScrollExampleScrollableRegion7ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion7, ScrollExampleScrollableRegion7HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion7, ScrollExampleScrollableRegion7VerticalScrollbar);
                }
                return _scrollExampleScrollableRegion7;
            }
        }

        private static Template _scrollExampleScrollableRegion7ContentRegion;
        public static Template ScrollExampleScrollableRegion7ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion7ContentRegion == null || _scrollExampleScrollableRegion7ContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion7ContentRegion == null)
#endif
                {
                    _scrollExampleScrollableRegion7ContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion7ContentRegion.Name = "ScrollExampleScrollableRegion7ContentRegion";
                    _scrollExampleScrollableRegion7ContentRegion.LineNumber = 24;
                    _scrollExampleScrollableRegion7ContentRegion.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion7ContentRegion;
            }
        }

        private static Template _scrollExampleScrollableRegion7HorizontalScrollbar;
        public static Template ScrollExampleScrollableRegion7HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion7HorizontalScrollbar == null || _scrollExampleScrollableRegion7HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion7HorizontalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion7HorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion7HorizontalScrollbar.Name = "ScrollExampleScrollableRegion7HorizontalScrollbar";
                    _scrollExampleScrollableRegion7HorizontalScrollbar.LineNumber = 26;
                    _scrollExampleScrollableRegion7HorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion7HorizontalScrollbar, ScrollExampleScrollableRegion7HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion7HorizontalScrollbar, ScrollExampleScrollableRegion7HorizontalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion7HorizontalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion7HorizontalScrollbarBar;
        public static Template ScrollExampleScrollableRegion7HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion7HorizontalScrollbarBar == null || _scrollExampleScrollableRegion7HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion7HorizontalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion7HorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion7HorizontalScrollbarBar.Name = "ScrollExampleScrollableRegion7HorizontalScrollbarBar";
                    _scrollExampleScrollableRegion7HorizontalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion7HorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion7HorizontalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion7HorizontalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion7HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion7HorizontalScrollbarHandle == null || _scrollExampleScrollableRegion7HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion7HorizontalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion7HorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion7HorizontalScrollbarHandle.Name = "ScrollExampleScrollableRegion7HorizontalScrollbarHandle";
                    _scrollExampleScrollableRegion7HorizontalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion7HorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion7HorizontalScrollbarHandle;
            }
        }

        private static Template _scrollExampleScrollableRegion7VerticalScrollbar;
        public static Template ScrollExampleScrollableRegion7VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion7VerticalScrollbar == null || _scrollExampleScrollableRegion7VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion7VerticalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion7VerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion7VerticalScrollbar.Name = "ScrollExampleScrollableRegion7VerticalScrollbar";
                    _scrollExampleScrollableRegion7VerticalScrollbar.LineNumber = 27;
                    _scrollExampleScrollableRegion7VerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion7VerticalScrollbar, ScrollExampleScrollableRegion7VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion7VerticalScrollbar, ScrollExampleScrollableRegion7VerticalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion7VerticalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion7VerticalScrollbarBar;
        public static Template ScrollExampleScrollableRegion7VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion7VerticalScrollbarBar == null || _scrollExampleScrollableRegion7VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion7VerticalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion7VerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion7VerticalScrollbarBar.Name = "ScrollExampleScrollableRegion7VerticalScrollbarBar";
                    _scrollExampleScrollableRegion7VerticalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion7VerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion7VerticalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion7VerticalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion7VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion7VerticalScrollbarHandle == null || _scrollExampleScrollableRegion7VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion7VerticalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion7VerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion7VerticalScrollbarHandle.Name = "ScrollExampleScrollableRegion7VerticalScrollbarHandle";
                    _scrollExampleScrollableRegion7VerticalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion7VerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion7VerticalScrollbarHandle;
            }
        }

        private static Template _scrollExampleRegion31;
        public static Template ScrollExampleRegion31
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion31 == null || _scrollExampleRegion31.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion31 == null)
#endif
                {
                    _scrollExampleRegion31 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion31.Name = "ScrollExampleRegion31";
                    _scrollExampleRegion31.LineNumber = 65;
                    _scrollExampleRegion31.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion31, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion31, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion31, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _scrollExampleRegion31;
            }
        }

        private static Template _scrollExampleRegion32;
        public static Template ScrollExampleRegion32
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion32 == null || _scrollExampleRegion32.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion32 == null)
#endif
                {
                    _scrollExampleRegion32 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion32.Name = "ScrollExampleRegion32";
                    _scrollExampleRegion32.LineNumber = 66;
                    _scrollExampleRegion32.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion32, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion32, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion32, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion32, Delight.ElementAlignment.TopLeft);
                }
                return _scrollExampleRegion32;
            }
        }

        private static Template _scrollExampleRegion33;
        public static Template ScrollExampleRegion33
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion33 == null || _scrollExampleRegion33.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion33 == null)
#endif
                {
                    _scrollExampleRegion33 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion33.Name = "ScrollExampleRegion33";
                    _scrollExampleRegion33.LineNumber = 67;
                    _scrollExampleRegion33.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion33, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion33, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion33, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion33, Delight.ElementAlignment.TopRight);
                }
                return _scrollExampleRegion33;
            }
        }

        private static Template _scrollExampleRegion34;
        public static Template ScrollExampleRegion34
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion34 == null || _scrollExampleRegion34.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion34 == null)
#endif
                {
                    _scrollExampleRegion34 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion34.Name = "ScrollExampleRegion34";
                    _scrollExampleRegion34.LineNumber = 68;
                    _scrollExampleRegion34.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion34, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion34, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion34, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion34, Delight.ElementAlignment.BottomLeft);
                }
                return _scrollExampleRegion34;
            }
        }

        private static Template _scrollExampleRegion35;
        public static Template ScrollExampleRegion35
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion35 == null || _scrollExampleRegion35.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion35 == null)
#endif
                {
                    _scrollExampleRegion35 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion35.Name = "ScrollExampleRegion35";
                    _scrollExampleRegion35.LineNumber = 69;
                    _scrollExampleRegion35.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion35, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion35, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion35, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion35, Delight.ElementAlignment.BottomRight);
                }
                return _scrollExampleRegion35;
            }
        }

        private static Template _scrollExampleScrollableRegion8;
        public static Template ScrollExampleScrollableRegion8
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion8 == null || _scrollExampleScrollableRegion8.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion8 == null)
#endif
                {
                    _scrollExampleScrollableRegion8 = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion8.Name = "ScrollExampleScrollableRegion8";
                    _scrollExampleScrollableRegion8.LineNumber = 73;
                    _scrollExampleScrollableRegion8.LinePosition = 6;
#endif
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_scrollExampleScrollableRegion8, Delight.ElementAlignment.Bottom);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollExampleScrollableRegion8, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollExampleScrollableRegion8, Delight.ScrollBounds.Clamped);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollExampleScrollableRegion8, ScrollExampleScrollableRegion8ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion8, ScrollExampleScrollableRegion8HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion8, ScrollExampleScrollableRegion8VerticalScrollbar);
                }
                return _scrollExampleScrollableRegion8;
            }
        }

        private static Template _scrollExampleScrollableRegion8ContentRegion;
        public static Template ScrollExampleScrollableRegion8ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion8ContentRegion == null || _scrollExampleScrollableRegion8ContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion8ContentRegion == null)
#endif
                {
                    _scrollExampleScrollableRegion8ContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion8ContentRegion.Name = "ScrollExampleScrollableRegion8ContentRegion";
                    _scrollExampleScrollableRegion8ContentRegion.LineNumber = 24;
                    _scrollExampleScrollableRegion8ContentRegion.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion8ContentRegion;
            }
        }

        private static Template _scrollExampleScrollableRegion8HorizontalScrollbar;
        public static Template ScrollExampleScrollableRegion8HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion8HorizontalScrollbar == null || _scrollExampleScrollableRegion8HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion8HorizontalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion8HorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion8HorizontalScrollbar.Name = "ScrollExampleScrollableRegion8HorizontalScrollbar";
                    _scrollExampleScrollableRegion8HorizontalScrollbar.LineNumber = 26;
                    _scrollExampleScrollableRegion8HorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion8HorizontalScrollbar, ScrollExampleScrollableRegion8HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion8HorizontalScrollbar, ScrollExampleScrollableRegion8HorizontalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion8HorizontalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion8HorizontalScrollbarBar;
        public static Template ScrollExampleScrollableRegion8HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion8HorizontalScrollbarBar == null || _scrollExampleScrollableRegion8HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion8HorizontalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion8HorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion8HorizontalScrollbarBar.Name = "ScrollExampleScrollableRegion8HorizontalScrollbarBar";
                    _scrollExampleScrollableRegion8HorizontalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion8HorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion8HorizontalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion8HorizontalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion8HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion8HorizontalScrollbarHandle == null || _scrollExampleScrollableRegion8HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion8HorizontalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion8HorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion8HorizontalScrollbarHandle.Name = "ScrollExampleScrollableRegion8HorizontalScrollbarHandle";
                    _scrollExampleScrollableRegion8HorizontalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion8HorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion8HorizontalScrollbarHandle;
            }
        }

        private static Template _scrollExampleScrollableRegion8VerticalScrollbar;
        public static Template ScrollExampleScrollableRegion8VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion8VerticalScrollbar == null || _scrollExampleScrollableRegion8VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion8VerticalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion8VerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion8VerticalScrollbar.Name = "ScrollExampleScrollableRegion8VerticalScrollbar";
                    _scrollExampleScrollableRegion8VerticalScrollbar.LineNumber = 27;
                    _scrollExampleScrollableRegion8VerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion8VerticalScrollbar, ScrollExampleScrollableRegion8VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion8VerticalScrollbar, ScrollExampleScrollableRegion8VerticalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion8VerticalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion8VerticalScrollbarBar;
        public static Template ScrollExampleScrollableRegion8VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion8VerticalScrollbarBar == null || _scrollExampleScrollableRegion8VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion8VerticalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion8VerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion8VerticalScrollbarBar.Name = "ScrollExampleScrollableRegion8VerticalScrollbarBar";
                    _scrollExampleScrollableRegion8VerticalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion8VerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion8VerticalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion8VerticalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion8VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion8VerticalScrollbarHandle == null || _scrollExampleScrollableRegion8VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion8VerticalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion8VerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion8VerticalScrollbarHandle.Name = "ScrollExampleScrollableRegion8VerticalScrollbarHandle";
                    _scrollExampleScrollableRegion8VerticalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion8VerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion8VerticalScrollbarHandle;
            }
        }

        private static Template _scrollExampleRegion36;
        public static Template ScrollExampleRegion36
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion36 == null || _scrollExampleRegion36.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion36 == null)
#endif
                {
                    _scrollExampleRegion36 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion36.Name = "ScrollExampleRegion36";
                    _scrollExampleRegion36.LineNumber = 75;
                    _scrollExampleRegion36.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion36, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion36, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion36, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _scrollExampleRegion36;
            }
        }

        private static Template _scrollExampleRegion37;
        public static Template ScrollExampleRegion37
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion37 == null || _scrollExampleRegion37.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion37 == null)
#endif
                {
                    _scrollExampleRegion37 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion37.Name = "ScrollExampleRegion37";
                    _scrollExampleRegion37.LineNumber = 76;
                    _scrollExampleRegion37.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion37, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion37, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion37, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion37, Delight.ElementAlignment.TopLeft);
                }
                return _scrollExampleRegion37;
            }
        }

        private static Template _scrollExampleRegion38;
        public static Template ScrollExampleRegion38
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion38 == null || _scrollExampleRegion38.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion38 == null)
#endif
                {
                    _scrollExampleRegion38 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion38.Name = "ScrollExampleRegion38";
                    _scrollExampleRegion38.LineNumber = 77;
                    _scrollExampleRegion38.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion38, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion38, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion38, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion38, Delight.ElementAlignment.TopRight);
                }
                return _scrollExampleRegion38;
            }
        }

        private static Template _scrollExampleRegion39;
        public static Template ScrollExampleRegion39
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion39 == null || _scrollExampleRegion39.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion39 == null)
#endif
                {
                    _scrollExampleRegion39 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion39.Name = "ScrollExampleRegion39";
                    _scrollExampleRegion39.LineNumber = 78;
                    _scrollExampleRegion39.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion39, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion39, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion39, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion39, Delight.ElementAlignment.BottomLeft);
                }
                return _scrollExampleRegion39;
            }
        }

        private static Template _scrollExampleRegion40;
        public static Template ScrollExampleRegion40
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion40 == null || _scrollExampleRegion40.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion40 == null)
#endif
                {
                    _scrollExampleRegion40 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion40.Name = "ScrollExampleRegion40";
                    _scrollExampleRegion40.LineNumber = 79;
                    _scrollExampleRegion40.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion40, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion40, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion40, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion40, Delight.ElementAlignment.BottomRight);
                }
                return _scrollExampleRegion40;
            }
        }

        private static Template _scrollExampleScrollableRegion9;
        public static Template ScrollExampleScrollableRegion9
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion9 == null || _scrollExampleScrollableRegion9.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion9 == null)
#endif
                {
                    _scrollExampleScrollableRegion9 = new Template(ScrollableRegionTemplates.ScrollableRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion9.Name = "ScrollExampleScrollableRegion9";
                    _scrollExampleScrollableRegion9.LineNumber = 83;
                    _scrollExampleScrollableRegion9.LinePosition = 6;
#endif
                    Delight.ScrollableRegion.ContentAlignmentProperty.SetDefault(_scrollExampleScrollableRegion9, Delight.ElementAlignment.BottomRight);
                    Delight.ScrollableRegion.CanScrollVerticallyProperty.SetDefault(_scrollExampleScrollableRegion9, true);
                    Delight.ScrollableRegion.ScrollBoundsProperty.SetDefault(_scrollExampleScrollableRegion9, Delight.ScrollBounds.Clamped);
                    Delight.ScrollableRegion.ContentRegionTemplateProperty.SetDefault(_scrollExampleScrollableRegion9, ScrollExampleScrollableRegion9ContentRegion);
                    Delight.ScrollableRegion.HorizontalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion9, ScrollExampleScrollableRegion9HorizontalScrollbar);
                    Delight.ScrollableRegion.VerticalScrollbarTemplateProperty.SetDefault(_scrollExampleScrollableRegion9, ScrollExampleScrollableRegion9VerticalScrollbar);
                }
                return _scrollExampleScrollableRegion9;
            }
        }

        private static Template _scrollExampleScrollableRegion9ContentRegion;
        public static Template ScrollExampleScrollableRegion9ContentRegion
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion9ContentRegion == null || _scrollExampleScrollableRegion9ContentRegion.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion9ContentRegion == null)
#endif
                {
                    _scrollExampleScrollableRegion9ContentRegion = new Template(ScrollableRegionTemplates.ScrollableRegionContentRegion);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion9ContentRegion.Name = "ScrollExampleScrollableRegion9ContentRegion";
                    _scrollExampleScrollableRegion9ContentRegion.LineNumber = 24;
                    _scrollExampleScrollableRegion9ContentRegion.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion9ContentRegion;
            }
        }

        private static Template _scrollExampleScrollableRegion9HorizontalScrollbar;
        public static Template ScrollExampleScrollableRegion9HorizontalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion9HorizontalScrollbar == null || _scrollExampleScrollableRegion9HorizontalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion9HorizontalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion9HorizontalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion9HorizontalScrollbar.Name = "ScrollExampleScrollableRegion9HorizontalScrollbar";
                    _scrollExampleScrollableRegion9HorizontalScrollbar.LineNumber = 26;
                    _scrollExampleScrollableRegion9HorizontalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion9HorizontalScrollbar, ScrollExampleScrollableRegion9HorizontalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion9HorizontalScrollbar, ScrollExampleScrollableRegion9HorizontalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion9HorizontalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion9HorizontalScrollbarBar;
        public static Template ScrollExampleScrollableRegion9HorizontalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion9HorizontalScrollbarBar == null || _scrollExampleScrollableRegion9HorizontalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion9HorizontalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion9HorizontalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion9HorizontalScrollbarBar.Name = "ScrollExampleScrollableRegion9HorizontalScrollbarBar";
                    _scrollExampleScrollableRegion9HorizontalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion9HorizontalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion9HorizontalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion9HorizontalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion9HorizontalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion9HorizontalScrollbarHandle == null || _scrollExampleScrollableRegion9HorizontalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion9HorizontalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion9HorizontalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionHorizontalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion9HorizontalScrollbarHandle.Name = "ScrollExampleScrollableRegion9HorizontalScrollbarHandle";
                    _scrollExampleScrollableRegion9HorizontalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion9HorizontalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion9HorizontalScrollbarHandle;
            }
        }

        private static Template _scrollExampleScrollableRegion9VerticalScrollbar;
        public static Template ScrollExampleScrollableRegion9VerticalScrollbar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion9VerticalScrollbar == null || _scrollExampleScrollableRegion9VerticalScrollbar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion9VerticalScrollbar == null)
#endif
                {
                    _scrollExampleScrollableRegion9VerticalScrollbar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion9VerticalScrollbar.Name = "ScrollExampleScrollableRegion9VerticalScrollbar";
                    _scrollExampleScrollableRegion9VerticalScrollbar.LineNumber = 27;
                    _scrollExampleScrollableRegion9VerticalScrollbar.LinePosition = 4;
#endif
                    Delight.Scrollbar.BarTemplateProperty.SetDefault(_scrollExampleScrollableRegion9VerticalScrollbar, ScrollExampleScrollableRegion9VerticalScrollbarBar);
                    Delight.Scrollbar.HandleTemplateProperty.SetDefault(_scrollExampleScrollableRegion9VerticalScrollbar, ScrollExampleScrollableRegion9VerticalScrollbarHandle);
                }
                return _scrollExampleScrollableRegion9VerticalScrollbar;
            }
        }

        private static Template _scrollExampleScrollableRegion9VerticalScrollbarBar;
        public static Template ScrollExampleScrollableRegion9VerticalScrollbarBar
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion9VerticalScrollbarBar == null || _scrollExampleScrollableRegion9VerticalScrollbarBar.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion9VerticalScrollbarBar == null)
#endif
                {
                    _scrollExampleScrollableRegion9VerticalScrollbarBar = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarBar);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion9VerticalScrollbarBar.Name = "ScrollExampleScrollableRegion9VerticalScrollbarBar";
                    _scrollExampleScrollableRegion9VerticalScrollbarBar.LineNumber = 7;
                    _scrollExampleScrollableRegion9VerticalScrollbarBar.LinePosition = 4;
#endif
                }
                return _scrollExampleScrollableRegion9VerticalScrollbarBar;
            }
        }

        private static Template _scrollExampleScrollableRegion9VerticalScrollbarHandle;
        public static Template ScrollExampleScrollableRegion9VerticalScrollbarHandle
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleScrollableRegion9VerticalScrollbarHandle == null || _scrollExampleScrollableRegion9VerticalScrollbarHandle.CurrentVersion != Template.Version)
#else
                if (_scrollExampleScrollableRegion9VerticalScrollbarHandle == null)
#endif
                {
                    _scrollExampleScrollableRegion9VerticalScrollbarHandle = new Template(ScrollableRegionTemplates.ScrollableRegionVerticalScrollbarHandle);
#if UNITY_EDITOR
                    _scrollExampleScrollableRegion9VerticalScrollbarHandle.Name = "ScrollExampleScrollableRegion9VerticalScrollbarHandle";
                    _scrollExampleScrollableRegion9VerticalScrollbarHandle.LineNumber = 8;
                    _scrollExampleScrollableRegion9VerticalScrollbarHandle.LinePosition = 6;
#endif
                }
                return _scrollExampleScrollableRegion9VerticalScrollbarHandle;
            }
        }

        private static Template _scrollExampleRegion41;
        public static Template ScrollExampleRegion41
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion41 == null || _scrollExampleRegion41.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion41 == null)
#endif
                {
                    _scrollExampleRegion41 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion41.Name = "ScrollExampleRegion41";
                    _scrollExampleRegion41.LineNumber = 85;
                    _scrollExampleRegion41.LinePosition = 8;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion41, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion41, new ElementSize(500f, ElementSizeUnit.Pixels));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion41, new UnityEngine.Color(1f, 1f, 1f, 1f));
                }
                return _scrollExampleRegion41;
            }
        }

        private static Template _scrollExampleRegion42;
        public static Template ScrollExampleRegion42
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion42 == null || _scrollExampleRegion42.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion42 == null)
#endif
                {
                    _scrollExampleRegion42 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion42.Name = "ScrollExampleRegion42";
                    _scrollExampleRegion42.LineNumber = 86;
                    _scrollExampleRegion42.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion42, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion42, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion42, new UnityEngine.Color(0f, 0f, 1f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion42, Delight.ElementAlignment.TopLeft);
                }
                return _scrollExampleRegion42;
            }
        }

        private static Template _scrollExampleRegion43;
        public static Template ScrollExampleRegion43
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion43 == null || _scrollExampleRegion43.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion43 == null)
#endif
                {
                    _scrollExampleRegion43 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion43.Name = "ScrollExampleRegion43";
                    _scrollExampleRegion43.LineNumber = 87;
                    _scrollExampleRegion43.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion43, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion43, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion43, new UnityEngine.Color(1f, 0f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion43, Delight.ElementAlignment.TopRight);
                }
                return _scrollExampleRegion43;
            }
        }

        private static Template _scrollExampleRegion44;
        public static Template ScrollExampleRegion44
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion44 == null || _scrollExampleRegion44.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion44 == null)
#endif
                {
                    _scrollExampleRegion44 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion44.Name = "ScrollExampleRegion44";
                    _scrollExampleRegion44.LineNumber = 88;
                    _scrollExampleRegion44.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion44, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion44, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion44, new UnityEngine.Color(0f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion44, Delight.ElementAlignment.BottomLeft);
                }
                return _scrollExampleRegion44;
            }
        }

        private static Template _scrollExampleRegion45;
        public static Template ScrollExampleRegion45
        {
            get
            {
#if UNITY_EDITOR
                if (_scrollExampleRegion45 == null || _scrollExampleRegion45.CurrentVersion != Template.Version)
#else
                if (_scrollExampleRegion45 == null)
#endif
                {
                    _scrollExampleRegion45 = new Template(RegionTemplates.Region);
#if UNITY_EDITOR
                    _scrollExampleRegion45.Name = "ScrollExampleRegion45";
                    _scrollExampleRegion45.LineNumber = 89;
                    _scrollExampleRegion45.LinePosition = 10;
#endif
                    Delight.Region.WidthProperty.SetDefault(_scrollExampleRegion45, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.HeightProperty.SetDefault(_scrollExampleRegion45, new ElementSize(0.5f, ElementSizeUnit.Percents));
                    Delight.Region.BackgroundColorProperty.SetDefault(_scrollExampleRegion45, new UnityEngine.Color(1f, 1f, 0f, 1f));
                    Delight.Region.AlignmentProperty.SetDefault(_scrollExampleRegion45, Delight.ElementAlignment.BottomRight);
                }
                return _scrollExampleRegion45;
            }
        }

        #endregion
    }

    #endregion
}
