using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Test");
            foreach (var arg in args)
            {
                if (Double.TryParse(arg, out double grade))
                {
                    book.AddGrade(grade);
                }
            }
            
            book.ShowStatistics();
        }
    }
}
