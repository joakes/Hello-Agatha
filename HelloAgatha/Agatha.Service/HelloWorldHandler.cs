namespace Agatha.Service
{
    using Common.Caching;
    using Model;

    public class HelloWorldHandler : RequestHandler<HelloWorldRequest, HelloWorldResponse>
    {
        private readonly IFoo _foo;

        public HelloWorldHandler(IFoo foo, ICacheManager cacheManager)
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
}