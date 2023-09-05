using Visitor_Placement_Tool;

var newEvent = new Event(5);

var visitor1 = new Visitor(1, "John Doe", new DateTime(1985, 5, 1), true);
var visitor2 = new Visitor(2, "Jane Doe", new DateTime(1980, 6, 15), true);
var visitor3 = new Visitor(3, "Jimmy Doe", new DateTime(2015, 9, 10), false);

if (newEvent.RegisterVisitor(visitor1))
    Console.WriteLine($"Registered Visitor: {visitor1.Name}");
if (newEvent.RegisterVisitor(visitor2))
    Console.WriteLine($"Registered Visitor: {visitor2.Name}");
if (newEvent.RegisterVisitor(visitor3))
    Console.WriteLine($"Registered Visitor: {visitor3.Name}");

newEvent.DisplaySeating();