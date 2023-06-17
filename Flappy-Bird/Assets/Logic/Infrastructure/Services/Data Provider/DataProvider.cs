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

                if (_data.ContainsKey(type))
                {
                    _data.Remove(type);
                }

                _data.Add(type, dataToSet);
            }
        }
        
        /*
         public void Set(params IData[] data)
        {
            foreach (var dataToSet in data)
            {
                var type = dataToSet.GetType();

                if (_data.ContainsKey(type))
                {
                    _data[type] = dataToSet;
                    return;
                }

                _data.Add(type, dataToSet);
            }
        }
         */
    }
}