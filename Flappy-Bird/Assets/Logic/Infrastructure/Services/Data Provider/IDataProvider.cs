using System.Collections.Generic;

namespace FlappyBird
{
    public interface IDataProvider
    {

        public T Get<T>() where T : IData;
        
        public void Set(params IData[] data);
    }
}