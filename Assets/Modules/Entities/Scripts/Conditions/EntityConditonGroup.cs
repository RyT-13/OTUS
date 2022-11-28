using System;
using UnityEngine;

namespace Modules.Entities.Scripts.Conditions
{
    [Serializable]
    public sealed class EntityConditionGroup : IEntityCondition
    {
#if ODIN_INSPECTOR
        [SerializeField]
#endif
        private IEntityCondition[] conditions;

        [SerializeField]
        private Mode mode;

        public EntityConditionGroup(Mode mode, params IEntityCondition[] conditions)
        {
            this.conditions = conditions;
            this.mode = mode;
        }

        public bool IsTrue(IEntity entity)
        {
            return this.mode switch
            {
                Mode.AND => this.All(entity),
                Mode.OR => this.Any(entity),
                _ => throw new Exception($"Mode is undefined {this.mode}")
            };
        }

        private bool All(IEntity entity)
        {
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                var condition = this.conditions[i];
                if (!condition.IsTrue(entity))
                {
                    return false;
                }
            }

            return true;
        }

        private bool Any(IEntity entity)
        {
            for (int i = 0, count = this.conditions.Length; i < count; i++)
            {
                var condition = this.conditions[i];
                if (condition.IsTrue(entity))
                {
                    return true;
                }
            }

            return false;
        }

        public enum Mode
        {
            AND,
            OR
        }
    }
}
