using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dict<int, string>();

            dict.Add(new Item<int, string>(1, "One"));
            dict.Add(new Item<int, string>(1, "One"));           
            dict.Add(new Item<int, string>(2, "Two"));
            dict.Add(new Item<int, string>(3, "Three"));
            dict.Add(new Item<int, string>(4, "Four"));
            dict.Add(new Item<int, string>(5, "Five"));
            dict.Add(new Item<int, string>(101, "OneHundredOne"));

            foreach (var item in dict)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine(dict.Search(7) ?? "Null");
            Console.WriteLine(dict.Search(3) ?? "Null");
            Console.WriteLine(dict.Search(101) ?? "Null");

            dict.Remove(3);
            dict.Remove(101); //не удаляет
            dict.Remove(1);
            dict.Remove(7);

            foreach (var item in dict)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            Console.ReadLine();

            var easyMap = new EasyMap<int, string>();

            easyMap.Add(new Item<int, string>(1, "One"));
            easyMap.Add(new Item<int, string>(2, "Two"));
            easyMap.Add(new Item<int, string>(3, "Three"));
            easyMap.Add(new Item<int, string>(4, "Four"));
            easyMap.Add(new Item<int, string>(5, "Five"));           

            foreach (var item in easyMap)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine(easyMap.Search(7) ?? "Null");
            Console.WriteLine(easyMap.Search(3) ?? "Null");

            easyMap.Remove(3);
            easyMap.Remove(1);

            foreach (var item in easyMap)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
