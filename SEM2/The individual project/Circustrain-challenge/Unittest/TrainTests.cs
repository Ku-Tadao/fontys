using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circustrain;

namespace Unittest
{
    internal class TrainTests
    {
        private Train _train;
        private Animal _lion;
        private Animal _elephant;

        [SetUp]
        public void SetUp()
        {
            _train = new Train();
            _lion = new Animal("Lion", DietType.Meat, SizeType.Large);
            _elephant = new Animal("Elephant", DietType.Plants, SizeType.Large);
        }

        [Test]
        public void AddAnimalToTrain_WhenCalled_AddsAnimalToWagon()
        {
            _train.AddAnimalToTrain(_lion);

            Assert.That(_train.Wagons.Count, Is.EqualTo(1));    
            Assert.That(_train.Wagons[0].Animals.Count, Is.EqualTo(1));
            Assert.That(_train.Wagons[0].Animals[0], Is.EqualTo(_lion));
        }

        [Test]
        public void AddAnimalToTrain_WhenAddingIncompatibleAnimals_CreatesNewWagon()
        {
            _train.AddAnimalToTrain(_lion);
            _train.AddAnimalToTrain(_elephant);

            Assert.That(_train.Wagons.Count, Is.EqualTo(2));
            Assert.That(_train.Wagons[1].Animals.Count, Is.EqualTo(1));
            Assert.That(_train.Wagons[1].Animals[0], Is.EqualTo(_elephant));
        }
    }
}
