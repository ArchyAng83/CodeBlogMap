using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogMap
{
    class Dict<TKey, TValue> : IEnumerable
    {
        private int size = 100;
        private Item<TKey, TValue>[] items;

        public Dict()
        {
            items = new Item<TKey, TValue>[size];
        }

        public void Add(Item<TKey, TValue> item)
        {
            var hash = GetHash(item.Key);

            if (items[hash] == null)
            {
                items[hash] = item;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {
                    if (items[i] == null)
                    {
                        items[i] = item;
                        placed = true;
                        break;
                    }

                    if (items[i].Key.Equals(item.Key))
                    {
                        return;
                    }                    
                }
                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {

                        if (items[i] == null)
                        {
                            items[i] = item;
                            placed = true;
                            break;
                        }

                        if (items[i].Key.Equals(item.Key))
                        {
                            return;
                        }                        
                    }
                }

                if(!placed)
                {
                    throw new Exception("Dictionary loaded");
                }
            }
        }
               
        public void Remove(TKey key)
        {
            var hash = GetHash(key);

            if (items[hash] == null)
            {
                return;
            }

            if (items[hash].Key.Equals(key))
            {
                items[hash] = null;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {
                    if (items[i] == null)
                    {
                        return;
                    }

                    if (items[i].Key.Equals(key))
                    {
                        items[i] = null;
                        return;
                    }                    
                }
                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {

                        if (items[i] == null)
                        {
                            return;
                        }

                        if (items[i].Key.Equals(key))
                        {
                            items[i] = null;
                            return;
                        }                        
                    }
                }
            }
        }

        public TValue Search(TKey key)
        {
            var hash = GetHash(key);

            if (items[hash] == null)
            {
                return default(TValue);
            }

            if (items[hash].Key.Equals(key))
            {
                return items[hash].Value;
            }
            else
            {
                var placed = false;
                for (var i = hash; i < size; i++)
                {

                    if (items[i] == null)
                    {
                        return default(TValue);
                    }

                    if (items[i].Key.Equals(key))
                    {                       
                        return items[i].Value;
                    }                    
                }
                if (!placed)
                {
                    for (var i = 0; i < hash; i++)
                    {
                        if (items[i] == null)
                        {
                            return default(TValue);
                        }

                        if (items[i].Key.Equals(key))
                        {
                            return items[i].Value;
                        }                        
                    }
                }
            }

            return default(TValue);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        private int GetHash(TKey key)
        {
            return key.GetHashCode() % size;
        }
    }
}
