namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Feeds;
    using Colab.Data;
    using Colab.Models;
    using Colab.API.DataTransferObjects.Posts;

    using Microsoft.AspNet.Identity;

    public class FeedController : BaseApiController
    {
        public FeedController(IColabData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult AddPost([FromBody]PostDto post)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var newPost = new Post
            {
                Body = post.Body,
                CreatorId = currentUserId
            };

            return Ok();
        }
    }
}