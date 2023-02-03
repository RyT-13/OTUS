namespace Core.Components.Abstract.GameObjects
{
    public interface ILoadZoneComponent
    {
        bool CanLoad();
        
        void Load(int resources);
    }
}
