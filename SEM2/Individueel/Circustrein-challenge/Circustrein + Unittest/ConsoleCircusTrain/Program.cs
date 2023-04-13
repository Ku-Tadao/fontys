class Program
{
    static void Main(string[] args)
    {
        Train train = new Train();

        Console.WriteLine("Welcome to the Circus Train!");

        List<Animal> animals = new List<Animal>
        {
            new() {AnimalDiet = "Carnivore", AnimalSize ="Large"},
            new() {AnimalDiet = "Carnivore", AnimalSize ="Medium"},
            new() {AnimalDiet = "Carnivore", AnimalSize ="Small"},
            new() {AnimalDiet = "Herbivore", AnimalSize = "Large"},
            new() {AnimalDiet = "Herbivore", AnimalSize = "Medium"},
            new() {AnimalDiet = "Herbivore", AnimalSize = "Small"}
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