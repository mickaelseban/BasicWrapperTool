using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicWrapperTool
{
    public class Result<TResult>
    {
        private readonly Result _innerResult;

        private Result(TResult value, Result innerResult)
        {
            _innerResult = innerResult;
            Value = value;
        }

        public bool IsFail => _innerResult.IsFail;
        public bool IsSuccess => _innerResult.IsSuccess;
        public string Message => _innerResult.Message;
        public IEnumerable<string> Messages => _innerResult.Messages;
        public TResult Value { get; }

        public static explicit operator TResult(Result<TResult> result)
        {
            return result.Value;
        }

        public static Result<TResult> Fail()
        {
            return new Result<TResult>(default, Result.Fail());
        }

        public static Result<TResult> Fail(IEnumerable<string> messages)
        {
            return new Result<TResult>(default, Result.Fail(messages));
        }

        public static Result<TResult> Fail(string message)
        {
            return new Result<TResult>(default, Result.Fail(message));
        }

        public static Result<TResult> Success(TResult value)
        {
            return new Result<TResult>(value, Result.Success());
        }

        public static Result<TResult> Success(TResult value, IEnumerable<string> messages)
        {
            return new Result<TResult>(value, Result.Success(messages));
        }

        public static Result<TResult> Success(TResult value, string message)
        {
            return new Result<TResult>(value, Result.Success(message));
        }

        public Result<TResult2> Bind<TResult2>(Func<TResult, Result<TResult2>> func)
        {
            return IsSuccess
                ? func(Value)
                : Result<TResult2>.Fail(Messages);
        }

        public Result<TResult2> Map<TResult2>(Func<TResult, TResult2> func)
        {
            return IsSuccess
                ? Result<TResult2>.Success(func(Value))
                : Result<TResult2>.Fail(Messages);
        }
    }

    public class Result
    {
        private Result(bool isSuccess, IEnumerable<string> messages)
        {
            IsSuccess = isSuccess;
            Messages = messages?.Where(m => !string.IsNullOrEmpty(m)) ?? Enumerable.Empty<string>();
        }

        public bool IsFail => !IsSuccess;

        public bool IsSuccess { get; }

        public bool HasMessages => Messages.Any(m => m != string.Empty);

        public string Message => string.Join(", ", Messages);

        public IEnumerable<string> Messages { get; }

        public static Result Fail()
        {
            return new Result(false, default);
        }

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
            return new Result(true, default);
        }

        public static Result Success(string message)
        {
            return new Result(true, new List<string> { message });
        }

        public static Result Success(IEnumerable<string> messages)
        {
            return new Result(true, messages);
        }
    }
}