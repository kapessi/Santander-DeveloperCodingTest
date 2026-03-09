namespace WebApi.Helppers
{
    internal static class ResponseMapper
    {
        internal static IEnumerable<Models.HackerNewsStory> MapHackerNewsStory(IEnumerable<Santander.DeveloperCodingTest.Entities.HackerNewsStory> source)
        {
            return source.Select(s => new Models.HackerNewsStory { Title = s.Title, Uri = s.Url, PostedBy = s.By, Time = new DateTime(s.Time.HasValue ? s.Time.Value : 0), CommentCount = s.Kids != null ? s.Kids.Count() : 0, Score = s.Score });
        }
    }
}