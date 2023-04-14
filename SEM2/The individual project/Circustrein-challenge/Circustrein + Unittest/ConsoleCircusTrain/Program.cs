class Program
{
    static void Main(string[] args)
    {
        Train train = new Train();

        Console.WriteLine("Welcome to the Circus Train!");

        List<Animal> animals = new List<Animal>
        {
            new(animalDiet: "Herbivore", animalSize: "Medium"),
            new(animalDiet: "Carnivore", animalSize: "Large"),
            new(animalDiet: "Carnivore", animalSize: "Medium"),
            new(animalDiet: "Herbivore", animalSize: "Large"),
            new(animalDiet: "Carnivore", animalSize: "Small"),
            new(animalDiet: "Herbivore", animalSize: "Small")
        };

        train.AddAnimals(animals);


        Console.WriteLine("\nAnimals distribution in wagons:");
        int wagonNumber = 1;
        foreach (Wagon wagon in train.Wagons)
        {
            Console.WriteLine($"Wagon {wagonNumber}:");
            foreach (Animal animal in wagon.Animals)
            {
                Console.WriteLine($" - {animal.AnimalDiet} {animal.AnimalSize} ({animal.Points} points)");
            }
            Console.WriteLine($"Total points: {wagon.Capacity - wagon.RemainingCapacity}/{wagon.Capacity}\n");
            wagonNumber++;
        }
    }
}