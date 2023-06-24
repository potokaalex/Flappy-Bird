namespace FlappyBird.Gameplay.Core.Score
{
    public class OpenSkinsAmountProgressWriter : IProgressDataWriter
    {
        public void OnDataSave(ProgressData data)
        {
            data.BirdOpenSkinsAmount = data.MaxScore switch
            {
                >= 5 => 3,
                >= 1 => 2,
                _ => 1
            };
        }
    }
}