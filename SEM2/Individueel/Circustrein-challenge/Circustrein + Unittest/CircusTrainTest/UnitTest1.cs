using CircusTrainTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TrainTests
{
    [TestMethod]
    public void TestAddAnimalToNewWagonInTrain()
    {
        // Arrange
        Animal animal = new Animal { AnimalDiet = Animal.Diet.Herbivore, AnimalSize = Animal.Size.Medium };
        Train train = new Train();

        // Act
        train.AddAnimal(animal);

        // Assert
        Assert.AreEqual(1, train.Wagons.Count);
        Assert.AreEqual(animal, train.Wagons[0].Animals[0]);
    }
}