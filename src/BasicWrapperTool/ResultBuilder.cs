namespace BasicWrapperTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ResultBuilder
    {
        private readonly IList<string> _messages = new List<string>();

        public Result Build()
        {
            return this._messages.Any() ? Result.Fail(this._messages) : Result.Success();
        }

        public Result<T> Build<T>(T value)
        {
            return this._messages.Any() ? Result<T>.Fail(this._messages) : Result<T>.Success(value);
        }

        public ResultBuilder Ensure(Func<bool> func, string message)
        {
            if (!Validate(func))
                this._messages.Add(message);

            return this;
        }

        private static bool Validate(Func<bool> func)
        {
            try
            {
                return func();
            }
            catch
            {
                return false;
            }
        }
    }
}
