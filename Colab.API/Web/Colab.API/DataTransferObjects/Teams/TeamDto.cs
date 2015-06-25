namespace Colab.API.DataTransferObjects.Teams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.API.DataTransferObjects.Issues;
    using Colab.API.DataTransferObjects.Projects;
    using Colab.API.DataTransferObjects.Users;
    using Colab.Models;

    [DataContract]
    public class TeamDto : TeamSimpleDto
    {
        public TeamDto()
        {
            this.Members = new List<UserDto>();
            this.Issues = new List<IssueDto>();
        }

        public static new Expression<Func<Team, TeamDto>> ToDto
        {
            get
            {
                return team => new TeamDto
                {
                    Id = team.Id,
                    Title = team.Title,
                    Description = team.Description,
                    ProjectId = team.ProjectId,
                    Project = new ProjectDto
                    {
                        Id = team.Project.Id,
                        Title = team.Project.Title,
                        Creator = new UserDto
                        {
                            Id = team.Project.CreatorId,
                            UserName = team.Project.Creator.UserName
                        },
                        Description = team.Project.Description,
                        Teams = team.Project.Teams.AsQueryable().Select(TeamSimpleDto.ToDto),
                        Members = team.Project.Members.AsQueryable().Select(UserDto.ToDto)
                    },
                    Issues = team.Issues.AsQueryable().Select(IssueDto.ToDto),
                    Members = team.Members.AsQueryable().Select(UserDto.ToDto)
                };
            }
        }

        [DataMember(Name = "projectId")]
        public int ProjectId { get; set; }

        [DataMember(Name = "project")]
        public ProjectDto Project { get; set; }

        [DataMember(Name = "issues")]
        public IEnumerable<IssueDto> Issues { get; set; }

        [DataMember(Name = "members")]
        public IEnumerable<UserDto> Members { get; set; }
    }
}