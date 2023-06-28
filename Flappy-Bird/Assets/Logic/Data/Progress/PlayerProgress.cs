using UnityEngine;

namespace FlappyBird
{
    public class PlayerProgress : IPlayerProgress
    {
        private const string PrefsKey = nameof(PlayerProgress);

        public void Initialize(IProgressData defaultData)
        {
            if (LoadData() == null)
                SaveData(defaultData);
        }

        public void SaveData(IProgressData data)
            => PlayerPrefs.SetString(PrefsKey, JsonUtility.ToJson(data));

        public IProgressData LoadData()
            => JsonUtility.FromJson<ProgressData>(PlayerPrefs.GetString(PrefsKey));

        public void ClearData()
            => PlayerPrefs.DeleteKey(PrefsKey);
    }
}