using Microsoft.AspNetCore.Mvc;
using Santander.DeveloperCodingTest.Business;
using WebApi.Helppers;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {

        #region Fields
        private IConfiguration configuration;
        private readonly ILogger<HackerNewsController> logger;
        private readonly HackerNewsBusiness hackerNewsBusiness;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the <see cref="OrderController"/>
        /// </summary>
        /// <param name="configuration">The current environment configuration.</param>
        /// <param name="logger">The logger to work.</param>
        public HackerNewsController(IConfiguration configuration, ILogger<HackerNewsController> logger, HackerNewsBusiness hackerNewsBusiness)
        {
            this.configuration = configuration;
            this.logger = logger;
            this.hackerNewsBusiness = hackerNewsBusiness;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Gets the Hacker News stories.
        /// </summary>
        /// <param name="n">The number of stories to get.</param>
        /// <returns>Returns a <see cref="IEnumerable"/> with the selected elements.</returns>
        [HttpGet(Name = "GetHackerNewsStories")]
        public IEnumerable<HackerNewsStory> Get(int n)
        {
            try
            {
                var stories = ResponseMapper.MapHackerNewsStory(hackerNewsBusiness.GetStories(n).Result);
                return stories;
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "An error ocurred in the request.");
                return new List<HackerNewsStory>();
            }
        }
        #endregion

    }
}