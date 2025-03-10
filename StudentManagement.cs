using System;
using System.Collections.Generic;
using StudentLibrary;

namespace StudentManagement
{
    public class Program
    {
        static StudentRepository repo = new StudentRepository();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nStudent Management System");
                Console.WriteLine("1.Add Student\n2.View Students\n3.Update Student\n4.Delete Student\n5.Exit\nEnter your choice:  ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ViewStudents();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid Choice!! Please Try Again");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Student Email: ");
            string email = Console.ReadLine();

            Student student = new Student { Name = name, Age = age, Email = email };
            repo.AddStudent(student);
            Console.WriteLine("Student Added Successfully");
        }

        static void ViewStudents()
        {
            List<Student> students = repo.GetAllStudent();
            Console.WriteLine("\nStudent List: ");
            foreach (Student student in students)
            {
                Console.WriteLine($"ID : {student.Id}, Name: {student.Name}, Age: {student.Age}, Email: {student.Email}");
            }
        }
        static void UpdateStudent()
        {
            Console.WriteLine("Enter Student ID to Update : ");
            int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New  Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter New Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter New Email: ");
            string email = Console.ReadLine();

            Student student = new Student { Id = Id, Name = name, Age = age, Email = email };
            repo.UpdateStudent(student);
            Console.WriteLine("Student Updated Successfully");
        }
        static void DeleteStudent()
        {
            Console.WriteLine("Enter Student ID to Delete : ");
            int Id = Convert.ToInt32(Console.ReadLine());
            repo.DeleteStudent(Id);
            Console.WriteLine("Student deleted Successfully");
        }
    }
}
