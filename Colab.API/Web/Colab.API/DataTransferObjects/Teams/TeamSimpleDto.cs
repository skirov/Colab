namespace Colab.API.DataTransferObjects.Teams
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.Models;
    using Colab.API.DataTransferObjects.Projects;

    [DataContract]
    public class TeamSimpleDto
    {
        public static Expression<Func<Team, TeamSimpleDto>> ToDto
        {
            get
            {
                return team => new TeamSimpleDto
                {
                    Id = team.Id,
                    Title = team.Title,
                    ProjectId = team.ProjectId,
                    Description = team.Description,
                    CreatorId = team.CreatorId
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "creatorId")]
        public string CreatorId { get; set; }

        [DataMember(Name = "projectId")]
        public int ProjectId { get; set; }

        [DataMember(Name = "project")]
        public ProjectDto Project { get; set; }
    }
}