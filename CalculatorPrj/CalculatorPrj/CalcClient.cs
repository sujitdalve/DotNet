using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorPrj
{
    internal class CalcClient
    {
        public static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.add(12, 19));
            Console.WriteLine(calculator.multiply(12, 23));

        }
    }
}
