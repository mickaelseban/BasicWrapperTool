namespace BasicWrapperTool
{
    using System;
    using System.Collections.Generic;

    public interface IResult
    {
        bool IsFail { get; }

        bool IsSuccess { get; }

        string Message { get; }

        IEnumerable<string> Messages { get; }
    }

    public interface IResult<out TResult>
    {
        bool IsFail { get; }

        bool IsSuccess { get; }

        string Message { get; }

        IEnumerable<string> Messages { get; }

        TResult Value { get; }

        IResult<TResult2> Bind<TResult2>(Func<TResult, IResult<TResult2>> func);

        IResult<TResult2> Map<TResult2>(Func<TResult, TResult2> func);
    }
}
