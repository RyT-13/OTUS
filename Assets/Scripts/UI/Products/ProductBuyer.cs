using GameState;
using GameState.Listeners;
using Sirenix.OdinInspector;
using UI.Money;
using UnityEngine;

namespace UI.Products
{
    public class ProductBuyer : MonoBehaviour, IConstructListener
    {
        private MoneyStorage _moneyStorage;

        [Button]
        public bool CanBuy(Product product)
        {
            return _moneyStorage.Money >= product.Price;
        }
        
        [Button]
        public void Buy(Product product)
        {
            if (CanBuy(product))
            {
                _moneyStorage.SpendMoney(product.Price);
                Debug.Log($"<color=green>Product {product.Title} successfully purchased!</color>");
            }
            else
            {
                Debug.LogWarning($"<color=red>Not enough money for product {product.Title}!</color>");
            }
        }
        
        public void Construct(GameContext context)
        {
            _moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}
