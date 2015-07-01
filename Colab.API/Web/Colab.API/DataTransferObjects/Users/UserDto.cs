namespace Colab.API.DataTransferObjects.Users
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.Models;

    [DataContract]
    public class UserDto
    {
        public static Expression<Func<User, UserDto>> ToDto
        {
            get
            {
                return user => new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                };
            }
        }

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "username")]
        public string UserName { get; set; }

        [DataMember(Name = "teamId")]
        public int TeamId { get; set; }
    }
}