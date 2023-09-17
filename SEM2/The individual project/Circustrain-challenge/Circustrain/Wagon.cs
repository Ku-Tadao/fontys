using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrain
{
    public class Wagon
    {
        public List<Animal> Animals { get; set; }
        public int TotalPoints { get; set; }

        public Wagon()
        {
            Animals = new List<Animal>();
            TotalPoints = 0;
        }

        public bool CanAddAnimal(Animal animal)
        {
            // Check if adding animal would exceed the maximum points
            if (TotalPoints + animal.GetPoints() > 10)
                return false;

            // Check if any diet/size conflicts with existing animals
            foreach (var existingAnimal in Animals)
            {
                if (existingAnimal.Diet == DietType.Meat && existingAnimal.Size >= animal.Size)
                    return false;
            }

            return true;
        }

        public void AddAnimal(Animal animal)
        {
            if (CanAddAnimal(animal))
            {
                Animals.Add(animal);
                TotalPoints += animal.GetPoints();
            }
        }
    }
}
