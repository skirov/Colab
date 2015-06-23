using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colab.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public int SenderId { get; set; }

        public int RecieverId { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Reciever { get; set; }
    }
}
