using System;
using UnityEngine;

namespace Game
{
    //Handler for drag events
    public class DragHandler : MonoBehaviour
    {
        public event Action OnStartDragging;
        public event Action<Vector2> OnDragObject;
        public event Action OnStopDragging;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            if (_camera == null) throw new NullReferenceException("Main Camera");
        }

        private void OnMouseDown()
        {
            OnStartDragging?.Invoke();
        }

        public void OnMouseDrag()
        {
            var direction = GetDirection();
            OnDragObject?.Invoke(direction);
        }

        private void OnMouseUp()
        {
            OnStopDragging?.Invoke();
        }

        private Vector3 GetDirection()
        {
            Vector3 newPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            return newPosition;
        }
    }
}