namespace Colab.API.DataModels
{
    using Colab.Models;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract()]
    public class ProjectSimpleDto
    {
        public ProjectSimpleDto()
        {
            this.Teams = new List<TeamDto>();
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name="title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "teams")]
        public IEnumerable<TeamSimpleDto> Teams { get; set; }
    }
}