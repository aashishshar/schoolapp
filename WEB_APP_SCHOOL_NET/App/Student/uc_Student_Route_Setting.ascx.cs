using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_APP_SCHOOL_NET.App.Student
{
    public partial class uc_Student_Route_Setting : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uc_Class.SectionEventHandler += UC_CLASSSECTIONHANDLER;
        }

        private void UC_CLASSSECTIONHANDLER(object sender, EventArgs e)
        {
            if (uc_Class.SectionIndex > 0)
            {

            }
        }
        //private void BindStudent
    }
}