using Components;
using Entities;
using UnityEngine;
using Zenject;

namespace Game
{
    public class ItemEntityInstaller : MonoInstaller
    {
        [SerializeField]
        private RectTransform _transform;

        [SerializeField]
        private Entity _entity;

        [SerializeField]
        private DragHandler _dragHandler;

        public override void InstallBindings()
        {
            Container.Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(_transform)
                .NonLazy();

            Container.BindInterfacesAndSelfTo<ItemMoveController>()
                .AsSingle()
                .WithArguments(_entity, _dragHandler)
                .NonLazy();
            
            Container.BindInterfacesAndSelfTo<ItemPlaceController>()
                .AsSingle()
                .WithArguments(_dragHandler)
                .NonLazy();
        }
    }
}