using System;
using System.Collections.Generic;
using Visitor_Placement_Tool;
using Visitor_Placement_Tool.Enums;

namespace Visitor_Placement_Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set maximum capacity for event
            int maxCap = 15;

            // Create new event
            Event event1 = new Event(new DateTime(2022, 1, 10), maxCap);

            // Create sections and add them to the event
            Section sectionA = new Section(SectionLetterEnum.SectionLetter.A, 3);
            Section sectionB = new Section(SectionLetterEnum.SectionLetter.B, 3);
            event1.AddSections(sectionA);
            event1.AddSections(sectionB);

            // Create list of signed up visitors
            // Signup Date is static in constructor (method overloading is allowed)
            List<Visitors> signedUp = new()
            {
                // Group 1
                new Visitors(new DateTime(2014, 1, 10), "G1K1", event1),
                new Visitors(new DateTime(2015, 1, 10), "G1K2", event1),
                new Visitors(new DateTime(2001, 1, 10), "G1A1", event1),
                new Visitors(new DateTime(2002, 1, 10), "G4A1(G1A2)", event1),
                new Visitors(new DateTime(2003, 1, 10), "G4A2(G1A3)", event1),
                // Group 2
                new Visitors(new DateTime(2014, 1, 10), "G2K1", event1),
                new Visitors(new DateTime(2016, 1, 10), "G2K2", event1),
                new Visitors(new DateTime(1950, 1, 10), "G2A1", event1),
                new Visitors(new DateTime(1951, 1, 10), "G4A3(G2A2)", event1),
                new Visitors(new DateTime(1952, 1, 10), "G4A4(G2A3)", event1),
                // Group 3
                new Visitors(new DateTime(2014, 1, 10), "G3K1", event1),
                new Visitors(new DateTime(1971, 1, 10), "G3A1", event1),
                new Visitors(new DateTime(1972, 1, 10), "G4A5(G3A2)", event1),
                new Visitors(new DateTime(1973, 1, 10), "G4A6(G3A3)", event1),
                new Visitors(new DateTime(1974, 1, 10), "G4A7(G3A4)", event1)
            };

            // Filter out visitors who registered too late or if there are too many visitors
            List<Visitors> allowedVisitors = event1.NotTooLate(signedUp);

            // Create groups and add them to the event
            Group group1 = new Group(allowedVisitors.GetRange(0, 5));
            Group group2 = new Group(allowedVisitors.GetRange(5, 5));
            Group group3 = new Group(allowedVisitors.GetRange(10, 5));
            event1.Groups.Add(group1);
            event1.Groups.Add(group2);
            event1.Groups.Add(group3);

            // Place all visitors in sections and rows
            event1.PlaceAllVisitors();

            // Display results in a table-like format
            Console.WriteLine("{0,-10} | {1,-15} | {2,-10} | {3,-15}", "Place", "Visitor Name", "Visitor ID", "Date of Birth");
            Console.WriteLine(new string('-', 55));
            foreach (Section sections in event1.Sections)
            {
                foreach (Row row in sections.Rows)
                {
                    foreach (Seat seat in row.Seats)
                    {
                        if (seat.SeatedVisitor != null)
                        {
                            Console.WriteLine("{0,-10} | {1,-15} | {2,-10} | {3,-15}", seat.SeatName, seat.SeatedVisitor.Name, seat.SeatedVisitor.VisitorId, seat.SeatedVisitor.DateOfBirth);
                        }
                        else
                        {
                            Console.WriteLine("{0,-10} | {1,-15} | {2,-10} | {3,-15}", seat.SeatName, "", "", "");
                        }
                    }
                }
            }

            // Display list of visitors who did not get access
            List<Visitors> visitorsWithoutAccess = event1.GetVisitorsWithoutAccess(signedUp);
            if (visitorsWithoutAccess.Count > 0)
            {
                Console.WriteLine("\nVisitors who did not get access:");
                foreach (Visitors visitor in visitorsWithoutAccess)
                {
                    Console.WriteLine("{0} (registered too late or too many visitors)", visitor.Name);
                }
            }
        }
    }
}