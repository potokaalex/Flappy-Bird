using Entitas.CodeGeneration.Attributes;
using Entitas;
using System;

namespace FlappyBird.Gameplay.Core.Score
{
    [Input,Unique]
    public class ScoreDataComponent : IComponent
    {
        public event Action<uint> OnCurrentScoreChanged;
        private uint _currentScore;

        public uint CurrentScore
        {
            set
            {
                _currentScore = value;
                OnCurrentScoreChanged?.Invoke(value);
            }
            
            get => _currentScore;
        }
    }
}