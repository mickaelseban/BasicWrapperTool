namespace BasicWrapperTool
{
    using System.Collections.Generic;
    using System.Linq;

    public class ResultValidationBuilder
    {
        private readonly IList<Result> _results = new List<Result>();

        private IEnumerable<string> Messages => this._results.Where(r => r.IsFail).SelectMany(m => m.Messages);
        private bool AllSucceed => this._results.All(r => r.IsSuccess);

        public ResultValidationBuilder AddResult<TResult>(Result<TResult> result)
        {
            this._results.Add(result.ToResult());
            return this;
        }

        public ResultValidationBuilder AddResult(Result result)
        {
            this._results.Add(result);
            return this;
        }

        public Result Build()
        {
            return this.AllSucceed
                ? Result.Success()
                : Result.Fail(this.Messages);
        }

        public Result<T> Build<T>(T value)
        {
            return this.AllSucceed
                ? Result<T>.Success(value)
                : Result<T>.Fail(this.Messages);
        }
    }
}