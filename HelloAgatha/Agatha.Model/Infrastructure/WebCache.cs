using System;
using System.Collections;
using System.Web;
using System.Web.Caching;
using Agatha.Common;
using Agatha.Common.Caching;

namespace Agatha.Model.Infrastructure
{
    public class WebCache : ICache
    {
        private const string PathDelimiter = "_";

        protected readonly string Region;
        protected string SessionId { get { return HttpContext.Current.Session.SessionID; }}
        protected Cache Cache { get { return HttpContext.Current.Cache; }}

        public WebCache(string region)
        {
            this.Region = region;
        }

        public Response GetCachedResponseFor(Request request)
        {
            var cachableRequest = AssertCachableRequest(request);
            
            return Cache.Get(GenerateKey(cachableRequest)) as Response;
        }

        private static CachableRequest AssertCachableRequest(Request request)
        {
            var cachableRequest = request as CachableRequest;
            if (cachableRequest == null)
                throw new ApplicationException(
                    string.Format(
                        "The request of type {0} has a cache attribute but does not implement {1}. A request must extend {1} to be cached.",
                        request.GetType(), typeof (CachableRequest).FullName));
            return cachableRequest;
        }

        public void Store(Request request, Response response, TimeSpan expiration)
        {
            var cachableRequest = AssertCachableRequest(request);

            Cache.Insert(GenerateKey(cachableRequest), response, null, Cache.NoAbsoluteExpiration, expiration);
        }

        private string GenerateKey(CachableRequest request)
        {
            var elements = new[] { Region, SessionId, request.CacheKey };
            return string.Join(PathDelimiter, elements);
        }

        public void Clear()
        {
            foreach (DictionaryEntry cachItem in Cache)
            {
                if (cachItem.Key.ToString().StartsWith(Region))
                {
                    Cache.Remove(cachItem.Key.ToString());
                }
            }
        }
    }
}