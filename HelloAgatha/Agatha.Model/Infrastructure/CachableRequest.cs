namespace Agatha.Model.Infrastructure
{
    using Common;

    // See http://thatextramile.be/blog/2010/06/using-agathas-server-side-caching

    public abstract class CachableRequest : Request
    {
        public bool Equals(CachableRequest other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.CacheKey, CacheKey);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CachableRequest)obj);
        }

        public override int GetHashCode()
        {
            return CacheKey.GetHashCode();
        }

        public virtual string MemberNumber { get; set; }

        public virtual string CacheKey
        {
            get { return MemberNumber + "|" + GetType().FullName; }
        }
    }
}