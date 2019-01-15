// Internal view logic generated from "MainView.xml"
#region Using Statements
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
#endregion

namespace Delight
{
    public partial class MainViewModel
    {
        private IDataProvider<Student> _studentDataProvider;
        public ObservableList<Student> Students { get; private set; }

        public MainViewModel(IDataProvider<Student> provider)
        {
            _studentDataProvider = provider;
            LoadStudents();
        }

        private void LoadStudents()
        {
            var students = _studentDataProvider.GetAll();
            Students = new ObservableList<Student>(students);
        }
    }

    public interface IDataProvider<T>
    {
        IEnumerable<T> GetAll();
    }

    public class StudentDataProvider : IDataProvider<Student>
    {
        public IEnumerable<Student> GetAll()
        {
            yield return new Student { Name = "Patrik" };
            yield return new Student { Name = "Julia" };
            yield return new Student { Name = "Victoria" };
            yield return new Student { Name = "Jessica" };
            yield return new Student { Name = "Anna" };
            yield return new Student { Name = "Delima" };
        }
    }
}
