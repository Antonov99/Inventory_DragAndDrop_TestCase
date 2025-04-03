using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game
{
    [UsedImplicitly]
    public class ItemInstaller : Installer<Transform, GraphicRaycaster, ItemInstaller>
    {
        [Inject]
        private Transform _placeholder;

        [Inject]
        private GraphicRaycaster _graphicRaycaster;

        public override void InstallBindings()
        {
            Container.Bind<ItemPlaceSystem>()
                .AsSingle()
                .WithArguments(_placeholder, _graphicRaycaster)
                .NonLazy();
        }
    }
}