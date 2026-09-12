using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Setting Up and Programming the Arduino for Absolute Beginners",
            "Paul McWhorter",
            620);

        video1.AddComment(new Comment(
            "Jonah",
            "This was a very helpful tutorial."));
        video1.AddComment(new Comment(
            "Divine",
            "I learned a lot from this video."));
        video1.AddComment(new Comment(
            "Dorothy",
            "The explanation was easy to understand."));
        video1.AddComment(new Comment(
            "David",
            "I would like to see more robotics videos."));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Introduction to C# Programming",
            "Code World",
            845);

        video2.AddComment(new Comment(
            "Daniel",
            "C# is becoming my favorite programming language."));
        video2.AddComment(new Comment(
            "Ama",
            "The examples were very clear."));
        video2.AddComment(new Comment(
            "Samuel",
            "This helped me understand classes."));
        video2.AddComment(new Comment(
            "Linda",
            "Great lesson!"));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "Arduino Beginner Project",
            "STEM Projects",
            730);

        video3.AddComment(new Comment(
            "Mavis",
            "I want to try this project."));
        video3.AddComment(new Comment(
            "Peter",
            "The wiring explanation was useful."));
        video3.AddComment(new Comment(
            "Divine",
            "Can you make another Arduino tutorial?"));
        video3.AddComment(new Comment(
            "James",
            "Excellent project idea."));

        videos.Add(video3);

        // Video 4
        Video video4 = new Video(
            "Understanding Artificial Intelligence",
            "Future Tech",
            915);

        video4.AddComment(new Comment(
             "Alex",
            "AI is very interesting."));
        video4.AddComment(new Comment(
            "Grace",
            "This video explained AI very well."));
        video4.AddComment(new Comment(
            "Robert",
            "I learned something new today."));
        video4.AddComment(new Comment(
            "Emma",
            "Please make a part two."));

        videos.Add(video4);

        // Display all videos and their comments.
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}