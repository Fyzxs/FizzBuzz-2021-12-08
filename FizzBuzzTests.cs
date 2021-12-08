using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddLikeYouMeanIt.lib;

namespace TddLikeYouMeanIt
{
    [TestClass]
    public class FizzBuzzTests
    {
        private static readonly Random Rand = new();

        [TestMethod]
        public void GivenInputReturnsStringOfInput()
        {
            //ARRANGE
            Dictionary<int, string> regressionValues = new()
            {
                { 1, "1" },
                { 2, "2" },
                { 4, "4" }
            };

            KeyValuePair<int, string> keyValuePair = regressionValues.ElementAt(Rand.Next(0, regressionValues.Count));
            TurnCount sourceInput = new IntTurnCount(keyValuePair.Key);
            string expected = keyValuePair.Value;
            IFizzBuzz subject = new FizzBuzz();

            //ACT
            string actual = subject.Turn(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenMultipleOf3ReturnsFizz()
        {
            //ARRANGE
            const int multiplicand = 3;
            const string expected = "Fizz";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnCount sourceInput = new IntTurnCount(multiplier * multiplicand);
            IFizzBuzz subject = new FizzBuzz();

            //ACT
            string actual = subject.Turn(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenMultipleOf5ReturnsBuzz()
        {
            //ARRANGE
            const int multiplicand = 5;
            const string expected = "Buzz";
            List<int> multiplierList = new() { 1, 2, 4 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnCount sourceInput = new IntTurnCount(multiplier * multiplicand);
            IFizzBuzz subject = new FizzBuzz();

            //ACT
            string actual = subject.Turn(sourceInput);
            //ASSERT
            actual.Should().Be(expected);
        }

        [TestMethod]
        public void GivenMultipleOf3And5ReturnsFizzBuzz()
        {
            //ARRANGE
            const int multiplicand = 3 * 5;
            const string expected = "FizzBuzz";
            List<int> multiplierList = new() { 1, 2, 3 };

            int randomIndex = Rand.Next(multiplierList.Count);
            int multiplier = multiplierList.ElementAt(randomIndex);
            TurnCount sourceInput = new IntTurnCount(multiplier * multiplicand);
            IFizzBuzz subject = new FizzBuzz();

            //ACT
            string actual = subject.Turn(sourceInput);

            //ASSERT
            actual.Should().Be(expected);
        }
    }
}