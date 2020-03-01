namespace BasicWrapperTool
{
    using System;

    public static class ResultExtensions
    {
        public static Result<TResult> EnsureNotNull<TResult>(this Func<TResult> func, string errorMessage) where TResult : class
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

        public static Result<TResult> FromMaybe<TMaybe, TResult>(this Maybe<TMaybe> maybe, string errorMessage,
                    Func<Result<TResult>> func
        ) where TMaybe : class
        {
            return maybe.HasValue
                ? Result<TResult>.Success(func())
                : Result<TResult>.Error(errorMessage);
        }

        public static Result<TResult> Select<TSource, TResult>(this Result<TSource> m, Func<TSource, TResult> f)
        {
            return m.Map(f);
        }

        public static Result<TResult> SelectMany<TSource, TResult>(this Result<TSource> m,
            Func<TSource, Result<TResult>> f)
        {
            return m.Bind(f);
        }

        public static Result<TResult> SelectMany<TSource, TM, TResult>(this Result<TSource> m,
            Func<TSource, Result<TM>> mSelector, Func<TSource, TM, TResult> rSelector)
        {
            return m.Bind(v =>
                mSelector(v)
                    .Map(tm =>
                        rSelector(v, tm)));
        }

        public static Result<T> ToResult<T>(this Maybe<T> maybe, string errorMessage) where T : class
        {
            return maybe.HasValue
                ? Result<T>.Success(maybe.Value)
                : Result<T>.Error(errorMessage);
        }

        public static Result<TResult> Try<TResult>(this Func<TResult> func)
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
