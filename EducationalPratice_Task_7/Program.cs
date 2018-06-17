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
        /// <summary>
        /// Список булевых функций
        /// </summary>
        static List<string[]> BooleanFunctions = new List<string[]>();
       
        /// <summary>
        /// Список линейных булевых функций
        /// </summary>
        static List<bool[]> LinearFunc = new List<bool[]>();

        static void Main(string[] args)
        {
            Console.WriteLine("Введите булевую функцию для проверки");

            string vector_func = Console.ReadLine();//Ввод булевой функции

            string[] buffer = new string[vector_func.Length];//Вектор булевой функции

            buffer = Parse(vector_func);

            for (int x0 = 0; x0 < 2; x0++)
                for (int x1 = 0; x1 <2; x1++)
                    for (int x2 = 0; x2 < 2; x2++)
                        for (int x3 = 0; x3 < 2; x3++)
                            for (int x4 = 0; x4 < 2; x4++)
                                for (int x5 = 0; x5 < 2; x5++)
                                    for (int x6 = 0; x6 < 2; x6++)
                                        for (int x7 = 0; x7 < 2; x7++)
                                            BooleanFunctions.Add(Parse($"{x0}{x1}{x2}{x3}{x4}{x5}{x6}{x7}"));
            
            Console.WriteLine("Булевые функции");
            foreach (var item in BooleanFunctions)
            {
                PolinomDjegalkin(Parse(item));
            }
            foreach (var item in LinearFunc)
            {
                foreach (var x in item)
                {
                    if(x == true)
                    {
                        Console.Write("1");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        static bool[] Parse(string[] vector)
        {
            bool[] temp = new bool[vector.Length];
            for (int i = 0; i < vector.Length; i++)
            {
                temp[i] = vector[i] == "1";
            }
            return temp;
        }
        /// <summary>
        /// Вычисление полинома жегалкина с помощью метода неопределенных коэффицентов
        /// </summary>
        /// <param name="vector_func">булевая функция</param>
        static void PolinomDjegalkin(bool[] vector_func) 
        {
            bool[] linear = new bool[vector_func.Length];//Коэфиценты
            linear[0] = vector_func[0];// Присвоение c0
            linear[1] = linear[0] ^ vector_func[1];// c1
            linear[2] = linear[0] ^ vector_func[2];//c2
            linear[3] = linear[0] ^ vector_func[3] ^ linear[1] ^ linear[2];//c3
            linear[4] = linear[0] ^ vector_func[4];//c4
            linear[5] = linear[0] ^ vector_func[5] ^ linear[1] ^ linear[4];//c5
            linear[6] = linear[0] ^ vector_func[6] ^ linear[4] ^ linear[2];//c6
            linear[7] = linear[0] ^ vector_func[7] ^ linear[1] ^ linear[2] ^ linear[4] ^ linear[3] ^ linear[5] ^ linear[6];//c7
            if (linear[3] || linear[5] || linear[6] || linear[7])//Проверка полинома
            {
                return;
            }
            else
            {
               
                LinearFunc.Add(vector_func);//Добавляем булевую функции в список
            }
        }

        /// <summary>
        /// Поиск функций
        /// </summary>
        /// <param name="vector_func"></param>
        static void FindAllFunc(string[] vector_func,string vector)
        {
            int counter = vector.Length;
            string vc_1 = vector;
            string vc_2 = vector;
            if (counter == vector_func.Length)
            {
                return;
            }
            else
            {
                for (int i = vector.Length; i < vector_func.Length; i++)
                {
                    string foo = vector_func[i];
                    if (vector.Length == vector_func.Length)
                    {
                        break;
                    }
                    counter++;
                    vc_1 += foo;
                    vc_2 += foo;
                    if (foo == "*")
                    {
                        vc_1 = vc_1.Replace('*', '0');
                        vc_2 = vc_2.Replace('*', '1');
                        FindAllFunc(vector_func, vc_1);
                        FindAllFunc(vector_func, vc_2); 
                    }
                }
                Add(vc_1);
                Add(vc_2);
            }        
        }
        static void Add(string vector)
        {
            string[] res = Parse(vector);
            if(Check(res))
            BooleanFunctions.Add(res);
            
        }
        /// <summary>
        /// Перевод вектора
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        static string[] Parse(string vector)
        {
            string[] res = new string[vector.Length];
            for (var index = 0; index <vector.Length; index++)
                res[index] = vector[index].ToString();
            return res;
        }
        static string UnParse(string[] vector)
        {
            string res = "";
            foreach (var item in vector)
            {
                res += item;
            }
            return res;
        }
        static bool Check(string[] item)
        {
            foreach (var text in BooleanFunctions)
            {
                if (Convert.ToInt32(UnParse(text)) == Convert.ToInt32(UnParse(item)))
                {
                    return false;
                }
               
            }
            return true;
        }
        
    }
}
