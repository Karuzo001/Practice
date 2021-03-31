using System.Collections;

namespace Objects
{
    public class Figures : IEnumerable
    {
        public BaseFigure[] BaseFigures { get; private set; }

        public Figures(BaseFigure[] baseFigures)
        {
            BaseFigures = baseFigures;
            for (var index = baseFigures.Length-1; index > -1; index--)
            {
                BaseFigures[index] = baseFigures[index];
            }
        }

        public Figures(int length)
        {
            GenerateRandomFigures(length);
        }

        private void GenerateRandomFigures(int length)
        {
            BaseFigures = new BaseFigure[length];
            for (var index = 0; index < length; index++)
            {
                BaseFigures[index] = BaseFigure.GenerateRandomFigure();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public BaseFigureEnumerator GetEnumerator()
        {
            return new BaseFigureEnumerator(BaseFigures);
        }
    }
}