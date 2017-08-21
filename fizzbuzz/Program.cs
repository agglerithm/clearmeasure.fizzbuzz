using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using fizzBuzzer;

namespace fizzbuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new FizzBuzzConfig();
            var configurationNotVerified = true;
            while (configurationNotVerified) {
                try
                {
                    config.SmallNumberMatchWord = GetValueFromUser("Please enter the match word for the first number",
                        config.SmallNumberMatchWord);
                    config.LargeNumberMatchWord = GetValueFromUser("Please enter the match word for the second number",
                        config.LargeNumberMatchWord);
                    config.SmallNumber = GetIntValueFromUser("Please enter the first number", config.SmallNumber);
                    config.LargeNumber = GetIntValueFromUser("Please enter the second number", config.LargeNumber);
                    config.UpperBound = GetIntValueFromUser("Please enter upper bound", config.UpperBound);
                    fizzBuzzer.fizzBuzzer.PrintToOutput(Console.Out,config);
                    configurationNotVerified = false;
                }
                catch (FizzBuzzerNonPositiveException)
                {
                    Console.WriteLine("Numeric values must be positive numbers.");
                    config = new FizzBuzzConfig(); //Set everything back to default
                }
            }
            Console.WriteLine("Press any key to quit. (Don't look for the 'any' key.  Just press any key.)");
            Console.ReadKey();
        }

        private static int GetIntValueFromUser(string instructions, int num)
        {
            Console.WriteLine("{0}, or leave blank to use default value, then press enter.", instructions);
            var str = Console.ReadLine();
            var retVal = 0;
            if (int.TryParse(str, out retVal))
                num = retVal;
            return num;
        }

        private static string GetValueFromUser(string instructions, string word)
        {
            Console.WriteLine("{0}, or leave blank to use default value, then press enter.", instructions);
            var retVal = Console.ReadLine();
            return retVal == "" ? word : retVal;
        }
    }
}
