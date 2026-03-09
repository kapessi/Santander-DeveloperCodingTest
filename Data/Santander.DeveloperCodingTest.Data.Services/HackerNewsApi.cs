using Santander.DeveloperCodingTest.Data.Services.Contracts;
using Santander.DeveloperCodingTest.Entities;
using System.Net.Http.Json;
using System.Text.Json;

namespace Santander.DeveloperCodingTest.Data.Services
{
    /// <summary>
    /// /// Represents the Hacker News API service provider.
    /// </summary>
    public class HackerNewsApi : IHackerNewsApi
    {

        #region Fields
        private readonly HackerNewsApiClient hackerNewsApiClient;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="HackerNewsApi"/> class.
        /// </summary>
        public HackerNewsApi(HackerNewsApiClient hackerNewsApiClient)
        {
            this.hackerNewsApiClient = hackerNewsApiClient;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets the story with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the story to get.</param>
        /// <returns>The <see cref="Task"/> object representing the asyncronous operation.</returns>
        public async Task<HackerNewsStory?> GetStory(int id)
        {
            return await hackerNewsApiClient.GetFromJsonAsync<HackerNewsStory>($"item/{id}.json");
        }
        #endregion

    }
}