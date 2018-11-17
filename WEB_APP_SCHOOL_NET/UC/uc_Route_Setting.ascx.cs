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
    public partial class uc_Route_Setting : System.Web.UI.UserControl
    {
        cls_Vehicle cls_Vehicle;
        cls_Route_Name cls_Route_Name;
        cls_Stoppage_Name cls_Stoppage_Name;
        cls_Driver_DTO cls_Driver ;// _driver_DTO;
        cls_RouteSetting cls_RouteSetting;
        public uc_Route_Setting()
        {
            cls_Vehicle = new cls_Vehicle();
            cls_Route_Name = new cls_Route_Name();
            cls_Stoppage_Name = new cls_Stoppage_Name();
            cls_Driver = new cls_Driver_DTO();
            cls_RouteSetting = new cls_RouteSetting();
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataItems();
            }
        }

        private void GetDataItems()
        {
            ddlVehicleName.DataSource = cls_Vehicle.Get_Vehicles();//.Get_RouteS();
            ddlVehicleName.DataTextField = "RegnNo";
            ddlVehicleName.DataValueField = "VehicleId";
            ddlVehicleName.DataBind();
            ddlVehicleName.Items.Insert(0, "[ SELECT ]");

            ddlDriverName.DataSource = cls_Driver.Get_DRIVERS();
            ddlDriverName.DataTextField = "DriverName";
            ddlDriverName.DataValueField = "DriverId";
            ddlDriverName.DataBind();
            ddlDriverName.Items.Insert(0, "[ SELECT ]");

            ddlRouteName.DataSource = cls_Route_Name.Get_RouteS();
            ddlRouteName.DataTextField = "RouteName";
            ddlRouteName.DataValueField = "RouteId";
            ddlRouteName.DataBind();
            ddlRouteName.Items.Insert(0, "[ SELECT ]");
            BindStoppageName();

            lvItems.DataSource = cls_RouteSetting.Get_RouteSettings();
            lvItems.DataBind();
        }

        private void BindStoppageName()
        {
            ddlStoppageName.Items.Clear();
            if (ddlRouteName.SelectedIndex > 0)
            {
                var routeId = Convert.ToInt32(ddlRouteName.SelectedValue);
                ddlStoppageName.DataSource = cls_Stoppage_Name.Get_Stoppages().FindAll(f => f.RouteId == routeId).ToList();
                ddlStoppageName.DataTextField = "StopName";
                ddlStoppageName.DataValueField = "StopId";
                ddlStoppageName.DataBind();
                ddlStoppageName.Items.Insert(0, "[ SELECT ]");
            }
            else
            {
                ddlStoppageName.DataSource = null;
                
                ddlStoppageName.DataBind();
                ddlStoppageName.Items.Insert(0, "[ SELECT ]");
            }
        }

        protected void ddlRouteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStoppageName();
        }

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                MST_ROUTE route = new MST_ROUTE();

                if (ddlRouteName.SelectedIndex <= 0)
                {
                    ShowMessage("Please route Name.", false);
                    return;
                }
                if (ddlVehicleName.SelectedIndex <= 0)
                {
                    ShowMessage("Please select Vehicle Name.", false);
                    return;
                }
                if (ddlDriverName.SelectedIndex <= 0)
                {
                    ShowMessage("Please select Driver Name.", false);
                    return;
                }
                if (ddlStoppageName.SelectedIndex <= 0)
                {
                    ShowMessage("Please select Stoppage Name.", false);
                    return;
                }

                route.RoutePriceAmt = Convert.ToInt32(txtRoutePrice.Text);
                route.RouteId = Convert.ToInt32(ddlRouteName.SelectedValue);
                route.VehicleId = Convert.ToInt32(ddlVehicleName.SelectedValue);
                route.DriverId = Convert.ToInt32(ddlDriverName.SelectedValue);
                route.StopId = Convert.ToInt32(ddlStoppageName.SelectedValue);
                route.Org_Id = cls_Common.UserProfile.ORG_ID;

                bool isSave = cls_RouteSetting.Save(route);
                if (isSave)
                {
                    ClearItems();
                    ShowMessage("Student Route created Successfully..", true);
                    // stoppage_Name = new cls_Stoppage_Name();
                    GetDataItems();
                }

                else
                {
                    ShowMessage("Some error found..", false);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ClearItems()
        {
            txtRoutePrice.Text = string.Empty;
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

                cls_RouteSetting.Delete(Convert.ToInt32(id));
                GetDataItems();
            }
        }
    }
}