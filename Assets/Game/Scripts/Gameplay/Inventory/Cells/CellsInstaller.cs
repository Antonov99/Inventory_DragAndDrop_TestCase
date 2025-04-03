using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game
{
    [UsedImplicitly]
    public class CellsInstaller : Installer<Cell, Transform, CellsInstaller>
    {
        [Inject]
        private Cell _cardPrefab;

        [Inject]
        private Transform _fieldOfView;

        public override void InstallBindings()
        {
            Container.Bind<CellSpawner>().AsSingle().WithArguments(_fieldOfView).NonLazy();
            Container.BindInterfacesAndSelfTo<CellsSpawnController>().AsSingle().NonLazy();
            Container.Bind<CellManager>().AsSingle().NonLazy();

            Container.BindMemoryPool<Cell, MonoMemoryPool<Cell>>()
                .WithInitialSize(9)
                .FromComponentInNewPrefab(_cardPrefab)
                .UnderTransformGroup("Cells").NonLazy();
        }
    }
}