using System;
using NUnit.Framework;
using Objects;

namespace Tests.Tasks
{
    [TestFixture]
    public class IntExtentionsTests
    {
        private enum TimeType {MilliSeconds,Seconds,Minutes,Hours,Days}
        private TimeSpan TimeGenerator (TimeType time)
        {
            var rand = new Random();
            var value = rand.Next(0, 10000000);
            Console.WriteLine(value);
            switch(time)
            {
                case TimeType.MilliSeconds: return value.MilliSeconds();
                case TimeType.Seconds: return value.Seconds();
                case TimeType.Minutes: return value.Minutes();
                case TimeType.Hours: return value.Hours();
                case TimeType.Days: return value.Days();
                default: return 0.MilliSeconds();
            }
        }
        [Test]
        public void TimeSpanMilliSecondsTest()
        {
            var t = TimeGenerator(TimeType.MilliSeconds);
            Console.WriteLine(t);
            Assert.IsNotNull(t);
        }
    }
}