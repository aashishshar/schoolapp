using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET;
using WEB_APP_SCHOOL_NET.DAL;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;

namespace WEB_APP_SCHOOL_NET.App.Admin
{

    public partial class Masters : System.Web.UI.Page
    {

        CommonBindControl commonBindControl= new CommonBindControl();
        cls_State stateModel = new cls_State();
        cls_City cityModel = new cls_City();
        cls_Caste casteModel = new cls_Caste();
        cls_Religion religionModel = new cls_Religion();
        cls_Occupation occupationModel = new cls_Occupation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllState();
                GetAllCity();
                GetAllReligion();
                GetAllCaste();
                GetAllOccupation();
                ddlBindState();
                ddlBindCasteType();
                ddlBindReligion();
            }
        }
        #region State
        /// <summary>
        /// Save, update and populate list for State Master
        /// </summary>
        private void GetAllState()
        {

            lvstate.DataSource = stateModel.GetStateMaster();
            lvstate.DataBind();

        }
        protected void lkbDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;

            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int stateID = Convert.ToInt32(lkbItem.CommandArgument);
                stateModel.DeleteState(stateID);
                uc_sucess.SuccessMessage = "State deleted.";
                GetAllState();
                uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            MST_STATE state = new MST_STATE();
            try
            {
                state.StateName = txtStateName.Text.Trim();
                //state.CreatedBy = ;
                state.CreatedDate = DateTime.Now;
                state.CountryId = 1;
                stateModel.SaveState(state);
                txtStateName.Text = "";
                GetAllState();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region City
        private void ddlBindState()
        {
            ddlState.DataSource = stateModel.GetStateMaster();
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem(" [ Select ] ", "0"));
        }
        private void GetAllCity()
        {
            lvCity.DataSource = cityModel.GetCityMaster();
            lvCity.DataBind();
        }
        public string CityId
        {
            get
            {
                return ViewState["CityId"].ToString();
            }
            set
            {
                ViewState["CityId"] = value;
            }
        }
        protected void btnSaveCity_Click(object sender, EventArgs e)
        {
            MST_CITY city = new MST_CITY();
            try
            {
                city.StateId = ddlState.SelectedIndex;
                city.CreatedDate = DateTime.Now;
                city.CityName = txtCityName.Text.Trim();
                cityModel.SaveCity(city);
                txtCityName.Text = "";
                ddlState.SelectedValue = "0";
                GetAllCity();
            }
            catch (Exception ex)
            {

            }
        }

        protected void lkbCityDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;

            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int cityID = Convert.ToInt32(lkbItem.CommandArgument);
                cityModel.DeleteCity(cityID);
                uc_sucess.SuccessMessage = "City deleted.";
                GetAllCity();
                uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
            }
        }
        #endregion
        #region Religion
        /// <summary>
        /// Save, update and Bind data for Religion
        /// </summary>
        protected void btnReligion_Click(object sender, EventArgs e)
        {
            MST_RELIGION religion = new MST_RELIGION();
            try
            {
                religion.CreatedDate = DateTime.Now;
                religion.ReligionName = txtReligion.Text.Trim();
                religionModel.SaveReligion(religion);
                txtReligion.Text = "";
                GetAllReligion();
            }
            catch (Exception ex)
            {

            }
        }
        private void GetAllReligion()
        {
            lvReligion.DataSource = religionModel.GetReligionMaster();
            lvReligion.DataBind();
        }
        protected void lkbReligionDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;

            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int religionID = Convert.ToInt32(lkbItem.CommandArgument);
                religionModel.DeleteReligion(religionID);
                uc_sucess.SuccessMessage = "Religion deleted.";
                GetAllReligion();
                uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
            }
        }

        #endregion
        #region Caste
        /// <summary>
        /// Save, update and Bind Data For Caste Master
        /// </summary>
        private void ddlBindCasteType()
        {
            commonBindControl.BindMasterData(ddlCasteType, EnumConstants.Masters.Cast);
            //ddlCasteType.DataSource = typeof(Common.EnumConstants.Caste).ToList();
            //ddlCasteType.DataTextField = "Value";
            //ddlCasteType.DataValueField = "Key";
            //ddlCasteType.DataBind();
        }
        private void ddlBindReligion()
        {
            ddlReligion.DataSource = casteModel.GetReligionMaster();
            ddlReligion.DataTextField = "ReligionName";
            ddlReligion.DataValueField = "ReligionId";
            ddlReligion.DataBind();
            ddlReligion.Items.Insert(0, new ListItem(" [ Select ] ", "0"));
        }
        protected void btnSaveCaste_Click(object sender, EventArgs e)
        {
            MST_CASTE caste = new MST_CASTE();
            try
            {
                caste.CasteName = txtCasteName.Text.Trim();
                caste.CasteType = Convert.ToSByte(ddlCasteType.SelectedValue);
                caste.ReligionId =Convert.ToInt32(ddlReligion.SelectedValue);
                caste.CreatedDate = DateTime.Now;
                casteModel.SaveCaste(caste);
                txtCasteName.Text = "";
                ddlReligion.SelectedValue = "0";
                GetAllCaste();
            }
            catch (Exception ex)
            {

            }
        }
        private void GetAllCaste()
        {
            lvCaste.DataSource = casteModel.GetCasteMaster();
            lvCaste.DataBind();
        }

        protected void lkbCasteDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;

            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int casteID = Convert.ToInt32(lkbItem.CommandArgument);
                casteModel.DeleteCaste(casteID);
                uc_sucess.SuccessMessage = "Caste deleted.";
                GetAllCaste();
                uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
            }
        }

        #endregion
        #region Occupation
        /// <summary>
        /// Save and populate data for Occupation
        /// </summary>
        protected void btnSaveOcc_Click(object sender, EventArgs e)
        {
            MST_OCCUPATION occu = new MST_OCCUPATION();
            try
            {
                occu.OccupationName = txtOccupation.Text.Trim();
                occu.Status = 1;
                occupationModel.SaveOccupation(occu);
                uc_sucess.SuccessMessage = "Occupation saved successfully.";
                txtOccupation.Text = "";
                GetAllOccupation();
            }
            catch (Exception ex)
            {

            }
        }
        private void GetAllOccupation()
        {
            lvOccupation.DataSource = occupationModel.GetOccupationMaster();
            lvOccupation.DataBind();
        }
        protected void lkbOccupationDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;

            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int occupID = Convert.ToInt32(lkbItem.CommandArgument);
                occupationModel.DeleteOccupation(occupID);
                uc_sucess.SuccessMessage = "Occupation deleted.";
                GetAllOccupation();
                uc_sucess.Visible = !String.IsNullOrEmpty(uc_sucess.SuccessMessage);
            }
        }
        #endregion
    }
}