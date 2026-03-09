using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text.Json;

namespace Santander.DeveloperCodingTest.Data.Services
{
    /// <summary>
    /// Represents the HackerNews API client.
    /// </summary>
    public sealed class HackerNewsApiClient : IDisposable
    {

        #region Fields
        private readonly HttpClient httpClient;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="HackerNewsApiClient"/> class.
        /// </summary>
        public HackerNewsApiClient(HttpClient httpClient, ILogger<HackerNewsApiClient> logger)
        {
            this.httpClient = httpClient;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Sends a GET request to the specified URI suffix and returns the value that results from deserializing the response body as JSON in an asyncronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlSuffix"></param>
        /// <returns>The <see cref="Task"/> object representing the asyncronous operation.</returns>
        public async Task<T?> GetFromJsonAsync<T>(string urlSuffix)
        {
            return await httpClient.GetFromJsonAsync<T>(urlSuffix, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        }

        /// <summary>
        /// Releases the unmanaged resources of the and disposes the managed resources used by the instance.
        /// </summary>
        public void Dispose() => httpClient?.Dispose();
        #endregion

    }
}