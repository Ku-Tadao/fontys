namespace Visitor_Placement_Tool
{
    public class Event
    {
        public DateTime StartDate { get; }
        public int MaxVisitors { get; }
        public List<Section> Sections { get; }
        public List<Group> Groups { get; }

        #region SetUp
        public Event(DateTime startDate, int maxVisitors)
        {
            StartDate = startDate;
            MaxVisitors = maxVisitors;
            Sections = new List<Section>();
            Groups = new List<Group>();
        }

        public List<Visitors> NotTooLate(List<Visitors> visitors)
        {
            //LINQ + Lambda would improve it, but i'm not smart enough to explain

            int currentVisitors = 0;
            List<Visitors> visitorsOnTime = new List<Visitors>();

            // Create a new list to store the sorted visitors
            List<Visitors> sortedVisitors = new List<Visitors>(visitors);

            // Sort the sortedVisitors list using a custom sort method
            sortedVisitors.Sort(CompareVisitorsByDateSignedUp);
            foreach (Visitors visitor in sortedVisitors)
            {
                if (visitor.DateSignedUp < StartDate && currentVisitors < MaxVisitors)
                {
                    visitorsOnTime.Add(visitor);
                    currentVisitors++;
                }
            }
            return visitorsOnTime;
        }

        // Custom sort method to compare visitors by DateSignedUp in descending order
        private int CompareVisitorsByDateSignedUp(Visitors x, Visitors y)
        {
            return y.DateSignedUp.CompareTo(x.DateSignedUp);
        }


        public void AddSections(Section section)
        {
            Sections.Add(section);
        }
        #endregion

        private void ReSortGroups()
        {
            Group groupAdults = new Group(new List<Visitors>());
            foreach (Group group in Groups)
            {
                int firstAdult = 0;

                if (group.HasChildInGroup() == true)
                {
                    for (int i = 0; i < group.Visitors.Count; i++)
                    {
                        Visitors visitor = group.Visitors[i];
                        if (!visitor.Ischild)
                        {
                            if (firstAdult == 0)
                            {
                                firstAdult++;
                            }
                            else
                            {
                                i--;
                                group.RemoveAdultFromGroup(visitor);
                                groupAdults.AddPeopleToGroup(visitor);
                            }
                        }
                    }
                }
            }
            Groups.Add(groupAdults);
        }

        public void PlaceAllVisitors()
        {
            ReSortGroups();
            List<Group> adults = new();
            foreach (Group group in Groups)
            {
                if (group.HasChildInGroup() == true)
                {
                    PlaceGroupWithChildren(group);
                }
                else
                {
                    adults.Add(group);
                }
            }

            foreach (Group group in adults)
            {
                PlaceGroupsWithoutChildren(group);
            }
        }

        private void PlaceGroupWithChildren(Group group)
        {
            int visitorsPlaced = 0;
            foreach (Section section in Sections)
            {
                if (section.IsEnoughSeatsForGroupWithChildren(group.Visitors.Count, group.GetAmountOfChildren()))
                {
                    foreach (Visitors visitor in group.Visitors.OrderByDescending(i => i.DateOfBirth))
                    {
                        visitorsPlaced++;
                        section.SeatVisitorInRow(visitor);
                    }
                    break;
                }
            }
            if (visitorsPlaced != group.Visitors.Count)
            {
                // Split group into subgroups and place each subgroup
                List<Group> subgroups = SplitGroup(group);
                foreach (Group subgroup in subgroups)
                {
                    PlaceGroupWithChildren(subgroup);
                }
            }
        }

        private List<Group> SplitGroup(Group group)
        {
            List<Group> subgroups = new List<Group>();
            List<Visitors> adults = group.Visitors.Where(v => !v.Ischild).ToList();
            List<Visitors> children = group.Visitors.Where(v => v.Ischild).ToList();

            // Create subgroups with one adult and as many children as can fit in a front row
            int frontRowCapacity = Sections[0].Rows[0].Seats.Count;
            while (adults.Count > 0 && children.Count > 0)
            {
                Group subgroup = new Group(new List<Visitors>());
                subgroup.AddPeopleToGroup(adults[0]);
                adults.RemoveAt(0);
                int numChildren = Math.Min(frontRowCapacity - 1, children.Count);
                for (int i = 0; i < numChildren; i++)
                {
                    subgroup.AddPeopleToGroup(children[0]);
                    children.RemoveAt(0);
                }
                subgroups.Add(subgroup);
            }

            // Add remaining adults to a new subgroup
            if (adults.Count > 0)
            {
                Group subgroup = new Group(adults);
                subgroups.Add(subgroup);
            }

            // Add remaining children to existing subgroups
            while (children.Count > 0)
            {
                foreach (Group subgroup in subgroups)
                {
                    if (subgroup.GetAmountOfChildren() < frontRowCapacity)
                    {
                        subgroup.AddPeopleToGroup(children[0]);
                        children.RemoveAt(0);
                        if (children.Count == 0) break;
                    }
                }
            }

            return subgroups;
        }

        public List<Visitors> GetVisitorsWithoutAccess(List<Visitors> allVisitors)
        {
            List<Visitors> allowedVisitors = NotTooLate(allVisitors);
            List<Visitors> visitorsWithoutAccess = allVisitors.Except(allowedVisitors).ToList();
            return visitorsWithoutAccess;
        }


        private void PlaceGroupsWithoutChildren(Group group)
        {
            foreach (Visitors visitor in group.Visitors)
            {
                foreach (Section section in Sections)
                {
                    bool placed = section.SeatVisitorInRow(visitor);
                    if (placed)
                    {
                        break;
                    }
                }
            }
        }
    }
}