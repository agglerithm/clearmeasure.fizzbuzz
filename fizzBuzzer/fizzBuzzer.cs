using System;
using System.IO;
using System.Text;

namespace fizzBuzzer
{
    public class fizzBuzzer
    {
        public static string Print(int upperBound)
        {
            var config = new FizzBuzzConfig {UpperBound = upperBound};

            return Print(config);
        }

        public static string Print(FizzBuzzConfig config = null, Action<string> printAction = null)
        {
            if(config == null)
                config = new FizzBuzzConfig();
            if(config.UpperBound < 1 || config.SmallNumber < 1 || config.LargeNumber < 1)
                throw new FizzBuzzerNonPositiveException();
            var sb = new StringBuilder(); 
            printAction = getDefaultPrintAction(sb,printAction);
            for (int i = 1; i <= config.UpperBound; i++)
            {
                if (i % config.SmallNumber == 0 || i % config.LargeNumber == 0)
                {
                    if (i % config.SmallNumber == 0)
                        printAction(config.SmallNumberMatchWord);
                    if (i % config.LargeNumber == 0)
                        printAction(config.LargeNumberMatchWord);
                    printAction(Environment.NewLine);
                }
                else
                {
                    printAction(i.ToString());
                    printAction(Environment.NewLine);
                }
            }
            return sb.ToString();
        }

        private static Action<string> getDefaultPrintAction(StringBuilder sb, Action<string> printAction)
        {
            return s =>
            {
                sb.Append(s);
                printAction?.Invoke(s);
            };
        }


        public static void PrintToOutput(TextWriter writer, FizzBuzzConfig config = null)
        { 
            Print(config, writer.Write);
        }

        public static void PrintToOutput(int upperBound, TextWriter writer)
        {

            var config = new FizzBuzzConfig { UpperBound = upperBound };

            Print(config, writer.Write);
        }
    }
}