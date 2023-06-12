using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Row
    {
        public int Number { get; set; }
        public List<Seat> Seats { get; set; }

        public Row(int number)
        {
            Number = number;
            Seats = new List<Seat>();
        }
    }
}
