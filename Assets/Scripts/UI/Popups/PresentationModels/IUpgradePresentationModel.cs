using System;
using UnityEngine;

namespace UI.Popups.PresentationModels
{
    public interface IUpgradePresentationModel
    {
        event Action<bool> OnUpgradeButtonStateChanged;
        
        Sprite GetIcon();
        string GetName();
        string GetDescription();
        
        string GetLevel();
        string GetHitPoints();
        string GetDamage();

        bool CanUpgrade();
        void OnUpgradeClicked();
    }
}
