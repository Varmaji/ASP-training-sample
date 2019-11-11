using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace ConsoleApp1
{
    class DbOperation2
    {
        internal static void Test()
        {
            string conStr = @"server=VAAYU\sqldev2016;database=northwind;integrated security=sspi";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = conStr;
            // string sql = "SELECT ProductID,ProductName,UnitPrice,UnitsInStock,Discontinued from Products";
            string sql = "sp_GetAllProducts";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            //cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = connection;

            //Add parameters to the command
            cmd.Parameters.AddWithValue("@search", "");
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read())
            {
                var discontinued = reader.GetBoolean(4);
                if(discontinued)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    
                }
                Console.WriteLine("ProductId:{0,5},ProductName:{1,-40},UnitPrice:{2,15},UnitsInStock:{3,5},Discontinued:{4,20}",reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetInt16(3),reader.GetBoolean(4));
            }
            reader.Close();
            connection.Close();

        }
    }
}
