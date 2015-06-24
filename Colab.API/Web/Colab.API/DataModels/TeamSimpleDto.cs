namespace Colab.API.DataModels
{
    using Colab.Models;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract()]
    public class TeamSimpleDto
    {
        public TeamSimpleDto()
        {
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}