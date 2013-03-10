namespace Agatha.Service
{
    using System;
    using System.Globalization;
    using Model;

    public class WelcomeMessageHandler : RequestHandler<WelcomeMessageRequest, WelcomeMessageResponse>
    {
        public override WelcomeMessageResponse Response(WelcomeMessageRequest request)
        {
            var welcomeMessageResponse = CreateTypedResponse();
            welcomeMessageResponse.WelcomeMessage = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture);
            return welcomeMessageResponse;
        }
    }
}