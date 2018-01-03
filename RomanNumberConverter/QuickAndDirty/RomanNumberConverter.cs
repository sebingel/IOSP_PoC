using System;
using System.Linq;

namespace RomanNumberConverter.QuickAndDirty
{
    public static class RomanNumberConverter
    {
        public static string Convert(string romanNumberAsString)
        {
            var dezimalNumber = 0;

            var validRomanNumbers = new[] {'M', 'D', 'C', 'L', 'X', 'V', 'I'};

            if (!romanNumberAsString.All(x => validRomanNumbers.Contains(x)))
                return null;

            for (var i = 0; i < romanNumberAsString.Length; i++)
            {
                var singleNumber = romanNumberAsString[i];

                if (i < romanNumberAsString.Length - 1 && !validRomanNumbers
                        .Skip(Array.IndexOf(validRomanNumbers, singleNumber))
                        .Contains(romanNumberAsString[i + 1]))
                    return null;

                switch (singleNumber)
                {
                    case 'I':
                        dezimalNumber++;
                        break;
                    case 'V':
                        dezimalNumber += 5;
                        break;
                    case 'X':
                        dezimalNumber += 10;
                        break;
                    case 'L':
                        dezimalNumber += 50;
                        break;
                    case 'C':
                        dezimalNumber += 100;
                        break;
                    case 'D':
                        dezimalNumber += 500;
                        break;
                    case 'M':
                        dezimalNumber += 1000;
                        break;
                }
            }

            return dezimalNumber.ToString();
        }
    }
}