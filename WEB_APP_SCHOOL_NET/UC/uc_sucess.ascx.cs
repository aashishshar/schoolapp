using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class uc_sucess : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
         


        public string SuccessMessage
        {
            get;set;
        }
        public string ErrorMessage
        {
            get;
            set;
        }
        public bool Visible
        {
            get
            {
                bool result = false;

                if (ViewState["Visible"] != null)
                {
                    result = (bool)ViewState["Visible"];
                }

                return result;
            }
            set
            {
                ViewState["Visible"] = value;
                MsgSuccess.Visible = value;
            }
        }

        public bool VisibleError
        {
            get
            {
                bool result = false;

                if (ViewState["Visible"] != null)
                {
                    result = (bool)ViewState["Visible"];
                }

                return result;
            }
            set
            {
                ViewState["Visible"] = value;
                MsgError.Visible = value;
            }
        }

    }
}