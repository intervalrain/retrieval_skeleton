using System;

namespace Retrieval.SDK
{
    public class ServiceProvider<TService> : IServiceProvider where TService : class
    {
        private List<TService> services;
        public ServiceProvider()
        {
            services = new List<TService>();
        }

        public void Add(TService service)
        {
            services.Add(service);
        }

        public object? GetService(Type serviceType)
        {
            List<object> res = new List<object>();
            foreach (var service in services)
            {
                if (service.GetType() == serviceType)
                {
                    res.Add(service);
                }
            }
            return res;
        }

        public object? GetService<TService>()
        {
            return GetService(typeof(TService));
        }
    }
}