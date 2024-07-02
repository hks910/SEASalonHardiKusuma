using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Factory
{
    public class BranchFactory
    {
        public static Branch Create(string branchName, string branchLocation, TimeSpan openingTime, TimeSpan closingTime)
        {
            Branch branch = new Branch();

            branch.BranchName = branchName;
            branch.BranchLocation = branchLocation;
            branch.OpeningTime = openingTime;
            branch.ClosingTime = closingTime;

            return branch;
        }
    }
}