namespace Agatha.Client
{
    using System;
    using System.Threading;
    using Common;
    using Common.InversionOfControl;
    using Model;

    class Program
    {
        static void Main()
        {
            InitializeAgatha();

            for (var i = 0; i < 100; i++)
            {
                GetMessage(i % 5 == 0); // invalidate the cache every 5 clicks
                Thread.Sleep(1000);
            }
        }

        private static void GetMessage(bool invalidateCache)
        {
            var requestDispatcher = IoC.Container.Resolve<IRequestDispatcher>();
            var response = requestDispatcher.Get<HelloWorldResponse>(new HelloWorldRequest("123456") { InvalidateCache = invalidateCache });
            Console.WriteLine(response.Message);
        }

        private static void InitializeAgatha()
        {
            var config = new ClientConfiguration(typeof(HelloWorldRequest).Assembly, typeof(Ninject.Container))
                             {
                                 CacheManagerImplementation = typeof(InvalidatingCacheManager)
                             };
            config.Initialize();
        }
    }
}
