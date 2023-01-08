using GameState;
using GameState.Listeners;
using Sirenix.OdinInspector;
using UI.Money;
using UI.Popups;
using UnityEngine;

namespace UI.Products
{
    public class ProductShower : MonoBehaviour, IConstructListener
    {
        private PopupManager _popupManager;
        private ProductBuyer _productBuyer;
        private MoneyStorage _moneyStorage;

        void IConstructListener.Construct(GameContext context)
        {
            _popupManager = context.GetService<PopupManager>();
            _productBuyer = context.GetService<ProductBuyer>();
            _moneyStorage = context.GetService<MoneyStorage>();
        }

        [Button]
        public void ShowProduct(Product product)
        {
            var presentationModel = new ProductPresentationModel(product, _productBuyer, _moneyStorage);
            _popupManager.ShowPopup(PopupName.PRODUCT, presentationModel);
        }
    }
}
