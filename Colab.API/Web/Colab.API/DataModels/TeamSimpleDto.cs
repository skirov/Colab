namespace Colab.API.DataModels
{
    using Colab.Models;
    using System;
    using System.Collections.Generic;

    public class TeamSimpleDto
    {
        public TeamSimpleDto()
        {
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}