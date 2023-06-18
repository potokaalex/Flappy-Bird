using System;

namespace FlappyBird
{
    [Serializable]
    public class ProgressData : IData
    {
        public int BirdCurrentSkinIndex;
        public int BirdOpenSkinsAmount;

        public uint MaxScore;
        
        public bool IsSoundPlaying;
    }
}