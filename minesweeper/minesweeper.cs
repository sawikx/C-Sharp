using System;

namespace minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Random los = new Random();
            int[,] tab = new int[12, 12];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    tab[i, j] = 0;
                }
            }
            for (int bi = 0; bi < 10; bi++)//number of bombs
            {
                int x = los.Next(1, 11), y = los.Next(1, 11);
                if (tab[x, y] != 1)
                {
                    tab[x, y] = -1;
                }
                else
                {
                    bi -= 1;
                }
            }
            int manybomb;//how many bombs around
            for (int i=1; i<11; i++)
            {
                for (int j=1;j<11;j++)
                {
                    if (tab[i,j]!=-1)
                    {
                        manybomb = 0;
                        for (int ii = -1; ii < 2; ii++)
                        {
                            for (int jj = -1; jj < 2; jj++)
                            {
                                if (ii != 0 || jj != 0)
                                {
                                    if (tab[i + ii, j + jj] == -1)
                                    {
                                        manybomb += 1;
                                    }
                                }
                            }
                        }
                        tab[i, j] = manybomb;
                    }
                }
            }
            uint a, b;
            string[,] choice = new string[12, 12];
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    choice[i, j] = "*";
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
            int end = 0;
            do
            {
                end = 0;
                for (int i = 1; i < 11; i++)
                {
                    for (int j = 1; j < 11; j++)
                    {
                        if (choice[i, j] == tab[i, j].ToString())
                        {
                            end += 1;
                        }
                        else
                        {
                            end -= 1;
                        }
                    }
                }
                Console.WriteLine("Enter X");
                if (uint.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Enter Y");
                    if (uint.TryParse(Console.ReadLine(), out b))
                    {
                        a += 1;
                        b = 12 - b;
                        if (a < 12 && b < 12)
                        {
                            a -= 1;
                            b -= 1;
                            if (tab[b, a] == -1)
                            {
                                choice[b, a] = "X";
                                Console.WriteLine("Bomb!");
                                for (int i = 1; i < 11; i++)
                                {
                                    for (int j = 1; j < 11; j++)
                                    {
                                        Console.Write(choice[i, j] + " ");
                                    }
                                    Console.WriteLine("");
                                }
                                break;
                            }
                            else
                            {
                                choice[b, a] = tab[b,a].ToString();
                                Console.WriteLine("Good choice ");
                                for (int i = 1; i < 11; i++)
                                {
                                    for (int j = 1; j < 11; j++)
                                    {
                                        Console.Write(choice[i, j] + " ");
                                    }
                                    Console.WriteLine("");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Enter a number in the range 1-10");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter a number!");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a number!");
                }
            }
            while (end != 90);
        }
    }
}
