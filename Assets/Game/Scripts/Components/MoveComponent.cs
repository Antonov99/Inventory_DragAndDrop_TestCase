using JetBrains.Annotations;
using UnityEngine;

namespace Components
{
    [UsedImplicitly]
    public class MoveComponent
    {
        private readonly RectTransform _transform;

        public MoveComponent(RectTransform transform)
        {
            _transform = transform;
        }

        public void Move(Vector2 delta)
        {
            _transform.anchoredPosition+=delta;
        }
    }
}