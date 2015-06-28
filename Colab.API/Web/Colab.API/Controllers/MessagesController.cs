namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Messages;
    using Colab.Data;

    using Microsoft.AspNet.Identity;

    public class MessagesController : BaseApiController
    {
        public MessagesController(IColabData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Send([FromBody]object inputModel)
        {
            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult AllRecivedMessages()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var messages =
                this.Data.Messages
                    .All()
                    .Where(x => x.RecieverId == currentUserId)
                    .Select(MessageDto.ToDto)
                    .ToList();

            return this.Ok(messages);
        }

        [HttpGet]
        public IHttpActionResult AllSentMessages()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var messages =
                this.Data.Messages
                    .All()
                    .Where(x => x.SenderId == currentUserId)
                    .Select(MessageDto.ToDto)
                    .ToList();

            return this.Ok(messages);
        }
    }
}
