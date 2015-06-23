namespace Colab.Models
{
    using System.ComponentModel.DataAnnotations;

    using Colab.Data.Contracts;

    public class Note : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }
    }
}
