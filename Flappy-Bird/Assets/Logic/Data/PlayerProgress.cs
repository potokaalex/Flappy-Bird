using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class PlayerProgress : IPlayerProgress
    {
        private const string PrefsKey = nameof(PlayerProgress);

        private readonly List<IProgressDataReader> _dataReaders;
        private readonly List<IProgressDataWriter> _dataWriters;
        private readonly IDataProvider _dataProvider;

        public PlayerProgress(IDataProvider dataProvider)
        {
            _dataReaders = new();
            _dataWriters = new();
            _dataProvider = dataProvider;
        }

        public void Initialize(ProgressData defaultData)
        {
            if (IsNoSavedProgress())
                SaveProgressData(defaultData);

            LoadData();
        }

        public void RegisterWatcher(IProgressDataWatcher watcher)
        {
            if (watcher is IProgressDataReader reader)
                _dataReaders.Add(reader);

            if (watcher is IProgressDataWriter writer)
                _dataWriters.Add(writer);
        }

        public void UnregisterWatcher(IProgressDataWatcher watcher)
        {
            if (watcher is IProgressDataReader reader)
                _dataReaders.Remove(reader);

            if (watcher is IProgressDataWriter writer)
                _dataWriters.Remove(writer);
        }

        public void SaveData()
        {
            var data = LoadProgressData();

            foreach (var writer in _dataWriters)
                writer.OnDataSave(data);

            SaveProgressData(data);
        }

        public void LoadData()
        {
            var data = LoadProgressData();

            foreach (var reader in _dataReaders)
                reader.OnDataLoad(data);

            _dataProvider.Set(data);
        }

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