using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Factory
{
    public class ServiceFactory
    {
        public static Service Create(String serviceName, int serviiceDuration)
        {
            Service service = new Service();
            service.ServiveName = serviceName;
            service.ServiceDuration = serviiceDuration;

            return service;

        }
    }
}