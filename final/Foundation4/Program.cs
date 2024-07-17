public class Program
{
    public static void Main()
    {
        var activities = new List<Activity>
        {
            new Running("03 Nov 2022", 30, 3.0),  // miles
            new Running("03 Nov 2022", 30, 4.8),  // kilometers
            new Cycling("03 Nov 2022", 45, 20.0), // speed in mph
            new Swimming("03 Nov 2022", 45, 20)   // laps
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}