namespace Agatha.Model
{
    using System;
    using Common;

    // See http://thatextramile.be/blog/2010/06/using-agathas-server-side-caching

    public abstract class BaseRequest : Request
    {
        private readonly Type _actualType;
        private readonly string _cacheKey;

        protected BaseRequest(string cacheKey) : this()
        {
            _cacheKey = cacheKey; // override default cache key by using a member number for example
        }

        protected BaseRequest()
        {
            _actualType = GetType();
            if (string.IsNullOrEmpty(_cacheKey))
            {
                _cacheKey = _actualType.FullName; // this default key can be used for app level caching
            }
        }

        public bool Equals(BaseRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other._cacheKey, _cacheKey);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != _actualType) return false;
            return Equals((BaseRequest)obj);
        }

        public override int GetHashCode()
        {
            return _cacheKey.GetHashCode();
        }
    }
}