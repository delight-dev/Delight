#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class MainView
    {
        public MainViewModel ViewModel;

        protected override void BeforeLoad()
        {
            base.BeforeLoad();

            ViewModel = new MainViewModel(new StudentDataProvider());

            //var list = new List<Student, Label>(StudentList);
            //list.Items = ViewModel.Students;
            //list.Margin = new ElementMargin(10);
            //_bindings.Add(new Binding(TestBinding2Property, Button.BackgroundColorProperty, () => this, () => Button3, () => Button3.BackgroundColor = TestBinding2, () => TestBinding2 = Button3.BackgroundColor));
        }

        protected override void AfterLoad()
        {
            base.AfterLoad();
        }

        public void AddStudent()
        {
            //ViewModel.AddStudent();
        }

        public void RemoveStudent()
        {

        }

        public void EditStudent()
        {

        }

        public void SubmitChanges()
        {

        }
    }
}
