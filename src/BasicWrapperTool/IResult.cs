namespace BasicWrapperTool
{
    using System;

    public interface IResult
    {
        string ErrorMessage { get; }
        bool IsFail { get; }
        bool IsSuccess { get; }
    }

    public interface IResult<out TResult>
    {
        string ErrorMessage { get; }

        bool IsFail { get; }

        bool IsSuccess { get; }

        TResult Value { get; }

        IResult<TResult2> Bind<TResult2>(Func<TResult, IResult<TResult2>> func);

        IResult<TResult2> Map<TResult2>(Func<TResult, TResult2> func);
    }
}
