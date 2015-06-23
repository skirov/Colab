namespace Colab.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Colab.Data.Contracts;
    using Colab.Data.Migrations;
    using Colab.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ColabDbContext : IdentityDbContext<User>, IColabDbContext
    {
        public ColabDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ColabDbContext, DefaultMigrationConfiguration>());
        }

        public virtual IDbSet<Feed> Feeds { get; set; }

        public virtual IDbSet<Issue> Issues { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Note> Notes { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Project> Projects { get; set; }

        public virtual IDbSet<Team> Teams { get; set; }

        public DbContext DbContext
        {
            get { return this; }
        }

        public static ColabDbContext Create()
        {
            return new ColabDbContext();
        }

        public void ClearDatabase()
        {
            throw new System.NotImplementedException();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
