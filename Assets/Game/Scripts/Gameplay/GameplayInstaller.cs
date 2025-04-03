using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField]
        private Cell _cellPrefab;

        [SerializeField]
        private Transform _fieldOfView;

        [SerializeField]
        private InventoryConfig _inventoryConfig;

        [SerializeField]
        private Transform _weaponPlaceholder;

        [SerializeField]
        private GraphicRaycaster _graphicRaycaster;

        public override void InstallBindings()
        {
            CellsInstaller.Install(Container, _cellPrefab, _fieldOfView);
            InventoryInstaller.Install(Container, _inventoryConfig);
            ItemInstaller.Install(Container, _weaponPlaceholder, _graphicRaycaster);
        }
    }
}