namespace Colab.Data
{
    using System;

    using Colab.Data.Contracts;
    using Colab.Data.Repositories.Contracts;

    using Microsoft.AspNet.Identity.EntityFramework;

    public interface ISbsData : IDisposable
    {
        IUsersRepository Users { get; }

        IRepository<IdentityRole> Roles { get; }

        IColabDbContext Context { get; }

        int SaveChanges();
    }
}
