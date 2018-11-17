using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;
using WEB_APP_SCHOOL_NET.StudentInfoTableAdapters;
//using static WEB_APP_SCHOOL_NET.WEB_APP_SCHOOL_NETDataSet;

namespace WEB_APP_SCHOOL_NET.App.Report
{
    public partial class uc_ReportViewer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        cls_OrganizationDTO orgDTO;

        public uc_ReportViewer()
        {
            orgDTO = new cls_OrganizationDTO();
        }

        public int SectionId { get; set; }

        public void GenerateStudentReport(string finYear, string classId, string sectionID, string gender, string casteType,string commandName)
        {

            try
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                cls_StudentDTO obj = new cls_StudentDTO();
                DataTable ds = new DataTable();//     
                if(commandName== "StudentReport")
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/App/Report/StudentList.rdlc");

                if (commandName == "CrossList")
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/App/Report/StudentCrossList.rdlc");

                if (commandName == "GeneralInfo")
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/App/Report/StudentGeneral_Info.rdlc");

                ds = obj.RPT_StudentData(finYear, sectionID, gender, casteType);

                ReportDataSource rds = new ReportDataSource("dsStudentList", ds);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        public void GenerateStudentReferredBySummaryReport(string finYear, string classId, string commandName)
        {
            try
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                cls_StudentDTO obj = new cls_StudentDTO();
                DataTable ds = new DataTable();//     
                if (commandName == "ReferredBy")
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/App/Report/ReferredBy.rdlc");

                ds = obj.RPT_StudentData(finYear, classId);

                ReportDataSource rds = new ReportDataSource("dsStudentList", ds);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        public void GenerateStudentSummaryReport(string finYear, string commandName)
        {
            try
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                cls_StudentDTO obj = new cls_StudentDTO();
                DataTable ds = new DataTable();//     
                if (commandName == "SummaryReport")
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/App/Report/StudentSummary.rdlc");

                ds = obj.RPT_StudentData(finYear);

                ReportDataSource rds = new ReportDataSource("dsStudentList", ds);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        public void GenerateHallTicketReport(int SectionID, string examType)
        {

            try
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/App/Report/HallTicket.rdlc");
                ReportParameter p1 = new ReportParameter("ExamType", examType);
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });

                PROC_RPT_STUDENTTableAdapter rpt = new PROC_RPT_STUDENTTableAdapter();
                DataTable ds = new DataTable();//
                ds = rpt.GetData(SectionID);
                ReportDataSource rds = new ReportDataSource("dsStudentReport", ds);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {

            }
        }

        public void GenerateAttandenceReport(int SectionID)
        {

            try
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/App/Report/Attandence.rdlc");
                               
                MST_STUDENT_ATTENDANCETableAdapter rpt = new MST_STUDENT_ATTENDANCETableAdapter();
                // StudentInfo
                DataTable ds = rpt.GetData(SectionID);
                ReportDataSource rds = new ReportDataSource("attandence", ds);
                ReportViewer1.LocalReport.DataSources.Clear();
                //Add ReportDataSource  
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }
            catch (Exception ex)
            {

            }
        }


        public void GenerateClassExamReport(string studentId,string resultFormatFileName)
        {
            try
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/App/Report/" + resultFormatFileName);
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
                ReportViewer1.LocalReport.DataSources.Clear();
                //Add ReportDataSource  
                ReportViewer1.LocalReport.DataSources.Add(rds);
            }
            catch (Exception ex)
            {

            }
        }
       
    }
}