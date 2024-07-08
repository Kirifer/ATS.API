using Ats.Core.Authentication;
using Ats.Core.Config;
using Ats.Core.Database;
using Ats.Core.Database.Abstraction.Interface;
using Ats.Core.Extensions;
using Ats.Datalayer;
using Ats.Datalayer.Implementation;
using Ats.Datalayer.Interface;
using Ats.DataLayer;

namespace Ats.Api.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddAtsDatabase(this IServiceCollection services, IMicroServiceConfig envConfig)
        {
            services.AddSingleton<IDbConfig, AtsDbConfig>(
                config => new AtsDbConfig()
                {
                    Host = envConfig.DatabaseConfig!.Host,
                    Port = Convert.ToUInt16(envConfig.DatabaseConfig.Port),
                    Database = "itsquarehub-ats",
                    User = envConfig.DatabaseConfig.User,
                    Password = envConfig.DatabaseConfig.Password,
                    Pooling = true
                }
            );

            services.AddTransient<IDbMigration, AtsDbMigration>();
            services.AddTransient<IDbUserContext>(provider =>
            {
                var userContext = provider.GetService<IUserContext>();
                return new DbUserContext(userContext);
            });
            services.AddTransient(provider =>
            {
                var dbConfig = provider.GetRequiredService<IDbConfig>();
                var dbUserContext = provider.GetRequiredService<IDbUserContext>();
                var dbMigration = provider.GetRequiredService<IDbMigration>();
                return new AtsDbContext(dbConfig, dbUserContext, dbMigration);
            });

            services.AddScoped<IUserRepository, UserRepository>();


            //services.RegisterAssemblies<IDbQuerySingle>("Ats.DataLayer", DependencyLifetime.Transient);
            //services.RegisterAssemblies<IDbQuery>("Ats.DataLayer", DependencyLifetime.Transient);
            //services.RegisterAssemblies<IDbCommand>("Ats.DataLayer", DependencyLifetime.Transient);

            return services;
        }

        public static IApplicationBuilder UseAtsDatabase(this IApplicationBuilder app)
        {
            var migrationRef = app.ApplicationServices.GetService<IDbMigration>();
            migrationRef!.ExecuteMigration();

            return app;
        }
    }
}
