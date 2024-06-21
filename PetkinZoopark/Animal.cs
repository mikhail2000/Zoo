using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetkinZoopark
{
    public abstract class Animal
    {
        public string Name { get; set; }

        public double Coef { get; set; }

        public string Food { get; set; }

        public static double PriceOfFruit { get; set; }

        public static double PriceOfMeat { get; set; }


        public static Dictionary<string, Animal> Types_of_Animals;


        protected Animal(string name, double coef, string food)
        {
            Name = name;
            Coef = coef;
            Food = food;
        }

        public abstract double Get_Price_of_Feed(double weight);

    }

    public class MeatAnimal : Animal
    {
        public MeatAnimal(string name, double coef, string food) : base(name, coef, food) { }

        public override double Get_Price_of_Feed(double weight)
        {
            return PriceOfMeat * Coef * weight;
        }

        public override string ToString()
        {
            return Name + " " + Food + " " + Coef;
        }
    }


    public class FruitAnimal : Animal
    {
        public FruitAnimal(string name, double coef, string food) : base(name, coef, food) { }

        public override double Get_Price_of_Feed(double weight)
        {
            return PriceOfFruit * Coef * weight;
        }

        public override string ToString()
        {
            return Name + " " + Food + " " + Coef;
        }
    }


    public class BothFoodAnimal : Animal
    {

        public double Percent { get; set; }

        public BothFoodAnimal(string name, double coef, string food, double percent) : base(name, coef, food)
        {
            Percent = percent;
        }

        public override double Get_Price_of_Feed(double weight)
        {
            return weight * (Percent * PriceOfMeat * Coef + (1 - Percent) * PriceOfFruit * Coef);
        }

        public override string ToString()
        {
            return Name + " " + Food + " " + Coef + " " + Percent;

        }
    }


}
