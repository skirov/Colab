namespace Colab.API.DataModels
{
    using Colab.Models;
    using System;
    using System.Collections.Generic;

    public class ProjectSimpleDto
    {
        public ProjectSimpleDto()
        {
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IEnumerable<TeamSimpleDto> TeamsSimple { get; set; }
    }
}