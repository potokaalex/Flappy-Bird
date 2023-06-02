using UnityEngine;
using System;

namespace FlappyBird
{
    [Serializable]
    public struct PlayerProgressConfiguration
    {
        public Transform BirdSpawnTransform;

        //Сохранять:
        //максимальный score
        //баланс (score)
        //купленные скини.
        //настройки: бинды, звуки(вкл/выкл), действующие скины
    }
}