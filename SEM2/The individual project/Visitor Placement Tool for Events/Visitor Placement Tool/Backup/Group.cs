using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Group
    {
        public int Id { get; set; }
        public List<Visitor> Members { get; set; }

        public Group()
        {
            Members = new List<Visitor>();
        }

        public void RegisterGroup()
        {
            // Register group logic here
        }
    }
}
