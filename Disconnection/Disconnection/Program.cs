using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disconnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Disconnected demo = new Disconnected();

            //demo.Showallrecord();   //---task1
            //demo.FilterEmployee();    //---task2
            //demo.Showcount();       //------task3
            //demo.copydata();          //---task 4
            //demo.DisplayMergeData();   //---task 5
            demo.Readxml();


            Console.ReadLine();
        }
    }
}
