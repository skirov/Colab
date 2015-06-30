namespace Colab.Models
{
    using System.ComponentModel.DataAnnotations;

    using Colab.Data.Contracts;

    public class Post : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string Body { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
