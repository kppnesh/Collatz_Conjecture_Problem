using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.IO;

namespace MathProj
{
    class Calculation
    {
        BigInteger x;
        public Calculation(BigInteger startValue)
        {
            x=startValue;
            this.calculate();
        }

        public void calculate()
        {
            try
            {
                BigInteger temp=x;
                do
                {
                    temp=Logic(temp);
                    if (BigInteger.Compare(temp, BigInteger.Zero) == 0)
                    {
                       temp= x = BigInteger.Add(x, BigInteger.Parse("2"));
                        if (BigInteger.Compare(BigInteger.Remainder(x, BigInteger.Parse("100000")), 1) == 0)
                        {
                            //Console.Clear();
                            Console.WriteLine("Current no: {0}", x);
                        }
                    }
                    else if (BigInteger.Compare(temp, BigInteger.One) == 0)
                    {
                        Console.WriteLine("The answer is {0}", x);
                        return;
                    }
                    else if (BigInteger.Compare(temp, BigInteger.MinusOne)==0)
                    {
                        Console.WriteLine("some error occured in Logic class");
                        return;
                    }
                } while (BigInteger.Compare(temp,BigInteger.Zero)!=0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        BigInteger Logic(BigInteger n)
        {
            try
            {
                BigInteger temp = oddEven(n);
                if (BigInteger.Compare(temp, x) == 0)
                {
                    return BigInteger.One;
                }
                else if (BigInteger.Compare(temp, BigInteger.Multiply(BigInteger.Parse("2"), x)) < 0)
                {
                    return BigInteger.Zero;
                }
                else { return temp; }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BigInteger.MinusOne;
            }
        }
        BigInteger oddEven(BigInteger n)
        {
            try
            {
                if (BigInteger.Remainder(n, BigInteger.Parse("2")) ==0)
                {
                    return BigInteger.Divide(n, BigInteger.Parse("2"));
                }
                else
                {
                    return BigInteger.Divide(BigInteger.Add(BigInteger.Multiply(BigInteger.Parse("3"), n), BigInteger.One), BigInteger.Parse("2"));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }

    }
}
