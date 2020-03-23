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

        public string ErrorMessage => this._resultComposite.ErrorMessage;

        public bool IsFail => this._resultComposite.IsFail;

        public bool IsSuccess => this._resultComposite.IsSuccess;

        public TResult Value { get; private set; }

        public static Result<TResult> Error(string errorMessage) => new Result<TResult>(default(TResult), Result.Error(errorMessage));

        public static Result<TResult> ErrorFromException(Exception exception) => new Result<TResult>(default(TResult), Result.ErrorFromException(exception));

        public static implicit operator TResult(Result<TResult> result) => result.Value;

        public static Result<TResult> Success(TResult value, string errorMessage = null) => new Result<TResult>(value, Result.Success());

        public IResult<TResult2> Bind<TResult2>(Func<TResult, IResult<TResult2>> func)
        {
            return this.IsSuccess
                ? func(this.Value)
                : Result<TResult2>.Error(this.ErrorMessage);
        }

        public IResult<TResult2> Map<TResult2>(Func<TResult, TResult2> func)
        {
            return this.IsSuccess
                ? Result<TResult2>.Success(func(this.Value))
                : Result<TResult2>.Error(this.ErrorMessage);
        }
    }

    public class Result : IResult
    {
        private Result(bool isSuccess, string errorMessage)
        {
            this.IsSuccess = isSuccess;
            this.ErrorMessage = errorMessage ?? string.Empty;
        }

        public string ErrorMessage { get; private set; }

        public bool IsFail => !this.IsSuccess;

        public bool IsSuccess { get; private set; }

        public static Result Error(string errorMessage = null) => new Result(false, errorMessage);

        public static Result ErrorFromException(Exception exception) => new Result(false, exception.Message);

        public static Result Success() => new Result(true, default(string));
    }
}
