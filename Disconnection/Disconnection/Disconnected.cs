using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disconnection
{
    internal class Disconnected
    {

        //-----------------------------------------task1------------------------------------------------
        SqlConnection con = new SqlConnection("Integrated Security = true; Database = master; Server = (localdb)\\MSSQLLocalDB");
        SqlDataAdapter da_emp;
        SqlDataAdapter da_dept;
      

        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        public void Showallrecord()
        {
            da_emp = new SqlDataAdapter("select * from employee", con);
            da_emp.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder sb = new SqlCommandBuilder(da_emp);
            da_emp.Fill(ds, "emp");
            dt1 = ds.Tables["emp"];

            Console.WriteLine("--------------Employee_Records------------");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                Console.WriteLine(dt1.Rows[i][0]);
                Console.WriteLine(dt1.Rows[i][1]);
                Console.WriteLine(dt1.Rows[i][2]);
                Console.WriteLine(dt1.Rows[i][3]);
                Console.WriteLine(dt1.Rows[i][4]);
                Console.WriteLine("------------------------------");
            }

            da_dept = new SqlDataAdapter("select * from department_01", con);
            da_dept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            SqlCommandBuilder sb1 = new SqlCommandBuilder(da_dept);
            da_dept.Fill(ds, "dept");
            dt2 = ds.Tables["dept"];

            Console.WriteLine("--------------Department_Records------------");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                Console.WriteLine(dt2.Rows[i][0]);
                Console.WriteLine(dt2.Rows[i][1]);
                Console.WriteLine("------------------------------");

            }


        }

        //--------------------------------task2--------------------------------

        public void FilterEmployee()
        {
            da_emp = new SqlDataAdapter("select * from employee", con);
            da_emp.Fill(ds, "emp");
            dt1 = ds.Tables["emp"];

            Console.WriteLine("Rows after filter is as follows ");
            Console.WriteLine("===================================================");
            DataView dv = new DataView(dt1);

              dv.RowFilter = "Salary > 47000 and DeptID = 10 and EmpName like 'M%'";
            dv.Sort = "Salary desc";


          
            foreach (DataRowView item in dv)
            {
                Console.WriteLine(item[0]);
                Console.WriteLine(item[1]);
                Console.WriteLine(item[2]);
                Console.WriteLine(item[3]);
                Console.WriteLine(item[4]);


            }

        }



        //----------------------------task 3---------------------------

        public void Showcount()
        {
            //da_emp = new SqlDataAdapter("select * from employee", con);
            //da_emp.Fill(ds, "emp");
            //da_dept = new SqlDataAdapter("select * from department_01", con);
            //da_dept.Fill(ds, "dept");
            Console.WriteLine("Total number of tables in DataSet: " + ds.Tables.Count);
            Console.WriteLine("-----------------------------------------------------");
            if (ds.Tables.Count > 0)
            {
                foreach (DataTable t in ds.Tables)
                {
                    Console.WriteLine(t.TableName);
                }
            }
            else
            {
                Console.WriteLine("No Tables found");
            }
        }

        //-----------------------------------task4--------------------------------

        public void copydata()
        {
            SqlCommand cmd = new SqlCommand("select * from Department_01", con);
            SqlCommandBuilder sb1 = new SqlCommandBuilder(da_dept);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            foreach(DataRow r in dt.Rows)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Console.WriteLine(dt.Rows[i][0]);
                    Console.WriteLine(dt.Rows[i][1]);
                    Console.WriteLine("------------------------------");

                }

            }


        }

        public void DisplayMergeData()
        {
            SqlDataAdapter da_cust;
            SqlDataAdapter da_order;
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            da_cust = new SqlDataAdapter("select * from Customers", con);
            da_cust.Fill(ds1, "cust");

            da_order = new SqlDataAdapter("select * from Orders", con);
            da_order.Fill(ds2, "orders");
            ds1.Merge(ds2);
            Console.WriteLine("------------Customers Records-------------------");
            DataTable dt3 = ds1.Tables["cust"];
            foreach(DataRow r in dt3.Rows)
            {
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    Console.WriteLine(dt3.Rows[i][0]);
                    Console.WriteLine(dt3.Rows[i][1]);
                    Console.WriteLine(dt3.Rows[i][2]);
                    Console.WriteLine(dt3.Rows[i][3]);
                    Console.WriteLine(dt3.Rows[i][4]);
                    Console.WriteLine("------------------------------");
                }

            }
            Console.WriteLine("---------------Orders Records--------------------");
            DataTable dt4 = ds1.Tables["orders"];
            foreach (DataRow r in dt4.Rows)
            {
                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    Console.WriteLine(dt4.Rows[i][0]);
                    Console.WriteLine(dt4.Rows[i][1]);
                    Console.WriteLine("------------------------------");
                }
            }
        }


        //--------------------------task 6----------------------------


        public void Readxml()
        {
          
            ds.Clear();
            ds.ReadXml("C:\\Users\\kanishkac\\Desktop\\ExcelFiles\\Customer.xml"); 
            foreach (DataTable table in ds.Tables)
            {
                Console.WriteLine("Table: " + table.TableName);
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        Console.WriteLine($"{col.ColumnName}: {row[col]}");
                    }
                    Console.WriteLine("------------------------------");
                }
            }
        }




    }
}
