using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Event
    {
        public int MaxVisitors { get; set; }
        public int NumBoxes { get; set; }
        public List<Visitor> Visitors { get; set; }

        public Event(int maxVisitors, int numBoxes)
        {
            MaxVisitors = maxVisitors;
            NumBoxes = numBoxes;
            Visitors = new List<Visitor>();
        }

        public void AddVisitor(Visitor visitor)
        {
            Visitors.Add(visitor);
        }

        public void AddBox(Box box)
        {
            Boxes.Add(box);
        }

        public void AssignSpots()
        {
            // Implement your spot assignment logic here
        }

        public void GenerateAsciiVisualization()
        {
            // Implement your ASCII visualization logic here
        }

        public void GenerateReport()
        {
            // Implement your report generation logic here
        }

    }

}
