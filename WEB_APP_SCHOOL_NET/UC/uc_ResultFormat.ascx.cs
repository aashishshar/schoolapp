using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.Common;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class ResultFormat : System.Web.UI.UserControl
    {
        CommonBindControl _obj;
        public ResultFormat()
        {
            _obj = new CommonBindControl();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                _obj.BindMasterData(ddlResultFormat, EnumConstants.Masters.ExamResultFormat);
            }

        }

        public string SelectedValue
        {
            get
            {
                return ddlResultFormat.SelectedValue;
            }
        }

        public int SelectedIndex
        {
            get
            {
                return ddlResultFormat.SelectedIndex;
            }
        }
    }
}