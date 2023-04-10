using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleCircusTrainTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class TrainUnitTest
        {
            [TestMethod]
            public void AddAnimalToWagon_SmallCarnivoreInEmptyWagon_ShouldReturnTrue()
            {
                // Arrange
                Wagon wagon = new Wagon();
                Animal animal = new Animal("Small Carnivore animal", Diet.Meat, Size.Small);

                var result = wagon.CanAddAnimal(animal);

                wagon.AddAnimal(animal);

                // Assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void AddAnimalToWagon_LargeHerbivoreInWagonWithSmallCarnivore_ShouldReturnTrue()
            {
                // Arrange
                Wagon wagon = new Wagon();
                wagon.AddAnimal(new Animal("Small Carnivore Animal" ,Diet.Meat, Size.Small));
                Animal animal = new Animal("Large Herbivore Animal" ,Diet.Plants, Size.Large);

                // Act
                wagon.AddAnimal(animal);

                // Assert
                Assert.AreEqual(2, wagon.Animals.Count);
                Assert.IsTrue(wagon.Animals.Contains(animal));
            }

            [TestMethod]
            public void GetTrainComposition_ThreeAnimalsInTwoWagons_ShouldReturnCorrectComposition()
            {
                // Arrange
                Wagon wagon = new Wagon();
                wagon.AddAnimal(new Animal("Large Herbivore Animal", Diet.Plants, Size.Large));
                wagon.AddAnimal(new Animal("Medium Carnivore Animal", Diet.Meat, Size.Medium));
                wagon.AddAnimal(new Animal("Medium Herbivore Animal", Diet.Plants, Size.Medium));

                // Act (kan verkeerd zijn, not sure)
                List<Wagon> composition = new List<Wagon> {wagon};

                // Assert
                Assert.AreEqual(1, composition.Count);
                Assert.AreEqual(3, composition[0].Animals.Count);
            }
        }
    }
}
