namespace Colab.Data
{
    using System;
    using System.Collections.Generic;

    using Colab.Data.Contracts;
    using Colab.Data.Repositories;
    using Colab.Data.Repositories.Base;
    using Colab.Data.Repositories.Contracts;
    using Colab.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ColabData : IColabData
    {
        private readonly IColabDbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ColabData()
            : this(new ColabDbContext())
        {
        }

        public ColabData(IColabDbContext context)
        {
            this.context = context;
        }

        public IRepository<Feed> Feeds
        {
            get { return this.GetRepository<Feed>(); }
        }

        public IRepository<Issue> Issues
        {
            get { return this.GetRepository<Issue>(); }
        }

        public IRepository<Message> Messages
        {
            get { return this.GetRepository<Message>(); }
        }

        public IRepository<Note> Notes
        {
            get { return this.GetRepository<Note>(); }
        }

        public IRepository<Post> Posts
        {
            get { return this.GetRepository<Post>(); }
        }

        public IRepository<Project> Projects
        {
            get { return this.GetRepository<Project>(); }
        }

        public IRepository<Team> Teams
        {
            get { return this.GetRepository<Team>(); }
        }

        public IUsersRepository Users
        {
            get
            {
                return (UsersRepository)this.GetRepository<User>();
            }
        }

        public IRepository<IdentityRole> Roles
        {
            get
            {
                return this.GetRepository<IdentityRole>();
            }
        }

        public IColabDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                if (typeof(T).IsAssignableFrom(typeof(User)))
                {
                    type = typeof(UsersRepository);
                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        private IDeletableEntityRepository<T> GetDeletableEntityRepository<T>() where T : class, IDeletableEntity
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(DeletableEntityRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeof(T)];
        }
    }
}
