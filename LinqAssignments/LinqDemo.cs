using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqAssignments
{
    internal class LinqDemo
    {
        class Movies
        {
            public int MovieId { get; set; }
            public string MovieName { get; set; }
            public string Actor { get; set; }
            public string Actress { get; set; }
            public int YOR { get; set; }
        }

        List<Movies> li = new List<Movies>()
    {
        new Movies(){ MovieId=100, MovieName="Bahubali", Actor="Prabhas",
Actress="Tamanna", YOR=2015 },
        new Movies(){ MovieId=200, MovieName="Bahubali2", Actor="Prabhas",
Actress="Anushka", YOR=2017 },
        new Movies(){ MovieId=300, MovieName="Robot", Actor="Rajini",
Actress="Aish", YOR=2010 },
        new Movies(){ MovieId=400, MovieName="3 idiots", Actor="Amir",
Actress="kareena", YOR=2009 },
        new Movies(){ MovieId=500, MovieName="Saaho", Actor="Prabhas",
Actress="shraddha", YOR=2019 },
    };
        public void demo1()
        {
            //--1. display list of movienames acted by prabhas 

            var res1 = from t in li where t.Actor == "Prabhas" select t;
            foreach (var item in res1)
            {
                Console.WriteLine($"{item.MovieId}  {item.MovieName}  {item.Actor} ");
            }
        }



        //-----------------------------------------------------------------


        //--2. display list of all movies released in year 2019
        public void demo2() {
            var res2 = from t in li where t.YOR == 2019 select t;
            foreach (var item in res2)
            {
                Console.WriteLine($"{item.MovieId}  {item.MovieName}    {item.YOR}");
            }
        }

        //----------------------------------------------------------------------------


        //3.display the list of movies who acted together by prabhas and anushka
        public void demo3()
        {
            var res3 = from t in li where t.Actor == "Prabhas" && t.Actress == "Anushka" select t;
            foreach (var item in res3)
            {
                Console.WriteLine($"{item.MovieId}  {item.MovieName}  {item.Actor}  {item.Actress}");
            }
        }

        //4. display the list of all actress who acted with prabhas 
        public void demo4()
        {
            var res4 = from t in li where t.Actor == "Prabhas"  select t;
            foreach (var item in res4)
            {
                Console.WriteLine($" {item.Actress}");
            }
        }
        //5. display the list of all moves released from 2010 - 2018 

        public void demo5()
        {
            var res5 = from t in li where t.YOR >=2010 && t.YOR<=2018 select t;
            foreach (var item in res5)
            {
                Console.WriteLine($" {item.MovieName}");
            }
        }
        //6. sort YOR in descending order and display all its records 
        public void demo6()
        {
            var res6 = from t in li orderby t.YOR descending  select t;
            foreach (var item in res6)
            {
                Console.WriteLine($"{item.MovieId}  {item.MovieName}  {item.Actor}  {item.Actress}  {item.YOR}");
            }
        }

        //7. display max movies acted by each actor 
        public void demo7()
        {
            var res7 = from t in li group t by t.Actor into g select new
                       {
                           Actor = g.Key,
                           movie_count = g.Count()
                       };
            foreach (var item in res7)
            {
                Console.WriteLine($"  {item.Actor}   {item.movie_count}  ");
            }
        }
        // 8. display the name of all movies which is 5 characters long
        public void demo8()
        {
            var res8 = from t in li where t.MovieName.Length==5 select t;
            foreach (var item in res8)
            {
                Console.WriteLine($"{item.MovieId}  {item.MovieName}");
            }
        }
        //9.display names of actor and actress where movie released in year 2017, 2009 and 2019 

        public void demo9()
        {
            int []years = { 2017, 2009, 2019 };
            var res9 = from t in li where years.Contains(t.YOR) select t;
            foreach (var item in res9)
            {
                Console.WriteLine($"{item.Actor}  {item.Actress}  {item.YOR}");
            }
        }

        //10.display the name of movies which start with 'b' and ends with 'i'

            
        public void demo10()
        {
            var res10 = from t in li where t.MovieName.StartsWith("B") && t.MovieName.EndsWith("i") select t;
            foreach (var item in res10)
            {
                Console.WriteLine($"{item.MovieId}  {item.MovieName}");
            }
        }
        //11.display name of actress who not acted with Rajini and print in descending order
        public void demo11()
        {
            var res11 = from t in li where t.Actor!= "Rajini" orderby t.Actress descending select t;
            foreach (var item in res11)
            {
                Console.WriteLine($"  {item.Actress}");
            }
        }

        //12. display records in following format 

        //eg: 
        //movie name     cast
        //Bahubali     prabhas-tammanna

        public void demo12()
        {
            var res12 = from t in li select new
            {
                MovieName = t.MovieName,
                Cast = t.Actor + "-" + t.Actress
            };
            Console.WriteLine("MovieName   Cast");


            foreach (var item in res12)
            {
                Console.WriteLine($"  {item.MovieName}   {item.Cast}");
            }
        }








    }
}
