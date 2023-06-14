using Visitor_Placement_Tool.Enums;

namespace Visitor_Placement_Tool
{
    public class Seat
    {
        public int Number { get; }
        public string SeatName { get; }
        public Visitors SeatedVisitor { get; private set; }

        public Seat(int number, SectionLetterEnum.SectionLetter sectionLetter, int row)
        {
            Number = number;
            SeatName = sectionLetter + "-" + row + "-" + Number;
        }

        public void PlaceVisitor(Visitors visitors)
        {
            SeatedVisitor = visitors;
        }
    }
}