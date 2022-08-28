using FirstProject.Models;

namespace FirstProject.Data.Repositories
{
    public interface IUserRepository
    {
        void AddUser(Users user);
        bool IsExistEmail(string email);

        Users user(string email,string password);
    }
}
