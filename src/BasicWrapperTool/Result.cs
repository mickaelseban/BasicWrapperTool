namespace BasicWrapperTool
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Result<TResult>
    {
        private readonly Result _resultComposite;

        private Result(TResult value, Result resultComposite)
        {
            this._resultComposite = resultComposite;
            this.Value = value;
        }

        public bool IsFail => this._resultComposite.IsFail;
        public bool IsSuccess => this._resultComposite.IsSuccess;
        public string Message => this._resultComposite.Message;

        public IEnumerable<string> Messages => this._resultComposite.Messages;
        public TResult Value { get; }

        public static explicit operator TResult(Result<TResult> result)
        {
            return result.Value;
        }

        public static Result<TResult> Fail(IEnumerable<string> messages)
        {
            return new Result<TResult>(default(TResult), Result.Fail(messages));
        }

        public static Result<TResult> Fail(string message)
        {
            return new Result<TResult>(default(TResult), Result.Fail(message));
        }

        public static Result<TResult> Success(TResult value)
        {
            return new Result<TResult>(value, Result.Success());
        }

        public Result<TResult2> Bind<TResult2>(Func<TResult, Result<TResult2>> func)
        {
            return this.IsSuccess
                ? func(this.Value)
                : Result<TResult2>.Fail(this.Messages);
        }

        public Result<TResult2> Map<TResult2>(Func<TResult, TResult2> func)
        {
            return this.IsSuccess
                ? Result<TResult2>.Success(func(this.Value))
                : Result<TResult2>.Fail(this.Messages);
        }
    }

    public class Result
    {
        private Result(bool isSuccess, IEnumerable<string> messages)
        {
            this.IsSuccess = isSuccess;
            this.Messages = messages?.Where(m => !string.IsNullOrEmpty(m)) ?? Enumerable.Empty<string>();
        }

        public bool IsFail => !this.IsSuccess;

        public bool IsSuccess { get; private set; }

        public string Message => string.Join(", ", this.Messages);

        public IEnumerable<string> Messages { get; }

        public static Result Fail(string message)
        {
            return new Result(false, new List<string> { message });
        }

        public static Result Fail(IEnumerable<string> messages)
        {
            return new Result(false, messages);
        }

        public static Result Success()
        {
            return new Result(true, default(IEnumerable<string>));
        }
    }
}