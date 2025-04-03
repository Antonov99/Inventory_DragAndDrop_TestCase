using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game
{
    [UsedImplicitly]
    public class ItemPlaceController : IInitializable, IDisposable
    {
        private readonly DragHandler _dragHandler;
        private readonly ItemPlaceSystem _itemPlaceSystem;

        public ItemPlaceController(DragHandler dragHandler, ItemPlaceSystem itemPlaceSystem)
        {
            _dragHandler = dragHandler;
            _itemPlaceSystem = itemPlaceSystem;
        }

        void IInitializable.Initialize()
        {
            _dragHandler.OnStartDrag += OnStartDrag;
            _dragHandler.OnStopDrag += OnStopDrag;
        }

        private void OnStartDrag(PointerEventData eventData)
        {
            _itemPlaceSystem.StartDrag(eventData);
        }

        private void OnStopDrag(PointerEventData eventData)
        {
            _itemPlaceSystem.PlaceItem(eventData);
        }

        void IDisposable.Dispose()
        {
            _dragHandler.OnStartDrag -= OnStartDrag;
            _dragHandler.OnStopDrag -= OnStopDrag;
        }
    }
}