using AvoidsCommunication.DAL.Interfaces;
using AvoidsCommunication.DAL.Repositories;
using AvoidsCommunication.Domain.Entity;
using AvoidsCommunication.Service.Implementations;
using AvoidsCommunication.Service.Interfaces;

namespace AvoidsCommunication
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, UserRepository>();

        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
