using System;
using System.Linq;
using System.Reflection;

namespace Objects.MyDelegate
{
    public class ParametersAndType : IEquatable<ParametersAndType>
    {
        private ParameterInfo[] _parameters;
        private Type _returnType;

        public ParametersAndType(ParameterInfo[] parameters, Type returnType)
        {
            if (parameters == null) throw new ArgumentNullException();
            _parameters = new ParameterInfo[parameters.Length];
            for (var i = 0; i < parameters.Length; i++)
            {
                _parameters[i] = parameters[i];
            }

            _returnType = returnType ?? throw new ArgumentNullException(nameof(returnType));
        }

        public void Clear()
        {
            _parameters = null;
            _returnType = null;
        }

        public bool Equals(ParametersAndType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ParametersInfoEquality(_parameters, other._parameters) && _returnType == other._returnType;
        }

        public bool Equals(MethodInfo other)
        {
            return Equals(new ParametersAndType(other.GetParameters(), other.ReturnType));
        }

        private static bool ParametersInfoEquality(ParameterInfo[] first, ParameterInfo[] second)
        {
            if (first.Length != second.Length) return false;
            return !first.Where((t, i) => t.ParameterType != second[i].ParameterType).Any();
        }

        public ParametersAndType Clone()
        {
            return new ParametersAndType(_parameters, _returnType);
        }
    }
}