using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogMap
{
    class EasyMap<TKey, TValue> : IEnumerable
    {
        private List<Item<TKey, TValue>> items = new List<Item<TKey, TValue>>();
        private List<TKey> keys = new List<TKey>();

        public int Count => items.Count;

        public EasyMap()
        {

        }

        public void Add(Item<TKey, TValue> item)
        {
            if (!keys.Contains(item.Key))
            {
                keys.Add(item.Key);
                items.Add(item);
            }
        }

        public TValue Search(TKey key)
        {
            if (keys.Contains(key))
            {
                return items.Single(i => i.Key.Equals(key)).Value;
            }
             
            // или исключение
            return default(TValue);
        }

        public void Remove(TKey key)
        {
            if (keys.Contains(key))
            {
                keys.Remove(key);
                items.Remove(items.Single(i => i.Key.Equals(key)));
            }
        }

        public IEnumerator GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
