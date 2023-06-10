using FlappyBird.Gameplay.Bird;

namespace FlappyBird
{
    public class PlayerProgress
    {
        public Score Score { get; } = new();

        public BirdData BirdData { get; } = new();
        
        public PipesData PipesData { get; } = new();

        // save/load
        
        //Сохранять:
        //максимальный score
        //баланс (score)
        //купленные скини.
        //настройки: бинды, звуки(вкл/выкл), действующие скины
    }
}