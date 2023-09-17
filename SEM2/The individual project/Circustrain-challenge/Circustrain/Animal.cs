using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrain
{
    public enum DietType { Meat, Plants }
    public enum SizeType { Small = 1, Medium = 3, Large = 5 }

    public class Animal
    {
        public string Name { get; set; }
        public DietType Diet { get; set; }
        public SizeType Size { get; set; }

        public Animal(string name, DietType diet, SizeType size)
        {
            Name = name;
            Diet = diet;
            Size = size;
        }

        public int GetPoints()
        {
            return (int)Size;
        }
    }

}
