namespace FlappyBird
{
    public class ScoreProgressWriter : IProgressDataWriter
    {
        private readonly Contexts _contexts;

        public ScoreProgressWriter(Contexts contexts) 
            => _contexts = contexts;

        public void OnDataSave(ProgressData data)
        {
            var currentScore = _contexts.input.scoreData.CurrentScore;

            if (currentScore > data.MaxScore)
                data.MaxScore = currentScore;

            data.CurrentScore = currentScore;
        }
    }
}