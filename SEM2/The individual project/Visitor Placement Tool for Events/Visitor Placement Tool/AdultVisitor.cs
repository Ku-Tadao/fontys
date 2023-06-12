using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class AdultVisitor : Visitor
    {
        public AdultVisitor(string name, DateTime dateOfBirth) : base(name, dateOfBirth) { }

        public override bool IsChild() => false;
    }
}
