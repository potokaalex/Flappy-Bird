using UnityEngine.SceneManagement;
using FlappyBird.StateMachine;
using UnityEngine;

[CreateAssetMenu(
    fileName = "New Scene Loading Configuration", 
    menuName = "Configurations/Scene Loading")]
public class SceneLoadingConfiguration : ScriptableObject, IStateParameter
{
    public LoadSceneMode LoadSceneMode;
    public string SceneName;
}
