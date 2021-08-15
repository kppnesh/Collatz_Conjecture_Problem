using System;
using System.Numerics;

namespace MathProj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Calculation cal1= new Calculation(BigInteger.Parse(Console.ReadLine()));
            //cal1.calculate(1);
        }
    }
}
