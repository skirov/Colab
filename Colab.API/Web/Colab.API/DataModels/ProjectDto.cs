namespace Colab.API.DataModels
{
    using Colab.Models;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract()]
    public class ProjectDto : ProjectSimpleDto
    {
        public ProjectDto()
        {
            this.Members = new List<User>();
        }

        [DataMember(Name = "creator")]
        public User Creator { get; set; }

        [DataMember(Name = "feed")]
        public Feed Feed { get; set; }

        [DataMember(Name = "members")]
        public IEnumerable<User> Members { get; set; }
    }
}