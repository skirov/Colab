namespace Colab.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Colab.Data.Contracts;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {
        private ICollection<Project> createdProjects;
        private ICollection<Project> projects; 
        private ICollection<Team> teams;
        private ICollection<Team> createdTeams; 
        private ICollection<Issue> assignedIssues;
        private ICollection<Issue> reportedIssues;
        private ICollection<Message> sentMessages;
        private ICollection<Message> recivedMessages;
        private ICollection<Note> notes;
        private ICollection<Post> posts;

        public User()
        {
            this.createdProjects = new HashSet<Project>();
            this.projects = new HashSet<Project>();
            this.teams = new HashSet<Team>();
            this.createdTeams = new HashSet<Team>();
            this.assignedIssues = new HashSet<Issue>();
            this.reportedIssues = new HashSet<Issue>();
            this.sentMessages = new HashSet<Message>();
            this.recivedMessages = new HashSet<Message>();
            this.notes = new HashSet<Note>();
            this.posts = new HashSet<Post>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<Project> CreatedProjects
        {
            get { return this.createdProjects; }
            set { this.createdProjects = value; }
        }

        public virtual ICollection<Project> Projects
        {
            get { return this.projects; }
            set { this.projects = value; }
        }

        public virtual ICollection<Team> CreatedTeams
        {
            get { return this.createdTeams; }
            set { this.createdTeams = value; }
        }

        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }

        public virtual ICollection<Issue> AssignedIssues
        {
            get { return this.assignedIssues; }
            set { this.assignedIssues = value; }
        }

        public virtual ICollection<Issue> ReportedIssues
        {
            get { return this.reportedIssues; }
            set { this.reportedIssues = value; }
        }

        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

        public virtual ICollection<Message> RecivedMessages
        {
            get { return this.recivedMessages; }
            set { this.recivedMessages = value; }
        }

        public virtual ICollection<Note> Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }

        #region IDeletableEntity
        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
        #endregion

        #region IAuditInfo
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Specifies whether or not the CreatedOn property should be automatically set.
        /// </summary>
        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
