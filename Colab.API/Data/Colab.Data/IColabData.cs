namespace Colab.Data
{
    using System;

    using Colab.Data.Contracts;
    using Colab.Data.Repositories.Contracts;
    using Colab.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IColabData : IDisposable
    {
        IRepository<Issue> Issues { get; }

        IRepository<Message> Messages { get; }

        IRepository<Note> Notes { get; }

        IRepository<Post> Posts { get; }

        IRepository<Project> Projects { get; }

        IRepository<Team> Teams { get; }

        IUsersRepository Users { get; }

        IRepository<IdentityRole> Roles { get; }

        IColabDbContext Context { get; }

        int SaveChanges();
    }
}
