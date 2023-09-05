using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Box
    {
        public string BoxId { get; set; }
        public List<List<Seat>> Rows { get; set; }

        public Box()
        {
            Rows = new List<List<Seat>>();
        }

        public void CreateBox()
        {
            // Box creation logic here
        }
    }
}
