namespace Colab.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Colab.Data.Contracts;

    public class Message : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int SenderId { get; set; }

        public int RecieverId { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Reciever { get; set; }
    }
}
