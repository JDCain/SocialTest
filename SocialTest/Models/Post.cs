using System;

namespace SocialTest.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
    }
    public class PostDisplay
    {
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime Posted { get; set; }
    }
}