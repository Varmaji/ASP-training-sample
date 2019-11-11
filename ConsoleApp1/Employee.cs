using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Employee
    {
        #region Variables
        private int empId;
        string empName;
        #endregion

        #region Properties
        public int EmployeeId
        {
            get { return empId; }
            set { empId = value; }
        }

        public string EmployeeName
        {
            get { return empName; }
            set { empName = value; }
        }

        #endregion



        #region Methods
        public void Show()
        {
            Console.WriteLine($"ID:{empId},Name:{empName}");
        }
        #endregion

    }
}
