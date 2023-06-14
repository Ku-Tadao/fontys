using static Visitor_Placement_Tool.Enums.SectionLetterEnum;

namespace Visitor_Placement_Tool
{
    public class Section
    {
        public SectionLetter Name { get; }
        public List<Row> Rows { get; }
        public int MaxRows { get; }

        public Section(SectionLetter name, int maxrows)
        {
            Name = name;
            Rows = new List<Row>();
            MaxRows = maxrows;
            GenerateRows();
        }

        private void GenerateRows()
        {
            int numSeats = 5; // Between 3/10 max!
            for (int i = 1; i <= MaxRows; i++)
            {
                Row row = new Row(i, Name, numSeats);
                Rows.Add(row);
            }
        }


        public bool SeatVisitorInRow(Visitors visitors)
        {
            foreach (Row row in Rows)
            {
                bool placed = row.PlaceVisitorOnSeat(visitors);
                if (placed) return true;
            }
            return false;
        }

        public bool IsEnoughSeatsForGroupWithChildren(int groupSize, int children)
        {
            int freeSeats = 0;
            int freeFrontSeats = Rows[0].FrontRowSeatsLeft();

            foreach (Row row in Rows)
            {
                freeSeats += row.TotalSeatsFree();
            }

            if (freeSeats >= groupSize && freeFrontSeats >= children) return true;
            return false;
        }
    }
}