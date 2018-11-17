using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class uc_RouteName : System.Web.UI.UserControl
    {
        cls_Route_Name _item;


        //CommonBindControl commonBindControl;
        public uc_RouteName()
        {
            RefreshClasses();
        }

        private void RefreshClasses()
        {
            _item = new cls_Route_Name();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshItems();
            }
        }

        private void RefreshItems()
        {
            lvItems.DataSource = _item.Get_RouteS();
            lvItems.DataBind();
        }

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                MST_ROUTE_NAME item = new MST_ROUTE_NAME();
                item.RouteName = txtRouteName.Text.Trim();
                item.Org_Id = cls_Common.UserProfile.ORG_ID;

                bool isSave = _item.Save(item);
                if (isSave)
                {
                    ClearItems();
                    ShowMessage("Route Name saved Successfully..", true);
                    RefreshItems();
                }

                else
                {
                    ShowMessage("Some error found..", false);
                }
            }
            catch (Exception ex)
            {

                ShowMessage(ex.Message, false);
            }
        }

        private void ClearItems()
        {
            txtRouteName.Text = string.Empty;
           // txtMoNo.Text = string.Empty;
        }

        private void ShowMessage(string message, bool successMessage)
        {
            // UC.uc_sucess msg = new UC.uc_sucess();
            UC.uc_sucess msg = (UC.uc_sucess)Page.LoadControl("~/uc/uc_sucess.ascx");
            msg.ID = "msg_id_student";
            if (successMessage)
            {
                msg.Visible = true;

                msg.VisibleError = false;
                msg.SuccessMessage = message;
            }
            else
            {
                msg.VisibleError = true;
                msg.Visible = false;
                msg.ErrorMessage = message;
            }
            litMessage.Controls.Add(msg);
        }

        protected void lkbDeleteClass_Click(object sender, EventArgs e)
        {
            LinkButton lkb = (LinkButton)sender;

            if (lkb.CommandName == "Delete")
            {
                string id = lkb.CommandArgument.ToString();
                _item.Delete(Convert.ToInt32(id));
                RefreshItems();
            }
        }
    }
}