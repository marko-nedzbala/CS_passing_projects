using System.Reflection;
using Chapter17_CommonSnappableTypes;

string typeName = "";
do
{
    Console.WriteLine("Enter a snapin to load");
    Console.Write("or enter Q to quit");
    typeName = Console.ReadLine();

    if (typeName.Equals("Q", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    try
    {
        LoadExternalModule(typeName);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Sorry cannot find snapin");
    }
} while (true);











static void LoadExternalModule(string assemblyName)
{
    Assembly theSnapInAsm = null;
    try
    {
        theSnapInAsm = Assembly.LoadFrom(assemblyName);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error ocurred loading the snapin: {ex.Message}");
        return;
    }

    var theClassTypes = theSnapInAsm
        .GetTypes()
        .Where(t => t.IsClass && (t.GetInterface("IAppFunctionality") != null))
        .ToList();

    if (!theClassTypes.Any())
    {
        Console.WriteLine("Nothing implements IAppFunctionality");
    }

    foreach (Type t in theClassTypes)
    {
        IAppFunctionality itfApp = (IAppFunctionality)theSnapInAsm.CreateInstance(t.FullName, true);
        itfApp?.DoIt();
        DisplayCompanyData(t);
    }
}


static void DisplayCompanyData(Type t)
{
    var compInfo = t
        .GetCustomAttributes(false)
        .Where(ci => (ci is CompanyInfoAttribute));

    foreach (CompanyInfoAttribute c in compInfo)
    {
        Console.WriteLine($"More info about {c.CompanyName} can be found at {c.CompanyUrl}");
    }
}






