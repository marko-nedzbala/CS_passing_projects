using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06
{
    public class Employee
    {
        protected string _empName;
        protected int _empId;
        protected float _currPay;
        protected int _empAge;
        protected string _empSSN;

        public Employee() { }
        public Employee(string name, int id, float pay)
            : this(name, 0, id, pay, "", EmployeePayTypeEnum.Salaried) { }

        public Employee(string name, int id, float pay, string empSsn)
            : this(name, 0, id, pay, empSsn, EmployeePayTypeEnum.Salaried) { }

        public Employee(string name, int age, int id, float pay, string empSsn, EmployeePayTypeEnum payType)
        {
            _empName = name;
            _empId = id;
            _empAge = age;
            _currPay = pay;
            SocialSecurityNumber = empSsn;
            PayType = payType;
        }

        public void DisplayStats()
        {
            Console.WriteLine("Name: {0}", _empName);
            Console.WriteLine("ID: {0}", _empId);
            Console.WriteLine("Age: {0}", _empAge);
            Console.WriteLine("Pay: {0}", _currPay);
        }

        public string Name
        {
            get { return _empName; }
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error! Name length exceeds 15 characters!");
                }
                else
                {
                    _empName = value;
                }
            }
        }

        public int Id
        {
            get { return _empId; }
            set { _empId = value; }
        }

        public float Pay
        {
            get { return _currPay; }
            set { _currPay = value; }
        }

        public int Age
        {
            get { return _empAge; }
            set { _empAge = value; }
        }

        private EmployeePayTypeEnum _payType;
        public EmployeePayTypeEnum PayType
        {
            get => _payType;
            set => _payType = value;
        }

        public string SocialSecurityNumber
        {
            get => _empSSN;
            private set => _empSSN = value;
        }

        public void GiveBonus(float amount)
        {
            Pay = this switch
            {
                { Age: >= 18, PayType: EmployeePayTypeEnum.Commission, HireDate.Year: > 2020 }
                    => Pay += 0.10F * amount,
                { Age: >= 18, PayType: EmployeePayTypeEnum.Hourly, HireDate.Year: > 2020 }
                    => Pay += 40F * amount / 2080F,
                { Age: >= 18, PayType: EmployeePayTypeEnum.Salaried, HireDate.Year: > 2020 }
                    => Pay += amount,
                _ => Pay += 0
            };
        }

        private DateTime _hireDate;
        public DateTime HireDate
        {
            get => _hireDate;
            set => _hireDate = value;
        }

        protected BenefitPackage EmpBenefits = new BenefitPackage();
        public double GetBenefitCost()
            => EmpBenefits.ComputePayDeduction();

        public BenefitPackage Benefits
        {
            get { return EmpBenefits; }
            set { EmpBenefits = value; }
        }

    }

    public enum EmployeePayTypeEnum
    {
        Hourly,
        Salaried,
        Commission
    }
}
