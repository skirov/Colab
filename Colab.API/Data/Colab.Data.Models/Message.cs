namespace Colab.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Colab.Data.Contracts;

    public class Message : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string SenderId { get; set; }

        [InverseProperty("SentMessages")]
        public virtual User Sender { get; set; }

        public string RecieverId { get; set; }

        [InverseProperty("RecivedMessages")]
        public virtual User Reciever { get; set; }
    }
}
