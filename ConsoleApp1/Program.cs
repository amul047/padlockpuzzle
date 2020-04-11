using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            var digits = GetAllPossibleDigits();

            var hundredsDigits = digits.Where(d => d.Place == 100);
            var tensDigits = digits.Where(d => d.Place == 10);
            var onesDigits = digits.Where(d => d.Place == 1);

            foreach(var hundredsDigit in hundredsDigits)
            {
                foreach(var tensDigit in tensDigits)
                {
                    foreach(var onesDigit in onesDigits)
                    {
                        var number = new Number { 
                            HundredsDigit = hundredsDigit,
                            TensDigit = tensDigit,
                            OnesDigit = onesDigit
                        };

                        if (number.Value == 469)
                        {
                            Console.WriteLine("");

                        }

                        var meetsCondition1 = MeetsCondition1(number);
                        var meetsCondition2 = MeetsCondition2(number);
                        var meetsCondition3 = MeetsCondition3(number);
                        var meetsCondition4 = MeetsCondition4(number);
                        var meetsCondition5 = MeetsCondition5(number);

                        if (meetsCondition1 &&
                            meetsCondition2 &&
                            meetsCondition3 &&
                            meetsCondition4 &&
                            meetsCondition5)
                        {
                            Console.WriteLine(number.Value);
                        }
                    }
                }
            }

            Console.ReadLine();
        }

        private static bool MeetsCondition3(Number number)
        {
            var faceValuesThatMatch = number.Digits.Select(d => d.FaceValue).Intersect(new List<int> { 9, 6, 4 });

            if (faceValuesThatMatch.Count() == 2)
            {
                var placesValues = number.Digits.Where(d => faceValuesThatMatch.Contains(d.FaceValue))
                    .Select(d => d.PlaceValue);

                var validPlaceValues = new List<Digit>
                {
                    new Digit{FaceValue=6,Place=100},
                    new Digit{FaceValue=4,Place=100},
                    new Digit{FaceValue=9,Place=10},
                    new Digit{FaceValue=4,Place=10},
                    new Digit{FaceValue=9,Place=1},
                    new Digit{FaceValue=6,Place=1},
                }.Select(d => d.PlaceValue);

                if (placesValues.Intersect(validPlaceValues).Count() == 2)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool MeetsCondition1(Number number)
        {
            return number.TensDigit.FaceValue == 1 ||
                number.OnesDigit.FaceValue == 1 ||
                number.HundredsDigit.FaceValue == 4 ||
                number.OnesDigit.FaceValue == 4 ||
                number.HundredsDigit.FaceValue == 7 ||
                number.TensDigit.FaceValue == 7;
        }

        private static bool MeetsCondition2(Number number)
        {
            return number.HundredsDigit.FaceValue == 1 ||
                number.TensDigit.FaceValue == 8 ||
                number.OnesDigit.FaceValue == 9;
        }
        private static bool MeetsCondition4(Number number)
        {
            return number.HundredsDigit.FaceValue != 5 &&
                number.TensDigit.FaceValue != 5 &&
                number.OnesDigit.FaceValue != 5 &&
                number.HundredsDigit.FaceValue != 2 &&
                number.TensDigit.FaceValue != 2 &&
                number.OnesDigit.FaceValue != 2 &&
                number.HundredsDigit.FaceValue != 3 &&
                number.TensDigit.FaceValue != 3 &&
                number.OnesDigit.FaceValue != 3 ;
        }

        private static bool MeetsCondition5(Number number)
        {
            return number.TensDigit.FaceValue == 2 ||
                number.OnesDigit.FaceValue == 2 ||
                number.HundredsDigit.FaceValue == 8 ||
                number.OnesDigit.FaceValue == 8 ||
                number.HundredsDigit.FaceValue == 6 ||
                number.TensDigit.FaceValue == 6;
        }

        private static List<Digit> GetAllPossibleDigits()
        {
            var digits = new List<Digit>();
            for (int i = 0; i < 10; i++)
            {
                digits.Add(new Digit { FaceValue = i, Place = 1 });
                digits.Add(new Digit { FaceValue = i, Place = 10 });
                digits.Add(new Digit { FaceValue = i, Place = 100 });             
            }
            return digits;
        }

    }
}