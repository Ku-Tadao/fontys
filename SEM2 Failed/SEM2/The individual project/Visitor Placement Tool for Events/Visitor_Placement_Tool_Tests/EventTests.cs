using NUnit.Framework;
using System;
using System.Collections.Generic;
using Visitor_Placement_Tool;
using Visitor_Placement_Tool.Enums;

namespace Visitor_Placement_Tool_Tests
{
    [TestFixture]
    public class EventTests
    {
        [Test]
        public void NotTooLate_FiltersOutLateVisitors()
        {
            // Arrange
            int maxCap = 2;
            Event event1 = new Event(new DateTime(2022, 1, 10), maxCap);
            List<Visitors> signedUp = new()
            {
                new Visitors(new DateTime(2000, 1, 1), "On time", event1, new DateTime(2022, 1, 9)),
                new Visitors(new DateTime(2000, 1, 1), "Too late", event1, new DateTime(2022, 1, 11)),
                new Visitors(new DateTime(2000, 1, 1), "On time", event1, new DateTime(2022, 1, 8))
            };

            // Act
            List<Visitors> allowedVisitors = event1.NotTooLate(signedUp);

            // Assert
            Assert.AreEqual(2, allowedVisitors.Count);
            Assert.AreEqual("On time", allowedVisitors[0].Name);
            Assert.AreEqual("On time", allowedVisitors[1].Name);
        }

        [Test]
        public void PlaceGroupWithChildren_PlacesChildrenInFrontRow()
        {
            // Arrange
            int maxCap = 15;
            Event event1 = new Event(new DateTime(2022, 1, 10), maxCap);
            Section sectionA = new Section(SectionLetterEnum.SectionLetter.A, 3);
            event1.AddSections(sectionA);

            Group group = new Group(new List<Visitors>()
            {
                new Visitors(new DateTime(2014, 1, 10), "Child", event1, new DateTime(2022, 1, 9)),
                new Visitors(new DateTime(2000, 1, 10), "Adult", event1, new DateTime(2022, 1, 9))
            });
            event1.Groups.Add(group);

            // Act
            event1.PlaceAllVisitors();

            // Assert
            Assert.AreEqual("Child", sectionA.Rows[0].Seats[0].SeatedVisitor.Name);
        }

        [Test]
        public void PlaceGroupsWithoutChildren_PlacesAdultsInFrontRow()
        {
            // Arrange
            int maxCap = 15;
            Event event1 = new Event(new DateTime(2022, 1, 10), maxCap);
            Section sectionA = new Section(SectionLetterEnum.SectionLetter.A, 3);
            event1.AddSections(sectionA);

            Group group = new Group(new List<Visitors>()
            {
                new Visitors(new DateTime(2000, 1, 10), "Adult", event1, new DateTime(2022, 1, 9))
            });
            event1.Groups.Add(group);

            // Act
            event1.PlaceAllVisitors();
            event1.Groups.RemoveAt(0);

            // Assert
            Assert.AreEqual("Adult", sectionA.Rows[0].Seats[0].SeatedVisitor.Name);
        }
    }
}