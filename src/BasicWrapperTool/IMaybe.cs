namespace BasicWrapperTool
{
    public interface IMaybe<out T> where T : class
    {
        bool HasNoValue { get; }
        bool HasValue { get; }
        T Value { get; }
    }
}
