using Core.Entities;
using UnityEngine;

namespace Services
{
    public class CharacterService : MonoBehaviour
    {
        [SerializeField] private Entity _character;

        public Entity GetCharacter()
        {
            return _character;
        }
    }
}
