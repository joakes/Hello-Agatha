using System.Collections.Generic;
using Agatha.Common;

namespace Agatha.Model
{
    using Infrastructure;

    [EnableClientResponseCaching(Hours = 60, Region = "Worlds")]
    public class HelloWorldRequest : CachableRequest
    {
        public HelloWorldRequest() { } // required for serialization

        public HelloWorldRequest(string memberNumber)
        {
            MemberNumber = memberNumber;
        }
    }
}