using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetkinZoopark
{
    public interface IWriter
    {
        public void Write();
    }

    public class WriteToConsole : IWriter
    {
        private double _result { get; set; }
        public WriteToConsole(double result)
        {
                _result = result;
        }
        public void Write()
        {
            Console.WriteLine(string.Format("{0:f}", _result));
        }
    }
}
