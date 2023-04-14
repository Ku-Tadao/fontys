public class Train
{
    private List<Wagon> _wagons;

    public IReadOnlyList<Wagon> Wagons => _wagons.AsReadOnly();

    public Train()
    {
        _wagons = new List<Wagon>();
    }

    public void AddAnimal(Animal animal)
    {
        bool added = false;

        foreach (Wagon wagon in _wagons)
        {
            if (wagon.CanAddAnimal(animal))
            {
                wagon.AddAnimal(animal);
                added = true;
                break;
            }
        }

        if (!added)
        {
            Wagon newWagon = new Wagon();
            newWagon.AddAnimal(animal);
            _wagons.Add(newWagon);
        }
    }

    public void AddAnimals(List<Animal> animals)
    {
        animals.Sort((a1, a2) =>
        {
            int dietComparison = a1.AnimalDiet.CompareTo(a2.AnimalDiet);
            if (dietComparison != 0) return -dietComparison;

            int size1 = a1.Points;
            int size2 = a2.Points;
            return size2.CompareTo(size1);
        });

        foreach (Animal animal in animals)
        {
            AddAnimal(animal);
        }
    }
}