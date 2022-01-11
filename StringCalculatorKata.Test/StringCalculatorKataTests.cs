using NUnit.Framework;
using StringCalculatorLibrary;
using System;

namespace StringCalculatorKata.Test
{
    public class StringCalculatorKataTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_AcceptsEmptyString_Returns0()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.Add(String.Empty);

            //Assert
            Assert.AreEqual(0, result);
        }
        [Test]
        public void Add_AcceptsCommaDelimitedString_ReturnsSum()
        {
            var calculator = new StringCalculator();

            //Act
            var result = calculator.Add("1,2");

            //Assert
            Assert.AreEqual(3, result);
        }
        [Test]
        public void Add_AcceptsString_ReturnsNumber()
        {
            var calculator = new StringCalculator();

            //Act
            var result = calculator.Add("1");

            //Assert
            Assert.AreEqual(1, result);
        }
        [Test]
        public void Add_AcceptsMultipleDelimitedString_ReturnsSum()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.Add("1,2,3,4");

            //Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Add_AcceptsNewLineCharacterAsDelimiter_ReturnsSum()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.Add("1\n2,3\n4");

            //Assert
            Assert.AreEqual(10, result);
        }

        [Test]
        public void Add_AcceptsNewDelimiterAfterCommentCharacter_ReturnsSum()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.Add("//;\n1,2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void Add_AcceptsNegativeNumbers_ThrowsAnException()
        {
            //Arrange
            var calculator = new StringCalculator();
            TestDelegate testDelegate = () => calculator.Add("-1,-2,3,4,5");

            //Assert
            Assert.Throws<Exception>(testDelegate, "Negatives are not allowed");
        }

        [Test]
        public void Add_IgnoresGreaterThanThousand_ReturnsSum()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.Add("1000,2");

            //Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Add_AcceptsDelimiterOfAnyLength_ReturnsSum()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.Add("//[***]\n1***2***3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_AcceptsMultipleNewDelimiters_ReturnsSum()
        {
            //Arrange
            var calculator = new StringCalculator();

            //Act
            var result = calculator.Add("//[*][%]\n1*2%3");

            //Assert
            Assert.AreEqual(6, result);
        }
     
    }
}