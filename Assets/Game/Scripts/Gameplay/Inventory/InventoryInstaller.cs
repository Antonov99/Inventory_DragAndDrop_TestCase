using JetBrains.Annotations;
using Zenject;

namespace Game
{
    [UsedImplicitly]
    public class InventoryInstaller : Installer<InventoryConfig, InventoryInstaller>
    {
        [Inject]
        private InventoryConfig _inventoryConfig;

        public override void InstallBindings()
        {
            Container.Bind<InventoryConfig>().FromInstance(_inventoryConfig).AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<Inventory>()
                .AsSingle()
                .NonLazy();
        }
    }
}