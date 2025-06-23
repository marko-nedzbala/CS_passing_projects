
//Console.Write("Do you want [1] or [2] threads?");
//string threadCount = Console.ReadLine();

//Thread primaryThread = Thread.CurrentThread;
//primaryThread.Name = "Primary";

//Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);

//Printer p = new Printer();

//switch(threadCount)
//{
//    case "2":
//        Thread backgroundThread = new Thread(new ThreadStart(p.PrintNumbers));
//        backgroundThread.Name = "Secondary";
//        backgroundThread.Start();
//        break;
//    case "1":
//        p.PrintNumbers();
//        break;
//    default:
//        Console.WriteLine("Default will give 1 thread");
//        goto case "1";
//}

//Console.WriteLine("Main thread and completed");

Console.WriteLine();

//Console.WriteLine("ID of thread in Main(): {0}", Environment.CurrentManagedThreadId);
//AddParams ap = new AddParams(10, 10);
//Thread t = new Thread(new ParameterizedThreadStart(Add));
//t.Start(ap);
//Thread.Sleep(5);

//Printer p = new Printer();
//Thread background = new Thread(new ThreadStart(p.PrintNumbers));
//background.IsBackground = true;
//background.Start();

//string message = await DoWorkAsync().ConfigureAwait(false);
//Console.WriteLine(message);

string data = await GetStockData();
Console.WriteLine(data);







void Add(object data)
{
    if(data is AddParams ap)
    {
        Console.WriteLine("ID of thread in Add(): {0}", Environment.CurrentManagedThreadId);
        Console.WriteLine($"{ap.a} + {ap.b} is {ap.a + ap.b}");
    }
}

static async Task<string> DoWorkAsync()
{
    return await Task.Run(() =>
    {
        Thread.Sleep(5_000);
        return "Done with work";
    });
}

static async Task<string> GetStockData()
{
    HttpClient client = new HttpClient();
    string stockData = await client.GetStringAsync("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=demo");
    return await Task.Run(() =>
    {
        Console.WriteLine("Download complete");
        return stockData;

    });

    // this is also acceptable
    return stockData;
}





public class Printer
{
    public void PrintNumbers()
    {
        Console.WriteLine("-> {0} is executing PrintNumbers()", Thread.CurrentThread.Name);
        Console.Write("Your numbers: ");
        for(int i = 0; i < 10; i++)
        {
            Console.Write("{0}, ", i);
            Thread.Sleep(2000);
        }
        Console.WriteLine();
    }
}

class AddParams
{
    public int a, b;
    public AddParams(int numb1, int numb2)
    {
        a = numb1;
        b = numb2;
    }
}















































