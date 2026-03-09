using Santander.DeveloperCodingTest.Business;
using Santander.DeveloperCodingTest.Data.Services;
using Santander.DeveloperCodingTest.Data.Services.Contracts;

namespace WebApi.Infrastructure
{
    internal static class InitializationModule
    {

        #region Internal methods
        internal static void InitializeInjections(WebApplicationBuilder builder)
        {
            var hackerNewsApiBaseUrl = builder.Configuration.GetConnectionString("HackerNewsApiBaseUrl");
            builder.Services.AddHttpClient<HackerNewsApiClient>("HackerNewsApiClient", c => c.BaseAddress = new Uri(hackerNewsApiBaseUrl));
            builder.Services.AddScoped(typeof(IBestStoriesApi), typeof(BestStoriesApi));
            builder.Services.AddScoped(typeof(IHackerNewsApi), typeof(HackerNewsApi));
            builder.Services.AddScoped(typeof(HackerNewsBusiness));
            builder.Services.AddScoped(typeof(StoriesSelector));
        }
        #endregion

    }
}