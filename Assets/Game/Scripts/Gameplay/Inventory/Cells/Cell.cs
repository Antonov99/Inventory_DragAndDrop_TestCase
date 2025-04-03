using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Cell : MonoBehaviour
    {
        [SerializeField]
        private Image _background;

        [SerializeField]
        private Vector2Int _pos;
        
        public void SetBackground(Sprite background)
        {
            _background.sprite = background;
        }

        public void SetCoordinates(Vector2Int coordinates)
        {
            _pos = coordinates;
        }

        public Vector2Int GetCoordinates()
        {
            return _pos;
        }
    }
}