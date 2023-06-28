namespace FlappyBird
{
    public interface IPlayerProgress
    {
        public void Initialize(IProgressData defaultData);

        public void SaveData(IProgressData data);

        public IProgressData LoadData();

        public void ClearData();
    }
}