using GameState;
using GameState.Listeners;
using Sirenix.OdinInspector;
using UI.Popups;
using UnityEngine;

namespace UI.Upgrades
{
    public class UpgradeShower : MonoBehaviour, IConstructListener
    {
        private PopupManager _popupManager;
        
        public void Construct(GameContext context)
        {
            _popupManager = context.GetService<PopupManager>();
        }

        [Button]
        public void ShowUpgrade(Player player)
        {
            var presentationModel = new UpgradePresentationModel(player);
            _popupManager.ShowPopup(PopupName.UPGRADE, presentationModel);
        }
    }
}
