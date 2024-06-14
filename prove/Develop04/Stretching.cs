//stretching activity added to exceed core requirements
public class Stretching : Activity
{
    public Stretching(int duration)
        : base(duration, "Stretching", "This activity will help you relax by guiding you through a series of stretching exercises. Follow the instructions to perform the stretches.")
    {
    }

    public void PerformActivity()
    {
        Start();
        SpinnerAnimation(5); 
        Console.WriteLine("Stretching activity in progress...");
        Countdown("Hold the stretch", _duration);
        Console.WriteLine("Release the stretch.");
        End();
    }
    //unique countdown animation
    private void Countdown(string message, int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{message} {i}  ");
            System.Threading.Thread.Sleep(1000); 
        }
        Console.WriteLine();
    }
}