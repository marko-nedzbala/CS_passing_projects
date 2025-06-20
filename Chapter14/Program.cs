using System.Diagnostics;
using System.Reflection;

//ListAllRunningProcesses();

AppDomain defaultAD = AppDomain.CurrentDomain;
Console.WriteLine(defaultAD);

Assembly[] loadedAssemblies = defaultAD.GetAssemblies();
Console.WriteLine("Loaded assemblies: {0}", loadedAssemblies);

foreach (Assembly assembly in loadedAssemblies)
{
    Console.WriteLine($"Name: {assembly.GetName().Name}, Version: {assembly.GetName().Version}");
}



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
        string info = "$-> PID: {p.Id}\tName: {p.ProcessName}";
        Console.WriteLine(info);
    }
}

















