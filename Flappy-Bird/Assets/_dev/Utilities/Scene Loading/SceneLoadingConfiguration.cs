using UnityEngine.SceneManagement;
using System;

namespace FlappyBird
{
    [Serializable]
    public struct SceneLoadingConfiguration : IStateParameter
    {
        public LoadSceneMode LoadSceneMode;
        public string SceneName;
    }
}