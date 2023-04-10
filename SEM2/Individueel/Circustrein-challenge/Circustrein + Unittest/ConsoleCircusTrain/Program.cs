using ConsoleCircusTrain;

List<Animal> animals = new List<Animal>();
int wagonIndex = 1;

// Static animals
animals.Add(new Animal("lion", Diet.Meat, Size.Large));
animals.Add(new Animal("giraffe", Diet.Plants, Size.Large));
animals.Add(new Animal("monkey", Diet.Meat, Size.Small));
animals.Add(new Animal("elephant", Diet.Plants, Size.Large));
animals.Add(new Animal("zebra", Diet.Plants, Size.Medium));
animals.Add(new Animal("tiger", Diet.Meat, Size.Medium));
animals.Add(new Animal("rat", Diet.Plants, Size.Small));

//Optional, pak manual input ipv static data
//while (true)
//{
//    // Declare a variable to hold the user's input
//    string userInput;

//    // Prompt the user to enter the animal name
//    Console.Write("Enter animal name: ");
//    userInput = UppercaseFirst(Console.ReadLine());

//    // Prompt the user to enter the animal's diet
//    Console.Write("Enter animal diet (Plants or Meat): ");
//    userInput = UppercaseFirst(Console.ReadLine());

//    // Parse the user's input into a Diet enum value
//    Diet diet;
//    if (!Enum.TryParse(userInput, out diet))
//    {
//        Console.WriteLine("Invalid diet entered. Please try again.");
//        return;
//    }

//    // Prompt the user to enter the animal's size
//    Console.Write("Enter animal size (Small, Medium or Large): ");
//    userInput = UppercaseFirst(Console.ReadLine());

//    // Parse the user's input into a Size enum value
//    Size size;
//    if (!Enum.TryParse(userInput, out size))
//    {
//        Console.WriteLine("Invalid size entered. Please try again.");
//        return;
//    }

//    // Create a new animal object using the user's input and add it to the animals collection
//    animals.Add(new Animal(userInput, diet, size));

//    // prompt the user to continue or exit
//    Console.Write("Do you want to add another animal? (Y/N): ");
//    string addanotheranimal = Console.ReadLine();

//    // check if the user wants to exit the loop
//    if (addanotheranimal.ToUpper() == "N")
//    {
//        // exit the loop
//        break;
//    }
//}

// Sort animals by size
animals.Sort();

// Create wagons and distribute animals
List<Wagon> wagons = new();
foreach (Animal animal in animals)
{
    Wagon? wagon = wagons.Find(w => w.CanAddAnimal(animal));
    if (wagon == null)
    {
        wagon = new Wagon(wagonIndex++);
        wagons.Add(wagon);
    }
    wagon.AddAnimal(animal);
}

// Print wagon contents
foreach (Wagon wagon in wagons)
{
    Console.WriteLine("Wagon {0}:", wagon.Id);
    foreach (Animal animal in wagon.Animals)
    {
        Console.WriteLine("- {0} ({1})", animal.Name, animal.Size);
    }
}

Console.ReadLine();