using UnityEngine.UI;
using UnityEngine;

public abstract class ButtonBase : MonoBehaviour
{
    [SerializeField] private Button _selectableButton;

    private void Awake()
        => _selectableButton.onClick.AddListener(OnClick);

    private void OnDestroy()
        => _selectableButton.onClick.RemoveListener(OnClick);

    private protected abstract void OnClick();
}