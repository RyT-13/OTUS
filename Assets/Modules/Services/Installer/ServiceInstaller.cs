using UnityEngine;
using UnityEngine.Serialization;

namespace Modules.Services.Installer
{
    public class ServiceInstaller : MonoBehaviour
    {
        [SerializeField]
        private bool installOnAwake;

        [Space]
        [SerializeField]
        private MonoBehaviour[] monoServices;

        [Space]
        [SerializeField]
        [FormerlySerializedAs("serviceLoaders")]
        private ServicePack[] servicePacks;

        private void Awake()
        {
            if (installOnAwake)
            {
                InstallServices();
            }
        }

        public void InstallServices()
        {
            InstallServicesFromBehaviours();
            InstallServicesFromPacks();
        }

        private void InstallServicesFromBehaviours()
        {
            for (int i = 0, count = monoServices.Length; i < count; i++)
            {
                var service = monoServices[i];
                ServiceLocator.AddService(service);
            }
        }

        private void InstallServicesFromPacks()
        {
            for (int i = 0, count = servicePacks.Length; i < count; i++)
            {
                var serviceLoader = servicePacks[i];
                var services = serviceLoader.LoadServices();
                for (int j = 0, length = services.Length; j < length; j++)
                {
                    var service = services[j];
                    ServiceLocator.AddService(service);
                }
            }
        }
    }
}
