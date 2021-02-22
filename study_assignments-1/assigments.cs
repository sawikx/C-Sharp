using System;
using System.IO;
namespace study_assignments
{
    class Program
    {
        static int Ilespace(string a)
        {
            int l = 0;
            char sp = ' ';
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == sp)
                {
                    l += 1;
                }
            }
            return l;
        }
        static string Backwards(string a)
        {
            string b = "";
            for (int i=0;i<a.Length;i++)
            {
                b += a[a.Length-1-i];
            }
            return b;
        }
        static int meto(string a)
        {
            int b = int.Parse(a);
            for (int i=0;i<Math.Sqrt(b); i++)
            {
                if (b == Math.Pow(3, i)) 
                {
                    return b;
                }
               
            }
            return 0;
        }
        static string Pali(string a)
        {
            a = a.ToLower();
            for (int i = 0; i < a.Length / 2; i++)
            {
                if (a[i] != a[a.Length - i - 1] )
                {
                    return "isn't";
                }

            }
            return "is";
        }
        static void Main(string[] args)
        {
            int wyb = 0;
            do
            {
                Console.WriteLine("1 - Text methods \n2 - Data from the file \n3 - The End ");

                if (int.TryParse(Console.ReadLine(), out wyb))
                {
                    if (wyb == 1 || wyb == 2 || wyb == 3)
                    {

                        switch (wyb)

                        {
                            case 1:
                                uint n = 1;
                                bool t = true;
                                do {
                                    try
                                    {
                                        Console.WriteLine("Enter n texts you want to write ");
                                        n = uint.Parse(Console.ReadLine());
                                        t = false;
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine("They must be numbers, {0}", e);
                                    }
                                    catch (OverflowException e)
                                    {
                                        Console.WriteLine("Number must be in the range 0 - 4 294 967 295 , {0}", e);
                                    }
                                }
                                while (t);
                                string[] tab = new string[n];
                                FileStream plik = new FileStream("text.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                                try
                                {
                                    StreamWriter zapis = new StreamWriter(plik);

                                    for (int i = 0; i < n; i++)
                                    {
                                        tab[i] = Console.ReadLine();
                                        Console.WriteLine("The text consists of {1} letters and {2} palindrome, Ilespace = {0}, Backwards = {3} ", Ilespace(tab[i]), tab[i].Length, Pali(tab[i]),Backwards(tab[i]));
                                        zapis.WriteLine("Text number {0} this: {1}.", i + 1, tab[i]);
                                        zapis.WriteLine("The above text consists of {0} words",tab[i].Length);
                                    }
                                    zapis.Close();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e);
                                }
                                plik.Close();

                                break;
                            case 2:
                                using (StreamReader odczyt1 = new StreamReader(@"numbers.txt"))
                                {
                                    int sp = 1, i = 1;
                                    do
                                    {
                                        string a = odczyt1.ReadLine();
                                        if (a == null)
                                        {
                                            break;
                                        }
                                        if (meto(a) !=0) {
                                            Console.WriteLine("{0} this number is a power of 3", a);
                                        }
                                        i += 1;

                                    }
                                    while (sp != 0);
                                }
                                break;
                            case 3:
                                Console.WriteLine("Goodbye");
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Enter the correct number ");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a number!");
                }
            }
            while (wyb != 3);
        }
    }
}
