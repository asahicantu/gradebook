using System.Collections.Generic;
using System;
using System.Linq;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {

        }
        public abstract void AddGrade(double grade);
        public abstract event GradeAddDelegate GradeAdded;

        public abstract Statistics GetStatistics();
        public virtual void ShowStatistics()
        {
            var stats = GetStatistics();
            Console.WriteLine($"For the book name {Name}");
            Console.WriteLine($"Lowest Grade is {stats.LowScore}");
            Console.WriteLine($"Highest Grade is {stats.HighScore}");
            Console.WriteLine($"Average Grade is {stats.Average}");
            Console.WriteLine($"Total Grades recorded {stats.TotalGrades}");
            Console.WriteLine($"Grade is {stats.Letter}");
        }

        public virtual double GetGradeFromLetter(char letter){
            switch (char.ToUpper(letter))
            {
                case 'A':
                    return 100;
                case 'B':
                    return 80;
                case 'C':
                    return 60;
                case 'D':
                    return 40;
                case 'E':
                    return 20;
                case 'F':
                default:
                    return 0;
            }
        }

    }



}