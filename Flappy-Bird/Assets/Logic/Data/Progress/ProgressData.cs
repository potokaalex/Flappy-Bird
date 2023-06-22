using System;

namespace FlappyBird
{
    [Serializable]
    public class ProgressData : IData
    {
        public int BirdCurrentSkinIndex;
        public int BirdOpenSkinsAmount;
        public int MaxOpenSkinsAmount;

        public uint CurrentScore;
        public uint MaxScore;
    }
}