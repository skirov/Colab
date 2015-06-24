namespace Colab.API.DataModels
{
    using Colab.Models;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract()]
    public class TeamDto : TeamSimpleDto
    {
        public TeamDto()
        {
            this.Members = new List<User>();
            this.Issues = new List<Issue>();
        }

        [DataMember(Name = "projectId")]
        public int ProjectId { get; set; }

        [DataMember(Name = "project")]
        public Project Project { get; set; }

        [DataMember(Name = "issues")]
        public IEnumerable<Issue> Issues { get; set; }

        [DataMember(Name = "members")]
        public IEnumerable<User> Members { get; set; }
    }
}