using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Placement_Tool
{
    public class Visitor
    {
        private int _id;
        private string _name;
        private DateTime _dob;
        private bool _isAdult;
        private int _groupId;

        public Visitor(int id, string name, DateTime dob, bool isAdult)
        {
            _id = id;
            _name = name;
            _dob = dob;
            _isAdult = isAdult;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime DOB
        {
            get { return _dob; }
            set { _dob = value; }
        }

        public bool IsAdult
        {
            get { return _isAdult; }
            set { _isAdult = value; }
        }

        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }

        public void Register()
        {
            // Register visitor logic here
        }
    }

}
