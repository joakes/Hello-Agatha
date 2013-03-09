namespace Agatha.Service
{
    using System;
    using System.Globalization;
    using Common;
    using Common.Caching;
    using Model;

    public class HelloWorldHandler : RequestHandler<HelloWorldRequest, HelloWorldResponse>
    {
        private readonly IFoo _foo;

        public HelloWorldHandler(IFoo foo, ICacheManager cacheManager) : base(cacheManager)
        {
            _foo = foo;
        }

        public override HelloWorldResponse Response(HelloWorldRequest request)
        {
            var helloWorldResponse = CreateTypedResponse();
            helloWorldResponse.Message = _foo.GetMessage();
            return helloWorldResponse;
        }
    }

    public abstract class RequestHandler<TRequest, TResponse> : ServiceLayer.RequestHandler<TRequest, TResponse> 
        where TRequest : Request
        where TResponse : Response
    {
        protected readonly ICacheManager CacheManager;

        protected RequestHandler(ICacheManager cacheManager)
        {
            this.CacheManager = cacheManager;
        }

        public override Response Handle(TRequest request)
        {
            return Response(request);
        }

        public abstract TResponse Response(TRequest request);
    }
}