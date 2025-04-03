using System;
using Components;
using Entities;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game
{
    [UsedImplicitly]
    public class ItemMoveController : IInitializable, IDisposable
    {
        private MoveComponent _moveComponent;

        private readonly IEntity _entity;
        private readonly DragHandler _dragHandler;

        public ItemMoveController(IEntity entity, DragHandler dragHandler)
        {
            _entity = entity;
            _dragHandler = dragHandler;
        }

        void IInitializable.Initialize()
        {
            _moveComponent = _entity.Get<MoveComponent>();

            _dragHandler.OnDragObject += OnDrag;
        }

        private void OnDrag(Vector2 direction)
        {
            _moveComponent.Move(direction);
        }

        void IDisposable.Dispose()
        {
            _dragHandler.OnDragObject -= OnDrag;
        }
    }
}