using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_oop
{
    public class Marks : Student
    {
        float objectiveMarks;
        float subjectiveMarks;

        public void acceptDetails()
        {
            base.acceptDetails();
            Console.Write("Enter Student Objective Marks: ");
            objectiveMarks = float.Parse(Console.ReadLine());
            Console.Write("Enter Student Subjective Marks: ");
            subjectiveMarks = float.Parse(Console.ReadLine());
        }
        public void displayDetails()
        {
            base.displayDetails();
            Console.WriteLine($"Student Objective Marks: {objectiveMarks}");
            Console.WriteLine($"Student Subjective Marks: {subjectiveMarks}");
        }
    }
}