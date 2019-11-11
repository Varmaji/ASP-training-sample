using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApp1
{
    class DisconnectedExample1
    {
        static void PrintData(DataTable table)
        {
            string tablename = string.IsNullOrEmpty(table.TableName) ? "<<NOT Specified>" : table.TableName;
            Console.WriteLine($"************Table:{tablename}**********");
            StringBuilder sb = new StringBuilder();
            foreach(DataColumn column in table.Columns)
            {
                sb.Append($"{column.ColumnName}\t");
            }
            Console.WriteLine(sb.ToString());

            foreach (DataRow row in table.Rows)
            {
                sb = new StringBuilder();
                for (int i = 0; i < row.ItemArray.Length; i++)
                {
                    sb.Append($"{row[i]}\t");
                }
                Console.WriteLine(sb.ToString());
            }
            Console.WriteLine("********************END OF LISTING**********************");

          
        }

        //Declare a global dataset object,which can be used across the entire code
        static DataSet dataset;

        //this function is used to create a employee table and populate the data
        static void CreateEmployeeTable() {
            if (dataset == null) dataset = new DataSet();
            DataTable table = new DataTable(EmpTableName);
            //Add the table to the dataset
            dataset.Tables.Add(table);

            //creates column or structure and add the structure to the table
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "EmpId";
            dc1.DataType = typeof(int);
            dc1.AutoIncrement = true;
            dc1.AutoIncrementSeed = 100;
            dc1.AutoIncrementStep = 1;
            dc1.Unique = true;
            dc1.AllowDBNull = false;
            //EmpId int IDENTITY(1,1) UNIQUE NOT NULL
            table.Columns.Add(dc1);
            dc1 = new DataColumn(columnName: "EmpName", dataType: typeof(string));
            dc1.AllowDBNull = false;
            table.Columns.Add(dc1);
            table.Columns.Add(columnName: "DeptID", type: typeof(int));
            table.Columns.Add(columnName: "Salary", type: typeof(double));

            //computed column
            dc1 = new DataColumn(columnName: "NetSalary", dataType: typeof(double));
            dc1.Expression = "Salary +(Salary * 0.5)- (Salary * 0.12)";
            table.Columns.Add(dc1);

            //creates rows and add the rows to the table
            DataRow row = table.NewRow();//creates and empty row object ,detached from the table
            row["EmpName"] = "Suresh";
            row["DeptId"] = 10; //DeptId can be 10,20,30,40
            row["Salary"] = 15000;
            table.Rows.Add(row);//Attaches the row object to  the table

            table.Rows.Add(null, "Mahesh", 20, 25000, null);
            table.Rows.Add(null, "Ganesh", 30, 35000, null);
            table.Rows.Add(null, "Rakesh", 10, 45000, null);
            table.Rows.Add(null, "Ramesh", 20, 55000, null);



        }

        static string EmpTableName = "Employees";
        static string DeptTableName = "Departments";

        //this funtions  created a department table and populate it wth data
        static void CreateDeptTable() {
            //Columns :DeptId(int not null),DeptName(string not null),Location(string not null);
            //Rows :{10,"Administration,"Bengaluru"},{20,"Marketing","Chennai'},
            //{ 30,"Developement","Pune"},{40,"Finanace","Bengaluru"}
            if (dataset == null) dataset = new DataSet();
            DataTable tablename = new DataTable(DeptTableName);
            //Add the table to the dataset
            dataset.Tables.Add(tablename);
            //creating the Columns
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "DeptId";
            dc1.DataType = typeof(int);
            dc1.AutoIncrement = true;
            dc1.AutoIncrementSeed = 10;
            dc1.AutoIncrementStep = 10;
            dc1.Unique = true;
            dc1.AllowDBNull = false;

           
            //EmpId int IDENTITY(1,1) UNIQUE NOT NULL
            tablename.Columns.Add(dc1);
            dc1 = new DataColumn(columnName: "DeptName", dataType: typeof(string));
            dc1.AllowDBNull = false;
            tablename.Columns.Add(dc1);
            dc1 = new DataColumn(columnName: "Location", dataType: typeof(string));
            dc1.AllowDBNull = false;

            tablename.Columns.Add(dc1);
            //creates rows and add the rows to the table
            //DataRow row = tablename.NewRow();//creates and empty row object ,detached from the table
            

            tablename.Rows.Add(null,  "Administration", "Bengaluru");
            tablename.Rows.Add(null,  "Marketing", "Chennai");
            tablename.Rows.Add(null,  "Finance", "Pune");
           // PrintData(tablename);
           // PrintData(tablename);

        }

       static void SetUpKeyColumns()
        {
            DataTable tblEmp = dataset.Tables[EmpTableName];
            DataTable tblDpt = dataset.Tables[DeptTableName];
            String EmpId = "EmpId", deptId = "DeptId";


            //set primary keys in both the tables
            tblEmp.PrimaryKey = new DataColumn[] { tblEmp.Columns[EmpId] };
            tblDpt.PrimaryKey = new DataColumn[] { tblDpt.Columns[EmpId] };

            //setup ForeignKey Constraint
            ForeignKeyConstraint fkc = new ForeignKeyConstraint(
            constraintName: "fkc_Dept_Emp_DeptId",
            parentColumn: tblDpt.Columns[deptId],
            childColumn: tblEmp.Columns[deptId]);
            tblEmp.Constraints.Add(fkc);

        }

        static void MakeChanges()
        {
            DataTable tblEmp = dataset.Tables[EmpTableName];
            DataRow row = tblEmp.Rows[0];
            //Begin the Editing of the Row,i.e, open the row for editing
            row.BeginEdit();
            try
            {
                //update the employee name
                Console.WriteLine("Enter the Employee name");
                row["EmpName"] = Console.ReadLine();
                //update the dept id,we neede to enter a value beyond what exists in dept table
                Console.WriteLine("Dept Id[10,20,30,40,50]");
                row["DeptId"] = int.Parse(Console.ReadLine());
                //once edting is ocver, update the row back in to the table
                row.EndEdit();
            }
            catch (InvalidConstraintException ex)
            {
                //if there are errors,cancel the editind operation
                row.CancelEdit();
                Console.WriteLine("Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                row.CancelEdit();
                Console.WriteLine("Error: { 0}  ", ex.Message);
            }
        }
        internal static void Test()
        {
            dataset = new DataSet();//initialize the dataset  
            //create the employee table
            CreateEmployeeTable();
            //PRint the details of EmployeeTable
            PrintData(dataset.Tables[EmpTableName]);

            CreateDeptTable();
            PrintData(dataset.Tables[DeptTableName]);

            SetUpKeyColumns();
            MakeChanges();
            PrintData(dataset.Tables[EmpTableName]);







        }
    }
}
