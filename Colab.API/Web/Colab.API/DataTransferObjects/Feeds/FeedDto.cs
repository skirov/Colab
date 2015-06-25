namespace Colab.API.DataTransferObjects.Feeds
{
    using System;
    using System.Linq.Expressions;

    using Colab.Models;

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

        public int Id { get; set; }
    }
}