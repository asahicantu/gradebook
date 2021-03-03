using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Test");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            EnterGrades(book);

            // foreach (var arg in args)
            // {
            //     if (Double.TryParse(arg, out double grade))
            //     {

            //     }
            // }

            book.ShowStatistics();
        }

        private static void EnterGrades(IBook book)
        {
            Console.WriteLine("Enter a grade or 'q'/'Q' or enter to quit");
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input) || (char)input[0] == 13 || input.ToUpper() == "Q" )
                    {
                        break;
                    }

                    if (double.TryParse(input, out double grade))
                    {
                        book.AddGrade(grade);
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    // optional
                    // throw;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    //Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Success!");
        }
    }
}
