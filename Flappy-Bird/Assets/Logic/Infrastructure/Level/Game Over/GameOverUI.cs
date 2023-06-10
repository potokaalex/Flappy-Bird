using UnityEngine;

namespace FlappyBird.Infrastructure
{
    public class GameOverUI : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
        }
    }
}