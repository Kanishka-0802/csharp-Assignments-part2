using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LamdaAssignment
{


    internal class LamdaDemo
    {
        class Products
        {
            public int pid { get; set; }
            public string pname { get; set; }
            public int price { get; set; }
            public int qty { get; set; }
        }
        List<Products> li = new List<Products>()
            {
                new Products() { pid = 100, pname = "book", price = 1000, qty = 5 },
                new Products() { pid = 200, pname = "cd", price = 2000, qty = 6 },
                new Products() { pid = 300, pname = "toys", price = 3000, qty = 5 },
                new Products() { pid = 400, pname = "mobile", price = 8000, qty = 6 },
                new Products() { pid = 600, pname = "pen", price = 200, qty = 7 },
                new Products() { pid = 700, pname = "tv", price = 30000, qty = 7 },
             };


        //1. find second highest price 
        public void demo1()
        {

            var res1 = li.OrderByDescending(t => t.price).Take(2).Skip(1);
            foreach (var item in res1)
            {
                Console.WriteLine($"{item.pid}  {item.pname}  {item.price} ");
            }
        }

        //2. display top 3 highest price 

        public void demo2()
        {

            var res2 = li.OrderByDescending(t => t.price).Take(3);
            foreach (var item in res2)
            {
                Console.WriteLine($"{item.pid}  {item.pname}  {item.price} ");
            }
        }

        //3. find the sum of price where product names contains letter 'O'  
        public void demo3()
        {
            int sum = li.Where(t => t.pname.Contains("o")).Sum(t => t.price);
            Console.WriteLine("Sum of Price : "+ sum);
        }


        //4.  find the product name ends with e and display only pid and pname(filter by column name)

        public void demo4()
        {
            var res = li.Where(t => t.pname.EndsWith("e")).Select(t => new { Pid = t.pid, Pname = t.pname });
             foreach (var item in res)
            {
                Console.WriteLine($"{item.Pid}   {item.Pname}");
            }
        }


        //5. group all records by qty find max of price

        public void demo5()
        {
            var res = li.GroupBy(t => t.qty).Select(g => new
            {
                Qty = g.Key,
                Max_price = g.Max(x => x.price)
            });


            foreach (var item in res)
            {
                Console.WriteLine($"Qty: {item.Qty}, Max Price: {item.Max_price}");
            }
        }


        //Arrays 


        //Q5.Find sum of price of all products.
        public void demo6()
        {
            var res = li.Sum(t => t.price);
            Console.WriteLine("Sum of prices : "+res);

        }
        //Q6.Find count of products where price > 5000. 

        public void demo7()
        {
            var res = li.Count(t => t.price >5000);
            Console.WriteLine("Sum of prices : " + res);

        }
    }
}
