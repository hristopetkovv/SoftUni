using CarTrip;
using NUnit.Framework;
using System;

namespace CarTrip.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test] // test construnctor + get property
        public void TestPropertyGettersWorkCorrectly()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            string model = car.Model;
            double capacity = car.TankCapacity;
            double fuel = car.FuelAmount;
            double consumption = car.FuelConsumptionPerKm;

            string expectedModel = "Kola";
            double expectedCapacity = 60;
            double expectedFuel = 50;
            double expectedConsumption = 0.2;

            Assert.AreEqual(expectedModel, model, "Model getter does not work as expect.");
            Assert.AreEqual(expectedCapacity, capacity, "Capacity getter does not work as expect.");
            Assert.AreEqual(expectedFuel, fuel, "Fuel amount getter does not work as expect.");
            Assert.AreEqual(expectedConsumption, consumption, "Fuel consumption getter does not work as expect.");
        }

        [Test]
        public void TestModelSetterThrowsExceptionWhenDataIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new Car("", 60, 50, 0.2), "Model setter does not validate the input data.");
        }

        [Test]
        public void TestFuelAmountSetterThrowsExceptionWhenDataIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new Car("", 60, 65, 0.2), "Fuel Amount setter does not validate the input data.");
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void TestFuelConsumptionSetterThrowsExceptionWhenDataIsInvalid(double consumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("", 60, 50, consumption), "Fuel consumption setter does not validate the input data.");
        }

        [Test]
        public void TestIfDriveMethodReducesFuelAmount()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            string message = car.Drive(10);

            string expectedMessage = "Have a nice trip";

            double fuel = car.FuelAmount;

            double expectedFuel = 48;

            Assert.AreEqual(expectedFuel, fuel);
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void TestIfDriveMethodThrowsExpectionWhenNotEnoughFuel()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            Assert.Throws<InvalidOperationException>(() => car.Drive(1000));
        }

        [Test]
        public void TestIfRefuelMethodIncreasesFuelAmount()
        {
            Car car = new Car("Kola", 60, 50, 0.2);
            car.Refuel(10);
            
            double fuel = car.FuelAmount;

            double expectedFuel = 60;

            Assert.AreEqual(expectedFuel, fuel);
        }

        [Test]
        public void TestIfRefuelMethodThrowsExpectionWhenTooMuchFuel()
        {
            Car car = new Car("Kola", 60, 50, 0.2);

            Assert.Throws<InvalidOperationException>(() => car.Refuel(100));
        }

    }
}