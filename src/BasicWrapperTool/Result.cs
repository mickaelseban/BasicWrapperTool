namespace BasicWrapperTool
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public sealed class Result<TResult> : Result, IResult<TResult>
    {
        private Result(TResult value, bool isSuccess, string message, Exception exception)
            : base(isSuccess, message, exception)
        {
            this.Value = value;
        }

        public TResult Value { get; private set; }

        public new static Result<TResult> Fail(string message = null)
        {
            return new Result<TResult>(default(TResult), false, message, default(Exception));
        }

        public new static Result<TResult> FailFromException(Exception exception)
        {
            return new Result<TResult>(default(TResult), false, exception.Message, exception);
        }

        public static implicit operator TResult(Result<TResult> result) => result.Value;

        public static Result<TResult> Success(TResult value)
        {
            return new Result<TResult>(value, true, default(string), default(Exception));
        }

        public IResult<TResult2> Bind<TResult2>(Func<TResult, IResult<TResult2>> func)
        {
            return this.IsSuccess
                ? func(this.Value)
                : Result<TResult2>.Fail(this.Message);
        }

        public IResult<TResult2> Map<TResult2>(Func<TResult, TResult2> func)
        {
            return this.IsSuccess
                ? Result<TResult2>.Success(func(this.Value))
                : Result<TResult2>.Fail(this.Message);
        }
    }

    public class Result : IResult
    {
        private readonly IList<string> _messages = new List<string>();

        protected Result(bool isSuccess, string message, Exception exception)
        {
            this.IsSuccess = isSuccess;
            this.Exception = exception;
            this.Messages = new ReadOnlyCollection<string>(this._messages);
            this._messages.Add(message ?? string.Empty);
        }

        public Exception Exception { get; }

        public bool IsFail => !this.IsSuccess;
        public bool IsFailFromException => !this.IsFail && (this.Exception != null);
        public bool IsSuccess { get; private set; }
        public string Message => string.Join(", ", this._messages.Where(f => !string.IsNullOrEmpty(f)));
        public IReadOnlyCollection<string> Messages { get; }

        public static Result Fail(string message = null)
        {
            return new Result(false, message, default(Exception));
        }

        public static Result FailFromException(Exception exception)
        {
            return new Result(false, exception.Message, exception);
        }

        public static Result Success()
        {
            return new Result(true, default(string), default(Exception));
        }

        public void AddMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
                this._messages.Add(message);
        }
    }
}
