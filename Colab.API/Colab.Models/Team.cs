using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colab.Models
{
    public class Team
    {
        private ICollection<User> members;

        private ICollection<Issue> issues;

        public Team()
        {
            this.members = new HashSet<User>();
            this.issues = new HashSet<Issue>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual ICollection<Issue> Issues
        {
            get { return issues; }
            set { issues = value; }
        }

        public virtual ICollection<User> Members
        {
            get { return members; }
            set { members = value; }
        }

    }
}
