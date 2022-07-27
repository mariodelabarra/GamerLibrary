namespace GamerLibrary.Game.API
{
    public static class DependencyInjection
    {

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            RegisterConfiguration(services);
            RegisterServices(services);
            RegisterRepositories(services);
        }

        public static void RegisterConfiguration(IServiceCollection services)
        {
            
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            //Mapper

            //Services

            //Validators
        }

        public static void RegisterRepositories(IServiceCollection services)
        {
        }
    }
}
