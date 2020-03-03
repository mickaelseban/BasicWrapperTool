namespace BasicWrapperTool
{
    using System;

    public static class ResultExtensions
    {
        public static IResult<TResult> EnsureNotNull<TResult>(this Func<TResult> func, string errorMessage)
            where TResult : class
        {
            try
            {
                var value = func();
                return value is null
                    ? Result<TResult>.Error(errorMessage)
                    : Result<TResult>.Success(value);
            }
            catch
            {
                return Result<TResult>.Error(errorMessage);
            }
        }

        public static IResult<TResult> FromMaybe<TMaybe, TResult>(this IMaybe<TMaybe> maybe,
            string errorMessage,
            Func<IResult<TResult>> func)
            where TMaybe : class
        {
            return maybe.HasValue
                ? Result<TResult>.Success(func.Invoke().Value)
                : Result<TResult>.Error(errorMessage);
        }

        public static IResult<TResult> Select<TSource, TResult>(this Result<TSource> m, Func<TSource, TResult> f)
        {
            return m.Map(f);
        }

        public static IResult<TResult> SelectMany<TSource, TResult>(this Result<TSource> m,
            Func<TSource, Result<TResult>> f)
        {
            return m.Bind(f);
        }

        public static IResult<TResult> SelectMany<TSource, TM, TResult>(this IResult<TSource> m,
            Func<TSource, IResult<TM>> mSelector, Func<TSource, TM, TResult> rSelector)
        {
            return m.Bind(v =>
                mSelector(v)
                    .Map(tm =>
                        rSelector(v, tm)));
        }

        public static IResult<TResult> ToResult<TResult>(this Func<TResult> func)
        {
            try
            {
                return Result<TResult>.Success(func());
            }
            catch (Exception e)
            {
                return Result<TResult>.Error(e.Message);
            }
        }

        public static IResult<T> ToResult<T>(this IMaybe<T> maybe, string errorMessage) where T : class
        {
            return maybe.HasValue
                ? Result<T>.Success(maybe.Value)
                : Result<T>.Error(errorMessage);
        }

        public static IResult<TResult> Try<TResult>(this Func<TResult> func)
        {
            try
            {
                return Result<TResult>.Success(func());
            }
            catch (Exception ex)
            {
                return Result<TResult>.Error(ex.Message);
            }
        }
    }
}
