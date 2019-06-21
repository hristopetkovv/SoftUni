using DemoDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            //this.database = new Database(1, 2, 3, 4, 5);
            this.database = new Database(new List<int>() { 1, 2, 3, 4, 5, 6});
        }

        [Test]
        public void AddMethodShouldThrowExceptionWithInvalidParameter()
        {
            for (int i = 0; i < 9; i++)
            {
                this.database.Add(45);
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(458));
        }

        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            for (int i = 0; i < 5; i++)
            {
                this.database.Add(45);
            }

            Assert.That(11, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWithEmptyDatabase()
        {
            for (int i = 0; i < 6; i++)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemoveOneElement()
        {
            this.database.Remove();

            Assert.That(5, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            this.database = new Database(1, 2, 3, 5);

            Assert.That(4, Is.EqualTo(this.database.DatabaseElements.Length));
        }

        [Test]
        [TestCase()]
        [TestCase(1,2,3,4,5,6,7,8,0,1,2,3,4,5,6,7,8,9)]
        public void ConstructorShouldThrowException(params int[] collection)
        {
            Assert.Throws<InvalidOperationException>(() => this.database = new Database(collection));
        }

        [Test]      
        public void PropertyDatabaseElementsShouldSetCorrectly()
        {
            var collection = new List<int>() { 1, 2, 3, 4, 5, 6 };

            CollectionAssert.AreEqual(collection, this.database.DatabaseElements);
        }

        [Test]      
        public void PropertyDatabaseElementsShouldGetCorrectly()
        {
            int expectedCount = 6;

            Assert.That(expectedCount, Is.EqualTo(this.database.DatabaseElements.Length));
        }



    }
}