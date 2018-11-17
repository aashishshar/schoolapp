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
    public partial class Driver : System.Web.UI.UserControl
    {
        cls_Driver_DTO _driver_DTO;
       

        //CommonBindControl commonBindControl;
        public Driver()
        {
            RefreshClasses();
        }

        private void RefreshClasses()
        {
            _driver_DTO = new cls_Driver_DTO();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshDrivers();
            }
        }

        private void RefreshDrivers()
        {
            lvItems.DataSource = _driver_DTO.Get_DRIVERS();
            lvItems.DataBind();
        }

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                MST_DRIVER mST_DRIVER = new MST_DRIVER();
                mST_DRIVER.DriverName = txtDriverName.Text.Trim();
                mST_DRIVER.MoNo = txtMoNo.Text.Trim();
                mST_DRIVER.OrgId = cls_Common.UserProfile.ORG_ID;

                bool isSave = _driver_DTO.Save(mST_DRIVER);
                if (isSave)
                {
                    ClearItems();
                    ShowMessage("Driver saved Successfully..", true);
                    RefreshDrivers();
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
            txtDriverName.Text = string.Empty;
            txtMoNo.Text = string.Empty;
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
                _driver_DTO = new cls_Driver_DTO(Convert.ToInt32(id));
                _driver_DTO.Delete(_driver_DTO._getDriver);
                RefreshDrivers();
            }
        }
    }
}