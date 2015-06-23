namespace Colab.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class DefaultMigrationConfiguration : DbMigrationsConfiguration<ColabDbContext>
    {
        public DefaultMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }
    }
}
