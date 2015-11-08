using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class Gradebook : GradeTracker
    {

        // Constructor
        public Gradebook()
        {
            // initializing this new list in the constructor.
            grades = new List<float>();
            _name = "Default GradeBook Name";
        }

        // Method for computing statistics.
        // Returns an instance of the GradeStatistics class
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("GradeBook::ComputeStatistics");

            // Instantiate the GradeStatistics object that will be returned
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (var grade in grades)
            {
                sum += grade;
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
            }
            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        // The _ prefix is indicative that it is a private variable
        // private field (not a property because does not use get/set declarations)
        // It is readonly because it will only be modified by methods
        protected readonly List<float> grades;

        //method to add a grade to the grades private field
        public override void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine(grades[i]);
            }
        }
    }
}