using UnityEngine;

namespace GameData.Character
{
    public class CharacterRepository
    {
        private const string PLAYER_PREFS_KEY = "CharacterData";

        public bool LoadStats(out CharacterDTO dto)
        {
            if (PlayerPrefs.HasKey(PLAYER_PREFS_KEY) == false)
            {
                dto = default;
                return false;
            }

            var json = PlayerPrefs.GetString(PLAYER_PREFS_KEY);
            dto = JsonUtility.FromJson<CharacterDTO>(json);

            Debug.Log($"Load Character Data: {json}");
            
            return true;
        }

        public void SaveStats(CharacterDTO dto)
        {
            var json = JsonUtility.ToJson(dto);
            PlayerPrefs.SetString(PLAYER_PREFS_KEY, json);
            
            Debug.Log($"Save Character Data: {json}");
        }
    }
}
