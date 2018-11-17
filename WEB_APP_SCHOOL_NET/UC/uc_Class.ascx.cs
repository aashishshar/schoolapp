using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class uc_Class : System.Web.UI.UserControl
    {
        CommonBindControl commonBindControl;
        cls_StudentDTO _StudentDTO;
        cls_SectionDTO _sectionDTO;
        public uc_Class()
        {
            _StudentDTO = new cls_StudentDTO();
            commonBindControl = new CommonBindControl();
            _sectionDTO = new cls_SectionDTO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                BindSection();
            }
        }

       
        private void Bind()
        {
           // commonBindControl.BindMasterData(dd, EnumConstants.Masters.AcademicYear);
           commonBindControl.BindMasterData(ddlClassName, EnumConstants.Masters.Class);

        }
        protected void ddlClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSection();
        }

        public int ClassIndex
        {
            get
            {
                return ddlClassName.SelectedIndex;
            }
        }

        public string ClassValue
        {
            get
            {
                return ddlClassName.SelectedValue;
            }
        }


        public void ddlClassName_ColorChange(Color ForeColor, Color BorderColor)
        {
            ddlClassName.ForeColor = ForeColor;
            ddlClassName.BorderColor = BorderColor;
        }

        public void ddlSectionName_ColorChange(Color ForeColor, Color BorderColor)
        {
            ddlSectionName.ForeColor = ForeColor;
            ddlSectionName.BorderColor = BorderColor;
        }
        private void BindSection()
        {
            if (ddlClassName.SelectedIndex > -1)
            {
                ddlSectionName.DataSource = _sectionDTO.GetSection(Convert.ToInt32(ddlClassName.SelectedValue.ToString()));
                ddlSectionName.DataTextField = "SectionName";
                ddlSectionName.DataValueField = "SectionId";
                ddlSectionName.DataBind();
                ddlSectionName.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }
            else
            {
                ddlSectionName.DataSource = null;
                ddlSectionName.DataBind();
                ddlSectionName.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }
        }

        public int SectionValue
        {
            get
            {
                return Convert.ToInt32(ddlSectionName.SelectedValue);
            }
        }

        public int SectionIndex
        {
            get
            {
                return ddlSectionName.SelectedIndex;
            }
        }

        public EventHandler SectionEventHandler;
        protected void ddlSectionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SectionEventHandler(sender, e);
        }
    }
}