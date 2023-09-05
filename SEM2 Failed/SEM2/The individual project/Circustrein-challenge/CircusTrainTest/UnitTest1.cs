namespace CircusTrainTest 
{
    [TestClass]
    public class AnimalTests
    {
        [TestMethod]
        public void AnimalDiet_SetValidValue_SetsValue()
        {
            // Arrange
            var animal = new Animal("Herbivore", "Small");

            // Act
            animal.AnimalDiet = "Carnivore";

            // Assert
            Assert.AreEqual("Carnivore", animal.AnimalDiet);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AnimalDiet_SetInvalidValue_ThrowsException()
        {
            // Arrange
            var animal = new Animal("Herbivore", "Small");

            // Act
            animal.AnimalDiet = "InvalidDiet";
        }
    }

    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void AddAnimal_AnimalFitsInExistingWagon_AddsAnimalToWagon()
        {
            // Arrange
            var train = new Train();
            var wagon = new Wagon();
            wagon.AddAnimal(new Animal("Herbivore", "Small"));
            train.AddAnimal(new Animal("Herbivore", "Small"));

            // Act
            train.AddAnimal(new Animal("Herbivore", "Small"));

            // Assert
            Assert.AreEqual(1, train.Wagons.Count);
            Assert.AreEqual(2, train.Wagons[0].Animals.Count);
        }

        [TestMethod]
        public void AddAnimal_AnimalDoesNotFitInExistingWagon_AddsNewWagon()
        {
            // Arrange
            var train = new Train();
            train.AddAnimal(new Animal("Carnivore", "Large"));

            // Act
            train.AddAnimal(new Animal("Herbivore", "Small"));

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);
        }
    }

    [TestClass]
    public class WagonTests
    {
        [TestMethod]
        public void CanAddAnimal_AnimalFitsInWagon_ReturnsTrue()
        {
            // Arrange
            var wagon = new Wagon();
            wagon.AddAnimal(new Animal("Herbivore", "Small"));

            // Act
            bool result = wagon.CanAddAnimal(new Animal("Herbivore", "Small"));

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanAddAnimal_AnimalDoesNotFitInWagon_ReturnsFalse()
        {
            // Arrange
            var wagon = new Wagon();
            wagon.AddAnimal(new Animal("Carnivore", "Large"));

            // Act
            bool result = wagon.CanAddAnimal(new Animal("Herbivore", "Small"));

            // Assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class AddAnimalsToWagonToTrain
    {
        [TestMethod]
        public void AddAnimal_LargeCarnivoreAndLargeHerbivoreInSameWagon_ReturnsFalse()
        {
            // Arrange
            var train = new Train();
            train.AddAnimal(new Animal("Carnivore", "Large"));

            // Act
            train.AddAnimal(new Animal("Herbivore", "Large"));

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);
        }

        [TestMethod]
        public void AddAnimal_LargeHerbivoreAndMediumCarnivoreInSameWagon_ReturnsFalse()
        {
            // Arrange
            var train = new Train();
            train.AddAnimal(new Animal("Herbivore", "Large"));

            // Act
            train.AddAnimal(new Animal("Carnivore", "Medium"));

            // Assert
            Assert.AreEqual(2, train.Wagons.Count);
        }

    }
}
