namespace Colab.Data
{
    using System.Data.Entity;

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
    }
}
