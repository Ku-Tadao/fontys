namespace Visitor_Placement_Tool
{
    public class Group
    {
        public List<Visitors> Visitors { get; }
        public int GroupId { get; }

        private static int _id;

        public Group(List<Visitors> list)
        {
            Visitors = list;
            _id++;
            GroupId = _id;
        }

        public bool HasChildInGroup()
        {
            foreach (var visitor in Visitors)
            {
                if (visitor.Ischild == true)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetAmountOfChildren()
        {
            int children = 0;
            foreach (Visitors vistor in Visitors)
            {
                if (vistor.Ischild) children++;
            }
            return children;
        }

        public void AddPeopleToGroup(Visitors visitor)
        {
            Visitors.Add(visitor);
        }
        public void RemoveAdultFromGroup(Visitors visitor)
        {
            Visitors.Remove(visitor);
        }
    }
}