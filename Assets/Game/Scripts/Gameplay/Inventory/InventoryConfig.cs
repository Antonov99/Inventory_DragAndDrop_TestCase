using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "InventoryConfig",
        menuName = "Inventory/New InventoryConfig",
        order = 1
    )]
    public class InventoryConfig : ScriptableObject
    {
        public int Width;

        public int Height;
    }
}