using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;

namespace WEB_APP_SCHOOL_NET
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/login.aspx");
            //cls_StudentDTO obj = new cls_StudentDTO();
            //obj.Rpt_StudentDetail();
           // GridView1.DataSource= 
           // GridView1.DataBind();
        }
    }
}