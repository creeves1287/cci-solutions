using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter
{
    public class Dog : ShelteredAnimal, IShelteredAnimal
    {
        public Dog(int id, string name)
            :base(id, name)
        {

        }
    }
}
