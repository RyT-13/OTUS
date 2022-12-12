using UnityEngine;

namespace GameState
{
    public class GameContextInstaller : MonoBehaviour
    {
        [SerializeField] private GameContext _context;

        [Space]
        [SerializeField] private MonoBehaviour[] _listeners;
        
        [Space]
        [SerializeField] private MonoBehaviour[] _services;

        private void Awake()
        {
            foreach (var listener in _listeners)
            {
                _context.AddListener(listener);
            }

            foreach (var service in _services)
            {
                _context.AddService(service);
            }
        }
    }
}
