namespace Agatha.Model.Infrastructure
{
    using Common.Caching;
    using Common;

    public class InvalidatableCachingInterceptor : Disposable, IRequestHandlerInterceptor
    {
        private readonly ICacheInvalidator _cacheInvalidator;

        public InvalidatableCachingInterceptor(ICacheInvalidator cacheInvalidator)
        {
            _cacheInvalidator = cacheInvalidator;
        }

        protected override void DisposeManagedResources()
        {
        }

        public void BeforeHandlingRequest(RequestProcessingContext context)
        {
        }

        public void AfterHandlingRequest(RequestProcessingContext context)
        {
            _cacheInvalidator.InvalidateAnyApplicableCacheRegions(context.Request);
        }
    }
}