using GamerLibrary.Common.Core.API;

namespace GamerLibrary.Game.API
{
    public class Startup : BaseStartUp
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment) 
            : base(configuration, webHostEnvironment)
        {
        }

        public override void ConfigureDepencencies(IServiceCollection services)
        {
            DependencyInjection.ConfigureDependencies(services);
        }
    }
}
