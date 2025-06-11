using System.Collections;
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



































public class PersonCollection
{
    private List<Person> people = new List<Person>();

    public Person this[int index]
    {
        get => (Person)people[index];
        set => people.Insert(index, value);
    }
}







