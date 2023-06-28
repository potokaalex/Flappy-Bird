using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(RectTransform))]
    public class WorkingAreaTransformer : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Awake()
            => _rectTransform = gameObject.GetComponent<RectTransform>();

        private void Start()
            => FitToWorkingArea();

        private void FitToWorkingArea()
        {
            var safeArea = Screen.safeArea;
            var minAnchor = safeArea.position;
            var maxAnchor = safeArea.position + safeArea.size;

            _rectTransform.anchorMin = NormalizeScreenPoint(minAnchor);
            _rectTransform.anchorMax = NormalizeScreenPoint(maxAnchor);
        }

        private Vector2 NormalizeScreenPoint(Vector2 pixelPoint)
            => pixelPoint / new Vector2(Screen.width, Screen.height);
    }
}