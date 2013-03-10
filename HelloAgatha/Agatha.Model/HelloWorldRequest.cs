namespace Agatha.Model
{
    using Common;
    using Infrastructure;

    [EnableServiceResponseCaching(Seconds = 60, Region = "HelloWorldRequest")]
    [EnableClientResponseCaching(Seconds = 60, Region = "HelloWorldRequest")]
    public class HelloWorldRequest : BaseRequest
    {
        public HelloWorldRequest() { } // required for serialization

        public HelloWorldRequest(string memberNumber) : base(memberNumber)
        {
            
        }
    }
}