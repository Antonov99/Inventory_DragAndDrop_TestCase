using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public event Action<PointerEventData> OnStartDrag;
        public event Action<Vector2> OnDragObject;
        public event Action<PointerEventData> OnStopDrag;

        private CanvasGroup _canvasGroup;
        private Canvas _canvas;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvas = GetComponentInParent<Canvas>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
            OnStartDrag?.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            OnDragObject?.Invoke(eventData.delta / _canvas.scaleFactor);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnStopDrag?.Invoke(eventData);
            _canvasGroup.blocksRaycasts = true;
        }
    }
}