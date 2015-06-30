namespace Colab.API.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Colab.Data;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public abstract class BaseApiController : ApiController
    {
        protected BaseApiController(IColabData data)
        {
            this.Data = data;
        }

        protected IColabData Data { get; set; }
    }
}
