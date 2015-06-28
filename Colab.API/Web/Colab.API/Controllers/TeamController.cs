namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Teams;
    using Colab.API.DataTransferObjects.Users;
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
        public IHttpActionResult Create([FromBody]TeamSimpleDto team)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var firstTeamMember = this.Data.Users.GetById(currentUserId);

            var newTeam = new Team
            {
                Title = team.Title,
                Description = team.Description,
                CreatorId = currentUserId,
                ProjectId = team.ProjectId
            };
            newTeam.Members.Add(firstTeamMember);

            this.Data.Teams.Add(newTeam);
            this.Data.SaveChanges();

            return this.Ok(newTeam.Id);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var teams = this.Data.Teams
                .All()
                .Select(TeamDto.ToDto)
                .ToList();

            return this.Ok(teams);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var teamDto = this.Data.Teams
                .All()
                .Where(x => x.Id == id)
                .Select(TeamDto.ToDto)
                .FirstOrDefault();

            return this.Ok(teamDto);
        }

        [HttpPost]
        public IHttpActionResult AddMember([FromBody]UserDto user, [FromUri]int id)
        {
            var team = this.Data.Teams.GetById(id);

            var userToAdd = this.Data.Users.GetById(user.Id);

            team.Members.Add(userToAdd);

            this.Data.Teams.Update(team);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult AllMembers(int id)
        {
            var foundMembers = this.Data.Teams
                .All()
                .Where(x => x.Id == id)
                .Select(TeamDto.ToDto)
                .FirstOrDefault()
                .Members;

            return this.Ok(foundMembers);
        }
    }
}
