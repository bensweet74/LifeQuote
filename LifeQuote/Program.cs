using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeQuote
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your postcode:");
            var postcode = Console.ReadLine();

            var calculator = new Calculator();
            var quote = calculator.GetQuote(
                new DateTime(1980, 12, 18),
                Calculator.Gender.Male,
                postcode,
                false,
                5,
                true);

            Console.WriteLine("Your premium is £{0}", quote.ToString());
            Console.ReadLine();

        }
    }
}
