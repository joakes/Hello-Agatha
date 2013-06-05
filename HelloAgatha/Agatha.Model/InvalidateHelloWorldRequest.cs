using System.Collections.Generic;
using System.Runtime.Serialization;
using Agatha.Common;
using Agatha.Model.Infrastructure;

namespace Agatha.Model
{
    public class InvalidateHelloWorldRequest : InvalidatingRequest
    {
        public InvalidateHelloWorldRequest() { } // required for serialization

        public InvalidateHelloWorldRequest(string memberNumber)
        {
            MemberNumber = memberNumber;
        }

        protected override IEnumerable<string> BaseRegionsToBeInvalidated
        {
            get { yield return "Worlds"; }
        }
    }
}