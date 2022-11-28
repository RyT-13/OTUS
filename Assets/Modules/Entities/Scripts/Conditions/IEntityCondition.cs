namespace Modules.Entities.Scripts.Conditions
{
    public interface IEntityCondition
    {
        bool IsTrue(IEntity entity);
    }
}