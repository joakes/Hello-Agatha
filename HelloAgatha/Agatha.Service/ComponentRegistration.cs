using Agatha.Model;
using Agatha.Model.Infrastructure;

namespace Agatha.Service
{
    public static class ComponentRegistration
    {
        public static void Register()
        {
            var container = new Ninject.Container(Container.Kernel);
            var config = new ServiceLayer.ServiceLayerConfiguration(
                typeof (HelloWorldHandler).Assembly,
                typeof (HelloWorldRequest).Assembly,
                container)
                {
                    CacheManagerImplementation = typeof (MemberSpecificCacheManager)
                }.RegisterRequestHandlerInterceptor<InvalidatableCachingInterceptor>();
            

            config.Initialize();
        }
    }
}
