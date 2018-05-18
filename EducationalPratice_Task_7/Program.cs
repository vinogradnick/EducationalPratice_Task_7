using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducationalPratice_Task_7
{
    /// <summary>
    /// Выписать все булевы функции от 3 аргументов, которые линейны. Выписать их вектора в лексикографическом порядке.
    /// Решение
    ///     Построить Полином Жегалкина
    /// </summary>
    class Program
    {
        
        static void Main(string[] args)
        {
           string[] boolStrings= new string[8];
            
            int counter = 0;
            
                for (int x1 = 0; x1 < 2; x1++)
                {
                    for (int x2 = 0; x2 < 2; x2++)
                    {
                        for (int x3 = 0; x3 < 2; x3++)
                        {
                            boolStrings[counter++] = $"{x1} {x2} {x3}";
                        }
                    }
                }

            foreach (string text in boolStrings)
            {
                Console.WriteLine(text);
            }
            Console.ReadKey();
        }

        static int f(int x1, int x2, int x3)
        {
            int f = 0;
            Console.Write($"F({x1},{x2},{x3}");
            f=1+x1+x3
            
        }
    }
}
