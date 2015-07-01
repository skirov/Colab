namespace Colab.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Colab.Data.Contracts;

    public class Issue : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        // Use enum if the values are predifined
        public string Status { get; set; }

        // Use enum if the values are predifined
        public string Priority { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public string AssigneeId { get; set; }

        public string Description { get; set; }

        [InverseProperty("AssignedIssues")]
        public virtual User Assignee { get; set; }

        public string ReporterId { get; set; }

        [InverseProperty("ReportedIssues")]
        public virtual User Reporter { get; set; }
    }
}
