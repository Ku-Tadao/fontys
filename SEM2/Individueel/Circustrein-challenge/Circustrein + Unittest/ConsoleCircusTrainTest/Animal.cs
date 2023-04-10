using System;

namespace ConsoleCircusTrainTest
{
    internal class Animal : IComparable<Animal>
    {
        public string Name { get; }
        public Diet Diet { get; }
        public Size Size { get; }

        public Animal(string name, Diet diet, Size size)
        {
            Name = name;
            Diet = diet;
            Size = size;
        }

        public int CompareTo(Animal other)
        {
            return Size.CompareTo(other.Size);
        }
    }

    public enum Diet
    {
        Meat,
        Plants
    }

    public enum Size
    {
        Small = 1,
        Medium = 3,
        Large = 5
    }
}
