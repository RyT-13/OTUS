using Core.Components.Abstract.GameObjects;
using Core.Primitives;
using GameResources;
using UnityEngine;

namespace Core.Components.GameObjects
{
    public class LoadZoneComponent : MonoBehaviour, ILoadZoneComponent
    {
        [SerializeField]
        private IntBehaviourLimited _loadStorage;

        [SerializeField]
        private ResourceType _resourceType;

        public ResourceType ResourceType => _resourceType;

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
