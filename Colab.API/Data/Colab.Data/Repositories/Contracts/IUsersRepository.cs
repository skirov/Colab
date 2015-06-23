namespace Colab.Data.Repositories.Contracts
{
    using Colab.Data.Contracts;
    using Colab.Models;

    public interface IUsersRepository : IRepository<User>
    {
        User GetByUsername(string username);

        User GetById(string id);
    }
}
