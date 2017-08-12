namespace fizzBuzzer
{
    public class FizzBuzzConfig
    {
        public int UpperBound { get; set; } = 100;
        public int SmallNumber { get; set; } = 3;
        public int LargeNumber { get; set; } = 5;
        public string SmallNumberMatchWord { get; set; } = "fizz";
        public string LargeNumberMatchWord { get; set; } = "buzz";
    }
}