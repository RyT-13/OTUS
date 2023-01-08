using System;
using UnityEngine;

namespace UI.Popups.PresentationModels
{
    public interface IProductPresentationModel
    {
        event Action<bool> OnBuyButtonStateChanged;

        void Start();
        void Stop();
        
        string GetTitle();
        string GetDescription();
        Sprite GetIcon();
        string GetPrice();
        bool CanBuy();
        void OnBuyClicked();
    }
}
