using FlappyBird.Gameplay.Core.Grass;
using FlappyBird.Gameplay.Core.Pipes;
using FlappyBird.Gameplay.Core.Score;
using FlappyBird.Gameplay.Core.Bird;

namespace FlappyBird
{
    public class ProgressData : IData
    {
        public BirdProgressData Bird { get; } = new();

        public ScoreProgressData Score { get; } = new();
        
        // save/load
        
        //Сохранять:
        //максимальный score
        //баланс (score)
        //купленные скини.
        //настройки: бинды, звуки(вкл/выкл), действующие скины
        
        //progress reader/writer (s)
        
        
        //в прогресс нелья писать напрямую?!
    }
}