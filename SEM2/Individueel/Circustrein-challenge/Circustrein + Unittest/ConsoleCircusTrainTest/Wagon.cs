using System.Collections.Generic;

namespace ConsoleCircusTrainTest
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

        public Wagon()
        {
            Animals = new List<Animal>();
        }

        public bool CanAddAnimal(Animal animal)
        {
            // Check if the wagon is empty
            if (Animals == null)
            {
                return true;
            }
            if (Animals?.Count == 0)
            {
                return true;
            }

            // Check if the animal is herbivorous
            if (animal.Diet == Diet.Plants)
            {
                // Check if the wagon has enough space
                int points = Animals.Count * (int)Animals[0].Size;
                return points + (int)animal.Size <= 10;
            }

            // Check if the animal can eat another animal in the wagon
            foreach (Animal a in Animals)
            {
                if (a.Size >= animal.Size)
                {
                    return false;
                }
            }

            // Check if the wagon has enough space
            int points2 = Animals.Count * (int)Animals[0].Size;
            return points2 + (int)animal.Size <= 10;
        }

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
        }
    }
}
