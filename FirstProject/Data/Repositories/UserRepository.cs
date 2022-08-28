using FirstProject.Models;

namespace FirstProject.Data.Repositories
{
    public class UserRepository:IUserRepository
    {
        private FirstProjectContext _firstProject;

        public UserRepository(FirstProjectContext firstProject)
        {
            _firstProject = firstProject;
        }

        public void AddUser(Users user)
        {
            _firstProject.Users.Add(user);
            _firstProject.SaveChanges();
        }

        public bool IsExistEmail(string email)
        {
            return _firstProject.Users.Any(x => x.Email == email);
        }

        public Users user(string email, string password)
        {
            return _firstProject.Users
                .SingleOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
