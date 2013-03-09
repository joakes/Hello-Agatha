namespace Agatha.Service
{
    using System.Reflection;
    using Model;
    using ServiceLayer;

    public static class ComponentRegistration
    {
        public static void Register()
        {
            var container = new Ninject.Container(Container.Kernel);
            var config = new ServiceLayerConfiguration(
                    Assembly.GetExecutingAssembly(),
                    typeof(HelloWorldRequest).Assembly,
                    container)
                             {
                                 CacheManagerImplementation = typeof(InvalidatingCacheManager)
                             };

            config.Initialize();
        }
    }
}
