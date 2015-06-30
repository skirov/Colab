namespace Colab.API.InputModels
{
    using System.Runtime.Serialization;

    using Colab.Models;

    public class IssueInputModel
    {
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

        public void UpdateEntity(Issue model)
        {
            model.Title = this.Title;
            model.Status = this.Status;
            model.Priority = this.Priority;
            model.TeamId = this.TeamId;
            model.AssigneeId = this.AssigneeId;
        }
    }
}