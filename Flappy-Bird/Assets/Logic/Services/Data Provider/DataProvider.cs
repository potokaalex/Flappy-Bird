using System.Collections.Generic;

namespace FlappyBird
{
    public class DataProvider : IDataProvider
    {
        private readonly List<IData> _data = new();

        public T Get<T>() where T : IData
        {
            foreach (var data in _data)
                if (data is T requiredData)
                    return requiredData;

            return default;
        }

        public void Set(params IData[] data)
            => _data.AddRange(data);
    }
}