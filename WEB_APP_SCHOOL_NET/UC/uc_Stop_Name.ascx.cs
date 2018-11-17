using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class uc_Stop_Name : System.Web.UI.UserControl
    {
        cls_Stoppage_Name stoppage_Name;
        cls_Route_Name route_Name;
        public uc_Stop_Name()
        {
            stoppage_Name = new cls_Stoppage_Name();
            route_Name = new cls_Route_Name();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRouteName();
                RefreshDataItems();
            }
        }

        private void BindRouteName()
        {
            ddlRouteName.DataSource = route_Name.Get_RouteS();
            ddlRouteName.DataTextField = "RouteName";
            ddlRouteName.DataValueField = "RouteId";
            ddlRouteName.DataBind();
            ddlRouteName.Items.Insert(0, "[ SELECT ]");
        }

        private void RefreshDataItems()
        {
            lvItems.DataSource = stoppage_Name.Get_Stoppages();
            lvItems.DataBind();
        }

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                MST_STOPNAME sTOPNAME  = new MST_STOPNAME();
                if (ddlRouteName.SelectedIndex > 0)
                {
                    sTOPNAME.RouteId = Convert.ToInt32(ddlRouteName.SelectedValue);
                    sTOPNAME.StopName = txtStopName.Text.Trim();
                    sTOPNAME.PickUpTiming = DateTime.ParseExact(txtPickUpTime.Text.Trim(), "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay; //TimeSpan.Parse();
                    sTOPNAME.DropTiming = DateTime.ParseExact(txtDropTime.Text.Trim(), "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay;// TimeSpan.Parse(txtDropTime.Text.Trim());
                    sTOPNAME.Org_Id = cls_Common.UserProfile.ORG_ID;

                    bool isSave = stoppage_Name.Save(sTOPNAME);
                    if (isSave)
                    {
                        ClearItems();
                        ShowMessage("Stoppage Name saved Successfully..", true);
                        stoppage_Name = new cls_Stoppage_Name();
                        RefreshDataItems();
                    }

                    else
                    {
                        ShowMessage("Some error found..", false);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ClearItems()
        {
            txtStopName.Text = string.Empty;
            //txtMoNo.Text = string.Empty;
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
              
                stoppage_Name.Delete(Convert.ToInt32(id));
                RefreshDataItems();
            }
        }
    }
}