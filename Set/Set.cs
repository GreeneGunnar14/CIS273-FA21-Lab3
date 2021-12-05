using System;
using System.Collections;
using System.Collections.Generic;

namespace Set
{
    public class Set<T> : ISet<T>
    {
        private HashSet<T> hashSet;

        public Set()
        {
            hashSet = new HashSet<T>();
        }

        public int Size => hashSet.Count;

        public List<T> Elements
        {
            get
            {
                List<T> elements = new List<T>();

                foreach(T item in hashSet)
                {
                    elements.Add(item);
                }

                return elements;
            }
        }

        public static ISet<T> Intersection(ISet<T> s1, ISet<T> s2)
        {
            ISet<T> result = new Set<T>();

            foreach (var item in s1)
            {
                if (s2.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public static ISet<T> Union(ISet<T> s1, ISet<T> s2)
        {
            ISet<T> result = new Set<T>();

            foreach (var item in s1)
            {
                result.Add(item);
            }

            foreach (var item in s2)
            {
                if (!result.Contains(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public void Add(ISet<T> s)
        {
            foreach (var item in s)
            {
                if (!hashSet.Contains(item))
                {
                    hashSet.Add(item);
                }
            }
        }

        public void Add(T value)
        {
            hashSet.Add(value);
        }

        public bool Contains(T value)
        {
            if (hashSet.Contains(value))
            {
                return true;
            }

            return false;
        }

        public void Remove(ISet<T> s)
        {
            foreach (var item in s)
            {
                hashSet.Remove(item);
            }
        }

        public void Remove(T value)
        {
            hashSet.Remove(value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return hashSet.GetEnumerator();
        }
    }
}
