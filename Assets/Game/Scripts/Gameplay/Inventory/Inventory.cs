using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class Inventory : IEnumerable<Item>
    {
        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        public int Width { get; }
        public int Height { get; }
        public int Count { get; private set; }

        public readonly Item[,] cells;
        public readonly Dictionary<Item, List<Vector2Int>> itemMap;

        public Inventory(in int width, in int height)
        {
            if (width < 0 || height < 0 || (width == 0 && height == 0)) throw new ArgumentException();
            Width = width;
            Height = height;
            cells = new Item[width, height];
            itemMap = new Dictionary<Item, List<Vector2Int>>();
        }

        public Inventory(InventoryConfig inventoryConfig)
        {
            if (inventoryConfig.Width < 0 || inventoryConfig.Height < 0 ||
                (inventoryConfig.Width == 0 && inventoryConfig.Height == 0)) throw new ArgumentException();
            Width = inventoryConfig.Width;
            Height = inventoryConfig.Height;
            cells = new Item[inventoryConfig.Width, inventoryConfig.Height];
            itemMap = new Dictionary<Item, List<Vector2Int>>();
        }

        public Inventory(
            in int width,
            in int height,
            params KeyValuePair<Item, Vector2Int>[] items
        ) : this(width, height)
        {
            if (items is null) throw new ArgumentException();
            foreach (var item in items)
            {
                AddItem(item.Key, item.Value);
            }
        }

        public Inventory(
            in int width,
            in int height,
            in IEnumerable<KeyValuePair<Item, Vector2Int>> items
        ) : this(width, height)
        {
            if (items is null) throw new ArgumentException();
            foreach (var item in items)
            {
                AddItem(item.Key, item.Value);
            }
        }

        public bool CanAddItem(in Item item, in Vector2Int position)
        {
            if (item is null) return false;
            if (item.SizeArray is null) throw new ArgumentException();
            if (Contains(item)) return false;
            
            Vector2Int[] points = item.SizeArray;

            foreach (var point in points)
            {
                if (position.x + point.x >= Width ||
                    position.y + point.y >= Height ||
                    position.x < 0 || position.y < 0)
                {
                    return false;
                }
                
                if (cells[point.x + position.x, point.y + position.y] != null)
                {
                    return false;
                }
            }

            return true;
        }

        public bool AddItem(in Item item, in Vector2Int position)
        {
            if (!CanAddItem(item, position))
            {
                return false;
            }

            Vector2Int[] itemSizeArray = item.SizeArray;
            List<Vector2Int> points = new(itemSizeArray);
            List<Vector2Int> newPoints = new(points.Count);

            foreach (var point in points)
            {
                var x = point.x + position.x;
                var y = point.y + position.y;
                
                cells[x, y] = item;
                newPoints.Add(new Vector2Int(x,y));
            }

            itemMap.Add(item, newPoints);
            Count++;
            OnAdded?.Invoke(item, position);

            return true;
        }

        public bool RemoveItem(in Item item)
        {
            if (!Contains(item)) return false;

            var points = itemMap[item];
            if (points is null) return false;

            foreach (var point in points)
            {
                cells[point.x, point.y] = null;
                Debug.Log($"{point.x} & { point.y}");
            }

            itemMap.Remove(item);

            return true;
        }

        public bool Contains(in Item item)
        {
            if (item is null) return false;
            return itemMap.ContainsKey(item);
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return itemMap.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}