using Santander.DeveloperCodingTest.Entities;

namespace Santander.DeveloperCodingTest.Data.Services.Contracts
{
    /// <summary>
    /// /// Represents the Hacker News API service provider.
    /// </summary>
    public interface IHackerNewsApi
    {

        #region Public methods
        /// <summary>
        /// Gets the story with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the story to get.</param>
        /// <returns>The <see cref="Task"/> object representing the asyncronous operation.</returns>
        Task<HackerNewsStory?> GetStory(int id);
        #endregion

    }
}