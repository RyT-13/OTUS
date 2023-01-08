using GameState;
using GameState.Listeners;
using UnityEngine;

namespace UI.Money
{
    public class MoneyPanelAdapter : MonoBehaviour,
        IConstructListener,
        IStartGameListener,
        IFinishGameListener
    {
        [SerializeField] private MoneyPanel _moneyPanel;

        private MoneyStorage _moneyStorage;

        void IConstructListener.Construct(GameContext context)
        {
            _moneyStorage = context.GetService<MoneyStorage>();
            _moneyPanel.SetupMoney(_moneyStorage.Money.ToString());
        }

        void IStartGameListener.OnStartGame()
        {
            _moneyStorage.OnMoneyChange += OnMoneyChanged;
        }

        void IFinishGameListener.OnFinishGame()
        {
            _moneyStorage.OnMoneyChange -= OnMoneyChanged;
        }

        private void OnMoneyChanged(int money)
        {
            _moneyPanel.UpdateMoney(money.ToString());
        }
    }
}
