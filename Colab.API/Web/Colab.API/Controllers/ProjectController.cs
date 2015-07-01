namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Posts;
    using Colab.API.DataTransferObjects.Projects;
    using Colab.API.DataTransferObjects.Users;
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

        [HttpPost]
        public IHttpActionResult AddPost([FromBody]PostDto post)
        {
            var project = this.Data.Projects
                .All()
                .FirstOrDefault(x => x.Id == post.ProjectId);

            if (project == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();
            var currentUser = this.Data.Users.GetById(currentUserId);

            var newPost = new Post
            {
                Body = post.Body,
                CreatorId = currentUserId,
                ProjectId = post.ProjectId
            };

            this.Data.Posts.Add(newPost);
            this.Data.SaveChanges();

            return this.Ok(new PostDto
            {
                Body = newPost.Body,
                CreatorId = newPost.CreatorId,
                ProjectId = newPost.ProjectId,
                Creator = new UserDto
                {
                    Id = currentUser.Id,
                    UserName = currentUser.UserName
                }
            });
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {

            var currentUserId = this.User.Identity.GetUserId();
            
            var projects = this.Data.Projects
                .All()
                .Where(x => x.CreatorId == currentUserId)
                .Select(ProjectSimpleDto.ToDto)
                .ToList();

            return this.Ok(projects);
        }

        [HttpGet]
        public IHttpActionResult GetPosts(int id)
        {
            var project = this.Data.Projects
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (project == null)
            {
                return this.NotFound();
            }

            var posts = project.Posts
                .AsQueryable()
                .Select(PostDto.ToDto)
                .ToList();

            return this.Ok(posts);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var project = this.Data.Projects
                .All()
                .Where(x => x.Id == id)
                .Select(ProjectDto.ToDto)
                .FirstOrDefault();

            if (project == null)
            {
                return this.NotFound();
            }

            return this.Ok(project);
        }

        [HttpPost]
        public IHttpActionResult AddMember([FromBody]UserDto user, [FromUri]int id)
        {
            var project = this.Data.Projects.GetById(id);
            if (project == null)
            {
                return this.NotFound();
            }

            var userToAdd = this.Data.Users.GetById(user.Id);
            if (userToAdd == null)
            {
                return this.NotFound();
            }

            project.Members.Add(userToAdd);

            this.Data.Projects.Update(project);
            this.Data.SaveChanges();

            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult AllMembers(int id)
        {
            var project = this.Data.Projects
                .All()
                .Where(x => x.Id == id)
                .Select(ProjectDto.ToDto)
                .FirstOrDefault();

            if (project != null)
            {
                return this.Ok(project.Members);
            }

            return this.NotFound();
        }

        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            var projectToDelete = this.Data.Projects
                .All()
                .FirstOrDefault(x => x.Id == id);

            if (projectToDelete == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();

            if (projectToDelete.CreatorId != currentUserId)
            {
                return this.Unauthorized();
            }

            this.Data.Projects.Delete(projectToDelete);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
