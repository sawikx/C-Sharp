using System;

namespace classfunctions
{
    class tasks
    {
        private double x;
        private double y;

        public tasks(double x,double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        public double calculator(double swit)
        {
            switch (swit)
            {
                case 1:
                    return aad();
                case 2:
                    return x - y;
                case 3:
                    return x * y;
                case 4:
                    return x / y;
                case 5:
                    return Math.Pow(x,y);
                case 6:
                    return Math.Sqrt(x);
                default:
                    return 0;
            }
        }
        private double aad()
        {
            return x+y;
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
                tasks ts = new tasks(a, b);
                do
                {
                    Console.WriteLine("Enter two numbers");
                    try
                    {
                        a = int.Parse(Console.ReadLine());
                        b = int.Parse(Console.ReadLine());
                        t = false;
                        ts.X = a;
                        ts.Y = b;

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
                Console.WriteLine("Score: "+ts.calculator(choice)+"\n");
                Console.WriteLine("Type yes to exit the program");
                endprogram =  Console.ReadLine();
                endprogram = endprogram.ToLower();
            }
            while (endprogram !="yes");
        }
    }
}
