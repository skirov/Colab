namespace Colab.API.DataTransferObjects.Feeds
{
    using Colab.API.DataTransferObjects.Posts;
    using Colab.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    [DataContract]
    public class FeedDto
    {
        public FeedDto()
        {
            this.Posts = new List<PostDto>();
        }

        public static Expression<Func<Feed, FeedDto>> ToDto
        {
            get
            {
                return feed => new FeedDto
                {
                    Id = feed.Id,
                    ProjectId = feed.ProjectId,
                    Posts = feed.Posts.AsQueryable().Select(PostDto.ToDto)
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "projectId")]
        public int ProjectId { get; set; }

        [DataMember(Name = "members")]
        public IEnumerable<PostDto> Posts { get; set; }
    }
}