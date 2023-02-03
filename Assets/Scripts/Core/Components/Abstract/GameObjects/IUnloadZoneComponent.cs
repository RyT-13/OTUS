namespace Core.Components.Abstract.GameObjects
{
    public interface IUnloadZoneComponent
    {
        bool CanUnload();
        
        int UnloadAll();
    }
}
