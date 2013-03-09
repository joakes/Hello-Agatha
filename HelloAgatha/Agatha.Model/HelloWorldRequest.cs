namespace Agatha.Model
{
    using Common;

    [EnableServiceResponseCaching(Seconds = 60, Region = "HelloWorldRequest")]
    [EnableClientResponseCaching(Seconds = 60, Region = "HelloWorldRequest")]
    public class HelloWorldRequest : BaseRequest, ICanInvalidateCaching
    {
        public bool InvalidateCache { get; set; }

        public HelloWorldRequest() { } // required for serialization

        public HelloWorldRequest(string memberNumber) : base(memberNumber)
        {
            
        }
    }
}