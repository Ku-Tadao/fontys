using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Event
    {

        public List<Box> Boxes { get; set; }
        public int MaxVisitors { get; set; }
        public List<Group> Groups { get; set; }
        public DateTime Date { get; set; }

        public Event(int maxVisitors, DateTime date)
        {
            MaxVisitors = maxVisitors;
            Date = date;
            Boxes = new List<Box>();
            Groups = new List<Group>();
        }

        public void AssignSeats()
        {
            // Sort groups by registration date
            Groups.Sort((g1, g2) => g1.RegistrationDate.CompareTo(g2.RegistrationDate));

            // Assign seats to groups
            foreach (var group in Groups)
            {
                // Find available seats for the group
                var seats = FindSeatsForGroup(group);

                if (seats.Count >= group.Visitors.Count)
                {
                    // Assign the visitors to the seats
                    for (int i = 0; i < group.Visitors.Count; i++)
                    {
                        seats[i].Visitor = group.Visitors[i];
                    }
                }
                else
                {
                    // No more available seats
                    break;
                }
            }
        }

        private List<Seat> FindSeatsForGroup(Group group)
        {
            var children = group.Visitors.Where(v => v.IsChild()).ToList();
            var adults = group.Visitors.Where(v => !v.IsChild()).ToList();

            if (children.Count > 0)
            {
                // Find available seats in the first row of any box
                var firstRowSeats = Boxes.SelectMany(b => b.Rows).Where(r => r.Number == 1).SelectMany(r => r.Seats).Where(s => s.Visitor == null).ToList();

                if (firstRowSeats.Count >= children.Count + 1)
                {
                    // Place children and one adult in the first row
                    return firstRowSeats.Take(children.Count + 1).ToList();
                }
                else
                {
                    // Not enough seats in the first row
                    return new List<Seat>();
                }
            }
            else
            {
                // Find available seats in any row of any box
                return Boxes.SelectMany(b => b.Rows).SelectMany(r => r.Seats).Where(s => s.Visitor == null).Take(adults.Count).ToList();
            }
        }


        public void Visualize()
        {
            foreach (var box in Boxes)
            {
                Console.WriteLine("True or False means if it's a Child or Not\n");

                Console.WriteLine($"Box {box.Letter}");
                foreach (var row in box.Rows)
                {
                    Console.Write($"Row {row.Number}: ");
                    foreach (var seat in row.Seats)
                    {
                        if (seat.Visitor != null)
                        {
                            Console.Write($"[{seat.Visitor.Name} | {seat.Visitor.IsChild()}] ");
                        }
                        else
                        {
                            Console.Write("O ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
