using System;

namespace RomanNumberConverter
{
    internal class Program
    {
        private static void Main()
        {
            //QaD();

            new IOSP.UserInterface().Start();
        }

        private static void QaD()
        {
            Console.WriteLine("Römische Nummer eingeben:");
            string s;
            while ((s = Console.ReadLine()) != string.Empty)
            {
                var result = QuickAndDirty.RomanNumberConverter.Convert(s);
                Console.WriteLine(result ?? "Fehlerhafte Eingabe");
            }
        }
    }
}