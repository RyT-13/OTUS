using GameResources;

namespace Core.Components.Abstract.GameObjects
{
    public interface ILoadZoneComponent
    {
        ResourceType ResourceType { get; }
        
        bool CanLoad();
        
        void Load(int resources);
        
    }
}
