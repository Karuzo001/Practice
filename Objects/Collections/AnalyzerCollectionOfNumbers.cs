using System.Collections.Generic;
using System.Linq;

namespace Objects.Collections
{
    public class AnalyzerCollectionOfNumbers
    {
        private readonly double[] _collection;

        public AnalyzerCollectionOfNumbers(IEnumerable<double> collection)
        {
            _collection = collection.ToArray();
        }

        public delegate void AnalyzerExceptionNotifier(string notify);

        public event AnalyzerExceptionNotifier TooBigDifference;


        public void Analyze(int maxDifferencePercent)
        {
            for (var i = _collection.Count() - 1; i > 0; i--)
            {
                var differencePercent = (_collection[i] > _collection[i - 1])
                    ? (_collection[i] / _collection[i - 1] - 1) * 100
                    : (_collection[i - 1] / _collection[i] - 1) * 100;
                if (!(differencePercent > maxDifferencePercent)) continue;
                TooBigDifference?.Invoke(
                    $"The difference between {_collection[i - 1]} and {_collection[i]} exceeds {maxDifferencePercent:0.###}%");
            }
        }
    }
}