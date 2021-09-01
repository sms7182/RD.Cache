using System;

namespace Service.Contract
{
    public interface ICache
    {
        object Get(string key);
        void Set(string key, object value);
    }
}
