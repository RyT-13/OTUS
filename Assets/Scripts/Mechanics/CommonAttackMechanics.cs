using Entities;
using UnityEngine;

namespace Mechanics
{
    public class CommonAttackMechanics : BaseAttackWithCooldownMechanics
    {
        [Space] [SerializeField] private Enemy _enemy;

        protected override void OnAttack(int damage)
        {
            _enemy.TakeDamage(damage);
        }
    }
}
