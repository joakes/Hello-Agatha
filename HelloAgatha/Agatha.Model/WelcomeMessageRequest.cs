using Agatha.Common;

namespace Agatha.Model
{
    using Infrastructure;

    [EnableServiceResponseCaching(Hours = 60, Region = "Worlds")]
    [EnableClientResponseCaching(Hours = 60, Region = "Worlds")]
    public class WelcomeMessageRequest : CachableRequest
    {
    }
}
