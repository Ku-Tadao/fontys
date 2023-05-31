using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Visitor
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int UniqueNumber { get; set; }
        public bool IsRegistered { get; set; }

        public Visitor(string name, DateTime dateOfBirth, int uniqueNumber)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            UniqueNumber = uniqueNumber;
            IsRegistered = false;
        }

        public void Register()
        {
            IsRegistered = true;
        }
    }
}
