using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;

namespace WEB_APP_SCHOOL_NET.App.Exam
{
    public partial class ClassExamReport : System.Web.UI.Page
    {
        cls_ExamDTO ExamDTO;
        CommonBindControl commonBindControl;
        cls_StudentDTO _StudentDTO;
         public ClassExamReport()
        {
            commonBindControl = new CommonBindControl();
            ExamDTO = new cls_ExamDTO();
            _StudentDTO = new cls_StudentDTO();
        }
         protected void Page_Load(object sender, EventArgs e)
         {
             uc_Class.SectionEventHandler += uc_Section_selectedIndexChange;
             if (!IsPostBack)
             {
                 ddlStudent.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
             }
         }

        private void uc_Section_selectedIndexChange(object sender, EventArgs e)
        {
           // uc_ReportViewer.GenerateClassExamReport(uc_Class.SectionValue);
            ddlStudent.DataSource = _StudentDTO.GetAllStudent(uc_finyear1.FinyearValue,Convert.ToInt32(uc_Class.ClassValue), uc_Class.SectionValue);
            ddlStudent.DataTextField = "StudentName";
            ddlStudent.DataValueField = "StudentId";
            ddlStudent.DataBind();
            ddlStudent.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
        }

        protected void btnGenerateResult_Click(object sender, EventArgs e)
        {
            uc_ReportViewer.GenerateClassExamReport(ddlStudent.SelectedValue.ToString(), uc_ResultFormat.SelectedValue);
        }
    }
}