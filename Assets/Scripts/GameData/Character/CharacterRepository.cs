using UnityEngine;

namespace GameData.Character
{
    public class CharacterRepository
    {
        private const string PLAYER_PREFS_KEY = "CharacterData";

        public bool LoadStats(out CharacterData data)
        {
            if (PlayerPrefs.HasKey(PLAYER_PREFS_KEY) == false)
            {
                data = default;
                return false;
            }

            var json = PlayerPrefs.GetString(PLAYER_PREFS_KEY);
            data = JsonUtility.FromJson<CharacterData>(json);

            Debug.Log($"Load Character Data: {json}");
            
            return true;
        }

        public void SaveStats(CharacterData data)
        {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(PLAYER_PREFS_KEY, json);
            
            Debug.Log($"Save Character Data: {json}");

        }
    }
}
