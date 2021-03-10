using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Tests
{
    public class BoxingUnboxingTest
    {
        [Test]
        public void TimeTest()
        {
            //  if (!uint.TryParse(Console.ReadLine(), out var length)) return;
            const int length = 100000;
            var box = new object[length];
            var number = new int[box.Length];
            var time = new Stopwatch();
            time.Start();
            for (var i = 0; i < box.Length; i++)
            {
                box[i] = i;
            }

            time.Stop();
            Console.WriteLine("Lead time {0} boxing = {1:0.000} ticks", box.Length, time.ElapsedTicks);
            time.Restart();
            for (var i = 0; i < number.Length; i++)
            {
                number[i] = (int) box[i];
            }

            time.Stop();
            Console.WriteLine("Lead time {0} unboxing = {1:0.000} ticks", box.Length, time.ElapsedTicks);
            time.Restart();
            for (var i = 0; i < number.Length; i++)
            {
                number[i] = i;
            }

            time.Stop();
            Console.WriteLine("Lead time {0} assignments = {1:0.000} ticks", box.Length, time.ElapsedTicks);
        }
    }
}