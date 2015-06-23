namespace Colab.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Note
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime CreationDate { get; set; }

        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }
    }
}
