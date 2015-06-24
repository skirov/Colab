namespace Colab.API.DataModels
{
    using Colab.Models;
    using System;
    using System.Collections.Generic;

    public class TeamDto : TeamSimpleDto
    {
        public TeamDto()
        {
            this.Members = new List<User>();
            this.Issues = new List<Issue>();
        }

        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public IEnumerable<Issue> Issues { get; set; }

        public IEnumerable<User> Members { get; set; }
    }
}