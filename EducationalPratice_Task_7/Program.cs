using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace EducationalPratice_Task_7
{
    /// <summary>
    /// Выписать все булевы функции от 3 аргументов, которые линейны. Выписать их вектора в лексикографическом порядке.
    /// Решение
    ///     Построить Полином Жегалкина
    /// </summary>
    class Program
    {
        static List<string> BooleanFunctions = new List<string>();
        static List<string[]> bufferlist  = new List<string[]>();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите булевую функцию для проверки");
            string boolean = Console.ReadLine();
            string[] buffer = new string[boolean.Length];
            for (var index = 0; index < boolean.Length; index++)
                buffer[index] = boolean[index].ToString();
           
            FindAllBooleanFunction(buffer);
            foreach (var item in bufferlist)
            {
                foreach (var t in item)
                    Console.Write(t);

                Console.WriteLine();
            }
            Console.WriteLine(bufferlist.Count);

            Console.ReadLine();
        }
        
        static void FindAllBooleanFunction(string[] vector_func)
        {

            if (!vector_func.Contains("*"))
            {

            }
            for (int i = vector_func.Length - 1; i >= 0; i--)
            {
                if (vector_func[i] == "*")
                {
                    vector_func[i] = "0";
                    bufferlist.Add(vector_func);
                    vector_func[i] = "1";
                    bufferlist.Add(vector_func);
                } 
            }
        }

        static int Convert(string str)
        {

        }

      
       
    }

    public static class  Polinom
    {
        
    }
}
