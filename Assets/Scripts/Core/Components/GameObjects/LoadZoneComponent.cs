using Core.Components.Abstract.GameObjects;
using Core.Primitives;
using UnityEngine;

namespace Core.Components.GameObjects
{
    public class LoadZoneComponent : MonoBehaviour, ILoadZoneComponent
    {
        [SerializeField]
        private IntBehaviourLimited _loadStorage;

        public bool CanLoad()
        {
            return _loadStorage.IsLimit == false;
        }

        public void Load(int resources)
        {
            _loadStorage.Value += resources;
        }
    }
}
