using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_ConsoleApp
{
    public class Student
    {
        public int id {  get; set; }
        public string name { get; set; }
    }

    public class StudentView
    {
        public void DisplayStudent(Student student)
        {
            Console.WriteLine($"Id : {student.id} and Name : {student.name}");
        }
    }

    public class StudentController
    {
        private Student _student;
        private StudentView _view;

        public StudentController(Student student, StudentView view)
        {
            _student = student;
            _view = view;
        }

        public void SetStudentName(string name)
        {
            _student.name = name;
        }

        public void UpdateView()
        {
            _view.DisplayStudent( _student );
        }
    }

    
    internal class StudentMVC
    {
        public static void Applications()
        {
            Student student = new Student { id = 1, name = "Ram"};
            StudentView view = new StudentView();
            StudentController controller = new StudentController(student, view);

            controller.UpdateView();
            controller.SetStudentName("Krushna");
            controller.UpdateView();
        }

    }
}

//mvc based banking application with a menu - showing 1.create account, deposit, withdraw and show balance using mvc in c#