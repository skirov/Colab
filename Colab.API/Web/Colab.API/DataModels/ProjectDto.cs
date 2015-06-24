namespace Colab.API.DataModels
{
    using Colab.Models;
    using System;
    using System.Collections.Generic;

    public class ProjectDto : ProjectSimpleDto
    {
        public ProjectDto()
        {
            this.Members = new List<User>();
        }

        public User Creator { get; set; }

        public Feed Feed { get; set; }

        public IEnumerable<User> Members { get; set; }
    }
}