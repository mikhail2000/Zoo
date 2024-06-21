using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetkinZoopark
{
    public class ZooAnimal
    {
        public string Name { get; set; }

        public readonly Animal TypeofAnimal;

        public double Weight { get; set; }

        public ZooAnimal(string name, double weight, Animal typeofAnimal)
        {
                Name = name;
                TypeofAnimal = typeofAnimal;    
                Weight = weight;    
        }

        public static List<ZooAnimal> ZooAnimalList;

        public override string ToString()
        {
            return Name+" "+ TypeofAnimal.Name + " "+ Weight;   
        }
    }
}
