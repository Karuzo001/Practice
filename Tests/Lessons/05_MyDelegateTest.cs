using System;
using System.Diagnostics;
using NUnit.Framework;
using Objects;
using Objects.MyDelegate;

namespace Tests.Lessons
{
    [TestFixture]
    public class _05_MyDelegateTest
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Remove(int a, int b)
        {
            return a - b;
        }
        public int ExceptionMethod(int a, int b)
        {
            throw new Exception("Exception!");
        }

        [Test]
        public void AddRemoveTest()
        {
            var type = Type.GetType(this.ToString());
            Debug.Assert(type != null, nameof(type) + " != null");
            var addMethodInfo = type.GetMethod(nameof(this.Add));

            var myDelegate = new MyDelegate(addMethodInfo);
            myDelegate -= new MyDelegate(type.GetMethod(nameof(Remove)));
            myDelegate += new MyDelegate(addMethodInfo);
            Assert.AreEqual(55, myDelegate.Invoke(this, new object[] {50, 5}));
        }

        [Test]
        public void IgnoreExceptionTest()
        {
            var type = Type.GetType(this.ToString());
            Debug.Assert(type != null, nameof(type) + " != null");

            var addMethodInfo = type.GetMethod(nameof(this.Add));
            var myDelegate = new MyDelegate(addMethodInfo);

            var exceptionInfo = type.GetMethod(nameof(this.ExceptionMethod));
            myDelegate -= myDelegate;
            myDelegate += new MyDelegate(exceptionInfo);
            myDelegate += myDelegate;
            var anotherMyDelegate = new MyDelegate(addMethodInfo);
            myDelegate += anotherMyDelegate;
            myDelegate -= new MyDelegate(type.GetMethod(nameof(Remove)));
            var result = myDelegate.Invoke(this, new object[] {10, 15});
            Assert.AreEqual(25, (int) result);
            Console.WriteLine("Result: " + result);
        }
    }
}