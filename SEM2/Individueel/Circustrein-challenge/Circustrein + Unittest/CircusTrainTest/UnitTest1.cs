using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CircusTrainTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CarnivoreCannotEatAnotherAnimal()
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
}
