namespace Santander.DeveloperCodingTest.Data.Services.Contracts
{
    /// <summary>
    /// Represents the best stories API service provider.
    /// </summary>
    public interface IBestStoriesApi
    {

        #region Public methods
        /// <summary>
        /// Gets a list of the best stories.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asyncronous operation.</returns>
        Task<IEnumerable<int>?> GetBestStories();
        #endregion

    }
}