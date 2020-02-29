namespace BasicWrapperTool
{
    public class Result<TResult>
    {
        private readonly Result _resultComposite;

        internal Result(TResult value, bool isSuccess, string errorMessage)
        {
            this._resultComposite = new Result(isSuccess, errorMessage);
            this.Value = value;
        }

        public string ErrorMessage => this._resultComposite.ErrorMessage;
        public bool IsFail => this._resultComposite.IsFail;
        public bool IsSuccess => this._resultComposite.IsSuccess;
        public TResult Value { get; private set; }

        public static Result<TResult> Error(string errorMessage) => new Result<TResult>(default(TResult), false, errorMessage);

        public static Result<TResult> Success(TResult value, string errorMessage = null) => new Result<TResult>(value, true, default(string));
    }

    public class Result
    {
        internal Result(bool isSuccess, string errorMessage)
        {
            this.IsSuccess = isSuccess;
            this.ErrorMessage = errorMessage ?? string.Empty;
        }

        public string ErrorMessage { get; private set; }
        public bool IsFail => !this.IsSuccess;
        public bool IsSuccess { get; private set; }

        public static Result Error(string errorMessage = null) => new Result(false, errorMessage);

        public static Result Success() => new Result(true, default(string));
    }
}
