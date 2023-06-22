namespace FlappyBird
{
    public interface IPlayerProgress
    {
        public void Initialize(ProgressData defaultData);
        
        public void RegisterWriter(IProgressDataWriter writer);
        
        public void UnregisterAllWriters();

        public void SaveData();

        public void LoadData();

        public void ClearData();
    }
}