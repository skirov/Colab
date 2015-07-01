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

            if (teamDto == null)
            {
                return this.NotFound();
            }

            return this.Ok(teamDto);
        }

        [HttpPost]
        public IHttpActionResult AddMember([FromBody]UserDto user)
        {
            var team = this.Data.Teams.GetById(user.TeamId);
            if (team == null)
            {
                return this.NotFound();
            }

            var userIdByEmail = this.Data.Users.All().FirstOrDefault(x => x.UserName == user.UserName).Id;

            var userToAdd = this.Data.Users.GetById(userIdByEmail);
            if (userToAdd == null)
            {
                return this.NotFound();
            }

            team.Members.Add(userToAdd);

            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult AllMembers(int id)
        {
            var team = this.Data.Teams
                           .All()
                           .Where(x => x.Id == id)
                           .Select(TeamDto.ToDto)
                           .FirstOrDefault();

            if (team == null)
            {
                return this.NotFound();
            }

            return this.Ok(team.Members);
        }

        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            var teamToDelete = this.Data.Teams.All().FirstOrDefault(x => x.Id == id);

            if (teamToDelete == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();

            if (teamToDelete.CreatorId != currentUserId)
            {
                return this.Unauthorized();
            }

            this.Data.Teams.Delete(teamToDelete);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
