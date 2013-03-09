namespace Agatha.Service
{
    using System;
    using System.Globalization;
    using global::Ninject;
    using global::Ninject.Modules;

    public interface IFoo {
        string GetMessage();
    }

    public class Foo : IFoo {
        public string GetMessage()
        {
            return DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
        }
    }

    public class ClientModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IFoo>().To<Foo>();
        }
    }

    public class Container
    {
        static Container()
        {
            if (Kernel == null)
            {
                Kernel = new StandardKernel(new ClientModule());
            }   
        }

        public static IKernel Kernel { get; set; }
    }
}
