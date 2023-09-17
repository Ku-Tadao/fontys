using Circustrain;

Train train = new Train();

// Create some animals
Animal lion = new Animal("Lion", DietType.Meat, SizeType.Large);
Animal elephant = new Animal("Elephant", DietType.Plants, SizeType.Large);
Animal cow = new Animal("Cow", DietType.Plants, SizeType.Medium);
Animal spider = new Animal("Spider", DietType.Meat, SizeType.Small);
Animal goat = new Animal("Goat", DietType.Plants, SizeType.Small);
Animal cat = new Animal("Cat", DietType.Meat, SizeType.Small);

// Add animals to the train
train.AddAnimalToTrain(lion);
train.AddAnimalToTrain(elephant);
train.AddAnimalToTrain(cow);
train.AddAnimalToTrain(spider);
train.AddAnimalToTrain(goat);
train.AddAnimalToTrain(cat);

// Print the number of wagons in the train
Console.WriteLine($"Number of wagons in the train: {train.Wagons.Count}");

// For each wagon, print the total points and the names of the animals
for (int i = 0; i < train.Wagons.Count; i++)
{
    Console.WriteLine($"Wagon {i + 1}:");
    Console.WriteLine($"Total points: {train.Wagons[i].TotalPoints}");
    Console.WriteLine("Animals:");
    foreach (var animal in train.Wagons[i].Animals)
    {
        Console.WriteLine(animal.Name);
    }
    Console.WriteLine();
}