using Circustrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unittest
{
    internal class AnimalTests
    {
        private Animal _lion;

        [SetUp]
        public void SetUp()
        {
            _lion = new Animal("Lion", DietType.Meat, SizeType.Large);
        }

        [Test]
        public void GetPoints_WhenCalled_ReturnsPointsBasedOnSize()
        {
            var result = _lion.GetPoints();

            Assert.That(result, Is.EqualTo(5));
        }
    }
}
