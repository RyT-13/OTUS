using System;
using TMPro;
using UI.Popups.PresentationModels;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class ProductPopup : Popup
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _buyButtonText;
        [SerializeField] private Button _buyButton;

        private IProductPresentationModel _presenter;

        protected override void OnShow(object args)
        {
            if (args is not IProductPresentationModel presenter)
            {
                throw new Exception("Expected Product presentation model!");
            }
            
            _presenter = presenter;

            _presenter.OnBuyButtonStateChanged += OnBuyButtonStateChanged;
            _presenter.Start();
            
            _titleText.text = presenter.GetTitle();
            _descriptionText.text = presenter.GetDescription();
            _iconImage.sprite = presenter.GetIcon();
            
            _buyButtonText.text = presenter.GetPrice();
            _buyButton.interactable = presenter.CanBuy();
            
            _buyButton.onClick.AddListener(OnBuyButtonClicked);
        }

        protected override void OnHide()
        {
            _presenter.OnBuyButtonStateChanged -= OnBuyButtonStateChanged;
            _buyButton.onClick.RemoveListener(OnBuyButtonClicked);
            _presenter.Stop();
        }

        private void OnBuyButtonStateChanged(bool isAvailable)
        {
            _buyButton.interactable = isAvailable;
        }
        
        private void OnBuyButtonClicked()
        {
            _presenter.OnBuyClicked();
        }
    }
}
