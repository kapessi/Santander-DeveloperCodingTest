namespace WebApi.Models
{
    /// <summary>
    /// Represents the result of the API.
    /// </summary>
    public class HackerNewsStory
    {
        public string? Title { get; set; }
        public string? Uri { get; set; }
        public string? PostedBy { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Score { get; set; }
        public int CommentCount { get; set; }
    }
}