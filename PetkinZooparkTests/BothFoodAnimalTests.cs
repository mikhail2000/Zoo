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
    public class BothFoodAnimalTests
    {
        [TestMethod()]
        public void Get_Price_of_FeedTest()
        {
            double coef = 0.1;
            double weight = 100;
            double fruitprice = 10;
            double meatprice = 20;
            double percent = 0.60;
            double expected = 160;

            BothFoodAnimal a = new BothFoodAnimal("ежик", coef, "meat", percent);
            Animal.PriceOfFruit = fruitprice;
            Animal.PriceOfMeat = meatprice; 
            double result = a.Get_Price_of_Feed(weight);

            Assert.AreEqual(expected, result);
        }
    }
}