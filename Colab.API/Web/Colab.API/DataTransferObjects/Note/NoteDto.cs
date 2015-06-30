namespace Colab.API.DataTransferObjects.Note
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.Models;

    [DataContract]
    public class NoteDto
    {
        public static Expression<Func<Note, NoteDto>> ToDto
        {
            get
            {
                return note => new NoteDto
                {
                    Id = note.Id,
                    Title = note.Title,
                    Body = note.Body,
                    CreatorUserName = note.Creator.UserName
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "creatorUserName")]
        public string CreatorUserName { get; set; }
    }
}