using Moq;
using Santander.DeveloperCodingTest.Data.Services.Contracts;

namespace Santander.DeveloperCodingTest.UnitTest.Mocks
{
    public class BestStoriesApiMock : Mock<IBestStoriesApi>
    {
        public void GetBestStories(IEnumerable<int> result)
        {
            Setup(m => m.GetBestStories()).ReturnsAsync(result);
        }
    }
}