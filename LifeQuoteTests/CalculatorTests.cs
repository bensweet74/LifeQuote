using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LifeQuote;

namespace LifeQuoteTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void GetQuoteReturnsExceptionINoPostcode()
        {
            // arrange
            var calculator = new Calculator();

            // act
            calculator.GetQuote(DateTime.MaxValue, Calculator.Gender.Male, string.Empty, true, 5, true);
        }

        [TestMethod]
        public void GetQuoteReturnsFor18YearOldEnglishNonSmokingChildlessMaleWhoExercises0HoursAWeek()
        {
            // arrange
            var calculator = new Calculator();
            var expectedQuote = 180;

            // act
            var actualQuote = calculator.GetQuote(CreateDateOfBirth(18), Calculator.Gender.Male, "PE2 6WZ", false, 0, false);

            // assert
            Assert.AreEqual(expectedQuote, actualQuote);
        }

        [TestMethod]
        public void GetQuoteReturnsFor18YearOldEnglishNonSmokingChildlessMaleWhoExercises4HoursAWeek()
        {
            // arrange
            var calculator = new Calculator();
            var expectedQuote = 105;

            // act
            var actualQuote = calculator.GetQuote(CreateDateOfBirth(18), Calculator.Gender.Male, "PE2 6WZ", false, 4, false);

            // assert
            Assert.AreEqual(expectedQuote, actualQuote);
        }

        [TestMethod]
        public void GetQuoteReturnsFor18YearOldEnglishNonSmokingChildlessMaleWhoExercises7HoursAWeek()
        {
            // arrange
            var calculator = new Calculator();
            var expectedQuote = 75;

            // act
            var actualQuote = calculator.GetQuote(CreateDateOfBirth(18), Calculator.Gender.Male, "PE2 6WZ", false, 7, false);

            // assert
            Assert.AreEqual(expectedQuote, actualQuote);
        }

        [TestMethod]
        public void GetQuoteReturnsFor18YearOldEnglishNonSmokingChildlessMaleWhoExercises9HoursAWeek()
        {
            // arrange
            var calculator = new Calculator();
            var expectedQuote = 225;

            // act
            var actualQuote = calculator.GetQuote(CreateDateOfBirth(18), Calculator.Gender.Male, "PE2 6WZ", false, 9, false);

            // assert
            Assert.AreEqual(expectedQuote, actualQuote);
        }

        [TestMethod]
        public void GetQuoteReturnsFor18YearOldEnglishSmokingChildlessMaleWhoExercises4HoursAWeek()
        {
            // arrange
            var calculator = new Calculator();
            var expectedQuote = 315;

            // act
            var actualQuote = calculator.GetQuote(CreateDateOfBirth(18), Calculator.Gender.Male, "PE2 6WZ", true, 4, false);

            // assert
            Assert.AreEqual(expectedQuote, actualQuote);
        }

        [TestMethod]
        public void GetQuoteReturnsFor18YearOldEnglishSmokingMaleParentWhoExercises4HoursAWeek()
        {
            // arrange
            var calculator = new Calculator();
            var expectedQuote = 472.50M;

            // act
            var actualQuote = calculator.GetQuote(CreateDateOfBirth(18), Calculator.Gender.Male, "PE2 6WZ", true, 4, true);

            // assert
            Assert.AreEqual(expectedQuote, actualQuote);
        }

        private DateTime CreateDateOfBirth(int requiredAge)
        {
            return new DateTime(DateTime.Now.Year - requiredAge, DateTime.Now.Month, DateTime.Now.Day).AddDays(-10);
        }
    }
}
