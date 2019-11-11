using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApp1
{
    class DisconnectedExample2
    {
        static string tablename = "Customers";
        static string connectionstring = @"server=VAAYU\sqldev2016;database=northwind;integrated security=sspi";
        static DataSet northwindDataset;
        static SqlDataAdapter northwindAdapter;
        static SqlConnection connection;
        static String SQL = "Select CustomerId,CompanyName,ContactName,City,country from Customers";

        static void Initialize()
        {
            if (connection == null) connection = new SqlConnection(connectionstring);
            connection.StateChange += Connection_StateChange;
            connection.Open();
            northwindDataset = new DataSet();

            northwindAdapter = new SqlDataAdapter(SQL, connection);
        }

        private static void Connection_StateChange(object sender, StateChangeEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"State Changed from {e.OriginalState} to {e.CurrentState}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PrintData(DataTable table)
        {
            string tablename = string.IsNullOrEmpty(table.TableName) ? "<<NOT Specified>" : table.TableName;
            Console.WriteLine($"************Table:{tablename}**********");
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn column in table.Columns)
            {
                sb.Append($"{column.ColumnName,25}\t");
            }
            Console.WriteLine(sb.ToString());

            foreach (DataRow row in table.Rows)
            {
                sb = new StringBuilder();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    sb.Append($"{row[i],25}\t");
                }
                Console.WriteLine(sb.ToString());
            }
            Console.WriteLine("********************END OF LISTING**********************");


        }
    
        static void PersistToXML()
        {
            String xmlFilename = @"C:\Databases\Customers.xml";
            if (System.IO.File.Exists(xmlFilename)) System.IO.File.Delete(xmlFilename);
            northwindDataset.WriteXml(xmlFilename, XmlWriteMode.WriteSchema);
            Console.WriteLine("File Succesfully written");
                
        }


        static void LoadFromXML()
        {
            String xmlFilename = @"C:\Databases\Customers.xml";
            northwindDataset.ReadXml(xmlFilename, XmlReadMode.ReadSchema);
            


        }


        internal static void Test()
        {
            Initialize();
            northwindAdapter.Fill(northwindDataset, tablename);
            PrintData(northwindDataset.Tables[tablename]);
            MakeChangesToCustomerTable();
            //class is used to generate INSERT,UPDATE,DELETE command based on the SELECT command
            SqlCommandBuilder bldr = new SqlCommandBuilder(northwindAdapter);
            Console.WriteLine("COMMAND:{0}\n\n", bldr.GetInsertCommand().CommandText); 
            //northwindDataset.RejectChanges();
            northwindDataset.AcceptChanges();
          //  northwindAdapter.Update(northwindDataset, tablename);
            PrintData(northwindDataset.Tables[tablename]);
            PersistToXML();
            Console.WriteLine("Press a key to load a customer data");
            Console.ReadKey();
            Console.Clear();
            northwindDataset = new DataSet();
            LoadFromXML();
            PrintData(northwindDataset.Tables[tablename]);
        }
        static void MakeChangesToCustomerTable()
        {
            DataTable table = northwindDataset.Tables[tablename];
            table.Rows.Add("RRRRR", "ZZZZZ Foods pvt ltd.", "Sleeper Dog", "RocketFort", "MarsMoon");
        }
    }
}
