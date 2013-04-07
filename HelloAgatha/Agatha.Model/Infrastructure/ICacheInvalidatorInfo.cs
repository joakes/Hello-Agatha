using System.Collections.Generic;

namespace Agatha.Model.Infrastructure
{
    public interface ICacheInvalidatorInfo
    {
        string MemberNumber { get; } 
        IEnumerable<string> CacheRegionsToBeInvalidated { get; } 
    }
}