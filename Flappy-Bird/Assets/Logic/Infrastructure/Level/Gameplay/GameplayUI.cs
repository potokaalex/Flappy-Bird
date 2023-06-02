using System.Globalization;
using UnityEngine;
using Zenject;

namespace FlappyBird.Infrastructure
{
    public class GameplayUI : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}