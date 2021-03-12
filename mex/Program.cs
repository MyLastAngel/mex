using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace mex
{
    class Program
    {

        static void Main(string[] args)
        {
            uint seed = 10;

            var mex = new MexDB();

            var key = "";
            //uint seed = 0;

            Console.WriteLine("Новый ID (Enter)");
            Console.WriteLine("Зашифровать базу (цифра)");
            Console.WriteLine("Выход (exit)");

            while (true)
            {
                Console.WriteLine("Список ID:");
                Console.WriteLine(string.Join(", ", mex.sorted.Select(c => c.ToString("D3"))));
                //Console.WriteLine(string.Join(", ", arr.Select(c => c.ToString("D3"))));
                //Console.WriteLine(string.Join(", ", arr.Select(c => Convert.ToString(c, 2).PadLeft(4, '0'))));

                key = Console.ReadLine();
                if (key == "exit")
                    break;

                // Если у нас цифра - шифруем базу
                if (uint.TryParse(key, out seed))
                {
                    mex.Rebuild(seed);
                    continue;
                }

                var id = mex.GetNext();
                Console.WriteLine($"Добавили ID: {id}");
            }

            Console.WriteLine("Any key to exit....");
            Console.ReadKey();
        }
    }
}
