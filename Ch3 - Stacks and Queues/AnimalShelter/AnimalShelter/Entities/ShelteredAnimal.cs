using System;

namespace AnimalShelter
{
    public abstract class ShelteredAnimal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Added { get; set; }
        public ShelteredAnimal(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public bool IsOlderThan(ShelteredAnimal animal)
        {
            return Added < animal.Added;
        }
    }
}