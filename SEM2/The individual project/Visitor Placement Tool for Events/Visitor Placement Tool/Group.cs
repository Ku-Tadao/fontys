using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Group
    {
        public int UniqueNumber { get; set; }
        public List<Visitor> Members { get; set; }

        public Group(int uniqueNumber)
        {
            UniqueNumber = uniqueNumber;
            Members = new List<Visitor>();
        }

        public void AddMember(Visitor visitor)
        {
            Members.Add(visitor);
        }
    }
}
