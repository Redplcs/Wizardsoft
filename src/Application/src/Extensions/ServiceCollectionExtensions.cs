using Microsoft.EntityFrameworkCore;
using Redplcs.Wizardsoft.Database;
using Redplcs.Wizardsoft.Domain;

namespace Redplcs.Wizardsoft.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services, string databaseName)
    {
        return services.AddDatabase(options =>
        {
            options.UseInMemoryDatabase(databaseName);
        });
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, Action<DbContextOptionsBuilder> optionAction)
    {
        services.AddDbContext<ApplicationContext>(optionAction);
        services.AddScoped<ITreeItemRepository, TreeItemRepository>();

        return services;
    }
}
