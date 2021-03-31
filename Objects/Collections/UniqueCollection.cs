using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Objects.People;

namespace Objects
{
    public class UniqueCollection<T> : ICollection<T>
    {
        private readonly Collection<T> _collection;
        public int Count => _collection.Count;
        public bool IsReadOnly => ((ICollection<T>) _collection).IsReadOnly;

        public UniqueCollection()
        {
            _collection = new Collection<T>();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_collection.Contains(item)) throw new ArgumentException("This element is already in the collection.");
            _collection.Add(item);
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return _collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (!_collection.Contains(item)) throw new ArgumentException("This element is not in the collection");
            return _collection.Remove(item);
        }
    }
}