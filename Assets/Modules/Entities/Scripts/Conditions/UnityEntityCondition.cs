using UnityEngine;

namespace Modules.Entities.Scripts.Conditions
{
    public abstract class UnityEntityCondition : MonoBehaviour, IEntityCondition
    {
        public abstract bool IsTrue(IEntity entity);
    }
}
