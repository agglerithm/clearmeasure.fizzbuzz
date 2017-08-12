using System;
using System.Linq;
using fizzBuzzer;
using Microsoft.VisualStudio.TestTools.UnitTesting; 

namespace testFizzBuzz
{
    [TestClass]
    public class FizzBuzzerTester
    {
        [TestMethod]
        public void TestFifteenCase()
        {
            //arrange
            var result = "";
            //Act
            result = fizzBuzzer.fizzBuzzer.Print(15);
            //Assert
            var arr = result.Split("\n".ToCharArray()).Select(r => r.Trim()).Where(r => r != "");
            var test = arr.Last();
            Assert.AreEqual(test,"fizzbuzz");
        }

        [TestMethod]
        public void TestNonDefaultNames()
        {
            //arrange
            var result = "";
            var config = new FizzBuzzConfig()
            {
                SmallNumberMatchWord = "fu",
                LargeNumberMatchWord = "bar",
                UpperBound = 15
            };
            //Act
            result = fizzBuzzer.fizzBuzzer.Print(config);
            //Assert
            var arr = result.Split("\n".ToCharArray()).Select(r => r.Trim()).Where(r => r != "");
            var test = arr.Last();
            Assert.AreEqual(test, "fubar");
        }

        [TestMethod] public void TestNonDefaultValues()
        {
            //arrange
            var result = "";
            var config = new FizzBuzzConfig()
            {
                SmallNumber = 10,
                LargeNumber = 4,
                UpperBound = 40
            };
            //Act
            result = fizzBuzzer.fizzBuzzer.Print(config);
            //Assert
            var arr = result.Split("\n".ToCharArray()).Select(r => r.Trim()).Where(r => r != "");
            var test = arr.Last();
            Assert.AreEqual(test, "fizzbuzz");
        }

        [TestMethod]
        public void TestSameValues()
        {
            //arrange
            var result = "";
            var config = new FizzBuzzConfig()
            {
                SmallNumber = 3,
                LargeNumber = 3,
                UpperBound = 9
            };
            //Act
            result = fizzBuzzer.fizzBuzzer.Print(config);
            //Assert
            var arr = result.Split("\n".ToCharArray()).Select(r => r.Trim()).Where(r => r != "").ToArray();
            Assert.AreEqual(arr[0], "1");
            Assert.AreEqual(arr[1], "2");
            Assert.AreEqual(arr[2], "fizzbuzz");
            Assert.AreEqual(arr[3], "4");
            Assert.AreEqual(arr[4], "5");
            Assert.AreEqual(arr[5], "fizzbuzz");
            Assert.AreEqual(arr[6], "7");
            Assert.AreEqual(arr[7], "8");
            Assert.AreEqual(arr[8], "fizzbuzz");
        }

        [TestMethod]
        [ExpectedException(typeof(FizzBuzzerNonPositiveException))]
        public void TestNegativeValues()
        {
            //arrange
            var result = "";
            var config = new FizzBuzzConfig()
            {
                SmallNumber = -1,
                LargeNumber = 3,
                UpperBound = 9
            };
            //Act
            result = fizzBuzzer.fizzBuzzer.Print(config);
            //Assert 
        }

        [TestMethod]
        public void TestPrintToScreen()
        {
            //Act
            fizzBuzzer.fizzBuzzer.PrintToOutput(Console.Out);
            fizzBuzzer.fizzBuzzer.PrintToOutput(100,Console.Out);
        }
    }

}
