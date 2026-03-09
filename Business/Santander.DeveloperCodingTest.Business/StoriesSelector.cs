namespace Santander.DeveloperCodingTest.Business
{
    /// <summary>
    /// Respresents the selector class.
    /// </summary>
    public class StoriesSelector
    {

        #region Public methods
        /// <summary>
        /// Randomly selects n elements from stories.
        /// </summary>
        /// <param name="n">The number of elements to select.</param>
        /// <param name="stories">The list to select from.</param>
        /// <returns>Returns a <see cref="IEnumerable"/> with the selected elements.</returns>
        public IEnumerable<int> SelectRandom(int n, IEnumerable<int>? stories)
        {
            if (stories == null)
                return new List<int>();

            var storiesCount = stories.Count();
            if (storiesCount > n)
                return stories.OrderBy(a => Guid.NewGuid()).Take(n);
            return stories;
        }
        #endregion

    }
}