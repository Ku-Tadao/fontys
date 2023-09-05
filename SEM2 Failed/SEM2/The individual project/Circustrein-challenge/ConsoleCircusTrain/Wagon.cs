public class Wagon
{
    private List<Animal> _animals = new List<Animal>();

    public IReadOnlyList<Animal> Animals => _animals.AsReadOnly();
    public int Capacity { get; } = 10;

    // lambda met sum:
    // public int RemainingCapacity => Capacity - _animals.Sum(a => a.Points);

    public int RemainingCapacity
    {
        get
        {
            int usedCapacity = 0;
            foreach (Animal animal in _animals)
            {
                usedCapacity += animal.Points;
            }
            return Capacity - usedCapacity;
        }
    }


    public bool CanAddAnimal(Animal animal)
    {
        if (animal.Points > RemainingCapacity) return false;

        bool hasCarnivore = false;
        foreach (Animal otherAnimal in _animals)
        {
            if (otherAnimal.AnimalDiet == "Carnivore")
            {
                hasCarnivore = true;
                if (otherAnimal.AnimalSize == "Large") return false;
            }
        }

        if (animal.AnimalDiet == "Carnivore")
        {
            if (_animals.Count > 0) return false;

            if (hasCarnivore) return false;

        }
        else
        {
            foreach (Animal otherAnimal in _animals)
            {
                if (otherAnimal.AnimalDiet == "Carnivore" && (otherAnimal.AnimalSize == animal.AnimalSize || otherAnimal.AnimalSize == "Small"))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void AddAnimal(Animal animal)
    {
        if (CanAddAnimal(animal))
        {
            _animals.Add(animal);
        }
    }
}
