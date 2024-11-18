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
            std1.acceptDetails();
            std1.displayDetails();
        }
    }

    class Student
    {
        // By default all members of the class is encasulated you can access
        // them by give the the public access modifier

        //Data Members
        public int studentID;
        public string studentName;

        //Member functions
        public void acceptDetails()
        {
            Console.Write("Enter Student ID: ");
            studentID = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Name: ");
            studentName = Console.ReadLine();
        }
        public void displayDetails()
        {
            Console.WriteLine($"StudentId: {studentID} and his name: {studentName}");
        }
    }
}