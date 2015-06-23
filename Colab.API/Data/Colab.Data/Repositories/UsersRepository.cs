namespace Colab.Data.Repositories
{
    using System;
    using System.Linq;

    using Colab.Data;
    using Colab.Data.Repositories.Base;
    using Colab.Data.Repositories.Contracts;
    using Colab.Models;

    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(IColabDbContext context)
            : base(context)
        {
        }

        public User GetByUsername(string username)
        {
            return this.All().FirstOrDefault(x => x.UserName == username);
        }

        public User GetById(string id)
        {
            return this.All().FirstOrDefault(x => x.Id == id);
        }

        public override void Delete(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
