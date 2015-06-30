namespace Colab.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Colab.Models;

    public interface IColabDbContext : IDisposable
    {
        DbContext DbContext { get; }

        IDbSet<Issue> Issues { get; set; }

        IDbSet<Message> Messages { get; set; }

        IDbSet<Note> Notes { get; set; }

        IDbSet<Post> Posts { get; set; }

        IDbSet<Project> Projects { get; set; }

        IDbSet<Team> Teams { get; set; }

        int SaveChanges();

        void ClearDatabase();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}
