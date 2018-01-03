using System;
using System.Linq;

namespace RomanNumberConverter.IOSP
{
    internal class IospRomanNumberCalculator
    {
        internal string GetDezimal(string roman)
        {
            return Validate(roman, CalculateRoman, InvalidFunc);
        }

        private readonly char[] _validRomanNumbers = {'M', 'D', 'C', 'L', 'X', 'V', 'I'};

        private string InvalidFunc()
        {
            return "Fehlerhafte Eingabe.";
        }

        private string CalculateRoman(string romanNumberAsString)
        {
            var dezimalNumber = 0;

            for (var i = 0; i < romanNumberAsString.Length; i++)
            {
                var singleNumber = romanNumberAsString[i];

                if (i < romanNumberAsString.Length - 1 && !_validRomanNumbers
                        .Skip(Array.IndexOf(_validRomanNumbers, singleNumber))
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

        private string Validate(string roman, Func<string, string> calculateRomanFunc,
            Func<string> invalidFunc)
        {
            var isValid = roman.All(x => _validRomanNumbers.Contains(x));

            for (var i = 0; i < roman.Length; i++)
            {
                var singleNumber = roman[i];

                if (i < roman.Length - 1 && !_validRomanNumbers
                        .Skip(Array.IndexOf(_validRomanNumbers, singleNumber))
                        .Contains(roman[i + 1]))
                    isValid = false;
            }

            return isValid ? calculateRomanFunc(roman) : invalidFunc();
        }
    }
}