using System.Collections.Generic;
using System;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private List<double> _grades = new List<double>();
        public string Name{get; private set;}
        public Book(string name)
        {
            Name = name;
        }

        public void AddGrade(double num)
        {
            _grades.Add(num);
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
            var stats = new Statistics{
                Average = _grades.Average(),
                LowScore = _grades.Min(),
                HighScore = _grades.Max()
            };
            return stats;
        }
    }
}