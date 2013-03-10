namespace Agatha.Model.Infrastructure
{
    using Agatha.Common;
    using Agatha.Common.Caching;

    public class InvalidatingCacheManager : CacheManager
    {
        public InvalidatingCacheManager(CacheConfiguration configuration, ICacheProvider cacheProvider)
            : base(configuration, cacheProvider)
        {
            
        }

        public override Response GetCachedResponseFor(Request request)
        {
            var response = base.GetCachedResponseFor(request);
            if (response == null)
            {
                return null;
            }

            var invalidatesCaching = request as ICanInvalidateCaching;
            if (invalidatesCaching != null)
            {
                if (invalidatesCaching.InvalidateCache)
                {
                    return null; // returning null by passes the cache 
                }
            }

            return response;
        }
    }
}