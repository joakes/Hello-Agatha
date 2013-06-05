using Agatha.Common.Caching;

namespace Agatha.Model.Infrastructure
{
    public class WebCacheCacheProvider : ICacheProvider
    {
        public ICache BuildCache(string region)
        {
            return new WebCache(region);
        }
    }
}