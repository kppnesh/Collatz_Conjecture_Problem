using System;
using System.Numerics;

namespace MathProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string input;
            //accepts only positive odd numbers
            do
            {
                Console.WriteLine("Please enter a value to start(Positive odd numbers only):");       
                input = Console.ReadLine();
            } while (BigInteger.Remainder(BigInteger.Parse(input), BigInteger.Parse("2")) == 0 || BigInteger.Parse(input)<BigInteger.Zero);
            Calculation cal1= new Calculation(BigInteger.Parse(input));
        }
    }
}
