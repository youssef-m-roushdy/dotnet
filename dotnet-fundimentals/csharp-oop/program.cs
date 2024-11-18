using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_oop
{
    public class program
    {
        public static void Main()
        {
            Student std1 = new Student();
            Student std2 = new Student(2, "Ahmed");
            //std1.acceptDetails();
            std1.displayDetails();
            std2.displayDetails();
        }
    }

    class Student
    {
        // By default all members of the class is encasulated you can access
        // them by give the the public access modifier

        //Data Members
        public int studentID;
        public string studentName;

        //Default Constructor
        public Student()
        {
            studentID = 1;
            studentName = "Youssef";
        }

        //Paramiterized Constructor
        public Student(int student_id, string student_name)
        {
            studentID = student_id;
            studentName = student_name;
        }
        //Member functions
        // public void acceptDetails()
        // {
        //     Console.Write("Enter Student ID: ");
        //     studentID = int.Parse(Console.ReadLine());
        //     Console.Write("Enter Student Name: ");
        //     studentName = Console.ReadLine();
        // }
        public void displayDetails()
        {
            Console.WriteLine($"StudentId: {studentID} and his name: {studentName}");
        }
    }
}