using Moq;
using Santander.DeveloperCodingTest.Data.Services.Contracts;
using Santander.DeveloperCodingTest.Entities;

namespace Santander.DeveloperCodingTest.UnitTest.Mocks
{
    public class HackerNewsApiMock : Mock<IHackerNewsApi>
    {
        public void GetStory(HackerNewsStory result)
        {
            Setup(m => m.GetStory(It.IsAny<int>())).ReturnsAsync(result);
        }
    }
}