using Autofac;
using Microsoft.Extensions.Configuration;
using TeamScheduler.Infrastructure.Extensions;
using TeamScheduler.Infrastructure.Settings;

namespace TeamScheduler.Infrastructure.IOC.Modules
{
    public class SettingsModule : Module
    {
        private readonly IConfiguration configuration;

        public SettingsModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(configuration.GetSettings<JwtSettings>())
                .SingleInstance();
        }
    }
}
