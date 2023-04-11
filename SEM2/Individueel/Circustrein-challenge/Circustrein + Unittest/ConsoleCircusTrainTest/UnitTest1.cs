using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class WagonTests
{
    [TestMethod]
    public void TestCarnivoreCannotEatAnotherAnimal()
    {
        // Arrange
        Animal carnivore = new Animal { AnimalDiet = Animal.Diet.Carnivore, AnimalSize = Animal.Size.Medium };
        Animal herbivore = new Animal { AnimalDiet = Animal.Diet.Herbivore, AnimalSize = Animal.Size.Small };
        Wagon wagon = new Wagon();

        // Act
        wagon.AddAnimal(carnivore);
        wagon.AddAnimal(herbivore);

        // Assert
        Assert.AreEqual(1, wagon.Animals.Count);
    }
}