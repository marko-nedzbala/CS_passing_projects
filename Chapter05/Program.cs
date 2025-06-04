
//Car myCar01 = new Car();
//Console.WriteLine(myCar01.petName);
//myCar01.petName = "Henry";
//myCar01.currSpeed = 10;

//for (int i = 0; i <= 10; i++)
//{
//    myCar01.SpeedUp(5);
//    myCar01.PrintState();
//}
//Console.ReadLine();

using System.ComponentModel.DataAnnotations;

Employee emp = new Employee("Marvin", 456, 30_000);
emp.GiveBonus(1000);
emp.DisplayStats();

emp.Name = "Marv";
Console.WriteLine("Employee is named: {0}", emp.Name);

Employee joe = new Employee();
Console.WriteLine(joe.Age++);

Console.WriteLine();

Employee emp02 = new Employee("Marvin", 45, 123, 1_000, "111-11-1111", EmployeePayTypeEnum.Salaried);
Console.WriteLine(emp02.Pay);
emp02.GiveBonus(100);
Console.WriteLine(emp02.Pay);


Console.WriteLine();

CarRecord myCarRecord01 = new CarRecord()
{
    Make = "Honda",
    Model = "Model",
    Color = "Blue"
};
Console.WriteLine("My car: ");
DisplayCarRecordStats(myCarRecord01);
Console.WriteLine();

CarRecord myCarRecord02 = new CarRecord("Honda", "Pilot", "Blue");
Console.WriteLine("Another variable for my car: ");
Console.WriteLine(myCarRecord02.ToString());
Console.WriteLine();

static void DisplayCarRecordStats(CarRecord c)
{
    Console.WriteLine("Car Make: {0}", c.Make);
    Console.WriteLine("Car Model: {0}", c.Model);
    Console.WriteLine("Car Color: {0}", c.Color);
}

Console.WriteLine();

var rs = new Point(2, 4, 6);
Console.WriteLine(rs.ToString());
rs.X = 8;
Console.WriteLine(rs.ToString());

var rs2 = new PointWithPropertySyntax(2, 4, 6);
Console.WriteLine(rs2.ToString());
rs2.X = 8;
Console.WriteLine(rs2.ToString());





class Car
{
    public string petName;
    public int currSpeed;

    public Car()
    {
        petName = "Chuck";
        currSpeed = 10;
    }

    public void PrintState()
        => Console.WriteLine("{0} is going {1} MPH.", petName, currSpeed);

    public void SpeedUp(int delta)
        => currSpeed += delta;
}

class Employee
{
    private string _empName;
    private int _empId;
    private float _currPay;
    private int _empAge;
    private string _empSSN;

    public Employee() { }
    public Employee(string name, int id, float pay)
        :this(name, 0, id, pay, "", EmployeePayTypeEnum.Salaried) { }

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
            if(value.Length > 15)
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
}

public enum EmployeePayTypeEnum
{
    Hourly,
    Salaried,
    Commission
}

record CarRecord
{
    public string Make { get; init; }
    public string Model { get; init; }
    public string Color { get; init; }

    public CarRecord() { }

    public CarRecord(string make, string model, string color)
    {
        Make = make;
        Model = model;
        Color = color;
    }
}



public record struct Point(double X, double Y, double Z);

public record struct PointWithPropertySyntax()
{
    public double X { get; set; } = default;
    public double Y { get; set; } = default;
    public double Z { get; set; } = default;


    public PointWithPropertySyntax(double x, double y, double z) : this()
    {
        X = x;
        Y = y;
        Z = z;
    }
};


public record struct MyStruct()
{
    public float value01 { get; set; } = default;
    public float value02 { get; set; } = default;

    public MyStruct(float value01, float value02) : this()
    {
        this.value01 = value01;
        this.value02 = value02;
    }
};
