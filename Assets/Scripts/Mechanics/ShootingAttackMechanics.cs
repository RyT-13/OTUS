using Entities;
using UnityEngine;

namespace Mechanics
{
    public class ShootingAttackMechanics : BaseAttackWithCooldownMechanics
    {
        [Space] [SerializeField] private Projectile _projectilePref;
        [SerializeField] private Transform _shootPoint;

        protected override void OnAttack(int damage)
        {
            var projectile = Instantiate(_projectilePref, _shootPoint.position, _shootPoint.rotation);
            projectile.Init(damage);
        }
    }
}
