#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;
#endregion

namespace Delight
{
    /// <summary>
    /// Binding test view.
    /// </summary>
    public partial class BindingTest
    {
        #region Fields

        #endregion

        #region Methods

        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            TestBinding2 = new Color(0.7f, 0.4f, 0.8f);
        }

        protected override void AfterUnload()
        {
            base.AfterUnload();

            // add your logic here
        }

        public int i = 0;
        public void Test1()
        {
            Debug.Log("Setting TestBinding and TestBinding2");
            TestBinding = "Clicked " + ++i;
            TestBinding2 = new Color(0.2f, 0.53f, 1f);
        }

        public void Test2(Button sender, PointerEventData eventData)
        {
            Debug.Log("Setting Label1.Text = Woho");
            ///Label1.Text = "Woho";
            Button4.Text = "Hey!";
            Debug.Log("TestBinding = " + TestBinding);
        }

        #endregion
    }

    // Test type
    public class TestType2 : DependencyObject
    {
        public readonly static DependencyProperty<System.String> TextProperty = new DependencyProperty<System.String>();
        public System.String Text
        {
            get { return TextProperty.GetValue(this); }
            set { TextProperty.SetValue(this, value); }
        }

        public readonly static DependencyProperty<Color> ColorProperty = new DependencyProperty<Color>();

        public TestType2(View parent, string id = null, Template template = null) : base(id, template)
        {
        }

        public Color Color
        {
            get { return ColorProperty.GetValue(this); }
            set { ColorProperty.SetValue(this, value); }
        }
    }
}
