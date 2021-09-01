using Service.Contract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CacheManagement
{
    public class Cache : ICache
    {
        private int capacity;
        private int count;
        ConcurrentDictionary<string, CacheNode> memory;
        CacheList cacheList;

        public Cache(int cp)
        {
            capacity = cp;
            count = 0;
            memory = new ConcurrentDictionary<string, CacheNode>();
            cacheList = new CacheList();
        }
        public object Get(string key)
        {
            if(!memory.TryGetValue(key,out CacheNode value))
            {
                return null;
            }
            
            CacheNode node =value;
            cacheList.RemoveNode(node);
            cacheList.AddToTop(node);
            return node.Value;
        }

        public void Set(string key, object value)
        {
            if(memory.TryGetValue(key,out CacheNode cacheNode))
            {
               
                cacheList.RemoveNode(cacheNode);
                cacheNode.Value = value;
                cacheList.AddToTop(cacheNode);
            }
            else
            {
                if (count == capacity)
                {
                    CacheNode temp = cacheList.RemoveCacheNode();
                    if(memory.TryRemove(temp.Key, out CacheNode vl))
                    {
                        count--;
                    }
                }
                CacheNode readyToAdd = new CacheNode(key, value);
                cacheList.AddToTop(readyToAdd);
                memory.TryAdd(key, readyToAdd);
                count++;
            }
        }
    }
}
