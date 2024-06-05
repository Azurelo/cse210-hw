public class Activity
{
    protected int _duration;
    protected string _name;
    protected string _description;

    public Activity(int duration, string name, string description)
    {
        _duration = duration;
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {_name} activity.");
        Console.WriteLine(_description);
        PauseWithAnimation("Prepare to begin...", 3);
    }

    public void End()
    {
        Console.WriteLine($"Great job! You've completed the {_name} activity for {_duration} seconds.");
        PauseWithAnimation("Ending...", 3);
    }

    public void PauseWithAnimation(string message, int seconds)
    {
        Console.WriteLine(message);
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine();
    }
}