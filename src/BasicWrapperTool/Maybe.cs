namespace BasicWrapperTool
{
    using System.Collections.Generic;
    using System.Linq;

    public class Maybe<T> : IMaybe<T> where T : class
    {
        private readonly IEnumerable<T> _values;

        public Maybe()
        {
            this._values = new T[0];
        }

        public Maybe(T value)
        {
            this._values = new[] { value };
        }

        public bool HasNoValue => !this.HasValue;
        public bool HasValue => this._values.Any();
        public T Value => this._values.FirstOrDefault();

        public static explicit operator Maybe<T>(T value) => new Maybe<T>(value);

        public static implicit operator T(Maybe<T> maybe) => maybe.Value;
    }
}
