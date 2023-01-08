using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI.Money
{
    public class MoneyStorage : MonoBehaviour
    {
        public event Action<int> OnMoneyChange;

        [ShowInInspector]
        public int Money { get; private set; }

        [Button]
        public void AddMoney(int range)
        {
            Money += range;
            OnMoneyChange?.Invoke(Money);
        }

        [Button]
        public void SpendMoney(int range)
        {
            Money -= range;
            OnMoneyChange?.Invoke(Money);
        }
    }
}
