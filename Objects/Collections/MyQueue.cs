using System.Collections.ObjectModel;
using System.Linq;

namespace Objects.Collections
{
    public class MyQueue<T>
    {
        private readonly Collection<T> _queue;
        private readonly uint _maxLength;
        public uint Count;

        public delegate void QueueExceptionNotifier(string notify);

        public event QueueExceptionNotifier QueueOverflow;
        public event QueueExceptionNotifier QueueUnderflow;

        public MyQueue(uint maxLength)
        {
            _queue = new Collection<T>();
            _maxLength = maxLength;
        }

        public void Enqueue(T item)
        {
            if(Count==_maxLength) QueueOverflow?.Invoke("The queue is full.");
            else
            {
                _queue.Add(item);
                Count++;
            }
        }

        public void Dequeue()
        {
            if(Count==0) QueueUnderflow?.Invoke("The queue is empty.");
            else
            {
                _queue.RemoveAt(0);
                Count--;
            }
        }

        public override string ToString()
        {
            return _queue.Aggregate("", (current, item) => current + (item + "\n"));
        }
    }
}