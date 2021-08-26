using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.IO;
using System.Threading;

namespace MathProj
{
    class Calculation
    {
        #region Local variables
        BigInteger x;
        BigInteger One = BigInteger.One;
        BigInteger MinusOne = BigInteger.MinusOne;
        BigInteger Two = BigInteger.Parse("2");
        BigInteger Three = BigInteger.Parse("3");
        BigInteger checkPoint = BigInteger.Parse("100000");
        BigInteger Zero = BigInteger.Zero;
        bool flag = true;

        //Not Working: Using array to store values and skip those values//
        //HashSet<BigInteger> hashSet =new HashSet<BigInteger>();
        //SortedSet<BigInteger> hashSet = new SortedSet<BigInteger>();
        #endregion

        #region Constructor used to initialize seed value
        public Calculation(BigInteger startValue)
        {
            x = startValue;
            this.calculate();
        }
        #endregion

        #region Logic for the problem
        //Calculate method will increment seed number till we find our desired number
        public void calculate()
        {
            try
            {
                BigInteger temp=x;
                Thread a = new Thread(CurrentExecution);
                a.Start();
                do
                {
                    temp = Logic(temp);
                    //checks output form oddeven method is '0'                
                    if (BigInteger.Compare(temp, Zero) == 0)        
                    {
                       //increments seed number by 2
                       temp = x = BigInteger.Add(x, Two);     
                        //while (hashSet.Remove(temp))
                        //{
                        //    //check number present in array and skip
                        //    temp = x = BigInteger.Add(x, Two);      //incrementing with 2 to get next odd number
                        //}

                        //Priniting current number in the console(now moved to new thread)
                        //if (BigInteger.Compare(BigInteger.Remainder(x, checkPoint), 1) == 0)
                        //{
                        //    //Console.Clear();
                        //    Console.WriteLine("Current no: {0}", x);            
                        //}
                    }
                    //checks output form oddeven method is '1'
                    else if (BigInteger.Compare(temp, One) == 0)     
                    {
                        flag = false;
                        Console.WriteLine("The answer is {0}", x);
                        return;
                    }
                    //checks output form oddeven method is '-1'
                    else if (BigInteger.Compare(temp, MinusOne)==0)  
                    {
                        flag = false;
                        Console.WriteLine("some error occured in Logic class");
                        return;
                    }
                } while (true);
            }
            catch (Exception e)
            {
                flag = false;
                Console.WriteLine(e.Message);
            }
        }

        //Core logic is written here
        BigInteger Logic(BigInteger n)
        {
            try
            {
                BigInteger temp = oddEven(n);
                if (BigInteger.Remainder(temp, Two) != 0)
                {
                    //checks current number is same as seed number
                    if (BigInteger.Compare(temp, x) == 0)           
                    {
                        return One;
                    }
                    else
                    {
                        //hashSet.Add(temp);   //stores new number in array
                        return temp;
                    }
                }
                //checks current even number < 2 times the seed number
                else if (BigInteger.Compare(temp, BigInteger.Multiply(Two, x)) < 0)       
                {
                    return Zero;
                }
                else { return temp; }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return MinusOne;
            }
        }

        //Do calculations based on odd/even number 
        BigInteger oddEven(BigInteger n)
        {
            try
            {
                if (BigInteger.Remainder(n, Two) ==0)
                {
                    return BigInteger.Divide(n, Two);             //Line is executed if number is even
                }
                else
                {
                    return BigInteger.Divide(BigInteger.Add(BigInteger.Multiply(Three, n), One), Two);     //line is executed if number is odd
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return MinusOne;
            }
        }
        #endregion

        #region Prints current executed seed number
        void CurrentExecution()
        {
            do
            {
                //if capslocak is turned on, clears screen
                if (Console.CapsLock) 
                { 
                    Console.Clear();
                }
                Console.WriteLine("current no: {0}", x);
            }
            while (flag);
        }
        #endregion
    }
}
