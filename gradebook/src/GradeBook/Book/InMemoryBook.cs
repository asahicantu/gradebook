using System;
using System.Collections.Generic;
using System.Linq;
namespace GradeBook
{
    public class InMemoryBook : Book, IBook
    {
        public override event GradeAddDelegate GradeAdded;
        private List<double> _grades = new List<double>();
        public InMemoryBook(string name) : base(name)
        {

        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                _grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}, must be between 0 and 100");
            }
        }

        public void AddGrade(char letter)
        {
            var grade = GetGradeFromLetter(letter);
            AddGrade(grade);
        }

        public override Statistics GetStatistics()
        {
            var stats = new Statistics(_grades);
            return stats;
        }
    }
}