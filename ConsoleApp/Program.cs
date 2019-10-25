using DatabaseService;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ds = new DataService();

            var a = ds.GetOrders();
            foreach (var item in a)
            {
                Console.WriteLine(item);  
            }

            //var a = ds.GetOrderDetailsByOrderId(10747);
            // foreach (var item in a)
            // {
            //     Console.WriteLine(item.ProductId);
            // }


        }
    }
}
