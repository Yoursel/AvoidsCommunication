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
            services.AddScoped<IBaseRepository<Rambling>, RamblingRepository>();
            services.AddScoped<IBaseRepository<Comment>, CommentRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRamblingService, RamblingService>();
            services.AddScoped<ICommentService, CommentService>();
        }
    }
}
