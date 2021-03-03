using System;
using System.Collections.Generic;
using System.IO;
namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {

        }

        public override event GradeAddDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                using (var w = File.AppendText($"{Name}.txt"))
                {
                    w.WriteLine(grade);
                }
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

        public override Statistics GetStatistics()
        {
            var grades = new List<double>();
            try
            {
                var lines = File.ReadAllLines($"{Name}.txt");
                foreach (var line in lines)
                {
                    if (double.TryParse(line, out double grade))
                    {
                        grades.Add(grade);
                    }
                    else
                    {
                        throw new InvalidCastException($"Value {line} could not be parsed");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException($"File {Name}.txt could not be found");
            }
            var stats = new Statistics(grades);
            return stats;
        }


    }
}