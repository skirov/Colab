namespace Colab.API.DataTransferObjects.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.API.DataTransferObjects.Teams;
    using Colab.API.DataTransferObjects.Users;
    using Colab.Models;
    using Colab.API.DataTransferObjects.Posts;

    [DataContract]
    public class ProjectDto : ProjectSimpleDto
    {
        public ProjectDto()
        {
            this.Members = new List<UserDto>();
        }

        public static new Expression<Func<Project, ProjectDto>> ToDto
        {
            get
            {
                return project => new ProjectDto
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Description,
                    CreatedOn = project.CreatedOn,
                    Creator = new UserDto
                    {
                        Id = project.Creator.Id,
                        UserName = project.Creator.UserName
                    },
                    Teams = project.Teams.AsQueryable().Select(TeamSimpleDto.ToDto),
                    Members = project.Members.AsQueryable().Select(UserDto.ToDto),
                    Posts = project.Posts.AsQueryable().OrderByDescending(x => x.Id).Select(PostDto.ToDto)
                };
            }
        }

        [DataMember(Name = "creator")]
        public UserDto Creator { get; set; }

        [DataMember(Name = "members")]
        public IEnumerable<UserDto> Members { get; set; }

        [DataMember(Name = "posts")]
        public IEnumerable<PostDto> Posts { get; set; }
    }
}