using System.Collections.Generic;
using System.Linq;
namespace GradeBook
{
    public class Statistics
    {

        public Statistics(IEnumerable<double> grades)
        {
            Grades = grades;
        }

        public IEnumerable<double> Grades = null;
        public double Average { get { return ValidGrades ? Grades.Average() : 0.0; } }
        public double HighScore { get { return ValidGrades ? Grades.Max() : 0.0; } }
        public double LowScore { get { return ValidGrades ? Grades.Min() : 0.0; } }

        public int TotalGrades { get { return Grades.Count(); } }

        public bool ValidGrades { get { return !(Grades is null) && Grades.Count() > 0; } }

        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 60.0:
                        return 'C';
                    case var d when d >= 40.0:
                        return 'D';
                    case var d when d >= 20.0:
                        return 'E';
                    case var d when d >= 0:
                    default:
                        return 'F';
                }
            }
        }
    }
}
