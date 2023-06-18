namespace FlappyBird
{
    public interface IProgressDataReader : IProgressDataWatcher
    {
        public void OnDataLoad(ProgressData data);
    }
}