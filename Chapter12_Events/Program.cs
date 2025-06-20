
Car c1 = new Car("Slugbug", 100, 10);
c1.AboutToBlow += CarIsAlmostDoomed;
c1.AboutToBlow += CarAboutToBlow;

c1.Example += DoingWork;

Car.CarEngineHandler d = CarExploded;
c1.Exploded += d;
Console.WriteLine("***** Speeding up *****");
for (int i = 0; i < 6; i++)
{
    c1.Accelerate(20);
}

c1.Exploded -= d;
Console.WriteLine("***** Speeding up *****");
for (int i = 0;i < 6;i++)
{
    c1.Accelerate(20);
}


static void CarAboutToBlow(object sender, CarEventArgs e)
{
    Console.WriteLine($"{sender} says: {e.msg}");
}

static void CarIsAlmostDoomed(object sender, CarEventArgs e)
{
    Console.WriteLine("=> Critical Message from {0}: {1}", sender, e.msg);
}

static void CarExploded(object sender, CarEventArgs e)
{
    if (sender is Car c)
    {
        Console.WriteLine($"Critical message from {c.PetName}: {e.msg}");
    }
}

static void DoingWork(object sender, CarEventArgs e)
{
    Console.WriteLine("Doing work {0}", e.msg);
}





public class CarEventArgs : EventArgs
{
    public readonly string msg;
    public CarEventArgs(string message)
    {
        msg = message;
    }
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
    public delegate void CarEngineHandler(object sender, CarEventArgs e);

    public event CarEngineHandler Exploded;
    public event CarEngineHandler AboutToBlow;
    public event CarEngineHandler Example;

    ////3.) add registration function for the caller
    //public void RegisterWithCarEngine(CarEngineHandler methodToCall)
    //{
    //    _listOfHandlers += methodToCall;
    //}

    //4.) implement the method to invoke the delegate's invocation list under the correct circumstances
    public void Accelerate(int delta)
    {
        Example?.Invoke(this, new CarEventArgs("The Doing work"));
        
        if (_carIsDead)
        {
            Exploded?.Invoke(this, new CarEventArgs("Sorry the car is dead."));
        }
        else
        {
            CurrentSpeed += delta;
            if (10 == (MaxSpeed - CurrentSpeed))
            {
                AboutToBlow?.Invoke(this, new CarEventArgs("Careful buddy! Gonna blow!"));
            }
            if (CurrentSpeed >= MaxSpeed)
            {
                _carIsDead = true;
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








































