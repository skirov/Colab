namespace Colab.API.DataTransferObjects.Messages
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.API.DataTransferObjects.Users;
    using Colab.Models;

    [DataContract]
    public class MessageDto
    {
        public static Expression<Func<Message, MessageDto>> ToDto
        {
            get
            {
                return message => new MessageDto
                {
                    Id = message.Id,
                    Title = message.Title,
                    Body = message.Body,
                    Sender = new UserDto
                    {
                        Id = message.Sender.Id,
                        UserName = message.Sender.UserName
                    },
                    Reciever = new UserDto
                    {
                        Id = message.Reciever.Id,
                        UserName = message.Reciever.UserName
                    }
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "sender")]
        public UserDto Sender { get; set; }

        [DataMember(Name = "reciever")]
        public UserDto Reciever { get; set; }
    }
}