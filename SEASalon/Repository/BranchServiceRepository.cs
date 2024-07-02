using SEASalon.Factory;
using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SEASalon.Repository
{
    public class BranchServiceRepository
    {
        Database1Entities2 db = DatabaseSingleton.getInstance();

        public void CreateService(int branchId, int serviceId)
        {
            BranchService branchService = BranchServiceFactory.Create(branchId, serviceId);
            db.BranchServices.Add(branchService);
            db.SaveChanges();
        }

        public List<int> GetServiceList(int BranchId) { 
        return(from x in db.BranchServices where x.BranchId.Equals(BranchId) select x.ServiceId).ToList();
        }


    }
}