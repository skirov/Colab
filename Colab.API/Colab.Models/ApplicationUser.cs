namespace Colab.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<Project> projects;
        private ICollection<Team> teams;
        private ICollection<Issue> issues;
        private ICollection<Message> messages;
        private ICollection<Note> notes;
        
        public User()
        {
            this.projects = new HashSet<Project>();
            this.teams = new HashSet<Team>();
            this.issues = new HashSet<Issue>();
            this.messages = new HashSet<Message>();
            this.notes = new HashSet<Note>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<Project> Projects
        {
            get { return projects; }
            set { projects = value; }
        }

        public virtual ICollection<Team> Teams
        {
            get { return teams; }
            set { teams = value; }
        }

        public virtual ICollection<Issue> Issues
        {
            get { return issues; }
            set { issues = value; }
        }

        public virtual ICollection<Message> Messages
        {
            get { return messages; }
            set { messages = value; }
        }

        public virtual ICollection<Note> Notes
        {
            get { return notes; }
            set { notes = value; }
        }
    }
}
