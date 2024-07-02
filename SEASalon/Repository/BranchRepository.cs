using SEASalon.Factory;
using SEASalon.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEASalon.Repository
{
    public class BranchRepository
    {
        Database1Entities2 db = DatabaseSingleton.getInstance();

        public List<Branch> GetBranches()
        {
            return(from x in db.Branches select x).ToList();
        }

        public void addBranch(String BranchName, String BranchLocation, TimeSpan OpeningTime, TimeSpan ClosingTime)
        {
            Branch branch = BranchFactory.Create(BranchName, BranchLocation, OpeningTime, ClosingTime);
            db.Branches.Add(branch);
            db.SaveChanges();
        }

        public void deleteBranch(int BranchId)
        {
            var branchToDelete = db.Branches.Find(BranchId);
            if (branchToDelete != null)
            {
                db.Branches.Remove(branchToDelete);
                db.SaveChanges();
            }
        }

    }
}