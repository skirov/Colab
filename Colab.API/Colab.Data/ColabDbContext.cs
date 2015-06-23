namespace Colab.Data
{
    using System.Data.Entity;

    using Colab.Data.Migrations;
    using Colab.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ColabDbContext : IdentityDbContext<User>
    {
        public ColabDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ColabDbContext, DefaultMigrationConfiguration>());
        }

        public static ColabDbContext Create()
        {
            return new ColabDbContext();
        }
    }
}
