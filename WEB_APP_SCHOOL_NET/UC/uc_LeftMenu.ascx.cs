using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class uc_LeftMenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowMenuItems();
            }
        }

        private void ShowMenuItems()
        {
            if (Common.cls_Common.IsSuperAdmin())
            {
                liMaster.Visible = true;
            }
            else
            {
                liMaster.Visible = false;
            }
        }
    }
}