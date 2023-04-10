using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCircusTrain
{
    internal class Wagon
    {

        public int Id { get; }
        public List<Animal> Animals { get; }

        public Wagon(int id)
        {
            Id = id;
            Animals = new List<Animal>();
        }

        public bool CanAddAnimal(Animal animal)
        {
            if (Animals.Count == 0)
            {
                return true;
            }

            if (animal.Diet == Diet.Plants)
            {
                int points = Animals.Count * (int)Animals[0].Size;
                return points + (int)animal.Size <= 10;
            }

            foreach (Animal a in Animals)
            {
                if (a.Size >= animal.Size)
                {
                    return false;
                }
            }

            int points2 = Animals.Count * (int)Animals[0].Size;
            return points2 + (int)animal.Size <= 10;
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }
    }
}
