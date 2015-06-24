namespace Colab.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Colab.Data.Contracts;

    public class Team : AuditInfo
    {
        private ICollection<User> members;
        private ICollection<Issue> issues;

        public Team()
        {
            this.members = new HashSet<User>();
            this.issues = new HashSet<Issue>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public string CreatorId { get; set; }

        [InverseProperty("CreatedTeams")]
        public virtual User Creator { get; set; }

        public virtual ICollection<Issue> Issues
        {
            get { return this.issues; }
            set { this.issues = value; }
        }

        [InverseProperty("Teams")]
        public virtual ICollection<User> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }
    }
}
