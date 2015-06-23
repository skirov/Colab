namespace Colab.API.Controllers
{
    using System.Web.Http;

    using Colab.Data;

    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController(IColabData data)
        {
            this.Data = data;
        }

        protected IColabData Data { get; set; }
    }
}
