using FlappyBird.Gameplay.Core.Bird;

namespace FlappyBird
{
    public class PlayerProgress : IData
    {
        public Score Score { get; } = new();

        public BirdData BirdData { get; } = new();
        
        public PipesData PipesData { get; } = new();
        
        public GrassData GrassData { get; } = new();

        // save/load
        
        //Сохранять:
        //максимальный score
        //баланс (score)
        //купленные скини.
        //настройки: бинды, звуки(вкл/выкл), действующие скины
    }
}