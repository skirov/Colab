namespace Colab.API.DataTransferObjects.Posts
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.API.DataTransferObjects.Users;
    using Colab.Models;

    [DataContract]
    public class PostDto
    {
        public static Expression<Func<Post, PostDto>> ToDto
        {
            get
            {
                return post => new PostDto
                {
                    Id = post.Id,
                    Body  = post.Body,
                    Creator = new UserDto
                    {
                        Id = post.Creator.Id,
                        UserName = post.Creator.UserName
                    },
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }
        
        [DataMember(Name = "creator")]
        public UserDto Creator { get; set; }
    }
}