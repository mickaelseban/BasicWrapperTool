namespace BasicWrapperTool
{
    using System;
    using System.Collections.Generic;

    public interface IResult
    {
        Exception Exception { get; }

        bool IsFail { get; }

        bool IsFailFromException { get; }

        bool IsSuccess { get; }

        string Message { get; }

        IReadOnlyCollection<string> Messages { get; }

        void AddMessage(string message);
    }

    public interface IResult<out TResult> : IResult
    {
        TResult Value { get; }

        IResult<TResult2> Bind<TResult2>(Func<TResult, IResult<TResult2>> func);

        IResult<TResult2> Map<TResult2>(Func<TResult, TResult2> func);
    }
}
