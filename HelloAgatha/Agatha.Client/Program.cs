using Agatha.Service;

namespace Agatha.Client
{
    using System;
    using System.Threading;
    using Common;
    using Common.InversionOfControl;
    using Model;
    using Model.Infrastructure;

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

            if (invalidateCache)
            {
                var resp = requestDispatcher.Get<InvalidateResponse>(new InvalidateHelloWorldRequest("123456"));
                Console.WriteLine(resp.Message);
            }
            requestDispatcher.Clear();
            var response = requestDispatcher.Get<HelloWorldResponse>(new HelloWorldRequest("123456"));
            Console.WriteLine(response.Message);
        }

        private static void InitializeAgatha()
        {
            var container = new Ninject.Container(Container.Kernel);
            var config = new ClientConfiguration(typeof(HelloWorldRequest).Assembly, container)
                             {
                                 RequestDispatcherImplementation = typeof(InvalidatableRequestDispatcher)
                             };
            config.Initialize();
        }
    }
}
