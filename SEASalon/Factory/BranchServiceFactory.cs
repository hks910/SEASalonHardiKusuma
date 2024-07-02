using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Factory
{
    public class BranchServiceFactory
    {
        public static BranchService Create(int branchId, int serviceId)
        {
         BranchService branchService = new BranchService();
            branchService.BranchId = branchId;
            branchService.ServiceId = serviceId;
            return branchService;

        }
    }
}