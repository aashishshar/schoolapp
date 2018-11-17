using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.Common;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class uc_FinYear : System.Web.UI.UserControl
    {
        CommonBindControl commonBindControl;
        public uc_FinYear()
        {
            commonBindControl = new CommonBindControl();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
     
        private void Bind()
        {

            commonBindControl.BindMasterData(ddlFinYear, EnumConstants.Masters.AcademicYear);
            // commonBindControl.BindMasterData(ddlClassName, EnumConstants.Masters.Class);

        }

        public Color ForeColor
        {
            get
            {
                return ddlFinYear.ForeColor;
            }
            set
            {
                ddlFinYear.ForeColor = value;
            }
        }

        public Color BorderColor
        {
            get
            {
                return ddlFinYear.BorderColor;
            }
            set
            {
                ddlFinYear.BorderColor = value;
            }
        }
        public int FinyearValue
        {
            get
            {
                return Convert.ToInt32(ddlFinYear.SelectedValue);
            }
        }
        public int FinyearSelectedIndex
        {
            get
            {
                return ddlFinYear.SelectedIndex;
            }
        }

        public ListItemCollection Items {
            get {
                return ddlFinYear.Items;
            }
        }
    }
}