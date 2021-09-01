using System;
using System.Collections.Generic;
using System.Text;

namespace CacheManagement
{
    public class CacheNode
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public CacheNode Previous { get; set; }

        public CacheNode Next { get; set; }
        public CacheNode(string key,object  vl)
        {
            Key = key;
            Value = vl;
        }
        public CacheNode()
        {

        }
    }
}
