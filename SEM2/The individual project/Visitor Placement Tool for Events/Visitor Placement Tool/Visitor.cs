namespace Visitor_Placement_Tool
{
    public class Visitors
    {
        public DateTime DateOfBirth { get; }
        public DateTime DateSignedUp { get; }
        public int VisitorId { get; }
        public string Name { get; }
        public bool Ischild { get; }

        private static int _lastVisitorId;

        public Visitors(DateTime dateOfBirth, string name, Event @event)
        {
            DateOfBirth = dateOfBirth;
            DateSignedUp = new DateTime(2020, 1, 10);
            Name = name;
            VisitorId = NextId();
            Ischild = IsChild(@event.StartDate);
        }

        public Visitors(DateTime dateOfBirth, string name, Event @event, DateTime signUpDate)
        {
            DateOfBirth = dateOfBirth;
            DateSignedUp = signUpDate;
            Name = name;
            VisitorId = NextId();
            Ischild = IsChild(@event.StartDate);
        }

        private int NextId()
        {
            _lastVisitorId++;
            return _lastVisitorId;
        }

        private bool IsChild(DateTime eventDate)
        {
            if (DateOfBirth > eventDate.Date.AddYears(-12))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}