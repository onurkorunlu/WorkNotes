using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkNotes.Business.Interfaces;
using WorkNotes.Business.Services;
using WorkNotes.Core;
using WorkNotes.DataAccess.Interfaces;
using WorkNotes.DataAccess.Services;

namespace WorkNotes.Configuration
{
    public class Configurations
    {
        public static void SetConfigurations(IConfiguration configuration)
        {
            ConfigurationCache.Instance.Add("MongoDbConnectionString", configuration.GetSection("MongoConnection:ConnectionString").Value);
            ConfigurationCache.Instance.Add("MongoDbName", configuration.GetSection("MongoConnection:Database").Value);
        }

        public static void RegisterServices()
        {
            AppServiceProvider.Instance.RegisterAsSingleton(typeof(IMapper), AutoMapperBuilder.GetMapper());
        }

        public static void RegisterBusinessServices()
        {
            AppServiceProvider.Instance.Register(typeof(IProjectService), new ProjectService());
            AppServiceProvider.Instance.Register(typeof(ICheckInService), new CheckInService());
            AppServiceProvider.Instance.Register(typeof(IApplicationService), new ApplicationService());
        }

        public static void RegisterDataAccessServices()
        {
            AppServiceProvider.Instance.Register(typeof(IProjectDataAccess), new ProjectDataAccess());
            AppServiceProvider.Instance.Register(typeof(IApplicationDataAccess), new ApplicationDataAccess());
        }

    }
}
