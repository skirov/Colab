namespace Colab.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Colab.Data.Contracts;

    public class Project : AuditInfo
    {
        private ICollection<Team> teams;
        private ICollection<User> members;
        private ICollection<Post> posts;

        public Project()
        {
            this.teams = new HashSet<Team>();
            this.members = new HashSet<User>();
            this.posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; }

        [InverseProperty("CreatedProjects")]
        public virtual User Creator { get; set; }

        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }

        [InverseProperty("Projects")]
        public virtual ICollection<User> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
