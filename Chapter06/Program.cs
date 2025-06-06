
Car myCar = new Car(80) { Speed = 50 };

Console.WriteLine("My car is going {0} MPH", myCar.Speed);
















Console.ReadLine();













class Car
{
    public readonly int MaxSpeed;
    private int _currSpeed;

    public Car(int max)
    {
        MaxSpeed = max;
    }

    public Car()
    {
        MaxSpeed = 55;
    }

    public int Speed
    {
        get { return _currSpeed; }
        set
        {
            _currSpeed = value;
            if (_currSpeed > MaxSpeed)
            {
                _currSpeed = MaxSpeed;
            }
        }
    }
}




