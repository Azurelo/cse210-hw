namespace QuestTrackerApp
{
    public class SimpleQuest : Quest
    {
        private bool _isComplete;

        public SimpleQuest(string name, string description, int points, bool isComplete = false)
            : base(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override void RecordEvent(ref int totalPoints)
        {
            if (!_isComplete)
            {
                totalPoints += Points;
                _isComplete = true;
                Console.WriteLine($"{Name} completed! You earned {Points} points.");
            }
            else
            {
                Console.WriteLine($"{Name} is already completed.");
            }
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string ToString()
        {
            return base.ToString() + $"|{_isComplete}";
        }
    }
}
