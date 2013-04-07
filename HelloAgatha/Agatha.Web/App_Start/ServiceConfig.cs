namespace Agatha.Web.App_Start
{
    using Common;
    using Model;
    using Model.Infrastructure;
    using global::Ninject;

    public class ServiceConfig
    {
        public static void Initialize(IKernel kernel)
        {
            var container = new Ninject.Container(kernel);
            var config = new ClientConfiguration(typeof(HelloWorldRequest).Assembly, container)
            {
                RequestDispatcherImplementation = typeof(InvalidatableRequestDispatcher)
            };
            config.Initialize();
        }
    }
}