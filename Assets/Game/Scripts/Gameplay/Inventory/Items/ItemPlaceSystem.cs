using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game
{
    [UsedImplicitly]
    public class ItemPlaceSystem
    {
        private readonly Inventory _inventory;
        private readonly Transform _weaponPlaceholder;
        private readonly GraphicRaycaster _graphicRaycaster;

        public ItemPlaceSystem(Inventory inventory, Transform weaponPlaceholder, GraphicRaycaster graphicRaycaster)
        {
            _inventory = inventory;
            _weaponPlaceholder = weaponPlaceholder;
            _graphicRaycaster = graphicRaycaster;
        }

        public void PlaceItem(PointerEventData eventData)
        {
            Item item = eventData.pointerDrag.GetComponent<Item>();
            if (item is null) throw new NullReferenceException("Null dragging object");

            eventData.position = item.AnchoredStartPoint.position;
            List<RaycastResult> results = new();
            _graphicRaycaster.Raycast(eventData, results);

            if (results.Count <= 0)
            {
                item.transform.SetParent(_weaponPlaceholder);
                return;
            }

            RaycastResult result = results[0];
            Cell cell = result.gameObject.GetComponentInParent<Cell>();

            if (cell == null)
            {
                item.transform.SetParent(_weaponPlaceholder);
                return;
            }

            Vector2Int positionForInventoryAdding = cell.GetCoordinates();

            if (!_inventory.AddItem(item, positionForInventoryAdding))
            {
                item.transform.SetParent(_weaponPlaceholder);
                return;
            }

            var position = cell.transform.position;
            item.transform.position = new Vector3(position.x + item.Width, position.y - item.Height, 0);
        }

        public void StartDrag(PointerEventData eventData)
        {
            Transform pointerDragTransform = eventData.pointerDrag.transform;
            var canvas = pointerDragTransform.GetComponentInParent<Canvas>();
            pointerDragTransform.SetParent(canvas.transform);

            Item item = pointerDragTransform.GetComponent<Item>();
            var result = _inventory.RemoveItem(item);
            Debug.Log(result);
        }
    }
}