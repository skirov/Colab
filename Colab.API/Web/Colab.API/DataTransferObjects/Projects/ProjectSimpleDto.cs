namespace Colab.API.DataTransferObjects.Projects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.API.DataTransferObjects.Teams;
    using Colab.Models;

    [DataContract]
    public class ProjectSimpleDto
    {
        public ProjectSimpleDto()
        {
            this.Teams = new List<TeamDto>();
        }

        public static Expression<Func<Project, ProjectSimpleDto>> ToDto
        {
            get
            {
                return project => new ProjectSimpleDto
                {
                    Id = project.Id,
                    Title = project.Title,
                    Description = project.Description,
                    Teams = project.Teams.AsQueryable().Select(TeamSimpleDto.ToDto),
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "teams")]
        public IEnumerable<TeamSimpleDto> Teams { get; set; }
    }
}