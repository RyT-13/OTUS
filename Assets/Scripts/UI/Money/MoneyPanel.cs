using TMPro;
using UnityEngine;

namespace UI.Money
{
    public class MoneyPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        
        public void SetupMoney(string money)
        {
            _moneyText.text = money;
        }

        public void UpdateMoney(string money)
        {
            _moneyText.text = money;
        }
    }
}
