using Moq;
using Santander.DeveloperCodingTest.Business;
using Santander.DeveloperCodingTest.Entities;
using Santander.DeveloperCodingTest.UnitTest.Mocks;

namespace Santander.DeveloperCodingTest.UnitTest
{
    public sealed class HackerNewsBusinessTest
    {

        #region Fields
        private HackerNewsApiMock hackerNewsApi;
        private BestStoriesApiMock bestStoriesApi;
        private StoriesSelector storiesSelector;
        #endregion

        #region Public methods
        /// <summary>
        /// Initializes the resources for the tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            hackerNewsApi = new HackerNewsApiMock();
            bestStoriesApi = new BestStoriesApiMock();
            storiesSelector = new StoriesSelector();
        }

        /// <summary>
        /// Executes the test Get 1 item from Hacker News in case of Success.
        /// </summary>
        [Test]
        public void TestHackerNewsGet1StorySuccess()
        {
            var n = 1;
            var expectedResult = new List<string> { "eggs", "Toast", "coffee" };
            var mockData = CreateGetBestStoriesMockResult(n);
            bestStoriesApi.GetBestStories(mockData);
            CreateStoriesMock(mockData);
            var business = new HackerNewsBusiness(hackerNewsApi.Object, bestStoriesApi.Object, storiesSelector);
            var result = business.GetStories(n);
            Assert.That(result.Result.Count(), Is.EqualTo(n));
        }

        /// <summary>
        /// Executes the test Get 2 items from Hacker News in case of Success.
        /// </summary>
        [Test]
        public void TestHackerNewsGet2StoriesSuccess()
        {
            var n = 2;
            var expectedResult = new List<string> { "eggs", "Toast", "coffee" };
            var mockData = CreateGetBestStoriesMockResult(n);
            bestStoriesApi.GetBestStories(mockData);
            CreateStoriesMock(mockData);
            var business = new HackerNewsBusiness(hackerNewsApi.Object, bestStoriesApi.Object, storiesSelector);
            var result = business.GetStories(n);
            Assert.That(result.Result.Count(), Is.EqualTo(n));
        }

        /// <summary>
        /// Executes the test Get 3 items from Hacker News in case of Success.
        /// </summary>
        [Test]
        public void TestHackerNewsGet3StoriesSuccess()
        {
            var n = 3;
            var expectedResult = new List<string> { "eggs", "Toast", "coffee" };
            var mockData = CreateGetBestStoriesMockResult(n);
            bestStoriesApi.GetBestStories(mockData);
            CreateStoriesMock(mockData);
            var business = new HackerNewsBusiness(hackerNewsApi.Object, bestStoriesApi.Object, storiesSelector);
            var result = business.GetStories(n);
            Assert.That(result.Result.Count(), Is.EqualTo(n));
        }

        /// <summary>
        /// Executes the test Get 5 items from Hacker News in case of Success.
        /// </summary>
        [Test]
        public void TestHackerNewsGet5StoriesSuccess()
        {
            var n = 5;
            var expectedResult = new List<string> { "eggs", "Toast", "coffee" };
            var mockData = CreateGetBestStoriesMockResult(n);
            bestStoriesApi.GetBestStories(mockData);
            CreateStoriesMock(mockData);
            var business = new HackerNewsBusiness(hackerNewsApi.Object, bestStoriesApi.Object, storiesSelector);
            var result = business.GetStories(n);
            Assert.That(result.Result.Count(), Is.EqualTo(n));
        }

        /// <summary>
        /// Executes the test Get 10 items from Hacker News in case of Success.
        /// </summary>
        [Test]
        public void TestHackerNewsGet10StoriesSuccess()
        {
            var n = 10;
            var expectedResult = new List<string> { "eggs", "Toast", "coffee" };
            var mockData = CreateGetBestStoriesMockResult(n);
            bestStoriesApi.GetBestStories(mockData);
            CreateStoriesMock(mockData);
            var business = new HackerNewsBusiness(hackerNewsApi.Object, bestStoriesApi.Object, storiesSelector);
            var result = business.GetStories(n);
            Assert.That(result.Result.Count(), Is.EqualTo(n));
        }
        #endregion

        #region Private methods
        private IEnumerable<int> CreateGetBestStoriesMockResult(int n)
        {
            var random = new Random();
            var result = new List<int>();
            for (int i = 0; i <= n; i++)
                result.Add(random.Next() * 10000);
            return result;
        }

        private void CreateStoriesMock(IEnumerable<int> idsList)
        {
            var mockSequence = hackerNewsApi.SetupSequence(m => m.GetStory(It.IsAny<int>()));
            foreach (var id in idsList)
            {
                var item = new HackerNewsStory { Id = id };
                mockSequence.ReturnsAsync(item);
            }
        }
        #endregion

    }
}