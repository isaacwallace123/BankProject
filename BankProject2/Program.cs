using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Savings test = new Savings(100.0, 20.0);

            Console.WriteLine(test);
        }
    }
}
