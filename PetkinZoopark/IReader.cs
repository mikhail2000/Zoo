using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace PetkinZoopark
{
    public interface IReader<T>
    {
        public T GetValue();
    }

    public class ReadPricesFromTxt : IReader<double[]>
    {
        public string Path { get; set; }

        public ReadPricesFromTxt(string path)
        {
            Path = path;
        }
       
        public double[] GetValue()
        {
            double[] prices = new double[2];
            using (StreamReader reader = new StreamReader(Path))
            {
                string line = reader.ReadLine();
                prices[0] =double.Parse(line.Substring(line.IndexOf('=') + 1), CultureInfo.CreateSpecificCulture("en"));
                line = reader.ReadLine();
                prices[1] = double.Parse(line.Substring(line.IndexOf('=') + 1), CultureInfo.CreateSpecificCulture("en"));
                return prices;  
            }
        }
    }

    public class ReadAnimalsFromCsv : IReader<Dictionary<string,Animal>>
    {
        private Dictionary<string, Animal> _p;
        public string Path { get; set; }

        public ReadAnimalsFromCsv(string path)
        {
            Path = path;
        }

        public Dictionary<string, Animal> GetValue()
        {
            _p= new Dictionary<string, Animal>();
            using (StreamReader reader = new StreamReader(Path))
            {
                string name;
                double coef;
                string food;
                double percent;
                string? line;
                while ((line = reader.ReadLine()) != null)
                {

                    string[] n = line.Split(',');
                    switch (n[2])
                    {
                        case "meat":
                            name = n[0];
                            coef = double.Parse(n[1], CultureInfo.CreateSpecificCulture("en"));
                            food = n[2];
                            _p.Add(name, new MeatAnimal(name, coef, food));
                            break;
                        case "fruit":
                            name = n[0];
                            coef = double.Parse(n[1], CultureInfo.CreateSpecificCulture("en"));
                            food = n[2];
                            _p.Add(name, new FruitAnimal(name, coef, food));
                            break;
                        case "both":
                            name = n[0];
                            coef = double.Parse(n[1], CultureInfo.CreateSpecificCulture("en"));
                            food = n[2];
                            percent = double.Parse(n[3].Remove(n[3].Length - 1), CultureInfo.CreateSpecificCulture("en"));
                            _p.Add(name, new BothFoodAnimal(name, coef, food, percent * 0.01));
                            break;
                    }

                }
            }
            return _p;
        }
    }

    public class ReadZooFromCsv : IReader<List<ZooAnimal>>
    {
        private List<ZooAnimal> _p;
        public string Path { get; set; }

        public ReadZooFromCsv(string path)
        {
            Path = path;
        }
        public List<ZooAnimal> GetValue()
        {
            _p=new List<ZooAnimal>();
            using (StreamReader reader = new StreamReader(Path))
            {
                string name;
                string typeofanimal;
                double weight;
                string? line;
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] n = line.Split(',');
                    name = n[1];
                    Animal a = Animal.Types_of_Animals[n[0]];
                    weight = double.Parse(n[2], CultureInfo.CreateSpecificCulture("en"));
                    _p.Add(new ZooAnimal(name, weight, a));
                }
            }
            return _p;
        }
    }
}
