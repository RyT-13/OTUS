using System;
using UI.Money;
using UI.Popups.PresentationModels;
using UnityEngine;

namespace UI.Products
{
    public class ProductPresentationModel : IProductPresentationModel
    {
        public event Action<bool> OnBuyButtonStateChanged;

        private readonly MoneyStorage _moneyStorage;
        private readonly ProductBuyer _productBuyer;
        private readonly Product _product;
        
        public ProductPresentationModel(Product product, ProductBuyer productBuyer, MoneyStorage moneyStorage)
        {
            _product = product;
            _productBuyer = productBuyer;
            _moneyStorage = moneyStorage;
        }

        public void Start()
        {
            _moneyStorage.OnMoneyChange += OnMoneyChange;
        }

        public void Stop()
        {
            _moneyStorage.OnMoneyChange -= OnMoneyChange;
        }

        public string GetTitle()
        {
            return _product.Title;
        }

        public string GetDescription()
        {
            return _product.Description;
        }

        public Sprite GetIcon()
        {
            return _product.Icon;
        }

        public string GetPrice()
        {
            return _product.Price.ToString();
        }

        public bool CanBuy()
        {
            return _productBuyer.CanBuy(_product);
        }

        public void OnBuyClicked()
        {
            _productBuyer.Buy(_product);
        }

        private void OnMoneyChange(int money)
        {
            var canBuy = _productBuyer.CanBuy(_product);
            OnBuyButtonStateChanged?.Invoke(canBuy);
        }
    }
}
