using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Camera))]
    public class CameraConstantWidth : MonoBehaviour
    {
        [SerializeField] private Vector2 _defaultResolution;
        [SerializeField] [Range(0f, 1f)] private float _widthOrHeight;

        private Camera _componentCamera;
        private float _initialSize;

        private void Awake()
        {
            _componentCamera = GetComponent<Camera>();
            _initialSize = _componentCamera.orthographicSize;
        }

        private void Update()
        {
            if (!_componentCamera.orthographic)
                return;

            var targetAspect = _defaultResolution.x / _defaultResolution.y;
            var constantWidthSize = _initialSize * (targetAspect / _componentCamera.aspect);

            _componentCamera.orthographicSize = Mathf.Lerp(constantWidthSize, _initialSize, _widthOrHeight);
        }
    }
}