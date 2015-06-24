namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataModels;
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
            var teamsFromDb = this.Data.Teams.All();

            var teams = from t in teamsFromDb
                           select new TeamSimpleDto()
                           {
                               Id = t.Id,
                               Title = t.Title,
                               Description = t.Description
                           };

            return this.Ok(teams);
        }

        [HttpGet]
        public IHttpActionResult Get([FromBody]int id)
        {
            var teamFromDb = this.Data.Teams.GetById(id);

            var team = new TeamDto
            {
                Id = teamFromDb.Id,
                Title = teamFromDb.Title,
                Description = teamFromDb.Description
                //TODO: Create full DTO
            };

            return this.Ok(team);
        }
    }
}
