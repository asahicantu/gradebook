using System.Collections.Generic;
using System;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private List<double> _grades = new List<double>();
        public string Name { get; set; }
        public Book(string name)
        {
            Name = name;
        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                _grades.Add(grade);
            }
            else{
                Console.WriteLine("Invalid Value");
            }

        }

        public void ShowStatistics()
        {
            var stats = GetStatistics();
            Console.WriteLine($"Lowest Grade is {stats.LowScore}");
            Console.WriteLine($"Highest Grade is {stats.HighScore}");
            Console.WriteLine($"Average Grade is {stats.Average}");
        }

        public Statistics GetStatistics()
        {
            Statistics stats = new Statistics();
            if (_grades.Count > 0)
            {
                stats = new Statistics
                {
                    Average = _grades.Average(),
                    LowScore = _grades.Min(),
                    HighScore = _grades.Max()

                };
            }
            return stats;
        }
    }
}