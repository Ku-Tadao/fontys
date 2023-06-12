using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Seat
    {
        public int Number { get; set; }
        public string Code { get; set; }
        public Visitor Visitor { get; set; }

        public Seat(int number, char boxLetter, int rowNumber)
        {
            Number = number;
            Code = $"{boxLetter}{rowNumber}-{number}";
        }
    }

}
