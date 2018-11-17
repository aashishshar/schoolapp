using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB_APP_SCHOOL_NET.App
{
    public partial class AdminMaster : MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!Common.cls_Common.IsAuthenticate())
            {
                Response.Redirect("~/Account/Login");
            }
            //if (Context.Session != null)
            //{
            //    if (Session.IsNewSession)
            //    {
            //        HttpCookie newSessionIdCookie = Request.Cookies["ASP.NET_SessionId"];
            //        if (newSessionIdCookie != null)
            //        {
            //            string newSessionIdCookieValue = newSessionIdCookie.Value;
            //            if (newSessionIdCookieValue != string.Empty)
            //            {
            //                // This means Session was timed Out and New Session was started
            //                Response.Redirect("/Account/Login");
            //            }
            //        }
            //    }
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Context.Session != null)
            //{
            //    if (Session.IsNewSession)
            //    {
            //        string cookieHeader = Request.Headers["Cookie"];
            //        if ((null != cookieHeader) && (cookieHeader.IndexOf("ASP.NET_SessionId") >= 0))
            //        {
            //            Response.Redirect("/Account/Login");
            //        }
            //    }
            //}
        }
    }
}