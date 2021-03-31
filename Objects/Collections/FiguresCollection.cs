using System;
using System.Collections.Generic;
using System.Linq;

namespace Objects.Collections
{
    public class FiguresCollection<T> where T : BaseFigure
    {
        public T[] Collection;
        public readonly int Length;

        public FiguresCollection(int length)
        {
            Length = length;
            Collection = new T[length];
        }

        public FiguresCollection(IEnumerable<T> collection)
        {
            Collection = collection.ToArray();
            Length = collection.Count();
        }

        public delegate void FiguresNotifier(string notify);

        public event FiguresNotifier FiguresAreSorted;

        public void SortByArea()
        {
            Collection = Collection.OrderBy(figure => figure).ToArray();
            FiguresAreSorted?.Invoke("Figures sorted by area.");
        }

        public void SortByPerimeter()
        {
            Array.Sort(Collection, BaseFigure.SortPerimeter());
            FiguresAreSorted?.Invoke("Figures are sorted by perimeter.");
        }
    }
}