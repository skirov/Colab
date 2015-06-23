using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Colab.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime CreationDate { get; set; }

        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }
    }
}
