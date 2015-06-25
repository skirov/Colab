namespace Colab.API.DataTransferObjects.Issues
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.Models;

    [DataContract]
    public class IssueDto
    {
        public static Expression<Func<Issue, IssueDto>> ToDto
        {
            get
            {
                return user => new IssueDto
                {
                    Id = user.Id,
                    Title = user.Title
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }
    }
}