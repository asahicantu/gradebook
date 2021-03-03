using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        public delegate string WriteLogDelegate(string logMessage);
        [Fact]
        public void WriteLogDelegateToMethod()
        {
            var log = new WriteLogDelegate(WriteTextMessage);
            log += WriteTextMessage;
            var msg = log("Hello");
            Assert.Equal("Hello",msg);

        }

        private string  WriteTextMessage(string message)
        {
            return message;
        }


        [Fact]
        public void StringsBehaveAsValueTypes()
        {
            string name = "Asahi";
            name = MakeUppercase(name);
            Assert.Equal("ASAHI", name);
        }

        private string MakeUppercase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void AssertInt()
        {
            var x = GetInt();
            Assert.Equal(3, x);
            SetInt(ref x);
            Assert.Equal(42, x);

        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassedByRef()
        {
            var book1 = GetBook("Book1");
            GetBookSetNameByRef(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CSharpIsPassedByValue()
        {
            var book1 = GetBook("Book1");
            GetBookSetNameByVal(book1, "New Name");
            Assert.Equal("Book1", book1.Name);
        }

        private void GetBookSetNameByRef(ref InMemoryBook book, string name)
        {
            book = GetBook(name);
        }

        private void GetBookSetNameByVal(InMemoryBook book, string name)
        {
            book = GetBook(name);
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }



        [Fact]
        public void GetBookReturnsDifferentObject()
        {
            //Arrange
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");
            //Act
            //Assert
            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //Arrange
            var book1 = GetBook("Book1");
            var book2 = book1;
            //Act
            //Assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }
    }
}
