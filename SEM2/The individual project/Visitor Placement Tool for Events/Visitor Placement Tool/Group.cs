using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Group
    {
        public int Number { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<Visitor> Visitors { get; set; }

        public Group(int number)
        {
            Number = number;
            Visitors = new List<Visitor>();
        }
    }

}
