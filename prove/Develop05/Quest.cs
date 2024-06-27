public abstract class Quest
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Points { get; private set; }

    public Quest(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public abstract void RecordEvent(ref int totalPoints);

    public abstract bool IsComplete();

    public override string ToString()
    {
        return $"{this.GetType().Name}|{Name}|{Description}|{Points}";
    }
}