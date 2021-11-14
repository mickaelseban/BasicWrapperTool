using System.Collections.Generic;
using System.Linq;

namespace BasicWrapperTool
{
    using System;

    public sealed class Maybe<T> where T : class
    {
        private readonly IEnumerable<T> _values;

        public Maybe()
        {
            _values = Array.Empty<T>();
        }

        public Maybe(T value)
        {
            _values = value is null ? Array.Empty<T>() : new[] { value };
        }

        public bool HasNoValue => !HasValue;
        public bool HasValue => _values.Any();
        public T Value => _values.FirstOrDefault();

        public static explicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }

        public static implicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }
    }
}