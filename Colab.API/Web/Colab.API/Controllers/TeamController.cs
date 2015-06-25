namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects;
    using Colab.API.DataTransferObjects.Projects;
    using Colab.API.DataTransferObjects.Teams;
    using Colab.Data;
    using Colab.Models;

    using Microsoft.AspNet.Identity;

    public class TeamController : BaseApiController
    {
        public TeamController(IColabData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]ProjectSimpleDto project)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var newTeam = new Team
            {
                Title = project.Title,
                Description = project.Description,
                CreatorId = currentUserId
            };

            this.Data.Teams.Add(newTeam);
            this.Data.SaveChanges();

            return this.Ok(newTeam.Id);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var teams = this.Data.Teams
                .All()
                .Select(TeamSimpleDto.ToDto)
                .ToList();

            return this.Ok(teams);
        }

        [HttpGet]
        public IHttpActionResult Get([FromBody]int id)
        {
            var teamDto = this.Data.Teams
                .All()
                .Where(x => x.Id == id)
                .Select(TeamDto.ToDto)
                .FirstOrDefault();

            return this.Ok(teamDto);
        }
    }
}
