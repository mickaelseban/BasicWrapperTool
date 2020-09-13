namespace BasicWrapperTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ResultBuilder
    {
        private readonly IList<string> _messages = new List<string>();

        public ResultBuilder Combine(ResultBuilder otherResultBuilder)
        {
            if (otherResultBuilder is null)
                return this;

            if (!otherResultBuilder._messages.Any())
                return this;

            var resultBuilder = new ResultBuilder();
            this._messages.ToList().ForEach(m => resultBuilder._messages.Add(m));
            otherResultBuilder._messages.ToList().ForEach(m => resultBuilder._messages.Add(m));

            return resultBuilder;
        }

        public Result Build()
        {
            return this._messages.Any()
                ? Result.Fail(this._messages)
                : Result.Success();
        }

        public Result<T> Build<T>(T value)
        {
            return this._messages.Any()
                ? Result<T>.Fail(this._messages)
                : Result<T>.Success(value);
        }

        public ResultBuilder Ensure(Func<bool> validation, string message)
        {
            if (!Validate(validation))
                this._messages.Add(message);

            return this;
        }

        public ResultBuilder EnsureNotNull<T>(T inputValidation, string message) where T : class
        {
            if (inputValidation is null)
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