
//DirectoryInfo dir = new DirectoryInfo($@"C{Path.VolumeSeparatorChar}{Path.DirectorySeparatorChar}Windows");
//Console.WriteLine("Fullname: {0}", dir.FullName);
//Console.WriteLine("Name: {0}", dir.Name);
//Console.WriteLine("Parent: {0}", dir.Parent);
//Console.WriteLine("Creation: {0}", dir.CreationTime);
//Console.WriteLine("Attributes: {0}", dir.Attributes);
//Console.WriteLine("Root: {0}", dir.Root);

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

//using (FileStream fs = File.Open("myMessage.data", FileMode.Create))
//{
//    // encode a string as an array of bytes
//    string msg = "Hello!";
//    byte[] msgByteArray = Encoding.Default.GetBytes(msg);

//    //write byte[] to a file
//    fs.Write(msgByteArray, 0, msgByteArray.Length);

//    //reset internal position of stream
//    fs.Position = 0;

//    //read the types from the file and display to console
//    Console.Write("Your message as an array of bytes: ");
//    byte[] bytesFromFile = new byte[msgByteArray.Length];
//    for (int i = 0; i < msgByteArray.Length; i++)
//    {
//        bytesFromFile[i] = (byte)msgByteArray[i];
//        Console.Write(bytesFromFile[i]);
//    }

//    //display decoded messages
//    Console.Write("\nDecoded message: ");
//    Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
//    Console.ReadLine();
//}
//File.Delete("myMessage.dat");


//using (StreamWriter sw = File.CreateText("reminders.txt"))
//{
//    sw.WriteLine("Do not forget to eat");
//    sw.WriteLine("Do not forget to take care of yourself");
//    for (int i = 0; i < 10; i++)
//    {
//        sw.Write(i + " ");
//    }
//    insert a new line
//    sw.Write(sw.NewLine);
//}

//Console.WriteLine("File created");

//File.Delete("reminders.txt");

//FileSystemWatcher watcher = new FileSystemWatcher();
//try
//{
//    watcher.Path = @".";
//}
//catch(ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//    return;
//}

//// set up things to be on the lookout for
//watcher.NotifyFilter = NotifyFilters.LastAccess
//    | NotifyFilters.LastWrite
//    | NotifyFilters.FileName
//    | NotifyFilters.DirectoryName;

//// only watch text files
//watcher.Filter = "*.txt";

//// now add the event handlers
//watcher.Changed += (s, e) => Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
//watcher.Created += (s, e) => Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
//watcher.Deleted += (s, e) => Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
//// specify what is done when a file is renamed
//watcher.Renamed += (s, e) => Console.WriteLine($"File: {e.OldFullPath} renamed to {e.FullPath}");
//// begin watching the directory
//watcher.EnableRaisingEvents = true;

//Console.WriteLine(@"Press 'q' to quit app");

//// raise some events
//using(var sw = File.CreateText("Test.txt"))
//{
//    sw.Write("This is some text");
//}
//File.Move("Test.txt", "Test2.txt");
////File.Delete("Test2.txt");

//while (Console.Read() != 'q') ;


var theRadio = new Radio
{
    StationPresets = new() { 89.3, 105.1, 97.1 },
    HasTweeters = true
};
JamesBondCar jbc = new()
{
    CanFly = true,
    CanSubmerge = true,
    TheRadio = new()
    {
        StationPresets = new() { 89.3, 105.1, 97.1 },
        HasTweeters = true
    }
};

List<JamesBondCar> myCars = new()
{
    new JamesBondCar { CanFly=true, CanSubmerge=true,TheRadio = theRadio},
    new JamesBondCar { CanFly=true, CanSubmerge=false,TheRadio = theRadio},
    new JamesBondCar { CanFly=false, CanSubmerge=true,TheRadio = theRadio},
    new JamesBondCar { CanFly=false, CanSubmerge=false,TheRadio = theRadio},
};

Person p = new Person
{
    FirstName = "James",
    IsAlive = true,
};

SaveAsXmlFormat(jbc, "CarData.xml");
Console.WriteLine("Saved car in XML format");

SaveAsXmlFormat(p, "PersonData.xml");
Console.WriteLine("Saved person in XML format");

SaveAsXmlFormat(myCars, "CarCollection.xml");
Console.WriteLine("Saved list of cars");

JamesBondCar savedCar = ReadAsXmlFormat<JamesBondCar>("CarData.xml");
Console.WriteLine("Original car:\t {0}", jbc.ToString());
Console.WriteLine("Read car: \t {0}", savedCar.ToString());

Console.WriteLine("Reading saved Cars");
List<JamesBondCar> savedCars = ReadAsXmlFormat<List<JamesBondCar>>("CarCollection.xml");
Console.WriteLine(savedCars.ToString());

SaveAsJsonFormat(jbc, "CarData.json");
Console.WriteLine("Saved car in JSON format");

SaveAsJsonFormat(p, "PersonData.json");
Console.WriteLine("Saved person data");

























static void SaveAsXmlFormat<T>(T objGraph, string fileName)
{
    XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
    using(Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        xmlFormat.Serialize(fStream, objGraph);
    }
}

static T ReadAsXmlFormat<T>(string fileName)
{
    XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
    using (Stream fStream = new FileStream(fileName, FileMode.Open))
    {
        T obj = default;
        obj = (T)xmlFormat.Deserialize(fStream);
        return obj;
    }
}

static void SaveAsJsonFormat<T>(T objGraph, string fileName)
{
    var options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = null,
        IncludeFields = true,
        WriteIndented = true,
    };
    File.WriteAllText(fileName, System.Text.Json.JsonSerializer.Serialize(objGraph, options));
}







public class Radio
{
    [JsonInclude]
    public bool HasTweeters;
    
    [JsonInclude]
    public bool HasSubWoofers;
    
    [JsonInclude]
    public List<double> StationPresets;

    [JsonInclude]
    public string RadioId = "XF-552RR6";

    public override string ToString()
    {
        var presents = string.Join(",", StationPresets.Select(i => i.ToString()).ToList());
        return $"HasTweeters:{HasTweeters} HasSubWoofers:{HasSubWoofers} Station Presets:{presents}";
    }
}

public class Car
{
    [JsonInclude]
    public Radio TheRadio = new Radio();

    [JsonInclude]
    public bool IsHatchBack;

    public override string ToString()
    {
        return $"IsHatchBack:{IsHatchBack} Radio:{TheRadio.ToString()}";
    }
}

[Serializable, XmlRoot(Namespace ="http://www.MyCompany.com")]
public class JamesBondCar : Car
{
    [XmlAttribute]
    [JsonInclude]
    public bool CanFly;
    
    [XmlAttribute]
    [JsonInclude]
    public bool CanSubmerge;

    public override string ToString()
    {
        return $"CanFly:{CanFly}, CanSubmerge:{CanSubmerge} {base.ToString()}";
    }
}

public class Person
{
    [JsonInclude]
    public bool IsAlive = true;
    private int PersonAge = 21;
    private string _fName = string.Empty;

    public string FirstName
    {
        get { return _fName; }
        set {  _fName = value; }
    }

    public override string ToString()
    {
        return $"IsAlive:{IsAlive} FirstName:{FirstName} Age:{PersonAge}";
    }
}





















