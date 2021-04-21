using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Objects.MyDelegate
{
    public sealed class MyDelegate : IEquatable<MyDelegate>
    {
        private List<MethodInfo> _methods;
        private ParametersAndType _signature;

        public MyDelegate(MethodInfo method)
        {
            if (method == null) throw new ArgumentNullException();
            _methods = new List<MethodInfo> {method};
            _signature = new ParametersAndType(method.GetParameters(), method.ReturnType);
        }
        public void Add(MethodInfo method)
        {
            if (method == null) throw new ArgumentNullException(nameof(method));
            if (_methods.Count == 0)
            {
                _methods = new List<MethodInfo>();
                _signature = new ParametersAndType(method.GetParameters(), method.ReturnType);
            }
            else if (!_signature.Equals(method)) throw new Exception("Signatures do not coincide");

            _methods.Add(method);
        }

        public void Add(MyDelegate myDelegate)
        {
            
            if (myDelegate == null) throw new ArgumentNullException(nameof(myDelegate));
            if (_methods == myDelegate._methods && _signature == myDelegate._signature)
            {
                var newList = new List<MethodInfo>();
                newList = newList.Concat(_methods).ToList();
                _methods = newList.Concat(_methods).ToList();
            }
            else
            {
                if (_methods.Count == 0)
                {
                    _methods = new List<MethodInfo>();
                    _signature = myDelegate._signature.Clone();
                }
                else if (!_signature.Equals(myDelegate._signature)) throw new Exception("Signatures do not coincide");

                foreach (var method in myDelegate._methods)
                {
                    _methods.Add(method);
                }
            }
        }

        public static MyDelegate operator +(MyDelegate first, MethodInfo second)
        {
            first.Add(second);
            return first;
        }

        public static MyDelegate operator +(MyDelegate first, MyDelegate second)
        {
            first.Add(second);
            return first;
        }

        public static MyDelegate operator -(MyDelegate first, MyDelegate second)
        {
            if (first == null || second == null) throw new ArgumentNullException();
            if (!first._signature.Equals(second._signature))
                throw new Exception("Signatures do not coincide");
            if (first.Equals(second))
            {
                first.Clear();
                return first;
            }

            if (first._methods.Count == 0) return first;
            foreach (var method in second._methods)
            {
                first._methods.Remove(method);
            }

            return first;
        }

        public object Invoke(object classInstance, object[] parameters)
        {
            if (_methods.Count == 0) return null;
            foreach (var methodInfo in _methods)
            {
                try
                {
                    return methodInfo.Invoke(classInstance, parameters);
                }
                catch (Exception exception)
                {
                    if (exception.InnerException != null) Console.WriteLine(exception.InnerException.Message);
                }
            }

            return null;
        }

        public void Clear()
        {
            _methods.Clear();
            _signature.Clear();
        }

        public bool Equals(MyDelegate other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(_methods, other._methods) && Equals(_signature, other._signature);
        }
    }
}