public class Reflection : Activity
{
    private static List<string> _reflectionPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static List<string> _reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public Reflection(int duration)
        : base(duration, "Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public void PerformActivity()
    {
        Start();
        var random = new Random();
        string prompt = _reflectionPrompts[random.Next(_reflectionPrompts.Count)];
        Console.WriteLine(prompt);
        for (int i = 0; i < _duration / 10; i++) // Assuming each question takes 10 seconds
        {
            string question = _reflectionQuestions[random.Next(_reflectionQuestions.Count)];
            Console.WriteLine(question);
            PauseWithAnimation("", 10);
        }
        End();
    }
}