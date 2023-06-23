namespace FlappyBird
{
    public class ScoreProgressWriter : IProgressDataWriter
    {
        private readonly Contexts _contexts;

        public ScoreProgressWriter(Contexts contexts) 
            => _contexts = contexts;

        public void OnDataSave(ProgressData data)
        {
            data.CurrentScore = _contexts.input.scoreData.CurrentScore;

            if (data.CurrentScore > data.MaxScore)
                data.MaxScore = data.CurrentScore;
        }
    }
}