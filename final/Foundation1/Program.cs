using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating mock videos
        Video video1 = new Video("Python Tutorial", "Alice", 600);
        Video video2 = new Video("Cooking 101", "Bob", 1200);
        Video video3 = new Video("Travel Vlog", "Charlie", 1800);

        // Adding comments to videos
        video1.AddComment(new Comment("Dave", "Great tutorial!"));
        video1.AddComment(new Comment("Eve", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Frank", "Clear and concise."));

        video2.AddComment(new Comment("George", "I love this recipe!"));
        video2.AddComment(new Comment("Hannah", "Can't wait to try this."));
        video2.AddComment(new Comment("Julie", "Make the videos longer please!"));
        video2.AddComment(new Comment("Marcus", "Nice."));

        video3.AddComment(new Comment("Ivy", "Beautiful places!"));
        video3.AddComment(new Comment("Jack", "Great video quality."));
        video3.AddComment(new Comment("Kate", "Awesome travel guide!"));

        // Putting videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information about each video
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}