using Autofac;
using NewsApp.Services;
using NewsApp.ViewModels;

namespace NewsApp.DependencyInjection
{
    public static class Bootstrapper
    {
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<NewsService>();

            containerBuilder.RegisterType<MainShell>();
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly)
                .Where(x => x.IsSubclassOf(typeof(BaseViewModel)));



            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
