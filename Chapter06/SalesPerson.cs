using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06
{
    internal class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson() { }

        public SalesPerson(string fullName, int age, int empId, float currPay, string ssn, int numbOfSales)
            : base(fullName, age, empId, currPay, ssn, EmployeePayTypeEnum.Commission)
        {
            SalesNumber = numbOfSales;
        }
    }
}
