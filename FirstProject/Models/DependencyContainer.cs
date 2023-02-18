using FirstProject.Data.Repositories;

namespace FirstProject.Models
{
    public static class DependencyContainer
    {
        public static void RegisterDependency(IServiceCollection service)
        {
            service.AddScoped<IGroupRepository, GroupRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
