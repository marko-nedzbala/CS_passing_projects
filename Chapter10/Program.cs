using Chapter10;
using System.Collections.ObjectModel;
using System.Collections.Specialized;



string[] strArray = { "First", "Second", "Third" };
foreach(string s in strArray)
{
    Console.WriteLine("Array entry: {0}", s);
}

Console.WriteLine();

ObservableCollection<Person> people = new ObservableCollection<Person>()
{
    new Person { FirstName="Peter", LastName="Billy", Age=52},
    new Person { FirstName="Kvein", LastName="Sammy", Age=48}
};

static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
{
    Console.WriteLine("Action for this event: {0}", e.Action);
    if(e.Action == NotifyCollectionChangedAction.Remove)
    {
        Console.WriteLine("Here are the old items");
        foreach(Person p in e.OldItems)
        {
            Console.WriteLine(p.ToString());
        }
    }

    if (e.Action == NotifyCollectionChangedAction.Add)
    {
        Console.WriteLine("Here are the new items");
        foreach(Person p in e.NewItems)
        {
            Console.WriteLine(p.ToString());
        }
    }
}

people.CollectionChanged += people_CollectionChanged;

people.Add(new Person("Fred", "Smith", 32));
people.RemoveAt(0);

Console.WriteLine();

static void Swap<T>(ref T a, ref T b)
{
    Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
    T temp = a;
    a = b;
    b = temp;
}

int x1 = 11;
int x2 = 24;
Swap<int>(ref x1, ref x2);
Console.WriteLine("New x1: {0}, New x2: {1}", x1, x2);

Console.WriteLine();












static void UseGenericList()
{
    List<Person> people = new List<Person>()
    {
        new Person { FirstName = "Homer", LastName="Simpson", Age=47},
        new Person { FirstName = "Bobby", LastName="Smithy", Age=35}
    };
}





