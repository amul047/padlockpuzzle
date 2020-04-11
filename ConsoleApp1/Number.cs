using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Number
    {
        public Digit HundredsDigit { get; set; }

        public Digit TensDigit { get; set; }
        
        public Digit OnesDigit { get; set; }

        public List<Digit> Digits => new List<Digit> { HundredsDigit, TensDigit, OnesDigit };

        public int Value => HundredsDigit.PlaceValue + TensDigit.PlaceValue + OnesDigit.PlaceValue;
    }
}
