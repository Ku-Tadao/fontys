using System.Collections.Generic;
using System.Linq;

public class Wagon
{
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public int Capacity { get; set; } = 10;
    public int RemainingCapacity => Capacity - Animals.Sum(a => a.Points);

    public bool CanAddAnimal(Animal animal)
    {
        if (animal.Points > RemainingCapacity) return false;

        if (animal.AnimalDiet == Animal.Diet.Carnivore)
        {
            return !Animals.Any(a => a.AnimalSize <= animal.AnimalSize);
        }
        else
        {
            return !Animals.Any(a => a.AnimalDiet == Animal.Diet.Carnivore && a.AnimalSize >= animal.AnimalSize);
        }
    }

    public void AddAnimal(Animal animal)
    {
        if (CanAddAnimal(animal))
        {
            Animals.Add(animal);
        }
    }
}