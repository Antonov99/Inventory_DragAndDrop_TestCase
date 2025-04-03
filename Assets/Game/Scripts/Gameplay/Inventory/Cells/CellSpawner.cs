using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game
{
    [UsedImplicitly]
    public class CellSpawner
    {
        private readonly MonoMemoryPool<Cell> _cardPool;
        private readonly Transform _fieldOfView;

        public CellSpawner(MonoMemoryPool<Cell> cardPool, Transform fieldOfView)
        {
            _cardPool = cardPool;
            _fieldOfView = fieldOfView;
        }

        public Cell SpawnCard()
        {
            var card = _cardPool.Spawn();
            card.transform.SetParent(_fieldOfView, false);

            return card;
        }

        public void RemoveCard(Cell card)
        {
            _cardPool.Despawn(card);
        }
    }
}