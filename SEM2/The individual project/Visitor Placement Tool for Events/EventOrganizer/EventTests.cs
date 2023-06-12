using Visitor_Placement_Tool;

namespace EventOrganizer;

public class EventTests
{
    [Test]
    public void TestAssignSeats()
    {
        // Create a new event with a maximum of 10 visitors
        var placementEvent = new Event(10);

        // Add boxes with rows and seats
        var boxA = new Box('A');
        boxA.Rows.Add(new Row(1) {Seats = {new Seat(1), new Seat(2), new Seat(3)}});
        boxA.Rows.Add(new Row(2) {Seats = {new Seat(1), new Seat(2), new Seat(3)}});
        placementEvent.Boxes.Add(boxA);

        var boxB = new Box('B');
        boxB.Rows.Add(new Row(1) {Seats = {new Seat(1), new Seat(2), new Seat(3)}});
        boxB.Rows.Add(new Row(2) {Seats = {new Seat(1), new Seat(2), new Seat(3)}});
        placementEvent.Boxes.Add(boxB);

        // Add visitors
        placementEvent.Visitors.Add(new AdultVisitor("Alice", new DateTime(1980, 1, 1))
            {RegistrationDate = DateTime.Now.AddDays(-7)});
        placementEvent.Visitors.Add(new ChildVisitor("Bob", new DateTime(2015, 1, 1))
            {RegistrationDate = DateTime.Now.AddDays(-6)});
        placementEvent.Visitors.Add(new AdultVisitor("Charlie", new DateTime(1990, 1, 1))
            {RegistrationDate = DateTime.Now.AddDays(-5)});

// Assign seats to visitors
        placementEvent.AssignSeats();

        // Check that visitors were assigned to seats
        Assert.AreEqual(placementEvent.Boxes[0].Rows[0].Seats[0].Visitor.Name, "Alice");
        Assert.AreEqual(placementEvent.Boxes[0].Rows[0].Seats[1].Visitor.Name, "Bob");
        Assert.AreEqual(placementEvent.Boxes[0].Rows[0].Seats[2].Visitor.Name, "Charlie");
    }
}