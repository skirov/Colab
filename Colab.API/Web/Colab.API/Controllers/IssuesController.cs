namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Issues;
    using Colab.Data;

    public class IssuesController : BaseApiController
    {
        public IssuesController(IColabData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var projects = this.Data.Issues
                .All()
                .Select(IssueDto.ToDto)
                .ToList();

            return this.Ok(projects);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var project = this.Data.Issues
                .All()
                .Where(x => x.Id == id)
                .Select(IssueDto.ToDto)
                .FirstOrDefault();

            return this.Ok(project);
        }
    }
}
