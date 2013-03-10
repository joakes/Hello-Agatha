namespace Agatha.Model.Infrastructure
{
    /// <summary>
    /// Allows a request object to specify whether the cache should be ignored for this request.
    /// Works for both client and server side caching
    /// See InvalidatingCacheManager and it's usages
    /// </summary>
    public interface ICanInvalidateCaching
    {
        bool InvalidateCache { get; set; }
    }
}