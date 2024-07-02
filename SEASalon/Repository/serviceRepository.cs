using SEASalon.Factory;
using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Repository
{
    public class serviceRepository
    {

        Database1Entities2 db = DatabaseSingleton.getInstance();

        public void CreateService(string name, int duration)
        {
            Service service = ServiceFactory.Create(name, duration);
            db.Services.Add(service);
            db.SaveChanges();
        }

        public void DeleteService(int id)
        {
            var serviceToDelete = db.Services.Find(id);
            if (serviceToDelete != null)
            {
                db.Services.Remove(serviceToDelete);
                db.SaveChanges();
            }
        }

        public List<Service> getAllService()
        {
            return (from x in db.Services select x).ToList();
        }

        public List<Service> getServiceList(List<int> serviceIdList)
        {
            return db.Services.Where(s => serviceIdList.Contains(s.ServiceId)).ToList();

        }
    }
     
}
