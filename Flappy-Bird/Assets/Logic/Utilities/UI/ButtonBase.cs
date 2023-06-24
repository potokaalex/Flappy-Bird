using UnityEngine.UI;
using UnityEngine;

namespace FlappyBird
{
    public abstract class ButtonBase : MonoBehaviour
    {
        [SerializeField] private Button _selectableButton;

        private protected virtual void Awake()
            => _selectableButton.onClick.AddListener(OnClick);

        private protected virtual void OnDestroy()
            => _selectableButton.onClick.RemoveListener(OnClick);

        private protected abstract void OnClick();
    }
}