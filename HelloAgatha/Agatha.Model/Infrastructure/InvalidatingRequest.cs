using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Agatha.Common;

namespace Agatha.Model.Infrastructure
{
    public abstract class InvalidatingRequest : Request
    {
        public virtual string MemberNumber { get; set; }

        [IgnoreDataMember]
        public IEnumerable<string> CacheRegionsToBeInvalidated 
        {
            get { return BaseRegionsToBeInvalidated.Select(br => MemberNumber + "|" + br); }
        }

        protected abstract IEnumerable<string> BaseRegionsToBeInvalidated { get; }
    }
}