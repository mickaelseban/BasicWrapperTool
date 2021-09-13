using System.Collections.Generic;
using System.Linq;

namespace BasicWrapperTool
{
    public class ResultValidationBuilder
    {
        private readonly IList<Result> _results = new List<Result>();

        private IEnumerable<string> Messages => _results.Where(r => r.IsFail).SelectMany(m => m.Messages);
        private bool AllSucceed => _results.All(r => r.IsSuccess);

        public ResultValidationBuilder AddResult<TResult>(Result<TResult> result)
        {
            _results.Add(result.ToResult());
            return this;
        }

        public ResultValidationBuilder AddResult(Result result)
        {
            _results.Add(result);
            return this;
        }

        public Result Build()
        {
            return AllSucceed
                ? Result.Success()
                : Result.Fail(Messages);
        }

        public Result<T> Build<T>(T value)
        {
            return AllSucceed
                ? Result<T>.Success(value)
                : Result<T>.Fail(Messages);
        }
    }
}