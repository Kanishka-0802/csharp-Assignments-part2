using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAssignments
{
    internal class ArrayDemo
    {

        List<int> listA = new List<int> { 10, 20, 30, 40, 50, 20, 30 };
        List<int> listB = new List<int> { 30, 40, 50, 60, 70, 40 };

        List<string> names1 = new List<string> { "Akshay", "Aasritha", "Deepa", "Kiran",
"Kiran" };
        List<string> names2 = new List<string> { "Kiran", "Manikanta", "Deepa", "Naveen"
};



        // Q1.Write a LINQ query to fetch unique values from listA.
        //Expected Output: 10, 20, 30, 40, 50 

        public void demo1() {
            var res = listA.Distinct();
            foreach(var  item in res)
            {
                Console.WriteLine(item);
            }
         }


        //Q2.Combine values from listA and listB without duplicates. 

        public void demo2()
        {
            var res = listA.Union(listB);

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }


        //Q3.Find items common in listA and listB.
        public void demo3()
        {
            var res = listA.Intersect(listB);

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        //Q4.Find names present in names1 but not in names2.
        public void demo4()
        {
            var res = listA.Except(listB);

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        //Q7.Find the highest value in listA.
        public void demo5()
        {
            var res = listA.Max();

                Console.WriteLine("Max Num is : "+res);
            
        }

        //Q8.Write a LINQ query to find numbers divisible by 3 
        //int[] numbers = { 1, 4, 9, 16, 25, 36 };
        public void demo6()
        {
            int[] numbers = { 1, 4, 9, 16, 25, 36 };
            var res = from i in numbers where i % 3 == 0 select i;
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        //Q9.Write a Linq to query to sort based on string Length
        //string[] st = { "India", "Srilanka", "canada", "Singapore" };
        public void demo7()
        {
            string[] st = { "India", "Srilanka", "canada", "Singapore" };
            var res = from i in st orderby i.Length select i;
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

    }

}
