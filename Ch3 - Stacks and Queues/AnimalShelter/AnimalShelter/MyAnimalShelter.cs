using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter
{
    public class MyAnimalShelter : IAnimalShelter
    {
        private LinkedList<ShelteredAnimal> _dogs = new LinkedList<ShelteredAnimal>();
        private LinkedList<ShelteredAnimal> _cats = new LinkedList<ShelteredAnimal>();
        private LinkedList<ShelteredAnimal> _animals = new LinkedList<ShelteredAnimal>();

        public void Enqueue<TAnimal>(TAnimal animal) where TAnimal: ShelteredAnimal
        {
            AddToQueue<ShelteredAnimal>(_animals, animal);
            AddToSpecificAnimalList(animal);
        }

        public ShelteredAnimal DequeueAny()
        {
            ShelteredAnimal animal = DequeueAnimal(_animals);
            _dogs.Remove(animal);
            _cats.Remove(animal);
            return animal;
        }

        public ShelteredAnimal DequeueDog()
        {
            ShelteredAnimal animal = DequeueAnimal(_dogs);
            _animals.Remove(animal);
            return animal;
        }

        public ShelteredAnimal DequeueCat()
        {
            ShelteredAnimal animal = DequeueAnimal(_cats);
            _animals.Remove(animal);
            return animal;
        }

        private ShelteredAnimal DequeueAnimal(LinkedList<ShelteredAnimal> animals)
        {
            ValidateList<ShelteredAnimal>(animals);
            ShelteredAnimal animal = animals.Last.Value;
            animals.RemoveLast();
            return animal;
        }

        private void AddToSpecificAnimalList<TAnimal>(TAnimal animal) where TAnimal : ShelteredAnimal
        {
            if (IsCat(animal))
            {
                AddToQueue<ShelteredAnimal>(_cats, animal);
            }
            else if (IsDog(animal))
            {
                AddToQueue<ShelteredAnimal>(_dogs, animal);
            }
        }

        private bool IsDog<TAnimal>(TAnimal animal) where TAnimal : ShelteredAnimal
        {
            Type animalType = typeof(TAnimal);
            return (animalType == typeof(Dog));
        }

        private bool IsCat<TAnimal>(TAnimal animal) where TAnimal : ShelteredAnimal
        {
            Type animalType = typeof(TAnimal);
            return (animalType == typeof(Cat));
        }

        private void AddToQueue<T>(LinkedList<T> list, T item)
        {
            list.AddFirst(item);
        }

        private void ValidateList<T>(LinkedList<T> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }
        }
    }
}
