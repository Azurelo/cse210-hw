namespace QuestTrackerApp
{
    public class ListQuest : Quest
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ListQuest(string name, string description, int points, int targetCount, int currentCount = 0, int bonusPoints = 0)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = currentCount;
            _bonusPoints = bonusPoints;
        }

        public override void RecordEvent(ref int totalPoints)
        {
            _currentCount++;
            totalPoints += Points;

            if (_currentCount == _targetCount)
            {
                totalPoints += _bonusPoints;
                Console.WriteLine($"{Name} completed! You earned {Points} points and a bonus of {_bonusPoints} points.");
            }
            else
            {
                Console.WriteLine($"{Name} event recorded ({_currentCount}/{_targetCount}). You earned {Points} points.");
            }
        }

        public override bool IsComplete()
        {
            return _currentCount >= _targetCount;
        }

        public override string ToString()
        {
            return base.ToString() + $"|{_targetCount}|{_currentCount}|{_bonusPoints}";
        }
    }
}
