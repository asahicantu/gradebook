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
            var book = new Book("Test");
            var grades = new List<double>{
                1.0,
                2.0,
                3.0
            };
            foreach(var grade in grades)
            {
                book.AddGrade(grade);
            }
            //Act
            var stats = book.GetStatistics();
            //Assert
            Assert.Equal(1.0,stats.LowScore);
            Assert.Equal(3.0,stats.HighScore);
            Assert.Equal(2.0,stats.Average);
            Assert.Equal(2.0,stats.Average,1);
        }
    }
}
