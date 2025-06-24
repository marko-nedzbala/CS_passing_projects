using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

















static void ListMethods(Type t)
{
    var methodNames = from n in t.GetMethods() orderby n.Name select n.Name;

    MethodInfo[] mi = t.GetMethods();
    foreach (MethodInfo m in mi)
    {
        Console.WriteLine("->{0}", m.Name);
    }
    Console.WriteLine();
}







public class Motorcycle
{

}

















