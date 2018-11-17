using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;

namespace WEB_APP_SCHOOL_NET.App.Report
{
    public partial class StudentReport : System.Web.UI.Page
    {
        cls_StudentDTO _StudentDTO;
        cls_FeeDTO _FeeDTO;
        cls_SectionDTO _sectionDTO;
        CommonBindControl commonBindControl;
        cls_ClassDTO _classDTO;
        public StudentReport()
        {
            _StudentDTO = new cls_StudentDTO();
            commonBindControl = new CommonBindControl();
            _sectionDTO = new cls_SectionDTO();
            _FeeDTO = new cls_FeeDTO();
            _classDTO = new cls_ClassDTO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                commonBindControl.BindMasterData(ddlCasteType, EnumConstants.Masters.Cast);
                ddlCasteType.Items.RemoveAt(0);
                ddlCasteType.Items.Insert(0, new ListItem("[ ALL ]", "A"));
                //BindMonth();
                //BindStudent();
            }
            uc_Class.SectionEventHandler += uc_Class_SectionSelectedIndexChanged;
        }

        private void uc_Class_SectionSelectedIndexChanged(object sender, EventArgs e)
        {
        }



        //private void BindCast()
        //{
        //    if (ddlCasteType.SelectedIndex > -1)
        //    {
        //        string castetype = Convert.ToString(ddlCasteType.SelectedValue);

        //        ddlCasteName.DataSource = _StudentDTO.GetCastebycastetype(castetype);
        //        ddlCasteName.DataTextField = "CasteName";
        //        ddlCasteName.DataValueField = "CasteId";
        //        ddlCasteName.DataBind();
        //        ddlCasteName.Items.Insert(0, new ListItem(" [ SELECT ] ", "-1"));
        //    }
        //    else
        //    {
        //        ddlCasteName.DataSource = null;
        //        ddlCasteName.DataBind();
        //        ddlCasteName.Items.Insert(0, new ListItem(" [ SELECT ] ", "-1"));
        //    }
        //}


        protected void lkbGetFeeDetail_Click(object sender, EventArgs e)
        {
            LinkButton lkb = (LinkButton)sender;
            uc_Class.ddlClassName_ColorChange(uc_FinYear.ForeColor,uc_FinYear.BorderColor);
            uc_Class.ddlSectionName_ColorChange(uc_FinYear.ForeColor, uc_FinYear.BorderColor);
            if (uc_Class.ClassIndex == 0 && (lkb.CommandName == "StudentReport" || lkb.CommandName == "GeneralInfo" || lkb.CommandName == "CrossList"))
            {
                uc_Class.ddlClassName_ColorChange(Color.Red, Color.Red);
                return;
            }
            else if (uc_Class.SectionIndex ==0 && (lkb.CommandName == "StudentReport" || lkb.CommandName == "GeneralInfo" || lkb.CommandName == "CrossList"))
            {
                uc_Class.ddlSectionName_ColorChange(Color.Red, Color.Red);
                return;
            }
            if (lkb.CommandName == "StudentReport" || lkb.CommandName == "CrossList" || lkb.CommandName == "GeneralInfo")
            {
                string gender = string.Empty; string casteType = string.Empty;
                if (ddlGender.SelectedValue == "A")
                {
                    gender = null;
                }
                else
                {
                    gender = ddlGender.SelectedValue;
                }
                if (ddlCasteType.SelectedValue == "A")
                {
                    casteType = null;
                }
                else
                {
                    //EnumConstants.Caste caste = (EnumConstants.Caste)Enum.Parse(typeof(EnumConstants.Caste), ddlCasteType.SelectedValue);
                    casteType = ((int)Enum.Parse(typeof(EnumConstants.Caste), ddlCasteType.SelectedValue)).ToString();
                }

                uc_ReportViewer.GenerateStudentReport(uc_FinYear.FinyearValue.ToString(), uc_Class.ClassValue, uc_Class.SectionValue.ToString(), gender, casteType, lkb.CommandName);
            }
            //else if (lkb.CommandName == "HallTicket")
            //{
            //    uc_ReportViewer.GenerateStudentReport(Convert.ToInt32(uc_Class.SectionValue), "HallTicket","");
            //}
            else if (lkb.CommandName == "Attandence")
            {
                uc_ReportViewer.GenerateAttandenceReport(Convert.ToInt32(uc_Class.SectionValue));
            }
            else if (lkb.CommandName == "SummaryReport")
            {
                uc_ReportViewer.GenerateStudentSummaryReport(uc_FinYear.FinyearValue.ToString(), lkb.CommandName);
            }
            else if (lkb.CommandName == "ReferredBy")
            {
                uc_ReportViewer.GenerateStudentReferredBySummaryReport(uc_FinYear.FinyearValue.ToString(), uc_Class.ClassValue, lkb.CommandName);
            }



        }

        protected void lkbGeneralInfo_Click(object sender, EventArgs e)
        {

        }
    }
}