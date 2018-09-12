using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Calculator.Utilities
{

    public class MemoryCacheUtility : UtilityBase, ICacheUtility
    {
        private static ConcurrentDictionary<string, double> _cache;

        public MemoryCacheUtility()
        {
            if (_cache == null)
            {
                _cache = new ConcurrentDictionary<string, double>();
            }
        }

        public void SaveToCache(CacheData cacheData)
        {
            if (_cache.TryAdd(cacheData.InstanceId.ToString(), cacheData.Value))
                Console.WriteLine($"Added [{cacheData.InstanceId}:{cacheData.Value}] on thread {Thread.CurrentThread.ManagedThreadId}");
            else
                Console.WriteLine($"Could not add [{cacheData.InstanceId}:{cacheData.Value}] on thread {Thread.CurrentThread.ManagedThreadId}");
        }

        public void ClearCache(CacheData cacheData)
        {
            if (_cache.TryRemove(cacheData.InstanceId.ToString(), out var outValue))
                Console.WriteLine($"Cleared [{cacheData.InstanceId}:{outValue}] on thread {Thread.CurrentThread.ManagedThreadId}");
            else
                Console.WriteLine($"Could not clear [{cacheData.InstanceId}] on thread {Thread.CurrentThread.ManagedThreadId}");
        }

        public CacheData RetrieveFromCache(CacheData cacheData)
        {
            if (_cache.TryGetValue(cacheData.InstanceId.ToString(), out var outValue))
                Console.WriteLine($"Retrieved [{cacheData.InstanceId}:{cacheData.Value}] on thread {Thread.CurrentThread.ManagedThreadId}");
            else
                Console.WriteLine($"Could not retrieve [{cacheData.InstanceId}:{cacheData.Value}] on thread {Thread.CurrentThread.ManagedThreadId}");

            return new CacheData()
            {
                Value = outValue,
                InstanceId = cacheData.InstanceId
            };
        }


    }
}
