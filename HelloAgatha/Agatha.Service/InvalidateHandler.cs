using Agatha.Model;

namespace Agatha.Service
{
    public class InvalidateHandler : RequestHandler<InvalidateHelloWorldRequest, InvalidateResponse>
    {
        public InvalidateHandler()
        {
        }

        public override InvalidateResponse Response(InvalidateHelloWorldRequest request)
        {
            var helloWorldResponse = CreateTypedResponse();
            helloWorldResponse.Message = "Invalidate";
            return helloWorldResponse;
        }
    }
}