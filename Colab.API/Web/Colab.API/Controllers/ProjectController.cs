namespace Colab.API.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Microsoft.AspNet.Identity;

    using Colab.Data;
    using Colab.Models;
    using Colab.API.DataModels;
    
    [Authorize]
    public class ProjectController : BaseApiController
    {
        private IColabData data;

        public ProjectController(IColabData data)
            : base(data)
        {
            this.data = data;
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

            this.data.Projects.Add(newProject);
            this.data.SaveChanges();

            return Ok(newProject.Id);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var projectsFromDB = this.data.Projects.All();

            var projects = from p in projectsFromDB
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

            return Ok(projects);
        }

        [HttpGet]
        public IHttpActionResult Get([FromBody]int id)
        {
            var projectFromDb = this.data.Projects.GetById(id);

            var project = new ProjectSimpleDto
            {
                Id = projectFromDb.Id,
                Title = projectFromDb.Title,
                Description = projectFromDb.Description
                //TODO: Create full DTO
            };

            return Ok(project);
        }
    }
}
