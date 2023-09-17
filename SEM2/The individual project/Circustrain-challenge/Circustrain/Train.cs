using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrain
{
    public class Train
    {
        public List<Wagon> Wagons { get; set; }

        public Train()
        {
            Wagons = new List<Wagon>();
        }

        public void AddAnimalToTrain(Animal animal)
        {
            foreach (var wagon in Wagons)
            {
                if (wagon.CanAddAnimal(animal))
                {
                    wagon.AddAnimal(animal);
                    return;
                }
            }

            // IF no existing wagon can add an animal, create a new one.
            var newWagon = new Wagon();
            newWagon.AddAnimal(animal);
            Wagons.Add(newWagon);
        }
    }
}
