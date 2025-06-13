using System.Collections;
using System.Reflection;
using Chapter11;

List<Person> myPeople = new List<Person>();
myPeople.Add(new Person("Bob", "Smith", 45));
myPeople.Add(new Person("Jimmy", "Johns", 32));

myPeople[0] = new Person("Sue", "Test", 35);

foreach (Person person in myPeople)
{
    Console.WriteLine("Person: {0}", person);
}

Console.WriteLine();

Point p1 = new Point(100, 100);
Point p2 = new Point(40, 55);
Console.WriteLine("Add {0}", p1 + p2);
Console.WriteLine("Subtract {0}", p1 - p2);

Console.WriteLine();

Rectange r = new Rectange(15, 4);
Console.WriteLine(r.ToString());
r.Draw();

Console.WriteLine();

Square s = (Square)r;
Console.WriteLine(s.ToString());
s.Draw();

Console.WriteLine();

int myInt = 1234567890;
myInt.DisplayDefiningAssembly();
Console.WriteLine("myInt: {0}", myInt.ReverseDigits());

System.Data.DataSet d = new System.Data.DataSet();
d.DisplayDefiningAssembly();

Console.WriteLine();

string[] data = { "Wow", "this", "is", "sort", "of", "annoying", "but", "in", "a", "weired", "way", "fun!" };
//data.PrintDataAndBeep();

List<int> myInts = new List<int>() { 10, 15, 20 };
//myInts.PrintDataAndBeep();

Console.WriteLine();

var car = new { Make = "Saab", Color = "Blue", Speed = 100 };
Console.WriteLine("Your {0} is a beautiful {1} going at: {2}", car.Make, car.Color, car.Speed);
Console.WriteLine("obj is instance of: {0}", car.GetType().Name);
Console.WriteLine("Base class of {0} is {1}", car.GetType().Name, car.GetType().BaseType);
Console.WriteLine("obj.ToString() == {0}", car.ToString());
Console.WriteLine("obj.GetHashCode() == {0}", car.GetHashCode());

Console.WriteLine();

var car02 = new { Make = "Saab", Color = "Blue", Speed = 100 };
if (car.Equals(car02))
{
    Console.WriteLine("Same object");
}
else
{
    Console.WriteLine("Not the same objects");
}













public class PersonCollection
{
    private List<Person> people = new List<Person>();

    public Person this[int index]
    {
        get => (Person)people[index];
        set => people.Insert(index, value);
    }
}

public struct Rectange
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectange(int w, int h)
    {
        Width = w;
        Height = h;
    }

    public void Draw()
    {
        for(int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    public override string ToString()
    {
        return $"[Width = {Width}; Height = {Height}]";
    }
}

public struct Square
{
    public int Length { get; set; }

    public Square(int l) : this()
    {
        Length = l;
    }

    public void Draw()
    {
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Length; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    public override string ToString()
    {
        return $"[Length = {Length}]";
    }

    public static explicit operator Square(Rectange r)
    {
        Square s = new Square { Length = r.Height };
        return s;
    }
}

public static class MyExtensions
{
    public static void DisplayDefiningAssembly(this object obj)
    {
        Console.WriteLine("{0} lives here: => {1}\n", obj.GetType().Name, Assembly.GetAssembly(obj.GetType()).GetName().Name);
    }

    public static int ReverseDigits(this int i)
    {
        char[] digits = i.ToString().ToCharArray();
        Array.Reverse(digits);
        string newDigits = new string(digits);
        return int.Parse(newDigits);
    }

    public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
    {
        foreach (var item in iterator)
        {
            Console.WriteLine(item);
            Console.Beep();
        }
    }
}


