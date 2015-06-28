namespace Colab.API.Controllers
{
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Posts;
    using Colab.Data;
    using Colab.Models;

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

            return this.Ok();
        }
    }
}