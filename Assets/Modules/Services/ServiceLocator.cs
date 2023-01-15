using System;
using System.Collections.Generic;
using Modules.Services.Context;

namespace Modules.Services
{
    public static class ServiceLocator
    {
        private static IServiceContext _instance;

        static ServiceLocator()
        {
            _instance = new ServiceContext();
        }

        public static void SetContext(IServiceContext context)
        {
            _instance = context;
        }

        public static T GetService<T>()
        {
            return _instance.GetService<T>();
        }

        public static object GetService(Type serviceType)
        {
            return _instance.GetService(serviceType);
        }

        public static IEnumerable<object> GetAllServices()
        {
            return _instance.GetAllServices();
        }
        
        public static IEnumerable<T> GetServices<T>()
        {
            return _instance.GetServices<T>();
        }

        public static IEnumerable<object> GetServices(Type serviceType)
        {
            return _instance.GetServices(serviceType);
        }

        public static bool TryGetService(Type serviceType, out object service)
        {
            return _instance.TryGetService(serviceType, out service);
        }
        
        public static bool TryGetService<T>(out T service)
        {
            return _instance.TryGetService(out service);
        }

        public static void AddService(object service)
        {
            _instance.AddService(service);
        }

        public static void RemoveService(object service)
        {
            _instance.RemoveService(service);
        }
    }
}
