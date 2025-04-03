using System;
using JetBrains.Annotations;
using Zenject;

namespace Game
{
    [UsedImplicitly]
    public class CellsSpawnController : IInitializable, IDisposable
    {
        private readonly CellManager _cellManager;
        
        public CellsSpawnController( CellManager cellManager)
        {
            _cellManager = cellManager;
        }

        void IInitializable.Initialize()
        {
            SpawnCells();
        }

        private void SpawnCells()
        {
            _cellManager.SpawnCells();
        }

        void IDisposable.Dispose()
        {
        }
    }
}