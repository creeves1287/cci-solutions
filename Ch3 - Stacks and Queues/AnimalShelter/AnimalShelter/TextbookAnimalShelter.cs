using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter
{
    public class TextbookAnimalShelter : IAnimalShelter
    {
        LinkedList<Dog> _dogs = new LinkedList<Dog>();
        LinkedList<Cat> _cats = new LinkedList<Cat>();

        public void Enqueue(ShelteredAnimal animal)
        {
            animal.Added = DateTime.Now;
            Type type = animal.GetType();
            if (type == typeof(Dog))
            {
                _dogs.AddLast((Dog)animal);
            }

            if (type == typeof(Cat))
            {
                _cats.AddLast((Cat)animal);
            }
        }

        public ShelteredAnimal DequeueAny()
        {
            if (_dogs.Count == 0)
            {
                return DequeueCat();
            }

            if (_cats.Count == 0)
            {
                return DequeueDog();
            }

            ShelteredAnimal dog = _dogs.First.Value;
            ShelteredAnimal cat = _cats.First.Value;

            if (dog.IsOlderThan(cat))
            {
                return DequeueDog();
            }

            return DequeueCat();
        }

        public Cat DequeueCat()
        {
            Cat cat = _cats.First.Value;
            _cats.RemoveFirst();
            return cat;
        }

        public Dog DequeueDog()
        {
            Dog dog = _dogs.First.Value;
            _dogs.RemoveFirst();
            return dog;
        }
    }
}
