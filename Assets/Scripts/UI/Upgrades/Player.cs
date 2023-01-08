using UnityEngine;

namespace UI.Upgrades
{
    [CreateAssetMenu(fileName = "Player", menuName = "UI SO/New Player", order = 0)]
    public class Player : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public string Description;
        
        public int Level;
        public int MaxLevel;
        public int HitPoints;
        public int MaxHitPoints;
        public int Damage;
    }
}
