using System;
using System.Runtime.Caching;
using QIQO.Common.Core.Logging;

namespace QIQO.Common.Core.Caching
{
    public class LocalMemoryCache : ICache
    {
        MemoryCache _cache = new MemoryCache("QIQOCache");

        //public LocalMemoryCache()
        //{
        //    Initialise();
        //}

        public CacheType CacheType
        {
            get
            {
                return CacheType.Memory;
            }
        }

        public bool Exists(string key)
        {
            //Log.Debug("QIQOCache MemoryCache Add - Key: {0}", key);
            return _cache.Contains(key);
        }

        public object Get(string key)
        {
            //Log.Debug("QIQOCache MemoryCache Get - Key: {0}", key);
            return _cache[key];
        }

        public void Initialise()
        {
            _cache = new MemoryCache("QIQOCache");
            Log.Debug("QIQOCache MemoryCache Initialized");
        }

        public void Remove(string key)
        {
            if (Exists(key))
                _cache.Remove(key);
            Log.Debug("QIQOCache MemoryCache Remove - Key: {0}", key);
        }

        public void Set(string key, object value)
        {
            var policy = new CacheItemPolicy() { AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(20.0) };
            _cache.Add(key, value, policy);
            Log.Debug("QIQOCache MemoryCache Add - Key: {0}", key);
        }

        public void Set(string key, object value, TimeSpan validFor)
        {
            var policy = new CacheItemPolicy();
            policy.SlidingExpiration = validFor;
            _cache.Add(key, value, policy);
            Log.Debug("QIQOCache MemoryCache Add - Key: {0}", key);
        }

        public void Set(string key, object value, DateTime expiresAt)
        {
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = expiresAt;
            _cache.Add(key, value, policy);
            Log.Debug("QIQOCache MemoryCache Add - Key: {0}", key);
        }
    }
}
