using System;

namespace calculator
{
    class tasks
    {
        public static double calculator(double a,double b,double swit)
        {
            switch (swit)
            {
                case 1:
                    return aad(a, b);
                case 2:
                    return a - b;
                case 3:
                    return a * b;
                case 4:
                    return a / b;
                case 5:
                    return Math.Pow(a,b);
                case 6:
                    return Math.Sqrt(a);
                default:
                    return 0;
            }
        }
        static double aad(double a, double b)
        {
            return a + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string endprogram="no";
            do
            {
                int a=0, b=0;
                uint choice =0;
                bool t = true;
                do
                {
                    Console.WriteLine("Enter two numbers");
                    try
                    {
                        a = int.Parse(Console.ReadLine());
                        b = int.Parse(Console.ReadLine());
                        t = false;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Enter the numbers!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                while (t);
                t = true;
                do
                {
                    Console.WriteLine("1 - addition | 2 - subtraction | 3 - multiplication | 4 - division | 5 - power | 6 - root ");
                    try
                    {
                        choice = uint.Parse(Console.ReadLine());
                        if (choice <7)
                        {
                            t = false;
                            break;
                        }
                        Console.WriteLine("Give one of the 1-6 Numbers");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Give one of the 1-6 Numbers");
                    }
                }
                while (t);
                Console.WriteLine("Score: "+tasks.calculator(a, b, choice)+"\n");
                Console.WriteLine("Type yes to exit the program");
                endprogram =  Console.ReadLine();
                endprogram = endprogram.ToLower();
            }
            while (endprogram !="yes");
        }
    }
}
