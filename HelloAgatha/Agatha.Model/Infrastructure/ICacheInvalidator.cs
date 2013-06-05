using Agatha.Common;
using Agatha.Common.Caching;

namespace Agatha.Model.Infrastructure
{
    public interface ICacheInvalidator
    {
        void InvalidateAnyApplicableCacheRegions(Request request);
    }

    public class CacheInvalidator : ICacheInvalidator
    {
        private readonly ICacheManager _cacheManager;

        public CacheInvalidator(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public void InvalidateAnyApplicableCacheRegions(Request request)
        {
            var invalidator = request as InvalidatingRequest;

            if (invalidator == null)
                return;

            var regions = invalidator.CacheRegionsToBeInvalidated;
            foreach (var region in regions)
            {
                _cacheManager.Clear(region);
            }
        }
    }
}