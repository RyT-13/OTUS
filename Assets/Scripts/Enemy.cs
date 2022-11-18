using Primitives;
using UnityEngine;

public class Enemy : MonoBehaviour
{
        [SerializeField] private IntEventReceiver _takeDamageReceiver;
        
        public void TakeDamage(int damage)
        {
                _takeDamageReceiver.Call(damage);
        }
}
