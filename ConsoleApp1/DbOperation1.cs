using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp1
{
    class DbOperation1
    {
        internal static void Test()
        {
            string conStr = @"server=(local)\sqldev2016;database=northwind;integrated security=sspi";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = conStr;
            string sql = "SELECT CustomerId, CompanyName, ContactName, City, Country FROM Customers";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;


            //begin the execution part
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int counter = 1;
            while(reader.Read())
            {

                if(counter%2==0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.BackgroundColor = ConsoleColor.Red;
                      
                }
                Console.WriteLine("ID:{0},Company:{1}, Contact:{2}, City:{3}, Country:{4}",
                    reader.GetString(0), reader["CompanyName"].ToString(), reader[2].ToString(), reader.GetString(3), reader["country"].ToString());
            }

            reader.Close();
            connection.Close();
        }
    }
}
