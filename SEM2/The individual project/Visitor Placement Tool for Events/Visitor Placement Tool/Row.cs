using Visitor_Placement_Tool.Enums;

namespace Visitor_Placement_Tool
{
    public class Row
    {
        public int Number { get; }
        public List<Seat> Seats { get; }
        public SectionLetterEnum.SectionLetter SectionLetter { get; }
        public int NumSeats { get; }

        public Row(int number, SectionLetterEnum.SectionLetter sectionletter, int numSeats)
        {
            Number = number;
            SectionLetter = sectionletter;
            Seats = new List<Seat>();
            NumSeats = numSeats;
            GenerateSeats();
        }

        private void GenerateSeats()
        {
            for (int i = 1; i <= NumSeats; i++)
            {
                Seat seat = new Seat(i, SectionLetter, Number);
                Seats.Add(seat);
            }
        }

        public int TotalSeatsFree()
        {
            int seatsFree = 0;
            foreach (Seat seat in Seats)
            {
                if (seat.SeatedVisitor == null) {
                    seatsFree++;
                }
            }
            return seatsFree;
        }

        public int FrontRowSeatsLeft()
        {
            if (Number == 1)
            {
                return TotalSeatsFree();
            }
            return 0;
        }

        public bool PlaceVisitorOnSeat(Visitors visitors)
        {
            foreach (Seat seat in Seats)
            {
                if (seat.SeatedVisitor == null)
                {
                    seat.PlaceVisitor(visitors);
                    return true;
                }

            }
            return false;
        }
    }
}