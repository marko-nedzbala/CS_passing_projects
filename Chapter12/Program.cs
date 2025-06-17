
SimpleMath sm1 = new SimpleMath();
BinaryOp b = new BinaryOp(sm1.Add);
Console.WriteLine("10 + 10 is {0}", b(10, 10));

Console.WriteLine();

SimpleMath sm2 = new SimpleMath();
BinaryOp b2 = new BinaryOp(sm2.Subtract);
Console.WriteLine(b2(4, 6));
DisplayDelegateInfo(b2);

Console.WriteLine();

Car c1 = new Car("Slugbug", 100, 10);
c1.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
Console.WriteLine("***** Speeding up *****");
for(int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}






static void OnCarEngineEvent(string msg)
{
    Console.WriteLine("Message from car object");
    Console.WriteLine(" => {0}", msg);
    Console.WriteLine("************\n");
}






static void DisplayDelegateInfo(Delegate delObj)
{
    foreach (Delegate d in delObj.GetInvocationList())
    {
        Console.WriteLine("Method name: {0}", d.Method);
        Console.WriteLine("Type name: {0}", d.Target);
    }
}

public class SimpleMath
{
    public int Add(int x, int y) => x + y;
    public int Subtract(int x, int y) => x - y;
}

public class Car
{
    public int CurrentSpeed { get; set; }
    public int MaxSpeed { get; set; } = 100;
    public string PetName { get; set; }

    private bool _carIsDead;

    public Car() { }

    public Car(string name, int maxSp, int currSp)
    {
        CurrentSpeed = currSp;
        MaxSpeed = maxSp;
        PetName = name;
    }

    //1.) define the delegate Type
    public delegate void CarEngineHandler(string msgForCaller);

    //2.) define a member variable of this delegate
    private CarEngineHandler _listOfHandlers;

    //3.) add registration function for the caller
    public void RegisterWithCarEngine(CarEngineHandler methodToCall)
    {
        _listOfHandlers = methodToCall;
    }

    //4.) implement the method to invoke the delegate's invocation list under the correct circumstances
    public void Accelerate(int delta)
    {
        if (_carIsDead)
        {
            _listOfHandlers?.Invoke("Sorry the car is dead.");
        }
        else
        {
            CurrentSpeed += delta;
            if (10 == (MaxSpeed - CurrentSpeed))
            {
                _listOfHandlers?.Invoke("Careful buddy! Gonna blow!");
            }
            if (CurrentSpeed >= MaxSpeed)
            {
                _carIsDead = true;
            }
            else
            {
                Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }

}




public delegate int BinaryOp(int x, int y);

