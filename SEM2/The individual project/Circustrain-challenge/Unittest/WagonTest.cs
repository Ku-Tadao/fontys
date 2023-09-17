using Circustrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittest
{
    internal class WagonTest
    {
        private Wagon _wagon;
        private Animal _lion;
        private Animal _elephant;

        [SetUp]
        public void SetUp()
        {
            _wagon = new Wagon();
            _lion = new Animal("Lion", DietType.Meat, SizeType.Large);
            _elephant = new Animal("Elephant", DietType.Plants, SizeType.Large);
        }

        [Test]
        public void CanAddAnimal_WhenCalled_ReturnsTrueIfAnimalCanBeAdded()
        {
            var result = _wagon.CanAddAnimal(_lion);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CanAddAnimal_WhenAddingIncompatibleAnimals_ReturnsFalse()
        {
            _wagon.AddAnimal(_lion);
            var result = _wagon.CanAddAnimal(_elephant);

            Assert.That(result, Is.False);
        }

        [Test]
        public void AddAnimal_WhenCalled_AddsAnimalToWagon()
        {
            _wagon.AddAnimal(_lion);

            Assert.That(_wagon.Animals.Count, Is.EqualTo(1));
            Assert.That(_wagon.Animals[0], Is.EqualTo(_lion));
        }
    }
}
