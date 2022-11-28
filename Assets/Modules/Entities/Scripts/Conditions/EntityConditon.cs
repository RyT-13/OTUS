using System;

namespace Modules.Entities.Scripts.Conditions
{
    public sealed class EntityCondition : IEntityCondition
    {
        private readonly Func<IEntity, bool> condition;
        
        public EntityCondition(Func<IEntity, bool> condition)
        {
            this.condition = condition;
        }
        
        public bool IsTrue(IEntity entity)
        {
            return this.condition.Invoke(entity);
        }
    }
}
