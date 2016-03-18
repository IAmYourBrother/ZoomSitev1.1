using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IT191P_Project.App_Code;

namespace IT191P_Project.Admin_Site
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            _Branch b = new _Branch(txtLocation.Text, Convert.ToInt32(ddlBranchOwner.SelectedValue));
            SQLManager.SQLAddBranch(b);
            ClearData();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            txtLocation.Text = "";
        }


    }
}