namespace Colab.Models
{
    using System;
    using System.Collections.Generic;

    public class Project
    {
        private ICollection<Team> teams;

        private ICollection<User> members;

        public Project()
        {
            this.teams = new HashSet<Team>();
            this.members = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public int CreatorId { get; set; }

        public int FeedId { get; set; }

        public virtual User Creator { get; set; }

        public virtual Feed Feed { get; set; }

        public virtual ICollection<Team> Teams
        {
            get { return teams; }
            set { teams = value; }
        }

        public virtual ICollection<User> Members
        {
            get { return members; }
            set { members = value; }
        }
        
    }
}
