class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        List<Wagon> wagons = new List<Wagon>();

        // Add code here to interact with the user and add animals to the animals list

        foreach (Animal animal in animals)
        {
            bool added = false;
            foreach (Wagon wagon in wagons)
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
                wagons.Add(newWagon);
            }
        }

        // Output the distribution of animals in wagons
    }
}