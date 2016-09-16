using System;

namespace QIQO.Common.Core.Caching
{
    public interface ICache
    {
        /// <summary>
        /// Returns the type of the cache
        /// </summary>
        CacheType CacheType { get; }

        /// <summary>
        /// Performs any one-time initialisation required for the cache implementation
        /// </summary>
        void Initialise();

        /// <summary>
        /// Insert or update a cache value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set(string key, object value);

        /// <summary>
        /// Insert or update a cache value with an expiry date
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresAt"></param>
        void Set(string key, object value, DateTime expiresAt);

        /// <summary>
        /// Insert or update a cache value with a fixed lifetime
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="validFor"></param>
        void Set(string key, object value, TimeSpan validFor);

        /// <summary>
        /// Retrieve a value from cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Cached value or null</returns>
        object Get(string key);
        
        /// <summary>
        /// Removes the value for the given key from the cache
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);

        /// <summary>
        /// Returns whether the cache contains a value for the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(string key);
    }
}
