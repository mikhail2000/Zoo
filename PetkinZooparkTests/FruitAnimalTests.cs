using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetkinZoopark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetkinZoopark.Tests
{
    [TestClass()]
    public class FruitAnimalTests
    {
        [TestMethod()]
        public void GetPrice_01and100and10_100returned()
        {
            double coef = 0.1;
            double weight = 100;
            double fruitprice = 10;
            double expected = 100;

            FruitAnimal a = new FruitAnimal("корова", coef, "fruit");
            Animal.PriceOfFruit = fruitprice;
            double result = a.Get_Price_of_Feed(weight);

            Assert.AreEqual(expected,result);
        }
    }
}