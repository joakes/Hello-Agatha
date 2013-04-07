using System.Collections.Generic;
using System.Runtime.Serialization;
using Agatha.Common;
using Agatha.Model.Infrastructure;

namespace Agatha.Model
{
    public class InvalidateHelloWorldRequest : Request, ICacheInvalidatorInfo
    {
        public InvalidateHelloWorldRequest() { } // required for serialization

        public InvalidateHelloWorldRequest(string memberNumber)
        {
            MemberNumber = memberNumber;
        }

        public string MemberNumber { get; set; }

        [IgnoreDataMember]
        public IEnumerable<string> CacheRegionsToBeInvalidated {
            get { yield return "Worlds"; }
        }
    }
}