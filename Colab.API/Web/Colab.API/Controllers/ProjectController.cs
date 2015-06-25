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

            var newProject = new Project
            {
                Title = project.Title,
                Description = project.Description,
                CreatorId = currentUserId
            };

            this.Data.Projects.Add(newProject);
            this.Data.SaveChanges();

            return this.Ok(newProject.Id);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var projectsFromDb = this.Data.Projects.All();

            var projects = from p in projectsFromDb
                           select new ProjectSimpleDto()
                           {
                               Id = p.Id,
                               Title = p.Title,
                               Description = p.Description,
                               Teams = from t in p.Teams
                                       select new TeamSimpleDto()
                                       {
                                           Id = t.Id,
                                           Title = t.Title,
                                           Description = t.Description
                                       }
                           };

            return this.Ok(projects);
        }

        [HttpGet]
        public IHttpActionResult Get([FromBody]int id)
        {
            var projectFromDb = this.Data.Projects.GetById(id);

            var project = new ProjectSimpleDto
            {
                Id = projectFromDb.Id,
                Title = projectFromDb.Title,
                Description = projectFromDb.Description
                // TODO: Create full DTO
            };

            return this.Ok(project);
        }
    }
}
