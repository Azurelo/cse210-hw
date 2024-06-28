namespace QuestTrackerApp
{
    public class EternalQuest : Quest
    {
        public EternalQuest(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override void RecordEvent(ref int totalPoints)
        {
            totalPoints += Points;
            Console.WriteLine($"{Name} event recorded! You earned {Points} points.");
        }

        public override bool IsComplete()
        {
            return false; // EternalQuest is never complete
        }
    }
}
