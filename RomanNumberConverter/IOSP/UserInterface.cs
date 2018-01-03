using System;

namespace RomanNumberConverter.IOSP
{
    internal class UserInterface
    {
        internal void Start()
        {
            Console.WriteLine("Römische Nummer eingeben:");

            Process(Console.ReadLine, new IospRomanNumberCalculator().GetDezimal, Console.WriteLine);
        }

        private void Process(Func<string> getInputFunc, Func<string, string> resultFunc,
            Action<string> presentAction)
        {
            string input;
            do
            {
                input = getInputFunc();
                var result = resultFunc(input);
                presentAction(result);
            } while (!string.IsNullOrEmpty(input));
        }
    }
}