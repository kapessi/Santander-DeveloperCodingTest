using Santander.DeveloperCodingTest.Data.Services.Contracts;
using Santander.DeveloperCodingTest.Entities;

namespace Santander.DeveloperCodingTest.Business
{
    /// <summary>
    /// Represents the Hacker News business class.
    /// </summary>
    public class HackerNewsBusiness
    {

        #region Fields
        private readonly IHackerNewsApi hackerNewsApi;
        private readonly IBestStoriesApi bestStoriesApi;
        private readonly StoriesSelector storiesSelector;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="HackerNewsBusiness"/> class.
        /// </summary>
        /// <param name="hackerNewsApi">The API to get the stories detail.</param>
        /// <param name="firebaseIoApi">The API to get the best stories list.</param>
        /// <param name="storiesSelector">The filter selector to process the stories.</param>
        /// <exception cref="ArgumentNullException">When one the parameters is null.</exception>
        public HackerNewsBusiness(IHackerNewsApi hackerNewsApi, IBestStoriesApi firebaseIoApi, StoriesSelector storiesSelector)
        {
            this.hackerNewsApi = hackerNewsApi ?? throw new ArgumentNullException(nameof(hackerNewsApi));
            this.bestStoriesApi = firebaseIoApi ?? throw new ArgumentNullException(nameof(firebaseIoApi));
            this.storiesSelector = storiesSelector ?? throw new ArgumentNullException(nameof(storiesSelector));
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns the n elements from the best stories.
        /// </summary>
        /// <param name="n">The number of elements to return.</param>
        /// <returns>Returns a <see cref="IEnumerable"/> with the selected elements.</returns>
        public async Task<IEnumerable<HackerNewsStory>> GetStories(int n)
        {
            var stories = new List<HackerNewsStory>();
            var bestStoriesTask = bestStoriesApi.GetBestStories().ConfigureAwait(false);
            var bestStories = await bestStoriesTask;
            var selectedStories = storiesSelector.SelectRandom(n, bestStories);
            foreach (var bestStory in selectedStories)
            {
                var story = await hackerNewsApi.GetStory(bestStory).ConfigureAwait(false);
                if (story != null)
                    stories.Add(story);
            }
            return stories.OrderByDescending(s => s.Score);
        }
        #endregion

    }
}