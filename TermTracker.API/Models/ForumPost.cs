namespace TermTracker.API.Models
{
    public class ForumPost
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string Tag { get; set; }
    }

}
