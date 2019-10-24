using DatabaseService;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ds = new DataService();


            foreach (var category in ds.GetCategories())
            {
                Console.WriteLine($"{category.Id} {category.Name}");
            }
        }
    }
}
