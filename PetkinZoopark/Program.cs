
using PetkinZoopark;
using System.Globalization;
using System.Net.Mail;
using static System.Runtime.InteropServices.JavaScript.JSType;



string pricespath = "C:\\Users\\Михаил\\source\\repos\\PetkinZoopark\\PetkinZoopark\\Data\\prices.txt";
string animalspath = "C:\\Users\\Михаил\\source\\repos\\PetkinZoopark\\PetkinZoopark\\Data\\animals.csv";
string zoopath = "C:\\Users\\Михаил\\source\\repos\\PetkinZoopark\\PetkinZoopark\\Data\\zoo.csv";

ReadPrices(new ReadPricesFromTxt(pricespath));
ReadAnimals(new ReadAnimalsFromCsv(animalspath));
ReadZooAnimals(new ReadZooFromCsv(zoopath));

double Consumption = GetDailyConsumption();

WriteResult(new WriteToConsole(Consumption));



void WriteResult(IWriter writer)
{
    writer.Write();
}

double GetDailyConsumption()
{
    double k = 0;
    foreach (var s in ZooAnimal.ZooAnimalList)
    {
        k+=s.TypeofAnimal.Get_Price_of_Feed(s.Weight);
    }
    return k;
}

void ReadPrices(IReader<double[]> reader)
{
    double[] prices = new double[2];
    Array.Copy(reader.GetValue(), prices,2);
    Animal.PriceOfMeat = prices[0]; 
    Animal.PriceOfFruit = prices[1];
}

void ReadAnimals(IReader<Dictionary<string, Animal>> reader)
{
    Animal.Types_of_Animals = new Dictionary<string, Animal>(reader.GetValue());
}


void ReadZooAnimals(IReader<List<ZooAnimal>> reader)
{
    ZooAnimal.ZooAnimalList= new List<ZooAnimal>(reader.GetValue());
}
