namespace Colab.API.DataTransferObjects.Issues
{
    using System;
    using System.Linq.Expressions;

    using Colab.Models;

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

        public int Id { get; set; }

        public string Title { get; set; }
    }
}