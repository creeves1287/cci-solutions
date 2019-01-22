using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter
{
    public class Cat : ShelteredAnimal, IShelteredAnimal
    {
        public Cat(int id, string name)
            : base(id, name)
        {

        }
    }
}
