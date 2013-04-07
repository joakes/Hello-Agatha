using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Agatha.Common;
using Agatha.Common.Caching;

namespace Agatha.Model.Infrastructure
{
    public class InvalidatableRequestDispatcher : RequestDispatcher
    {
        private readonly ICacheInvalidator _cacheInvalidator;

        public InvalidatableRequestDispatcher(IRequestProcessor requestProcessor, ICacheManager cacheManager, ICacheInvalidator cacheInvalidator) : base(requestProcessor, cacheManager)
        {
            _cacheInvalidator = cacheInvalidator;
        }

        protected override void AfterSendingRequests(IEnumerable<Request> sentRequests)
        {
            base.AfterSendingRequests(sentRequests);
            foreach (var sentRequest in sentRequests)
            {
                _cacheInvalidator.InvalidateAnyApplicableCacheRegions(sentRequest);
                
            }
        }
    }
}
