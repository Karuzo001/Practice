using System;

namespace Objects
{
    public static class IntExtentions
    {
        public static TimeSpan MilliSeconds(this int number)
        {
            return new TimeSpan(0, 0, 0, 0, Math.Abs(number));
        }

        public static TimeSpan Seconds(this int value)
        {
            return new TimeSpan(0, 0, 0, Math.Abs(value), 0);
        }

        public static TimeSpan Minutes(this int value)
        {
            return new TimeSpan(0, 0, Math.Abs(value), 0, 0);
        }

        public static TimeSpan Hours(this int value)
        {
            return new TimeSpan(0, Math.Abs(value), 0, 0, 0);
        }

        public static TimeSpan Days(this int value)
        {
            return new TimeSpan(Math.Abs(value), 0, 0, 0, 0);
        }
    }
}