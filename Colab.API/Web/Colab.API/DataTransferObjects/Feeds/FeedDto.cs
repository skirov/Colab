namespace Colab.API.DataTransferObjects.Feeds
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.Models;

    [DataContract]
    public class FeedDto
    {
        public static Expression<Func<Feed, FeedDto>> ToDto
        {
            get
            {
                return user => new FeedDto
                {
                    Id = user.Id,
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }
    }
}