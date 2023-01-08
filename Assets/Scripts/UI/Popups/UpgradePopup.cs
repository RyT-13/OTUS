using System;
using TMPro;
using UI.Popups.PresentationModels;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class UpgradePopup : Popup
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private TextMeshProUGUI _nameText;
        [SerializeField] private TextMeshProUGUI _descriptionText;
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private TextMeshProUGUI _hitPointsText;
        [SerializeField] private TextMeshProUGUI _damageText;
        [SerializeField] private Button _upgradeButton;

        private IUpgradePresentationModel _presenter;

        protected override void OnShow(object args)
        {
            if (args is not IUpgradePresentationModel presenter)
            {
                throw new Exception("Expected Upgrade presentation model!");
            }

            _presenter = presenter;

            _presenter.OnUpgradeButtonStateChanged += OnUpgradeButtonStateChanged;

            _nameText.text = presenter.GetName();
            _descriptionText.text = presenter.GetDescription();
            _iconImage.sprite = presenter.GetIcon();

            UpdateStats();

            _upgradeButton.interactable = presenter.CanUpgrade();
            _upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
        }

        protected override void OnHide()
        {
            _presenter.OnUpgradeButtonStateChanged -= OnUpgradeButtonStateChanged;
            _upgradeButton.onClick.RemoveListener(OnUpgradeButtonClicked);
        }

        private void OnUpgradeButtonStateChanged(bool isAvailable)
        {
            _upgradeButton.interactable = isAvailable;
        }

        private void OnUpgradeButtonClicked()
        {
            _presenter.OnUpgradeClicked();
            UpdateStats();
        }

        private void UpdateStats()
        {
            _levelText.text = $"Level: {_presenter.GetLevel()}";
            _hitPointsText.text = $"Hit Points: {_presenter.GetHitPoints()}";
            _damageText.text = $"Damage: {_presenter.GetDamage()}";
        }
    }
}
