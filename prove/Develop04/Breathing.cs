public class Breathing : Activity
{
    //using base activity constructor and passing in duration entered by user
    public Breathing(int duration)
        : base(duration, "Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void PerformActivity()
    {
        Start();
        SpinnerAnimation(5);
        for (int i = 0; i < _duration / 6; i++) 
        {
            Console.WriteLine("Breathe in...");
            Pause("", 3);
            Console.WriteLine("Breathe out...");
            Pause("", 3);
        }
        End();
    }
}
