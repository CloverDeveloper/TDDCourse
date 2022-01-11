using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecondCourse.NUnit
{
    [TestFixture]
    public class FizzBuzz
    {
        [TestCase("Fizz",3)]
        [TestCase("Buzz", 5)]
        [TestCase("", 7)]
        [TestCase("FizzBuzz", 15)]
        public void FizzBuzzTests(string expect,int testVal) 
        {
            Assert.AreEqual(expect, RunFizzBuzz(testVal));
        }

        private string RunFizzBuzz(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return "FizzBuzz";

            if (number % 3 == 0)
                return "Fizz";

            if (number % 5 == 0)
                return "Buzz";

            return "";
        }
    }
}
