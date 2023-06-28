using System;

namespace FlappyBird
{
    [Serializable]
    public class ProgressData : IProgressData
    {
        public int BirdCurrentSkinIndex;
        public int BirdOpenSkinsAmount;
        
        public uint CurrentScore;
        public uint MaxScore;
    }
}