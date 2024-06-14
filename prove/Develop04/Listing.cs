public class Listing : Activity
{
    private static List<string> _listingPrompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public Listing(int duration)
        : base(duration, "Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public void PerformActivity()
    {
        Start();
        SpinnerAnimation(5);
        var random = new Random();
        //Get random prompt
        string prompt = _listingPrompts[random.Next(_listingPrompts.Count)];
        Console.WriteLine(prompt);
        Pause("Prepare to begin listing...", 5);
        var startTime = DateTime.Now;
        var items = new List<string>();
        //allow user to keep entering items
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("List an item: ");
            string item = Console.ReadLine();
            items.Add(item);
        }
        Console.WriteLine($"You listed {items.Count} items.");
        End();
    }
}
