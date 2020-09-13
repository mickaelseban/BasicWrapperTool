namespace BasicWrapperTool
{
    public static class MaybeExtensions
    {
        public static Maybe<T> ToMaybe<T>(this T value) where T : class
        {
            return new Maybe<T>(value);
        }
    }
}