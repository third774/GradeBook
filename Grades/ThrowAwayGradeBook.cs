using System;

namespace Grades
{
    public class ThrowAwayGradeBook : Gradebook
    {
        // override will allow the compiler to reference the object type instead of
        // the variable type when calling this method. In this case, the object type
        // ThrowAwayGradeBook would remove the lowest score before computing
        // statistics.
        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("ThrowAwayGradeBook::ComputeStatistics");

            // The .MaxValue on the Float class returns the maximum storable value
            // for a float
            var lowest = float.MaxValue;

            Console.WriteLine(grades.GetType());
            foreach (var grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}