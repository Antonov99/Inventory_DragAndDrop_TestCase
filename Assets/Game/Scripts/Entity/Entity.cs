using UnityEngine;
using Zenject;

namespace Game
{
    [RequireComponent(typeof(GameObjectContext))]
    public class Entity : MonoBehaviour, IEntity
    {
        private DiContainer _container;

        private void Awake()
        {
            _container = GetComponent<GameObjectContext>().Container;
        }

        public T Get<T>()
        {
            return _container.Resolve<T>();
        }
    }
}