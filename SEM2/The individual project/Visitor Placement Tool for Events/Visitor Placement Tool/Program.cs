using Visitor_Placement_Tool;

Event myEvent = new Event(100, 5);

// Create some visitors
Visitor visitor1 = new Visitor("Alice", new DateTime(1990, 1, 1), 1);
Visitor visitor2 = new Visitor("Bob", new DateTime(2000, 1, 1), 2);

// Register the visitors
visitor1.Register();
visitor2.Register();

// Add the visitors to the event
myEvent.AddVisitor(visitor1);
myEvent.AddVisitor(visitor2);