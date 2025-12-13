using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoConnections1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CollectionDemo demo = new CollectionDemo();
            //task 1
            //demo.ShowEmployees();
            //task2
            //demo.getrecord();
            //task3
            //demo.InsertRecordsusingtrans();
            //task4

            demo.fetchdata();
            Console.ReadLine();
        }
    }
}
