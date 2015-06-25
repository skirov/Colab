namespace Colab.API.DataTransferObjects.Users
{
    using System;
    using System.Linq.Expressions;

    using Colab.Models;

    public class UserDto
    {
        public static Expression<Func<User, UserDto>> ToDto
        {
            get
            {
                return user => new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
        }

        public string Id { get; set; }

        public string UserName { get; set; }
    }
}