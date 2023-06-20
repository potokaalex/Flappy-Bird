using System.Collections.Generic;
using System;

namespace FlappyBird
{
    public class DataProvider : IDataProvider
    {
        private readonly Dictionary<Type, IData> _data = new();

        public T Get<T>() where T : IData
            => (T)_data[typeof(T)];

        public void Set(params IData[] data)
        {
            foreach (var dataToSet in data)
            {
                var type = dataToSet.GetType();

                if (_data.TryAdd(type, dataToSet))
                    continue;
                
                _data[type] = dataToSet;
            }
        }
    }
}