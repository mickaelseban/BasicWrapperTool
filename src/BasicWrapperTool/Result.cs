namespace BasicWrapperTool
{
    using System;

    public class Result<TResult> : IResult<TResult>
    {
        private readonly Result _resultComposite;

        private Result(TResult value, Result resultComposite)
        {
            this._resultComposite = resultComposite;
            this.Value = value;
        }

        public string FailMessage => this._resultComposite.FailMessage;

        public bool IsFail => this._resultComposite.IsFail;

        public bool IsSuccess => this._resultComposite.IsSuccess;

        public TResult Value { get; private set; }

        public static Result<TResult> Fail(string failMessage) => new Result<TResult>(default(TResult), Result.Fail(failMessage));

        public static Result<TResult> FailFromException(Exception exception) => new Result<TResult>(default(TResult), Result.FailFromException(exception));

        public static implicit operator TResult(Result<TResult> result) => result.Value;

        public static Result<TResult> Success(TResult value, string failMessage = null) => new Result<TResult>(value, Result.Success());

        public IResult<TResult2> Bind<TResult2>(Func<TResult, IResult<TResult2>> func)
        {
            return this.IsSuccess
                ? func(this.Value)
                : Result<TResult2>.Fail(this.FailMessage);
        }

        public IResult<TResult2> Map<TResult2>(Func<TResult, TResult2> func)
        {
            return this.IsSuccess
                ? Result<TResult2>.Success(func(this.Value))
                : Result<TResult2>.Fail(this.FailMessage);
        }
    }

    public class Result : IResult
    {
        private Result(bool isSuccess, string failMessage)
        {
            this.IsSuccess = isSuccess;
            this.FailMessage = failMessage ?? string.Empty;
        }

        public string FailMessage { get; private set; }

        public bool IsFail => !this.IsSuccess;

        public bool IsSuccess { get; private set; }

        public static Result Fail(string failMessage = null) => new Result(false, failMessage);

        public static Result FailFromException(Exception exception) => new Result(false, exception.Message);

        public static Result Success() => new Result(true, default(string));
    }
}
