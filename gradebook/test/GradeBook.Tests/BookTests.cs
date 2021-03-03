using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void TestAverage()
        {
            //Arrange
            IBook book = new InMemoryBook("Test");
            var grades = new List<double>{
                100.0,
                100.0,
                20.0,
                20.0,
                80.0,
                60.0,
            };
            foreach(var grade in grades)
            {
                book.AddGrade(grade);
            }
            //Act
            var stats = book.GetStatistics();
            //Assert
            Assert.Equal(20,stats.LowScore);
            Assert.Equal(100,stats.HighScore);
            Assert.Equal(63.3,stats.Average,1);
            Console.WriteLine(stats.Letter);
            Assert.Equal('C',stats.Letter);
            
        }
    }
}
