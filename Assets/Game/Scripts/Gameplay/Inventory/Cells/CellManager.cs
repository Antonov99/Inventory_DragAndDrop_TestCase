using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Game
{
    [UsedImplicitly]
    public class CellManager
    {
        private readonly List<Cell> _cells = new();

        private readonly InventoryConfig _inventoryConfig;
        private readonly CellSpawner _cellSpawner;

        public CellManager(InventoryConfig inventoryConfig, CellSpawner cellSpawner)
        {
            _inventoryConfig = inventoryConfig;
            _cellSpawner = cellSpawner;
        }

        public void SpawnCells()
        {
            for (int i = 0; i < _inventoryConfig.Height; i++)
            {
                for (var j = 0; j < _inventoryConfig.Width; j++)
                {
                    var cell = _cellSpawner.SpawnCard();
                    cell.SetCoordinates(new Vector2Int(j,i));
                    _cells.Add(cell);
                }
            }
        }

        public void DespawnCells()
        {
            foreach (var cell in _cells)
            {
                _cellSpawner.RemoveCard(cell);
                _cells.Remove(cell);
            }
        }
    }
}