using System;

namespace BasicWrapperTool
{
    public static class ResultExtensions
    {
        public static Result<TResult> FromMaybe<TMaybe, TResult>(this Maybe<TMaybe> maybe,
            string failMessage,
            Func<Result<TResult>> func)
            where TMaybe : class
        {
            return maybe.HasValue
                ? Result<TResult>.Success(func.Invoke().Value)
                : Result<TResult>.Fail(failMessage);
        }

        public static Result<TResult> Select<TSource, TResult>(this Result<TSource> result, Func<TSource, TResult> func)
        {
            return result.Map(func);
        }

        public static Result<TResult> SelectMany<TSource, TResult>(this Result<TSource> result,
            Func<TSource, Result<TResult>> func)
        {
            return result.Bind(func);
        }

        public static Result ToResult<TResult>(this Result<TResult> result)
        {
            return result.IsSuccess ? Result.Success() : Result.Fail(result.Messages);
        }

        public static Result<TResult> Try<TResult>(this Func<TResult> func)
        {
            try
            {
                var value = func();
                return Result<TResult>.Success(value);
            }
            catch (Exception ex)
            {
                return Result<TResult>.Fail(ex.Message);
            }
        }
    }
}