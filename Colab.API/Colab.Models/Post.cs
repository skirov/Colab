namespace Colab.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Body { get; set; }

        public int CreatorId { get; set; }

        public int FeedId { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual User Creator { get; set; }

        public virtual Feed Feed { get; set; }
    }
}
