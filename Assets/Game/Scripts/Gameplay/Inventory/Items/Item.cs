using UnityEngine;

namespace Game
{
    public sealed class Item : MonoBehaviour
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private Vector2Int[] _sizeArray;

        [SerializeField]
        private Transform _anchoredStartPoint;

        [SerializeField]
        private int _width;

        [SerializeField]
        private int _height;

        public string Name => _name;
        public Vector2Int[] SizeArray => _sizeArray;
        public Transform AnchoredStartPoint => _anchoredStartPoint;
        public int Width => _width;
        public int Height => _height;
    }
}