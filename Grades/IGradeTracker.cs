using System.IO;

namespace Grades
{
    internal interface IGradeTracker
    {
        void AddGrade(float grade);

        // Same as above - this is an abstract method, however, it returns a GradeStatistics type.
        GradeStatistics ComputeStatistics();

        void WriteGrades(TextWriter destination);

        string Name { get; set; }
    }
}