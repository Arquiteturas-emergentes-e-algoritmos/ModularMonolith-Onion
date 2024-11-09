using Microsoft.Extensions.DependencyInjection;
using User.Application.Repository;
using User.Application.Services;
using User.Persistence;
using User.Persistence.Repository;

namespace User;

public static class UserModule
{
    public static IServiceCollection AddUserModule(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<UserService>();

        services.AddDbContext<UserDbContext>(options =>
        {
        });

        return services;
    }
}
