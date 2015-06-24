namespace Colab.API.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Colab.Data;
    using Colab.Models;
    using Colab.API.DataModels;

    public class TeamController : BaseApiController
    {
        private IColabData data;

        public TeamController(IColabData data)
            : base(data)
        {
            this.data = data;
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

            this.data.Teams.Add(newTeam);
            this.data.SaveChanges();

            return Ok(newTeam.Id);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var teamsFromDB = this.data.Teams.All();

            var teams = from t in teamsFromDB
                           select new TeamSimpleDto()
                           {
                               Id = t.Id,
                               Title = t.Title,
                               Description = t.Description
                           };

            return Ok(teams);
        }

        [HttpGet]
        public IHttpActionResult Get([FromBody]int id)
        {
            var teamFromDB = this.data.Teams.GetById(id);

            var team = new TeamDto
            {
                Id = teamFromDB.Id,
                Title = teamFromDB.Title,
                Description = teamFromDB.Description
                //TODO: Create full DTO
            };

            return Ok(team);
        }
    }
}
