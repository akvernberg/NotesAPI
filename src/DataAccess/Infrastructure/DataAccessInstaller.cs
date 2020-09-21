using DataAccess.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Infrastructure
{
    public static class DataAccessInstaller
    {
        public static IServiceCollection InstallDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var dataAccessConfiguration = new DataAccessConfiguration();
            configuration.Bind(dataAccessConfiguration);

            return serviceCollection
                .AddSingleton(dataAccessConfiguration)
                .AddSingleton<ISQLiteClient, SQLiteClient>();
        }
    }
}