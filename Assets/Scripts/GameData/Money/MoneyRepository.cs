using UnityEngine;

namespace GameData.Money
{
    public class MoneyRepository
    {
        private const string MONEY_PREFS_KEY = "MoneyData";
        
        public bool LoadMoney(out MoneyDTO dto)
        {
            if (PlayerPrefs.HasKey(MONEY_PREFS_KEY) == false)
            {
                dto = default;
                return false;
            }
            
            var json = PlayerPrefs.GetString(MONEY_PREFS_KEY);
            dto = JsonUtility.FromJson<MoneyDTO>(json);
            
            Debug.Log($"Load Money Data: {json}");
            
            return true;
        }
        
        public void SaveMoney(MoneyDTO dto)
        {
            var json = JsonUtility.ToJson(dto);
            PlayerPrefs.SetString(MONEY_PREFS_KEY, json);
            
            Debug.Log($"Save Money Data: {json}");
        }
    }
}
