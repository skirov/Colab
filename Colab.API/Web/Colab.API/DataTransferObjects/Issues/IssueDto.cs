namespace Colab.API.DataTransferObjects.Issues
{
    using System;
    using System.Linq.Expressions;
    using System.Runtime.Serialization;

    using Colab.Models;
    using Colab.API.DataTransferObjects.Users;

    [DataContract]
    public class IssueDto
    {
        public static Expression<Func<Issue, IssueDto>> ToDto
        {
            get
            {
                return issue => new IssueDto
                {
                    Id = issue.Id,
                    Title = issue.Title,
                    Status = issue.Status,
                    Priority = issue.Priority,
                    Reporter = new UserDto
                    {
                        Id = issue.Reporter.Id,
                        UserName = issue.Reporter.UserName
                    },
                    Assignee = new UserDto
                    {
                        Id = issue.Assignee.Id,
                        UserName = issue.Assignee.UserName
                    },
                    TeamId = issue.TeamId,
                };
            }
        }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "priority")]
        public string Priority { get; set; }

        [DataMember(Name = "teamId")]
        public int TeamId { get; set; }

        [DataMember(Name = "assigneeId")]
        public string AssigneeId { get; set; }

        [DataMember(Name = "reporterId")]
        public string ReporterId { get; set; }

        [DataMember(Name = "assignee")]
        public UserDto Assignee { get; set; }

        [DataMember(Name = "reporter")]
        public UserDto Reporter { get; set; }
    }
}