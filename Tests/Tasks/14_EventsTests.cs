using System;
using System.ComponentModel;
using NUnit.Framework;
using Objects;
using Objects.Collections;

namespace Tests.Tasks
{
    [TestFixture]
    public class _14_EventsTests
    {
        [Test]
        public void NotifyPropertyChangedTest()
        {
            var rn = new Random();
            var circle = Circle.GenerateRandomFigure(rn);
            string propertyName = null;
            circle.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                propertyName = e.PropertyName;
            };
            circle.ChangeR(15);
            Assert.IsNotNull(propertyName);
            Assert.AreEqual(propertyName, "R");
            Assert.AreNotEqual(propertyName, "Center");
        }
        [Test]
        public void QueueOverflowTest()
        {
            var queue1 = new MyQueue<int>(15);
            var queue2 = new MyQueue<int>(10);
            string overflowMessage1=null,overflowMessage2=null;
            queue1.QueueOverflow += delegate(string notify)
            {
                overflowMessage1 = notify;
            };
            queue2.QueueUnderflow += delegate(string notify)
            {
                overflowMessage2 = notify;
            };
            for (var i = 0; i < queue1.Count+1; i++)
            {
                queue1.Enqueue(i);
            }
            for (var i = 0; i < queue2.Count-3; i++)
            {
                queue2.Enqueue(i);
            }
            Assert.AreEqual("The queue is full.",overflowMessage1);
            Assert.IsNotNull(overflowMessage1);
            Assert.AreNotEqual("The queue is full.",overflowMessage2);
            Assert.IsNull(overflowMessage2);
        }
        [Test]
        public void QueueUnderflowTest()
        {
            var queue1 = new MyQueue<int>(15);
            var queue2 = new MyQueue<int>(15);
            string underflowMessage1=null,underflowMessage2=null;
            queue1.QueueUnderflow += delegate(string notify)
            {
                underflowMessage1 = notify;
            };
            queue2.QueueUnderflow += delegate(string notify)
            {
                underflowMessage2 = notify;
            };
            queue1.Dequeue();
            Assert.AreEqual("The queue is empty.",underflowMessage1);
            Assert.NotNull(underflowMessage1);
            Assert.Null(underflowMessage2);
        }
        [Test]
        public void AnalyzerCollectionOfNumbersTest()
        {
            var numbers = new double[10];
            for (var i = 0; i < numbers.Length; i++)
            {
                numbers[i] = (i + 1) * 2 + 1 ;
            }

            var collection1 = new AnalyzerCollectionOfNumbers(numbers);
            var collection2 = new AnalyzerCollectionOfNumbers(numbers);
            string message1=null,message2=null;
            collection1.TooBigDifference += delegate(string notify)
            {
                message1 = notify;
            };
            collection2.TooBigDifference += delegate(string notify)
            {
                message2 = notify;
            };
            collection1.Analyze(20);
            collection2.Analyze(80);
            Assert.NotNull(message1);
            Assert.Null(message2);
        }
    }
}