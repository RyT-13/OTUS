using System.Linq;
using Core.Components.Abstract.GameObjects;
using Core.Entities;
using GameResources;
using Sirenix.OdinInspector;
using UnityEngine;

public class DoubleConveyorTest : MonoBehaviour
{
    [SerializeField] private Entity _conveyor;

    [Button]
    private void LoadResource(ResourceType type, int count)
    {
        var loadComponents = _conveyor.GetAll<ILoadZoneComponent>();
        var loadComponent = loadComponents.FirstOrDefault(c => c.ResourceType == type);
        
        if (loadComponent is not null && loadComponent.CanLoad())
        {
            loadComponent.Load(count);
        }
    }

    [Button]
    private void TakeAllResources()
    {
        var unloadComponent = _conveyor.Get<IUnloadZoneComponent>();
        
        if (unloadComponent.CanUnload())
        {
            unloadComponent.UnloadAll();
        }
    }
}
