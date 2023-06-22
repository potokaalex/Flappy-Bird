namespace FlappyBird.Gameplay.Core.Score
{
    public class OpenSkinsAmountProgressWriter : IProgressDataWriter
    {
        public void OnDataSave(ProgressData data)
        {
            data.BirdOpenSkinsAmount = data.MaxScore switch
            {
                >= 10 => 3,
                >= 5 => 2,
                _ => 1
            };
        }
    }
}