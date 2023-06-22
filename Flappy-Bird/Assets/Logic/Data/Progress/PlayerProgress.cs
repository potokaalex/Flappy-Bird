using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class PlayerProgress : IPlayerProgress
    {
        private const string PrefsKey = nameof(PlayerProgress);
        
        private readonly List<IProgressDataWriter> _dataWriters;
        private readonly IDataProvider _dataProvider;

        public PlayerProgress(IDataProvider dataProvider)
        {
            _dataWriters = new();
            _dataProvider = dataProvider;
        }

        public void Initialize(ProgressData defaultData)
        {
            if (IsNoSavedProgress())
                SaveProgressData(defaultData);
        }

        public void RegisterWriter(IProgressDataWriter writer) 
            => _dataWriters.Add(writer);

        public void UnregisterAllWriters() 
            => _dataWriters.Clear();

        public void SaveData()
        {
            var data = _dataProvider.Get<ProgressData>();

            foreach (var writer in _dataWriters)
                writer.OnDataSave(data);

            SaveProgressData(data);
        }

        public void LoadData() 
            => _dataProvider.Set(LoadProgressData());

        public void ClearData()
            => PlayerPrefs.DeleteKey(PrefsKey);

        private bool IsNoSavedProgress()
            => LoadProgressData() == null;

        private void SaveProgressData(ProgressData data)
            => PlayerPrefs.SetString(PrefsKey, JsonUtility.ToJson(data));

        private ProgressData LoadProgressData()
            => JsonUtility.FromJson<ProgressData>(PlayerPrefs.GetString(PrefsKey));
    }
}