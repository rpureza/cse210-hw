

using System;
using System.Collections.Generic;

class Comment
{
    public string Author { get; set; }
    public string Text { get; set; }

    public Comment(string author, string text)
    {
        Author = author;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return new List<Comment>(comments);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create and add videos
        Video video1 = new Video("Introduction to C#", "Alice", 300);
        video1.AddComment(new Comment("Bob", "Great video!"));
        video1.AddComment(new Comment("Charlie", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Dave", "I learned a lot."));
        videos.Add(video1);

        Video video2 = new Video("Advanced C# Techniques", "Bob", 600);
        video2.AddComment(new Comment("Alice", "Awesome content!"));
        video2.AddComment(new Comment("Charlie", "Could you do a video on LINQ?"));
        video2.AddComment(new Comment("Eve", "Subscribed!"));
        videos.Add(video2);

        Video video3 = new Video("C# Design Patterns", "Charlie", 900);
        video3.AddComment(new Comment("Bob", "Great explanation of patterns."));
        video3.AddComment(new Comment("Dave", "This is exactly what I needed."));
        video3.AddComment(new Comment("Eve", "Well done!"));
        videos.Add(video3);

        // Display video information
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Author}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
