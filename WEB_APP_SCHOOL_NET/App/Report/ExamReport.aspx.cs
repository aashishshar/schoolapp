using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.App.Report
{
    public partial class ExamReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uc_Class.SectionEventHandler += uc_class_Section_IndexChanged;
        }

        private void uc_class_Section_IndexChanged(object sender, EventArgs e)
        {
        }

        UnitOfWork unitOfWork = new UnitOfWork();
        protected void lkbGetFeeDetail_Click(object sender, EventArgs e)
        {
            LinkButton lkb = (LinkButton)sender;

            uc_Class.ddlClassName_ColorChange(ddlExamType.ForeColor,ddlExamType.BorderColor);
            uc_Class.ddlSectionName_ColorChange(ddlExamType.ForeColor, ddlExamType.BorderColor);

            if (uc_Class.ClassIndex == 0)
            {
                uc_Class.ddlClassName_ColorChange(Color.Red, Color.Red);
                return;
            }
            else if(uc_Class.SectionIndex ==0)
            {
                uc_Class.ddlSectionName_ColorChange(Color.Red, Color.Red);
                return;
            }
            if (lkb.CommandName == "HallTicket")
            {
                uc_ReportViewer.GenerateHallTicketReport(Convert.ToInt32(uc_Class.SectionValue.ToString()),ddlExamType.SelectedItem.Text);
            }
            
        }

        //private void Bind()
        //{
        //    ddlExamType.DataValueField = "ExamCode";
        //    ddlExamType.DataTextField = "ExamType";
        //    ddlExamType.DataSource = unitOfWork.
        //    ddlExamType.DataBind();
        //    ddlExamType.Items.Insert(0, new ListItem(" [ Select ] ", "-1"));
        //}
    }
}