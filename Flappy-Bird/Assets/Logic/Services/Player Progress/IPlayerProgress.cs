namespace FlappyBird
{
    public interface IPlayerProgress
    {
        public void Initialize(ProgressData defaultData);
        
        public void RegisterWatcher(IProgressDataWatcher watcher);
        
        public void UnregisterWatcher(IProgressDataWatcher watcher);

        public void SaveData();

        public void LoadData();

        public void ClearData();
    }
}