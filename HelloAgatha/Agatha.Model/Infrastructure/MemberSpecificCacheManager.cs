using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agatha.Common;
using Agatha.Common.Caching;

namespace Agatha.Model.Infrastructure
{
    public class MemberSpecificCacheManager : ICacheManager
    {
		private const string DefaultRegionName = "_defaultRegion";

		private readonly CacheConfiguration configuration;
		private readonly ICacheProvider cacheProvider;
		private ConcurrentDictionary<string, ICache> caches;

        public MemberSpecificCacheManager(CacheConfiguration configuration, ICacheProvider cacheProvider)
		{
			this.configuration = configuration;
			this.cacheProvider = cacheProvider;
            this.caches = new ConcurrentDictionary<string, ICache>();
		}

        private ICache GetCacheForRegion(string region)
        {
            return caches.GetOrAdd(region, r => cacheProvider.BuildCache(r));
        }

        private string GetRegionForRequest(Request request)
        {
            var cachableRequest = request as CachableRequest;
            if (cachableRequest == null)
                throw new ApplicationException(string.Format("The request of type {0} has a cache attribute but does not implement {1}. A request must extend {1} to be cached.", request.GetType(), typeof(CachableRequest).FullName));

            var baseRegion = configuration.GetRegionNameFor(request.GetType()) ?? DefaultRegionName;
            return cachableRequest.MemberNumber + "|" + baseRegion;
        }

		public virtual bool IsCachingEnabledFor(Type requestType)
		{
			return configuration.IsCachingEnabledFor(requestType);
		}

		public virtual Response GetCachedResponseFor(Request request)
		{
            return GetCachedResponseFor(request, GetRegionForRequest(request));
		}

		protected virtual Response GetCachedResponseFor(Request request, string region)
		{
            return GetCacheForRegion(region).GetCachedResponseFor(request);
		}

		public virtual void StoreInCache(Request request, Response response)
		{
			var config = configuration.GetConfigurationFor(request.GetType());
            StoreInCache(request, response, config.Expiration, GetRegionForRequest(request));
		}

		protected virtual void StoreInCache(Request request, Response response, TimeSpan expiration, string region)
		{
			var clone = response.GetShallowCopy(); // shallow copy is sufficient
			clone.IsCached = true;
            GetCacheForRegion(region).Store(request, clone, expiration);
		}

		public virtual void Clear(string region)
		{
            GetCacheForRegion(region).Clear();
		}
    }
}
