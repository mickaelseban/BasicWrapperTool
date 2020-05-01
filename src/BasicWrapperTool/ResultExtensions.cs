namespace BasicWrapperTool
{
    using System;

    public static class ResultExtensions
    {
        public static IResult<TResult> FromMaybe<TMaybe, TResult>(this IMaybe<TMaybe> maybe,
                  string failMessage,
                  Func<IResult<TResult>> func)
                  where TMaybe : class
        {
            return maybe.HasValue
                ? Result<TResult>.Success(func.Invoke().Value)
                : Result<TResult>.Fail(failMessage);
        }

        public static IResult<TResult> Select<TSource, TResult>(this IResult<TSource> result, Func<TSource, TResult> func)
        {
            return result.Map(func);
        }

        public static IResult<TResult> SelectMany<TSource, TResult>(this IResult<TSource> result,
            Func<TSource, IResult<TResult>> func)
        {
            return result.Bind(func);
        }

        public static IResult<TResult> Try<TResult>(this Func<TResult> func)
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
