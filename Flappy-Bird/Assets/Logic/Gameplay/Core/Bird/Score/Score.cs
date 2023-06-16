using System;

namespace FlappyBird.Gameplay.Core.Bird
{
    public class Score//score data?
    {
        public event Action<float> OnCurrentScoreChanged;

        public float _currentScore;
        //private float _maxScore;
        
        public void IncreaseScore()
        {
            _currentScore += 1;
            OnCurrentScoreChanged?.Invoke(_currentScore);
        }

        /*
        public float GetMaxScore()
            => _currentScore > _maxScore ? _currentScore : _maxScore;

        public byte[] Serialize() //получаем поток байт для сохранения
        {
            //_maxScore to data.
            return default;
        }

        public void Deserialize(byte[] data) //из потока байт восстанавливаем состояние.
        {
            //data to _maxScore!
        }
        */
    }
}