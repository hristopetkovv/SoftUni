namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestPropertyGettersWorkCorrectly()
        {
            Phone phone = new Phone("Samsung", "S8");

            string make = phone.Make;
            string model = phone.Model;
            

            string expectedMake = "Samsung";
            string expectedModel = "S8";

            Assert.AreEqual(expectedMake, make);
            Assert.AreEqual(expectedModel, model);
            
        }

        [Test]
        public void TestMakeSetterThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Phone("", "S8"), "Make setter does not validate the input data.");
        }

        [Test]
        public void TestModelSetterThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Phone("Samsung", ""), "Model setter does not validate the input data.");
        }

        [Test]
        public void TestCorrectCount()
        {
            int expectedCount = 1;

            Phone phone = new Phone("Samsung", "S8");
            phone.AddContact("Pesho", "055555");

            Assert.That(expectedCount, Is.EqualTo(phone.Count));
        }

        [Test]
        public void TestAddMethodShouldThrowsException()
        {
            Phone phone = new Phone("Samsung", "S8");

            phone.AddContact("Pesho", "055555");

            Assert.Throws<InvalidOperationException>(() => phone.AddContact("Pesho", "S8"));
        }

        [Test]
        public void TestCallMethodWorkCorrectly()
        {
            Phone phone = new Phone("Samsung", "S8");

            phone.AddContact("Pesho", "55555");

            string message = phone.Call("Pesho");

            string expectedMessage= $"Calling Pesho - 55555...";

            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        public void TestCallShouldThrowArgumentException()
        {
            Phone phone = new Phone("Samsung", "S8");

            phone.AddContact("Pesho", "555");

            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }

        
    }
}