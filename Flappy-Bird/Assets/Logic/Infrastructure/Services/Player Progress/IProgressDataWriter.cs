namespace FlappyBird
{
    public interface IProgressDataWriter : IProgressDataWatcher
    {
        public void OnDataSave(ProgressData data);
    }
}