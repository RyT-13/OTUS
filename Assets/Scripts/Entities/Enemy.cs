using Primitives;
using UnityEngine;

namespace Entities
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private IntEventReceiver _takeDamageReceiver;

        public void TakeDamage(int damage)
        {
            _takeDamageReceiver.Call(damage);
        }
    }
}
