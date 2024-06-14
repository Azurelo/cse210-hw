public class Activity
{
    protected int _duration;
    protected string _name;
    protected string _description;

    //activity constructor
    public Activity(int duration, string name, string description)
    {
        _duration = duration;
        _name = name;
        _description = description;
    }

    //universl start function
    public void Start()
    {
        Console.WriteLine($"Starting {_name} activity.");
        Console.WriteLine(_description);
        Pause("Prepare to begin the activity", 3);
    }

    //universal end function
    public void End()
    {
        Console.WriteLine($"Great job! You've completed the {_name} activity for {_duration} seconds.");
        Pause("Activity ending soon", 3);
    }
    
    //Pause animation all of the derived activities will use when the user is waiting
    public void Pause(string message, int seconds)
    {
        Console.WriteLine(message);
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000); 
        }
        Console.WriteLine();
    }

    protected void SpinnerAnimation(int durationInSeconds)
    {
        char[] spinnerChars = new[] { '|', '/', '-', '\\' };
        int totalSteps = durationInSeconds * 10; 
        for (int i = 0; i < totalSteps; i++)
        {
            Console.Write($"\r{spinnerChars[i % spinnerChars.Length]}");
            Thread.Sleep(100); 
        }
        Console.WriteLine();
    }
}