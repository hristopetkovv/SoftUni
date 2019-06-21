namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class SoftParkTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestPropertyGettersWorkCorrectly()
        {
            Car car = new Car("Vw", "8596");

            string make = car.Make;
            string registrationNumber = car.RegistrationNumber;

            string expectedMake = "Vw";
            string expectedRegistrationNumber = "8596";

            Assert.AreEqual(expectedMake, make);
            Assert.AreEqual(expectedRegistrationNumber, registrationNumber);
        }

        [Test]
        public void TestSoftParksParkingWorkCorrectly()
        {
            Car car = new Car("Audi", "8596");

            SoftPark softpark = new SoftPark();

            var expectedCar = "A1";
            var carFromParking = softpark.Parking.FirstOrDefault(x => x.Key == "A1").Key;

            Assert.AreEqual(expectedCar, carFromParking);
        }

        [Test]
        public void TestParkCarMethodWorkCorrectly()
        {
            Car car = new Car("Audi", "8596");

            SoftPark softpark = new SoftPark();

            string message=softpark.ParkCar("A1", car);

            string expectedMessage= $"Car:8596 parked successfully!";

            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void TestParkCarMethodShouldThrowsException()
        {
            Car car = new Car("Audi", "8596");

            SoftPark softpark = new SoftPark();

            //softpark.ParkCar("Volkswagen", car);

            Assert.Throws<ArgumentException>(() => softpark.ParkCar("Volkswagen",car));
        }

        [Test]
        public void TestParkCarMethodShouldThrowArgumentException()
        {
            Car car = new Car("Audi", "8596");

            SoftPark softpark = new SoftPark();
            string message = "";
            softpark.ParkCar("A1", car);

            if(softpark.Parking["A1"] != null)
            {
                message = "Parking spot is already taken!";
            }

            string expectedMessage = "Parking spot is already taken!";

            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void TestParkCarExistCar()
        {
            Car car = new Car("Audi", "8596");

            SoftPark softpark = new SoftPark();

            softpark.ParkCar("A1", car);

            string message = "";

            if(softpark.Parking.Values.Any(x => x?.RegistrationNumber == car.RegistrationNumber))
            {
                message = "Car is already parked!";
            }

            string expectedMessage = "Car is already parked!";

            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void TestRemoveCarMethodWorkCorrectly()
        {
            Car car = new Car("Audi", "8596");

            SoftPark softpark = new SoftPark();

            softpark.ParkCar("A1", car);

            string message= softpark.RemoveCar("A1", car);

            string expectedMessage= "Remove car:8596 successfully!";

            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void TestRemoveCarMethodShouldThrowsException()
        {
            Car car = new Car("Audi", "8596");

            SoftPark softpark = new SoftPark();

            Assert.Throws<ArgumentException>(() => softpark.RemoveCar("Volkswagen", car));
        }

        [Test]
        public void TestRemoveCarMethodShouldThrowsArgumentException()
        {
            Car car = new Car("Audi", "8596");

            SoftPark softpark = new SoftPark();
            
            softpark.ParkCar("A1", car);

            Assert.Throws<ArgumentException>(() => softpark.RemoveCar("A1", null));
        }
    }
}