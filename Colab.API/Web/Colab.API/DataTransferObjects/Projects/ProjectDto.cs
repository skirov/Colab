namespace Colab.API.DataTransferObjects.Projects
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.API.DataTransferObjects.Teams;
    using Colab.Models;

    using Colab.API.DataTransferObjects.Users;
    using System;

    [DataContract]
    public class ProjectDto : ProjectSimpleDto
    {
        public new static Expression<Func<Project, ProjectDto>> ToDto
        {
            get
            {
                return project => new ProjectDto
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Description,
                    Creator = new UserDto
                    {
                        Id = project.Creator.Id,
                        UserName = project.Creator.UserName
                    },
                    Teams = project.Teams.AsQueryable().Select(TeamSimpleDto.ToDto),
                    Members = project.Members.AsQueryable().Select(UserDto.ToDto)
                };
            }
        }

        public ProjectDto()
        {
            this.Members = new List<UserDto>();
        }

        [DataMember(Name = "creator")]
        public UserDto Creator { get; set; }

        // TODO: Do you need this in the DTO?
        [DataMember(Name = "feed")]
        public Feed Feed { get; set; }

        [DataMember(Name = "members")]
        public IEnumerable<UserDto> Members { get; set; }
    }
}