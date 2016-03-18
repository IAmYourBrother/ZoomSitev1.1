using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT191P_Project.App_Code
{
    public class _Branch
    {
        int branchownerid, branchmanagerid;
        string location;

        public _Branch(string l, int boi)
        {
            location = l;
            branchownerid = boi;
        }

        public _Branch(int bmi)
        {
            branchmanagerid = bmi;
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public int BranchOwnerID
        {
            get { return branchownerid; }
            set { branchownerid = value; }
        }

        public int BranchManagerID
        {
            get { return branchmanagerid; }
            set { branchmanagerid = value; }
        }
    }
}