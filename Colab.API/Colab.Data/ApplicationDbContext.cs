
namespace Colab.Data
{
    using System.Data.Entity;
    using Colab.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Colab.Data.Migrations;

    public class ColabDbContext : IdentityDbContext<User>
    {
        public ColabDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ColabDbContext, Configuration>());
        }

        public static ColabDbContext Create()
        {
            return new ColabDbContext();
        }
    }
}
