namespace Visitor_Placement_Tool;

internal class Program
{
    private static void Main(string[] args)
    {
        // Create a new event with a maximum amount
        var placementEvent = new Event(100, DateTime.Now.AddDays(-5));

        // Add boxes with rows and seats
        int totalSeats = 0;
        Random rnd = new Random();
        for (var c = 'A'; c <= 'F'; c++)
        {
            var box = new Box(c);
            int numberOfRows = rnd.Next(1, 3); // Specify the number of rows in a box
            int seatsPerRow = rnd.Next(3,10); // Specify the number of seats per row
            for (var i = 1; i <= numberOfRows; i++)
            {
                if (totalSeats >= placementEvent.MaxVisitors)
                    break;

                var row = new Row(i);
                for (var j = 1; j <= seatsPerRow; j++)
                {
                    if (totalSeats < placementEvent.MaxVisitors)
                    {
                        row.Seats.Add(new Seat(j, c, i));
                        totalSeats++;
                    }
                    else
                        break;
                }
                box.Rows.Add(row);
            }
            if (box.Rows.Any(r => r.Seats.Count > 0))
                placementEvent.Boxes.Add(box);
        }

        var groups = new List<Group>
        {
            new Group(1) { RegistrationDate = DateTime.Now.AddDays(-7) },
            new Group(2) { RegistrationDate = DateTime.Now.AddDays(-6) },
            new Group(3) { RegistrationDate = DateTime.Now.AddDays(-5) },
            new Group(4) { RegistrationDate = DateTime.Now.AddDays(-4) },
            new Group(5) { RegistrationDate = DateTime.Now.AddDays(-3) },
            new Group(6) { RegistrationDate = DateTime.Now.AddDays(-2) },
            new Group(7) { RegistrationDate = DateTime.Now.AddDays(-1) },
            new Group(8) { RegistrationDate = DateTime.Now }
        };

        // Load visitor data from static data
        groups[1].Visitors.Add(new AdultVisitor("Alice", new DateTime(1980, 1, 1)));
        groups[1].Visitors.Add(new ChildVisitor("Bob", new DateTime(2015, 1, 1)));

        groups[2].Visitors.Add(new AdultVisitor("Charlie", new DateTime(1990, 1, 1)));
        groups[2].Visitors.Add(new AdultVisitor("Dave", new DateTime(2000, 1, 1)));

        // Not allowed as full of kids
        groups[3].Visitors.Add(new ChildVisitor("Eve", new DateTime(2010, 1, 1)));
        groups[3].Visitors.Add(new ChildVisitor("Frank", new DateTime(2011, 1, 1)));
        groups[3].Visitors.Add(new ChildVisitor("Grace", new DateTime(2012, 1, 1)));
        groups[3].Visitors.Add(new ChildVisitor("Heidi", new DateTime(2013, 1, 1)));

        groups[4].Visitors.Add(new AdultVisitor("Isaac", new DateTime(1985, 1, 1)));
        groups[4].Visitors.Add(new ChildVisitor("Jack", new DateTime(2010, 1, 1)));
        groups[4].Visitors.Add(new ChildVisitor("Kate", new DateTime(2011, 1, 1)));

        groups[5].Visitors.Add(new AdultVisitor("Liam", new DateTime(1995, 1, 1)));
        groups[5].Visitors.Add(new ChildVisitor("Mia", new DateTime(2012, 1, 1)));
        groups[5].Visitors.Add(new ChildVisitor("Noah", new DateTime(2013, 1, 1)));

        groups[6].Visitors.Add(new AdultVisitor("Olivia", new DateTime(1980, 1, 1)));
        groups[6].Visitors.Add(new ChildVisitor("Peter", new DateTime(2010, 1, 1)));
        groups[6].Visitors.Add(new ChildVisitor("Quinn", new DateTime(2011, 1, 1)));

        groups[7].Visitors.Add(new AdultVisitor("Rachel", new DateTime(1990, 1, 1)));
        groups[7].Visitors.Add(new ChildVisitor("Sophie", new DateTime(2012, 1, 1)));
        groups[7].Visitors.Add(new ChildVisitor("Tom", new DateTime(2013, 1, 1)));


        // Check for duplicate entries
        var allVisitors = groups.SelectMany(g => g.Visitors).ToList();
        var duplicateNames = allVisitors.GroupBy(v => v.Name).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
        if (duplicateNames.Count > 0)
        {
            Console.WriteLine($"Error: Duplicate entries found for visitors: {string.Join(", ", duplicateNames)}");
            return;
        }

        // Check for late registrations
        var registrationDeadline = placementEvent.Date.AddDays(-7);
        var lateGroups = groups.Where(g => g.RegistrationDate > registrationDeadline).ToList();
        if (lateGroups.Count > 0)
        {
            Console.WriteLine($"Error: Late registrations found for groups: {string.Join(", ", lateGroups.Select(g => g.Number))}");
            return;
        }

        // Add valid groups to the event
        placementEvent.Groups.AddRange(groups.Except(lateGroups));

// Assign seats to visitors
placementEvent.AssignSeats();

        // Visualize the seating arrangement
        placementEvent.Visualize();
    }
}