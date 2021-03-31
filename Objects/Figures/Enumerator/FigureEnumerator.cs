using System;
using System.Collections;

namespace Objects
{
    public class BaseFigureEnumerator : IEnumerator
    {
        private readonly BaseFigure[] _items;
        private int _position = -1;

        public BaseFigureEnumerator(BaseFigure[] list)
        {
            _items = list;
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _items.Length;
        }

        public void Reset()
        {
            _position = -1;
        }

        object IEnumerator.Current => Current;

        public BaseFigure Current
        {
            get
            {
                try
                {
                    return _items[_position];
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}