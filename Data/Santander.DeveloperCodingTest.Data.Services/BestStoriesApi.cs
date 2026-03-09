using Santander.DeveloperCodingTest.Data.Services.Contracts;
using System.Net.Http.Json;
using System.Text.Json;

namespace Santander.DeveloperCodingTest.Data.Services
{
    /// <summary>
    /// Represents the best stories API service provider.
    /// </summary>
    public class BestStoriesApi : IBestStoriesApi
    {

        #region Fields
        private readonly HackerNewsApiClient hackerNewsApiClient;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="BestStoriesApi"/> class.
        /// </summary>
        public BestStoriesApi(HackerNewsApiClient hackerNewsApiClient)
        {
            this.hackerNewsApiClient = hackerNewsApiClient;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets a list of the best stories.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asyncronous operation.</returns>
        public async Task<IEnumerable<int>?> GetBestStories()
        {
            var bestStories = await hackerNewsApiClient.GetFromJsonAsync<List<int>>("beststories.json");
            return bestStories;
        }
        #endregion

    }
}