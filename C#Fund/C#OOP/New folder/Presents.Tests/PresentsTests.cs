namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void SetUp()
        {
            this.bag = new Bag();
        }

        [Test]
        public void TestIfPresentCtorWorksCorrectly()
        {
            string expectedName = "Stick";
            double expMagic = 100;

            Present present = new Present(expectedName, expMagic);

            Assert.AreEqual(expectedName, present.Name);
            Assert.AreEqual(expMagic, present.Magic);
        }

        [Test]
        public void TestIfBagCtorWorkCorrectly()
        {
            Bag bag = new Bag();

            Assert.IsNotNull(bag.GetPresents());
        }

        [Test]
        public void CreateShouldThrowExceptionWithLikeNullPresent()
        {
            Present present = null;

            Assert.That(() =>
            {
                this.bag.Create(present);
            }, Throws.ArgumentNullException);  
        }

        [Test]
        public void CreateShouldThrowExceptionWithLikeExistingPresent()
        {
            Present present = new Present("Stick", 100);
            bag.Create(present);

            Assert.That(() =>
            {
                bag.Create(present);
            }, Throws.InvalidOperationException.With.Message.EqualTo("This present already exists!"));
        }

        [Test]
        public void CreateShouldAddThePresent()
        {
            string name = "Stick";
            int magic = 100;

            Present p1 = new Present(name, magic);
            Present p2 = new Present(name, magic);

            bag.Create(p1);
            bag.Create(p2);

            IReadOnlyCollection<Present> exp = new List<Present>()
            { 
                p1, p2
            };

            IReadOnlyCollection<Present> act = bag.GetPresents();

            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        public void RemoveShouldRemovePresentCorrectly()
        {
            string name = "Stick";
            int magic = 100;

            Present p1 = new Present(name, magic);
            Present p2 = new Present(name, magic);

            bag.Create(p1);
            bag.Create(p2);

            bool res = bag.Remove(p1);

            IReadOnlyCollection<Present> exp = new List<Present>()
            {
                p2
            };

            IReadOnlyCollection<Present> act = bag.GetPresents();

            Assert.IsTrue(res);
            CollectionAssert.AreEqual(exp, act);
        }

        [Test]
        public void TryRemovingNonExistingPresent()
        {
            string name = "Stick";
            int magic = 100;

            Present p1 = new Present(name, magic);

            bool res = bag.Remove(p1);

            Assert.IsFalse(res);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldWorkCorrectly()
        {
            string name = "Stick";
            int magic = 100;

            Present p1 = new Present(name, magic);
            Present p2 = new Present(name, 50);
            Present exp = new Present(name, 20);

            bag.Create(p1);
            bag.Create(p2);
            bag.Create(exp);

            Present act = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldThrowException()
        {
            Assert.That(() =>
            {
                bag.GetPresentWithLeastMagic();
            }, Throws.InvalidOperationException);
        }

        [Test]
        public void GetPresentShouldReturnCorrectPresent()
        {
            string name = "Stick";
            int magic = 100;

            Present exp = new Present(name, magic);

            Present p1 = new Present("Another", 50);

            bag.Create(exp);
            bag.Create(p1);

            Present act = bag.GetPresent(name);

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void GetPresentShouldReturnFirstPresentWhenDublicate()
        {
            string name = "Stick";
            int magic = 100;

            Present exp = new Present(name, magic);

            Present p1 = new Present(name, magic);

            bag.Create(exp);
            bag.Create(p1);

            Present act = bag.GetPresent(name);

            Assert.AreEqual(exp, act);
        }

        [Test]
        public void GetPresentShouldReturnNullPresentWhenNameNotExist()
        {
            string name = "Stick";
            int magic = 100;

            Present exp = new Present(name, magic);

            Present p1 = new Present(name, magic);

            bag.Create(exp);
            bag.Create(p1);

            string invalidName = "None Existing";
            Present act = bag.GetPresent(invalidName);

            Assert.IsNull(act);
        }
    }
}
