using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Box
    {
        public char Letter { get; set; }
        public List<Row> Rows { get; set; }

        public Box(char letter)
        {
            Letter = letter;
            Rows = new List<Row>();
        }
    }
}
