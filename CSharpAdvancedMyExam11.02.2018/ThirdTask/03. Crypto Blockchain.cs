using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ThirdTask
{
    public class FourthTask
    {
        public static void Main()
        {
            var firstBrecketsDigitsList = new List<string>();
            var secondBrecketsDigitsList = new List<string>();
            var firstCryptoBlockLength = 0;
            var secondCryptoBlockLength = 0;
            var n = int.Parse(Console.ReadLine());
            //if one of two matched and contains the other one - ignore
            //make all lines to one
            var input = string.Empty;
            for (int i = 0; i < n; i++)
            {
                input += Console.ReadLine();
            }
            var firstBrecketsPattern = @"({.*\d{3,}.*})";
            var secondBrecketsPattern = @"\[(\d{3,}.*)\]";
            //match first input
            foreach (Match firstBrecketsMatch in Regex.Matches(input, firstBrecketsPattern))
            {
                //firstBreckets's check
                if (firstBrecketsMatch.Value[0] == ('[')
                    || firstBrecketsMatch
                    .Value[firstBrecketsMatch.Length - 1] == ']')
                {
                    return;
                }
                //take digits
                var digitsCount = 0;
                var digitsToNumber = string.Empty;
                foreach (var currentDigit in firstBrecketsMatch.Value)
                {
                    firstCryptoBlockLength++;
                    if (int.TryParse(currentDigit.ToString(), out _))
                    {
                        digitsToNumber += currentDigit;
                        digitsCount++;
                        if (digitsCount % 3 == 0)
                        {
                            firstBrecketsDigitsList.Add(digitsToNumber);
                            digitsToNumber = string.Empty;
                        }
                    }
                }
                //check if digits valid
                if (digitsCount % 3 != 0)
                {
                    return;
                }
            }
            //SecondBrecketsCheck
            foreach (Match secondBrecketsMatch in Regex.Matches(input, secondBrecketsPattern))
            {
                //firstBreckets's check
                if (secondBrecketsMatch.Value[0] == ('{')
                    || secondBrecketsMatch
                        .Value[secondBrecketsMatch.Length - 1] == '}')
                {
                    return;
                }
                //take digits
                var digitsCount = 0;
                var digitsToNumber = string.Empty;
                foreach (var currentDigit in secondBrecketsMatch.Value)
                {
                    secondCryptoBlockLength++;
                    if (int.TryParse(currentDigit.ToString(), out _))
                    {
                        digitsToNumber += currentDigit;
                        digitsCount++;
                        if (digitsCount % 3 == 0)
                        {
                            secondBrecketsDigitsList.Add(digitsToNumber);
                            digitsToNumber = string.Empty;
                        }
                    }
                }
                //check if digits valid
                if (digitsCount % 3 != 0)
                {
                    return;
                }
            }

            var stringResult = string.Empty;

            char firstBlockCharResult;
            foreach (var currentNumberStr in firstBrecketsDigitsList)
            {
                var currentNumberInt = int.Parse(currentNumberStr);
                var currentNumberChar = currentNumberInt - firstCryptoBlockLength;
                firstBlockCharResult = (char)currentNumberChar;
                stringResult += firstBlockCharResult;
            }
            char secondBlockCharResult;
            foreach (var currentNumberStr in secondBrecketsDigitsList)
            {
                var currentNumberInt = int.Parse(currentNumberStr);
                var currentNumberChar = currentNumberInt - secondCryptoBlockLength;
                secondBlockCharResult = (char)currentNumberChar;
                stringResult += secondBlockCharResult;
            }
            Console.WriteLine(stringResult);
        }
    }
}
