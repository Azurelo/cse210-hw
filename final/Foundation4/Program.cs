public class Program
{
    public static void Main()
    {
        var activities = new List<Activity>
        {
            new Running("03 July 2024", 30, 3.0),  // miles
            new Cycling("21 April 2024", 45, 20.0), // speed in mph
            new Swimming("30 Nov 2024", 45, 20)   // laps
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}