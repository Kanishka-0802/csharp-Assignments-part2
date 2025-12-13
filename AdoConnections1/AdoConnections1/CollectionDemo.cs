using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoConnections1
{
    internal class CollectionDemo
    {
        // -------------------------------task 1------------------------------------
        public void ShowEmployees()
        {

            Console.Write("Enter start date : ");
            DateTime start = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Enter end date : ");
            DateTime end = Convert.ToDateTime(Console.ReadLine());

            SqlConnection con = new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB");

            con.Open();

            SqlCommand cmd = new SqlCommand("getemployees", con);

            cmd.Parameters.Add(new SqlParameter("@startdate", start));
            cmd.Parameters.Add(new SqlParameter("@enddate", end));

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}   {dr[1]}   {dr[2]}");
            }

        }


        //--------------------------------task 2---------------------------

        public void getrecord()
        {
            Console.WriteLine("Enter the Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlConnection con = new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB");
            
                con.Open();

                SqlCommand cmd = new SqlCommand("sp_getrecord", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DeptId", id));

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine($"{dr["EmpId"]}   {dr["EmpName"]}   {dr["DeptName"]}");
                }
            }
        



        // ---------------------------------------task3-----------------------------

        public void InsertRecordsusingtrans()
        {

            SqlTransaction tr = null;

            try
            {
                SqlConnection con = new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB");

                con.Open();

                tr = con.BeginTransaction();


                Console.Write("Enter Employee Name: ");
                string empName = Console.ReadLine();

                Console.Write("Enter Salary: ");
                decimal salary = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter Date Of Join : ");
                DateTime doj = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Enter Department Id: ");
                int deptId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Department Name: ");
                string deptName = Console.ReadLine();


            
                SqlCommand cmd1 = new SqlCommand(
                    $"insert into Department_01 (DeptID, DeptName) values ({deptId}, '{deptName}')", con, tr);
                SqlCommand cmd2 = new SqlCommand(
                    $"insert into Employee (EmpName, Salary, DateOfJoin, DeptID) " +
                    $"values ('{empName}', {salary}, '{doj:yyyy-MM-dd}', {deptId})", con, tr);

                int rowaffected1 = cmd1.ExecuteNonQuery();
                int rowaffected2 = cmd2.ExecuteNonQuery();

                Console.WriteLine("Total Records Inserted in Department: " + rowaffected1);
                Console.WriteLine("Total Records Inserted in Employee: " + rowaffected2);

                tr.Commit();
                Console.WriteLine("Transaction committed successfully!");
            }

            catch (Exception ex)
            {
                if (tr != null)
                {
                    try
                    {
                        tr.Rollback();
                        Console.WriteLine("Transaction rolled back.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }


        //----------------------------task4-------------------------------



        public void fetchdata()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB");
            con.Open();

            Console.WriteLine("Enter EmpName : ");
            string empname = Console.ReadLine();
            Console.WriteLine("Enter Emp Salary : ");
            decimal sal = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter JoinDate : ");
            DateTime  data_time = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Dept Id : ");
            int deptid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter DeptName : ");
            string deptname = Console.ReadLine();

            SqlCommand cmd1 = new SqlCommand(
               $"insert into Department_01 (DeptID, DeptName) values ({deptid}, '{deptname}')", con);
            int rowaffected1 = cmd1.ExecuteNonQuery();

            SqlCommand cmd2 = new SqlCommand($"insert into  Employee (EmpName,Salary,DateOfJoin,DeptID)"+$"values('{empname}',{sal},'{data_time}',{deptid})"+$" select scope_identity()",con);
            int newid = Convert.ToInt32(cmd2.ExecuteScalar());

            SqlCommand cmd3 = new SqlCommand($"select EmpID,EmpName,Salary,DateOfJoin,DeptID from Employee where EmpID={newid}",con);
            SqlDataReader reader = cmd3.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Validated: {reader["EmpID"]} | {reader["EmpName"]} | {reader["Salary"]} | {reader["DateOfJoin"]} | {reader["DeptID"]}");
            }
            else
            {
                Console.WriteLine("Validation failed: Employee not found.");
            }




            con.Close();



        }
        //--------------------------task5---------------------------

        public void multidata()
        {
            SqlConnection con = new SqlConnection("Integrated security=true;database=master;server=(localdb)\\MSSQLLocalDB");
            con.Open();
            Console.WriteLine("Enter Dept Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            SqlCommand cmd = new SqlCommand("select  e.EmpId, e.EmpName, d.DeptName " + "from Employee e inner join Department_01 d on e.DeptID = d.DeptID " +
                "where e.DeptID=@id",con);
            SqlCommand cmd2 = new SqlCommand($"select EmpID, EmpName from Employee where EmpID = {id}", con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine($"{dr["EmpId"]} | {dr["EmpName"]} | {dr["DeptName"]}");
            }
            if (dr.NextResult())
            {
              
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["DeptID"]} | {dr["DeptName"]}");
                }
            }

            con.Close();
        }

    }

    }

        




    


   
