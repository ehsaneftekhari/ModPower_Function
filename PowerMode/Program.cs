using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PowerMode
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("a ^ b mod c       and x for base limit\nEnter a:");
                    BigInteger a = BigInteger.Parse(Console.ReadLine());
                    Console.Write("b: ");
                    BigInteger b = BigInteger.Parse(Console.ReadLine());
                    Console.Write("c: ");
                    BigInteger c = BigInteger.Parse(Console.ReadLine());
                    Console.Write("x: ");
                    BigInteger x = BigInteger.Parse(Console.ReadLine());
                    if (x < c)
                        Console.WriteLine("x for base limit, can not be lesser than c");
                    else
                    {
                        PowerModeSolver t = new PowerModeSolver(a, b, c);

                        BigInteger ans = t.solve(x);

                        if (t.solvstrinng.Length > 1000)
                            Console.Write($"Done.\nAnswer is = {ans}\n\nPrinting solution:\n");
                        else
                            Console.Write("\n\nPrinting solution:\n");

                        string solvstrinng = t.solvstrinng;
                        for (int i = 0; i < solvstrinng.Length - 1; i++)
                        {
                            if (solvstrinng[i] == '(' || solvstrinng[i] == ')' || solvstrinng[i] == '^')
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            else
                            {
                                if (solvstrinng[i] == '×')
                                {
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                }
                                else
                                {
                                    if (solvstrinng[i] == 'm' || solvstrinng[i] == 'o' || solvstrinng[i] == 'd')
                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                }
                            }
                            Console.Write(solvstrinng[i]);
                            Console.ResetColor();
                        }
                        Console.Write(" = " + ans + "\n");
                        try
                        {
                            int po = int.Parse(b.ToString());
                            Console.Write("\n\nTasting...\nplease waite");
                            BigInteger test = BigInteger.Pow(a, po) % c;
                            Console.Write("\nAnswer is ");

                            if (test == ans)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Right");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Wrong");
                                Console.ResetColor();
                                Console.WriteLine("Right answer is = " + test);
                            }
                            Console.ResetColor();
                        }
                        catch (System.OverflowException OfEx)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\n\n" + OfEx.GetType().Name);
                            Console.ResetColor();
                            Console.Write(":");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(OfEx.Message);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("\nIt means that we can not test the answer with pow () function \n" +
                                $"It's because the power parameter in pow() function is an Int32, and the b: {b} is too large for this type\n" +
                                "but the answer is probably Right");
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("\n\n" + ex.GetType().Name);
                            Console.ResetColor();
                            Console.Write(":");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n\n" + ex.GetType().Name);
                    Console.ResetColor();
                    Console.Write(":");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                }
                Console.ResetColor();
                Console.Write("\nPress a key...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
