public class Breathing : Activity
{
    public Breathing(int duration)
        : base(duration, "Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void PerformActivity()
    {
        Start();
        for (int i = 0; i < _duration / 6; i++) // Assuming 6 seconds per breath cycle
        {
            Console.WriteLine("Breathe in...");
            PauseWithAnimation("", 3);
            Console.WriteLine("Breathe out...");
            PauseWithAnimation("", 3);
        }
        End();
    }
}
