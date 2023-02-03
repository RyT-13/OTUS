using System.Collections.Generic;
using UnityEngine;

namespace Visual.GameObjects
{
    public class ConveyorZoneVisual : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _items;

        private int _currentAmount;

        public void SetupItems(int currentAmount)
        {
            _currentAmount = Mathf.Min(currentAmount, _items.Count);

            for (int i = 0; i < currentAmount; i++)
            {
                var item = _items[i];
                item.SetActive(true);
            }

            for (int i = currentAmount; i < _items.Count; i++)
            {
                var item = _items[i];
                item.SetActive(false);
            }
        }

        public void IncrementItems(int range)
        {
            var prevAmount = _currentAmount;
            var newAmount = Mathf.Min(_currentAmount + range, _items.Count);
            _currentAmount = newAmount;

            for (int i = prevAmount; i < newAmount; i++)
            {
                var item = _items[i];
                item.SetActive(true);
            }
        }

        public void DecrementItems(int range)
        {
            var prevAmount = _currentAmount;
            var newAmount = Mathf.Max(_currentAmount - range, 0);
            _currentAmount = newAmount;

            for (int i = prevAmount - 1; i >= newAmount; i--)
            {
                var item = _items[i];
                item.SetActive(false);
            }
        }
    }
}
