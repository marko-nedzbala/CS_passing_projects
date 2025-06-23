using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;

//ListAllRunningProcesses();

//Console.WriteLine();

//AppDomain defaultAD = AppDomain.CurrentDomain;
//Console.WriteLine(defaultAD);

//Console.WriteLine();

//Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
//Console.WriteLine("Loaded assemblies: {0}", loadedAssemblies);

//Console.WriteLine();

//foreach (Assembly assembly in loadedAssemblies)
//{
//    Console.WriteLine($"Name: {assembly.GetName().Name}, Version: {assembly.GetName().Version}");
//}

//Console.WriteLine();

//Process theProc = null;
//try
//{
//    theProc = Process.GetProcessById(41104);
//    Console.WriteLine(theProc?.ProcessName);
//}
//catch(ArgumentException ex)
//{
//    Console.WriteLine(ex.Message);
//}

//Console.WriteLine();

//ProcessThreadCollection theThreads = theProc.Threads;

//foreach (ProcessThread pt in theThreads)
//{
//    string info = $"-> Thread ID: {pt.Id}\tStart Time: {pt.StartTime.ToShortTimeString()}\tPriority: {pt.PriorityLevel}";
//    Console.WriteLine(info);
//}

//Console.WriteLine();

//ProcessModuleCollection theMods = theProc.Modules;
//foreach (ProcessModule pm in theMods)
//{
//    string info = $"-> Mod Name: {pm.ModuleName}";
//    Console.WriteLine(info);
//}

//Console.WriteLine();

//Process proc = null;

////try
////{
////    proc = Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "www.facebook.com");
////}
////catch (InvalidOperationException ex)
////{
////    Console.WriteLine(ex.Message);
////}

//Console.WriteLine();

////ProcessStartInfo si = new ProcessStartInfo(@"F:\Downloads\Grammer.docx");
////int i = 0;
////foreach (var verb in si.Verbs)
////{
////    Console.WriteLine($" {i++}. {verb}");
////}

////si.WindowStyle = ProcessWindowStyle.Minimized;
////si.Verb = "Edit";
////si.UseShellExecute = true;
////Process.Start(si);

//Console.WriteLine();


//AppDomain ad = AppDomain.CurrentDomain;
//Console.WriteLine("Name of this domain: {0}", ad.FriendlyName);
//Console.WriteLine("ID of domain in this process: {0}", ad.Id);
//Console.WriteLine("Is this the default domain?: {0}", ad.IsDefaultAppDomain());
//Console.WriteLine("Base directory of this domain: {0}", ad.BaseDirectory);
//Console.WriteLine("Setu info for this domain, App Base: {0}", ad.SetupInformation.ApplicationBase);
//Console.WriteLine("Target framework: {0}", ad.SetupInformation.TargetFrameworkName);

//Console.WriteLine();

//Assembly[] loadedAssemblies2 = ad.GetAssemblies();
//Console.WriteLine("Assemblies loaded in {0}", ad.FriendlyName);
//foreach (Assembly a in loadedAssemblies2)
//{
//    Console.WriteLine($"-> Name: {a.GetName().Name}, Version: {a.GetName().Version}"); ;
//}

//Console.WriteLine();

//AppDomain ad3 = AppDomain.CurrentDomain;
//var lA = ad3.GetAssemblies().OrderBy(x => x.GetName().Name);
//Console.WriteLine("Here are the assemblies loaded in {0}", ad3.FriendlyName);
//foreach (Assembly a in lA)
//{
//    Console.WriteLine($"-> Name: {a.GetName().Name}, Version: {a.GetName().Version}");
//}

//Console.WriteLine();








var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Chapter14_ClassLibrary1.dll");

AssemblyLoadContext lc1 = new AssemblyLoadContext("NewContext1", false);
var cl1 = lc1.LoadFromAssemblyPath(path);
var c1 = cl1.CreateInstance("Chapter14_ClassLibrary1.Car");

AssemblyLoadContext lc2 = new AssemblyLoadContext("NewContext2", false);
var cl2 = lc2.LoadFromAssemblyPath(path);
var c2 = cl2.CreateInstance("Chapter14_ClassLibrary1.Car");

Console.WriteLine("*** Loading Additionl Assemblies in Different Contexts ***");
Console.WriteLine($"Assembly1 Equals(Assembly2) {cl1.Equals(cl2)}");
Console.WriteLine($"Assembly1 == Assembly2 {cl1 == cl2}");
Console.WriteLine($"Class1.Equals(Class2) {c1.Equals(c2)}");
Console.WriteLine($"Class1 = Class2 {c1 == c2}");
































Console.ReadLine();



static void ListAllRunningProcesses()
{
    var runningProcs = 
        from proc
        in Process.GetProcesses(".")
        orderby proc.Id
        select proc;
    
    foreach (var p in runningProcs)
    {
        string info = $"-> PID: {p.Id}\tName: {p.ProcessName}";
        Console.WriteLine(info);
    }
}

















