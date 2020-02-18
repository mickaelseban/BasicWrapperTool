namespace BasicWrapperTool.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    public abstract class TheoryDataClass : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>();

        public IEnumerator<object[]> GetEnumerator()
        {
            return this._data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        protected void AddRow(params object[] values)
        {
            this._data.Add(values);
        }
    }
}
