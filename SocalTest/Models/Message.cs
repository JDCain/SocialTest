namespace SocialTest.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string Text { get; set; }
    }
}