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
    public partial class uc_Vehicle : System.Web.UI.UserControl
    {
        cls_Vehicle _item;
        CommonBindControl commonBindControl;
        public uc_Vehicle()
        {
            RefreshClasses();
            
        }
        private void RefreshClasses()
        {
            _item = new cls_Vehicle();
            commonBindControl = new CommonBindControl();
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
            commonBindControl.BindMasterData(ddlFuelUsed, EnumConstants.Masters.FuelUsed);
            commonBindControl.BindMasterData(ddlVehicleType, EnumConstants.Masters.VehicleType);
            lvItems.DataSource = _item.Get_Vehicles();
            lvItems.DataBind();
        }

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                MST_VEHICLE item = new MST_VEHICLE();
                item.RegnNo = txtRegistrationNo.Text.Trim();
                item.RegnOwnerName = txtRegnOwnerName.Text.Trim();
                item.MFGDate =Convert.ToDateTime(txtMFGDate.Text.Trim());
                item.ChassisNo = txtChassisNo.Text.Trim();
                item.RegnAuthority = txtRegnAuthority.Text.Trim();
                item.RegnDate = Convert.ToDateTime(txtRegnDate.Text.Trim());
                item.RegnValidUpTo =Convert.ToDateTime(txtRegnValidUpTo.Text.Trim());
                if (ddlFuelUsed.SelectedIndex > 0)
                    item.FuelUsed = Convert.ToByte(ddlFuelUsed.Text.Trim());
                item.EngineNo = txtEngineNo.Text.Trim();
                item.Color = txtColor.Text.Trim();
                item.MakersClass = txtMakersClass.Text.Trim();
                item.CompanyName = txtCompanyName.Text.Trim();
                item.FitnessValidity =Convert.ToDateTime(txtFitnessValidity.Text);
                if (ddlVehicleType.SelectedIndex > 0)
                    item.VehicleType = Convert.ToByte(ddlVehicleType.SelectedValue);
                item.InsuranceNo = txtInsuranceNo.Text.Trim();
                item.InsuranceBy = txtInsuranceBy.Text.Trim();
                item.InsuranceStartDate = Convert.ToDateTime(txtInsuranceStartDate.Text.Trim());
                item.InsuranceValidUpToDate = Convert.ToDateTime(txtInsuranceValidUpToDate.Text.Trim());
                item.PolutionNo = txtPolutionNo.Text.Trim();
                item.PollutionBy = txtPollutionBy.Text.Trim();
                item.PollutionStartDate =Convert.ToDateTime(txtPollutionStartDate.Text.Trim());
                item.PollutionEndDate =Convert.ToDateTime(txtPollutionEndDate.Text.Trim());
                item.SeatingCapacity =Convert.ToInt16( txtSeatingCapacity.Text);
               // item.CompanyName = txtCompanyName.Text.Trim();







                item.Org_Id = cls_Common.UserProfile.ORG_ID;

                bool isSave = _item.Save(item);
                if (isSave)
                {
                    ClearItems();
                    ShowMessage("Vehicle saved Successfully..", true);
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
           // txtRouteName.Text = string.Empty;
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

        protected void lkbDelete_Click(object sender, EventArgs e)
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