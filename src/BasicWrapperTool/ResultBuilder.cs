namespace BasicWrapperTool
{
    using System;

    public sealed class ResultBuilder<TResult>
    {
        private string _errorMessage;
        private bool? _success;

        private TResult _value;

        private ResultBuilder()
        {
            this._errorMessage = string.Empty;
        }

        public static ResultBuilder<TResult> Create()
        {
            return new ResultBuilder<TResult>();
        }

        public Result<TResult> Build()
        {
            return new Result<TResult>(this._value, this._success.GetValueOrDefault(), this._errorMessage);
        }

        public ResultBuilder<TResult> FromFail()
        {
            this._success = false;
            return this;
        }

        public ResultBuilder<TResult> FromSuccess()
        {
            this._success = true;
            return this;
        }

        public ResultBuilder<TResult> WithMessage(string errorMessage)
        {
            this._errorMessage = errorMessage;
            return this;
        }

        public ResultBuilder<TResult> WithNonNullValue(Func<TResult> func)
        {
            try
            {
                this._value = func.Invoke();

                if (typeof(TResult).IsValueType)
                    this._success = true;
                else
                    this._success = !this._value.Equals(default(TResult));
            }
            catch
            {
                this._value = default(TResult);
                this._success = false;
            }

            return this;
        }

        public ResultBuilder<TResult> WithValue(TResult value)
        {
            this._value = value;
            return this;
        }
    }

    public class ResultBuilder<TResult, TMaybe> where TMaybe : class
    {
        private readonly ResultBuilder<TResult> _resultBuilderComposite;
        private Maybe<TMaybe> _maybeInput;

        private ResultBuilder()
        {
            this._maybeInput = new Maybe<TMaybe>();
            this._resultBuilderComposite = ResultBuilder<TResult>.Create();
        }

        public static ResultBuilder<TResult, TMaybe> Create(Maybe<TMaybe> maybeInput, string errorMessage)
        {
            return new ResultBuilder<TResult, TMaybe>().CreateFromMaybe(maybeInput, errorMessage);
        }

        public Result<TResult> Build()
        {
            return this._resultBuilderComposite.Build();
        }

        public ResultBuilder<TResult, TMaybe> WithMessage(string message)
        {
            this._resultBuilderComposite.WithMessage(message);
            return this;
        }

        public ResultBuilder<TResult, TMaybe> WithNonNullValue(Func<TResult> func)
        {
            if (this.CanExecute())
                this._resultBuilderComposite.WithNonNullValue(func);
            return this;
        }

        public ResultBuilder<TResult, TMaybe> WithValue(TResult value)
        {
            if (this.CanExecute())
                this._resultBuilderComposite.WithValue(value);
            return this;
        }

        private bool CanExecute() => this._maybeInput.HasValue;

        private bool CannotExecute() => !this.CanExecute();

        private ResultBuilder<TResult, TMaybe> CreateFromMaybe(Maybe<TMaybe> maybeInput, string errorMessage)
        {
            this._maybeInput = maybeInput;

            if (this.CannotExecute())
            {
                this._resultBuilderComposite.FromFail();
                this._resultBuilderComposite.WithMessage(errorMessage);
            }

            return this;
        }
    }
}
