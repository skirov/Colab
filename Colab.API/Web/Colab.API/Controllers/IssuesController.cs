namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Issues;
    using Colab.Data;
    using Colab.Models;

    public class IssuesController : BaseApiController
    {
        public IssuesController(IColabData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]IssueDto issue)
        {
            var newIssue = new Issue()
            {
                Title = issue.Title,
                Status = issue.Status,
                Priority = issue.Priority,
                TeamId = issue.TeamId,
                ReporterId = issue.ReporterId,
                AssigneeId = issue.AssigneeId
            };

            this.Data.Issues.Add(newIssue);
            this.Data.SaveChanges();


            return Ok(new {
                teamId = issue.TeamId,
                issueId = newIssue.Id
            });
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
