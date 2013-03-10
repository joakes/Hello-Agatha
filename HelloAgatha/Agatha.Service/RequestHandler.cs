namespace Agatha.Service
{
    using Common;

    public abstract class RequestHandler<TRequest, TResponse> : ServiceLayer.RequestHandler<TRequest, TResponse> 
        where TRequest : Request
        where TResponse : Response
    {
        public override Response Handle(TRequest request)
        {
            return Response(request);
        }

        public abstract TResponse Response(TRequest request);
    }
}