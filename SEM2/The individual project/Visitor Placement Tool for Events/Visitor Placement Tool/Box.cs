using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Box
    {
        public int Size { get; set; }
        public int NumRows { get; set; }
        public int NumChairs { get; set; }
        public char Letter { get; set; }

        public Box(int size, int numRows, int numChairs, char letter)
        {
            Size = size;
            NumRows = numRows;
            NumChairs = numChairs;
            Letter = letter;
        }
    }
}
