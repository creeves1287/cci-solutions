using System;
using AnimalShelter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnimalShelterTests
{
    [TestClass]
    public class AnimalShelterTests
    {
        [TestMethod]
        public void MyAnimalShelterTests()
        {
            IAnimalShelter animalShelter = new MyAnimalShelter();
            RunTests(animalShelter);
        }

        [TestMethod]
        public void TextbookAnimalShelterTests()
        {
            IAnimalShelter animalShelter = new TextbookAnimalShelter();
            RunTests(animalShelter);
        }

        private void RunTests(IAnimalShelter animalShelter)
        {
            EnqueueTest(animalShelter);
            DequeueTest(animalShelter);
        }

        private void DequeueTest(IAnimalShelter animalShelter)
        {
            ShelteredAnimal animal = animalShelter.DequeueAny();
            Dog dog = (Dog)animalShelter.DequeueDog();
            Cat cat = (Cat)animalShelter.DequeueCat();

            Assert.AreEqual("Pip", animal.Name);
            Assert.AreEqual("Beep", cat.Name);
            Assert.AreEqual("Rex", dog.Name);
        }

        private void EnqueueTest(IAnimalShelter animalShelter)
        {
            Dog dog1 = new Dog(1, "Pip");
            Cat cat1 = new Cat(2, "Beep");
            Dog dog2 = new Dog(3, "Rex");

            animalShelter.Enqueue(dog1);
            animalShelter.Enqueue(cat1);
            animalShelter.Enqueue(dog2);
        }
    }
}
