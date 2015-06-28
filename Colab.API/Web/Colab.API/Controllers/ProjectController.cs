namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Projects;
    using Colab.Data;
    using Colab.Models;

    using Microsoft.AspNet.Identity;
    using Colab.API.DataTransferObjects.Users;

    [Authorize]
    public class ProjectController : BaseApiController
    {
        public ProjectController(IColabData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]ProjectDto project)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var firstProjectMember = this.Data.Users.GetById(currentUserId);

            var newProject = new Project
            {
                Title = project.Title,
                Description = project.Description,
                CreatorId = currentUserId
            };
            newProject.Members.Add(firstProjectMember);

            this.Data.Projects.Add(newProject);
            this.Data.SaveChanges();

            return this.Ok(newProject.Id);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var projects = this.Data.Projects
                .All()
                .Select(ProjectSimpleDto.ToDto)
                .ToList();

            return this.Ok(projects);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var project = this.Data.Projects
                .All()
                .Where(x => x.Id == id)
                .Select(ProjectDto.ToDto)
                .FirstOrDefault();

            return this.Ok(project);
        }

        [HttpPost]
        public IHttpActionResult AddMember([FromBody]UserDto user, [FromUri]int id)
        {
            var project = this.Data.Projects.GetById(id);

            var userToAdd = this.Data.Users.GetById(user.Id);

            project.Members.Add(userToAdd);

            this.Data.Projects.Update(project);
            this.Data.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult AllMembers(int id)
        {
            var foundMembers = this.Data.Projects
                .All()
                .Where(x => x.Id == id)
                .Select(ProjectDto.ToDto)
                .FirstOrDefault()
                .Members;

            return Ok(foundMembers);
        }
    }
}
