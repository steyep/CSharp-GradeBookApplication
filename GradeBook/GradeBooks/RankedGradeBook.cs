using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            char[] grades = new char[] { 'A', 'B', 'C', 'D', 'F' };
            var index = Students.OrderByDescending(e => e.AverageGrade)
                // .Select(e => e.AverageGrade)
                .ToList()
                .FindIndex(e => e.AverageGrade == averageGrade);

            var threshold = Math.Ceiling(Students.Count * 0.2);
            return grades[(int) Math.Floor(index / threshold)];
        }
    }
}
