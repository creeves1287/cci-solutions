namespace AnimalShelter
{
    public interface IAnimalShelter
    {
        void Enqueue<TAnimal>(TAnimal animal) where TAnimal : ShelteredAnimal;
        ShelteredAnimal DequeueAny();
        ShelteredAnimal DequeueDog();
        ShelteredAnimal DequeueCat();
    }
}