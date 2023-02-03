using Core.Components.Abstract.GameObjects;
using Core.Primitives;
using UnityEngine;

namespace Core.Components.GameObjects
{
    public class UnloadZoneComponent : MonoBehaviour, IUnloadZoneComponent
    {
        [SerializeField] private IntBehaviourLimited _unloadStorage;


        public bool CanUnload()
        {
            return _unloadStorage.Value > 0;
        }

        public int UnloadAll()
        {
            var result = _unloadStorage.Value;
            _unloadStorage.Value = 0;
            return result;
        }
    }
}
