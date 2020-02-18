namespace BasicWrapperTool.Logic
{
    using System.Collections.Generic;
    using System.Linq;

    public class Result<TResult>
    {
        private readonly Result _resultComposite;

        internal Result(TResult value, bool success, List<string> messages)
        {
            this._resultComposite = new Result(success, messages);
            this.Value = value;
        }

        public bool IsFail => this._resultComposite.IsFail;
        public bool IsSuccess => this._resultComposite.IsSuccess;
        public IReadOnlyCollection<string> Messages => this._resultComposite.Messages;
        public TResult Value { get; private set; }

        public static Result<TResult> FromFail(List<string> errorMessages) => new Result<TResult>(default(TResult), false, errorMessages);

        public static Result<TResult> FromSuccess(TResult value, List<string> infoMessages = null) => new Result<TResult>(value, true, infoMessages);
    }

    public class Result
    {
        private readonly List<string> _messages;

        internal Result(bool success, List<string> messages)
        {
            this.IsSuccess = success;
            this._messages = messages ?? new List<string>();
        }

        public bool HasMessages => this._messages.Any();
        public bool HasNoMessages => !this.HasMessages;
        public bool IsFail => !this.IsSuccess;

        public bool IsSuccess { get; }

        public IReadOnlyCollection<string> Messages => this._messages;

        public static Result FromFail(List<string> errorMessages = null) => new Result(false, errorMessages);

        public static Result FromSuccess(List<string> infoMessages = null) => new Result(true, infoMessages);
    }
}
