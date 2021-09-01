using Service.Contract;
using System;
using System.Threading.Tasks;

namespace Cache.Example.Service
{
    public class UsingService : IUsingService
    {
        private readonly ICache cache;
        public UsingService(ICache _cache)
        {
            cache = _cache;
        }
        public object GetContent(string key)
        {
           
           return cache.Get(key);
        }
    }
}
