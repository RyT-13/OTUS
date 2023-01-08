using System;
using UI.Popups.PresentationModels;
using UnityEngine;

namespace UI.Upgrades
{
    public class UpgradePresentationModel : IUpgradePresentationModel
    {
        private const int HitPointsMagnifier = 10;
        private const int DamageMagnifier = 5;

        public event Action<bool> OnUpgradeButtonStateChanged;

        private readonly Player _player;

        public UpgradePresentationModel(Player player)
        {
            _player = player;
        }

        public Sprite GetIcon()
        {
            return _player.Icon;
        }

        public string GetName()
        {
            return _player.Name;
        }

        public string GetDescription()
        {
            return _player.Description;
        }

        public string GetLevel()
        {
            return $"{_player.Level}/{_player.MaxLevel}";
        }

        public string GetHitPoints()
        {
            return $"{_player.HitPoints}/{_player.MaxHitPoints}";
        }

        public string GetDamage()
        {
            return _player.Damage.ToString();
        }

        public bool CanUpgrade()
        {
            return _player.Level < _player.MaxLevel;
        }

        public void OnUpgradeClicked()
        {
            UpgradePlayer();
            OnUpgradeButtonStateChanged?.Invoke(CanUpgrade());
        }

        private void UpgradePlayer()
        {
            _player.Level++;
            _player.MaxHitPoints += HitPointsMagnifier;
            _player.HitPoints += HitPointsMagnifier;
            _player.Damage += DamageMagnifier;
        }
    }
}
