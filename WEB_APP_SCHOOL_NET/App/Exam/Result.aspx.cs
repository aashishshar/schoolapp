using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.App.Report;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.StudentInfoTableAdapters;

namespace WEB_APP_SCHOOL_NET.App.Exam
{
    public partial class Result : System.Web.UI.Page
    {
        cls_StudentDTO _obj;
        public Result()
        {
            _obj = new cls_StudentDTO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            uc_Class.SectionEventHandler += uc_Section_selectedIndexChange;
            
        }

        private void BindStudent()
        {
            lvStudent.DataSource = _obj.GetAllStudent(uc_finyear.FinyearValue, Convert.ToInt32(uc_Class.ClassValue), uc_Class.SectionValue);
            lvStudent.DataBind();
        }
        private void uc_Section_selectedIndexChange(object sender, EventArgs e)
        {
            BindStudent();
        }
        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
           // BindStudent();
            uc_ReportViewer rv = new uc_ReportViewer();
            //GenerateClassExamReportDownloadPDF("1100");
           // ScriptManager.RegisterStartupScript(this, typeof(ImageButton), "scr", "DownloadFile('" + filePath + "');", true);
        }

         protected void lkbDownload_Click(object sender, EventArgs e)
        {
        LinkButton lkb = (LinkButton)sender;
        GenerateClassExamReportDownloadPDF(lkb.CommandArgument,lkb.CommandName);
        //ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(lkbdownload.ClientID);

        }
    
        public void GenerateClassExamReportDownloadPDF(string studentId,string fileName)
        {
            try
            {
                Warning[] warnings;
                string[] streams;
                string MIMETYPE = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;
                ReportViewer rptviewer = new ReportViewer();
                rptviewer.ProcessingMode = ProcessingMode.Local;

                rptviewer.LocalReport.ReportPath = Server.MapPath("~/App/Report/" + uc_ResultFormat.SelectedValue);
                PROC_EXAMREPORTGENERATETableAdapter rpt = new PROC_EXAMREPORTGENERATETableAdapter();

                //PROC_RPT_STUDENTTableAdapter 
                //var Org = orgDTO.GetORGANIZATION(cls_Common.UserProfile.ORG_ID);
                //var OrganisationName_Address = Org.Name +"\n"+ Org.Address;
                // ReportParameter rpm = new ReportParameter("SchoolName_Address",OrganisationName_Address);
                // ReportViewer1.LocalReport.SetParameters(rpm);
                //MST_STUDENT_ATTENDANCETableAdapter rpt = new MST_STUDENT_ATTENDANCETableAdapter();
                //// StudentInfo
                DataTable ds = rpt.GetData(studentId);
                ReportDataSource rds = new ReportDataSource("dsExamResult", ds);
                rptviewer.LocalReport.DataSources.Clear();
                //Add ReportDataSource  
                rptviewer.LocalReport.DataSources.Add(rds);
                byte[] bytes = rptviewer.LocalReport.Render("pdf", null, out MIMETYPE, out encoding, out extension, out streams, out warnings);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = MIMETYPE;
                Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
                Response.BinaryWrite(bytes);
                Response.Flush();
            }
            catch (Exception ex)
            {

            }
        }

        protected void lvStudent_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                LinkButton linkButton = (LinkButton)e.Item.FindControl("lkbDownload");
                var scriptManager = ScriptManager.GetCurrent(this.Page);
                if (scriptManager != null)
                {
                    scriptManager.RegisterPostBackControl(linkButton);
                }
            }
        }

        

       
    }
}