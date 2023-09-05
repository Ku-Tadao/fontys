using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Event
    {
        public string Id { get; set; }
        public List<Visitor> RegisteredVisitors { get; set; }
        public List<Box> Boxes { get; set; }
        public int MaxCapacity { get; set; }

        public Event(int maxCapacity)
        {
            RegisteredVisitors = new List<Visitor>();
            Boxes = new List<Box>();
            MaxCapacity = maxCapacity;
        }

        public bool RegisterVisitor(Visitor visitor)
        {
            if (RegisteredVisitors.Count >= MaxCapacity)
            {
                Console.WriteLine("Registration failed: Event is full.");
                return false;
            }
            else if (RegisteredVisitors.Any(v => v.Id == visitor.Id))
            {
                Console.WriteLine($"Registration failed: Visitor with ID {visitor.Id} is already registered.");
                return false;
            }
            else
            {
                RegisteredVisitors.Add(visitor);
                AssignSeatToVisitor(visitor);
                return true;
            }
        }



        public void RegisterGroup(Group group)
        {
            foreach (var visitor in group.Members)
            {
                RegisterVisitor(visitor);
            }
        }

        public void DisplaySeating()
        {
            foreach (var box in Boxes)
            {
                Console.WriteLine($"Box {box.BoxId}:");
                foreach (var row in box.Rows)
                {
                    string rowDisplay = "";
                    foreach (var seat in row)
                    {
                        if (seat.SeatId == null)
                        {
                            rowDisplay += "E "; // Empty seat
                        }
                        else
                        {
                            var visitor = RegisteredVisitors.First(v => v.Id.ToString() == seat.SeatId);
                            rowDisplay += visitor.IsAdult ? "A " : "C "; // Adult or Child seat
                        }
                    }
                    Console.WriteLine(rowDisplay);
                }
                Console.WriteLine();
            }
        }


        public void CreateSeatingChart()
        {
            // Seating chart creation logic here
        }

        public void CheckCapacity()
        {
            // Check capacity logic here
        }

        public void GenerateReport()
        {
            // Report generation logic here
        }

        public void AssignSeatToVisitor(Visitor visitor)
        {
            foreach (var box in Boxes)
            {
                foreach (var row in box.Rows)
                {
                    if (row.Any(seat => seat.SeatId == null)) // check for an empty seat
                    {
                        var emptySeat = row.First(seat => seat.SeatId == null);
                        emptySeat.SeatId = visitor.Id.ToString();

                        if (!visitor.IsAdult) // place children in the first row
                        {
                            var firstRow = box.Rows.First();
                            if (firstRow.Any(seat => seat.SeatId == null))
                            {
                                emptySeat.SeatId = null; // remove visitor from previous seat
                                var emptySeatInFirstRow = firstRow.First(seat => seat.SeatId == null);
                                emptySeatInFirstRow.SeatId = visitor.Id.ToString();
                            }
                        }

                        return;
                    }
                }
            }
        }


    }

}
