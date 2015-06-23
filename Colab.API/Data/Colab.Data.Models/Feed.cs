namespace Colab.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Colab.Data.Contracts;

    public class Feed : AuditInfo
    {
        private ICollection<Post> posts;

        public Feed()
        {
            this.posts = new HashSet<Post>();
        }

        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }

        [Required]
        public virtual Project Project { get; set; }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
