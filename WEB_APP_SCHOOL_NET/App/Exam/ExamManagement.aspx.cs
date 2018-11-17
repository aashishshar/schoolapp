using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.App.Exam
{
    public partial class ExamManagement : System.Web.UI.Page
    {
        cls_ExamDTO ExamDTO;
        CommonBindControl commonBindControl;
        cls_StudentDTO _StudentDTO;
        public ExamManagement()
        {
            commonBindControl = new CommonBindControl();
            ExamDTO = new cls_ExamDTO();
            _StudentDTO = new cls_StudentDTO();
        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
            uc_Class.SectionEventHandler+= uc_sectionSelectedIndexChange;
        }

        public string EvaluateExamId(object ExamTypeId)
        {
            return ddlExamType.Items.FindByValue(ExamTypeId.ToString()).Text;
        }

        public string EvaluateFinId(object FinId)
        {
            return ExamDTO.GetAcademicYear(Convert.ToInt32(FinId));
        }
        private void uc_sectionSelectedIndexChange(object sender, EventArgs e)
        {
            ddlStudent.DataSource = _StudentDTO.GetAllStudent(uc_finyear1.FinyearValue, Convert.ToInt32(uc_Class.ClassValue), uc_Class.SectionValue);
            ddlStudent.DataTextField = "StudentName";
            ddlStudent.DataValueField = "StudentId";
            ddlStudent.DataBind();
            ddlStudent.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
        }

        private void Bind()
        {
            commonBindControl.BindMasterData(ddlClassName, EnumConstants.Masters.Class);
            var data = Enum.GetNames(typeof(EnumConstants.ExamType)).Select(o => new { Text = o, Value = Convert.ToByte(Enum.Parse(typeof(EnumConstants.ExamType), o)) });
            ddlExamType.DataSource = data;
            ddlExamType.DataTextField = "Text";
            ddlExamType.DataValueField = "Value";
            ddlExamType.DataBind();
            ddlExamType_Report.DataSource = data;
            ddlExamType_Report.DataTextField = "Text";
            ddlExamType_Report.DataValueField = "Value";
            ddlExamType_Report.DataBind();
            ddlStudent.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            BindClassExam();
        }

        public void BindClassExam()
        {
            SqlDataSource3.SelectParameters["ORG_ID"].DefaultValue = cls_Common.UserProfile.ORG_ID.ToString();
            lvClassExam.DataSourceID = "SqlDataSource3";
            lvClassExam.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<MST_EXAM> NEWEXAM = new List<MST_EXAM>();
                List<MST_EXAM> OLDEXAM = new List<MST_EXAM>();
                int? SubjectId, SubSubjectId;
                byte ExamTypeId, Fin_Id;
                foreach (var item in lvExam.Items)
                {
                    SubjectId = lvExam.DataKeys[item.DisplayIndex].Values["SUBJECTID"] as int?;
                    SubSubjectId = lvExam.DataKeys[item.DisplayIndex].Values["SUBSUBJECTID"] as int?;
                    ExamTypeId = Convert.ToByte(ddlExamType.SelectedValue);
                    Fin_Id = Convert.ToByte(uc_finyear.FinyearValue);
                    //if (SubjectId!= null && SubSubjectId!= null)
                    //{
                    //    var data =ExamDTO.GetExamSubSubjectId(Convert.ToInt32(SubjectId), ExamTypeId, Fin_Id);
                    //    if(data!=null)
                    //    {
                    //        ExamDTO.Delete(data);
                    //        continue;
                    //    }
                    //}
                    int ExamId = Convert.ToInt32(lvExam.DataKeys[item.DisplayIndex].Values["EXAMID"].ToString().Trim() != "" ? lvExam.DataKeys[item.DisplayIndex].Values["EXAMID"].ToString() : "0");
                    var ExamData = ExamDTO.GetById(ExamId);
                    if (ExamData != null)
                    {
                        ExamData.MaximumMarks = Convert.ToByte(((TextBox)(item.FindControl("txtMaximumMarks"))).Text);
                        ExamData.PassingMarks = Convert.ToByte(((TextBox)(item.FindControl("txtPassingMarks"))).Text);
                        ExamData.ExamTypeId = ExamTypeId;
                        ExamData.Fin_ID = Fin_Id;
                        OLDEXAM.Add(ExamData);
                    }
                    else
                    {
                        MST_EXAM NewExamData = new MST_EXAM();
                        NewExamData.SubjectId = SubjectId;
                        NewExamData.SubSubjectId = SubSubjectId;
                        NewExamData.MaximumMarks = Convert.ToByte(((TextBox)(item.FindControl("txtMaximumMarks"))).Text);
                        NewExamData.PassingMarks = Convert.ToByte(((TextBox)(item.FindControl("txtPassingMarks"))).Text);
                        NewExamData.ExamTypeId = ExamTypeId;
                        NewExamData.Fin_ID = Fin_Id;
                        NEWEXAM.Add(NewExamData);
                    }
                }
                foreach (var Exam in NEWEXAM)
                {
                    if (!ExamDTO.Create(Exam))
                        throw new Exception();
                }
                foreach (var Exam in OLDEXAM)
                {
                    if (!ExamDTO.Update(Exam))
                        throw new Exception();
                }
                uc_sucess.VisibleError = false;
                BindClassExam();
                uc_sucess.SuccessMessage = "Saved Successfully!";
                uc_sucess.Visible = true;
            }
            catch(Exception ex)
            {
                uc_sucess.ErrorMessage = ex.Message;
                uc_sucess.VisibleError = true;
            }
        }

        protected void btnGetExam_Click(object sender, EventArgs e)
        {
            lvExam.DataBind();
            ddlClassName.ForeColor = ddlExamType.ForeColor;
            ddlClassName.BorderColor = ddlExamType.BorderColor;
            if (ddlClassName.SelectedIndex > 0)
            {
                SqlDataSource1.SelectParameters["CLASSID"].DefaultValue = ddlClassName.SelectedValue;
                SqlDataSource1.SelectParameters["EXAMTYPEID"].DefaultValue = ddlExamType.SelectedValue;
                SqlDataSource1.SelectParameters["FIN_ID"].DefaultValue = uc_finyear.FinyearValue.ToString();
                lvExam.DataSourceID = "SqlDataSource1";
                lvExam.DataBind();
                foreach (var item in lvExamStudent.Items)
                {
                    if (item.DisplayIndex > 0)
                    {
                        if (string.IsNullOrEmpty(lvExamStudent.DataKeys[item.DisplayIndex].Values["EXAMTYPEID"] as string) && string.IsNullOrEmpty(lvExamStudent.DataKeys[item.DisplayIndex].Values["FIN_ID"] as string) && string.IsNullOrEmpty(lvExamStudent.DataKeys[item.DisplayIndex].Values["SUBSUBJECTID"] as string))
                        {
                            lvExam.Items.RemoveAt(item.DisplayIndex - 1);
                            return;
                        }
                        if (lvExamStudent.DataKeys[item.DisplayIndex - 1].Values["EXAMTYPEID"].ToString() != ddlExamType.SelectedValue && lvExamStudent.DataKeys[item.DisplayIndex - 1].Values["FIN_ID"].ToString() != ddlExamType.SelectedValue && string.IsNullOrEmpty(lvExamStudent.DataKeys[item.DisplayIndex].Values["SUBSUBJECTID"] as string))
                            lvExam.Items.RemoveAt(item.DisplayIndex - 1);
                    }
                }
                btnSave.Visible = true;
            }
            if (ddlClassName.SelectedIndex < 1)
            {
                ddlClassName.ForeColor = Color.Red;
                ddlClassName.BorderColor = Color.Red;
            }
        }

        protected void btnGetStudentExams_Click(object sender, EventArgs e)
        {
            lkbSaveExamReport.Visible = true;
            uc_Class.ddlClassName_ColorChange(uc_finyear1.ForeColor, uc_finyear1.BorderColor);
            uc_Class.ddlSectionName_ColorChange(uc_finyear1.ForeColor, uc_finyear1.BorderColor);
            if (uc_Class.ClassIndex> 0 && uc_Class.SectionIndex > 0 && ddlStudent.SelectedIndex>0)
            {
                SqlDataSource2.SelectParameters["CLASSID"].DefaultValue = uc_Class.ClassValue;
                SqlDataSource2.SelectParameters["STUDENTID"].DefaultValue = ddlStudent.SelectedValue;
                SqlDataSource2.SelectParameters["FIN_ID"].DefaultValue = uc_finyear1.FinyearValue.ToString();
                SqlDataSource2.SelectParameters["EXAMTYPEID"].DefaultValue = ddlExamType_Report.SelectedValue;
                lvExamStudent.DataSourceID = "SqlDataSource2";
                lvExamStudent.DataBind();
            }
            if (uc_Class.ClassIndex < 1)
                uc_Class.ddlClassName_ColorChange(Color.Red,Color.Red);
            if(uc_Class.SectionIndex<1)
                uc_Class.ddlSectionName_ColorChange(Color.Red, Color.Red);

        }

        protected void lkbSaveExamReport_Click(object sender, EventArgs e)
        {
            try
            {
                List<MST_EXAM_REPORT> NEWEXAM_REPORT = new List<MST_EXAM_REPORT>();
                List<MST_EXAM_REPORT> OLDEXAM_REPORT = new List<MST_EXAM_REPORT>();
                if (ddlStudent.SelectedIndex < 1 )
                {
                    uc_sucess1.ErrorMessage = "Student Year must be selected before Save";
                    uc_sucess1.VisibleError = true;
                    return;
                }
                foreach (var item in lvExamStudent.Items)
                {
                    int ExamId = Convert.ToInt32(lvExamStudent.DataKeys[item.DisplayIndex].Values["EXAMID"].ToString().Trim() != "" ? lvExamStudent.DataKeys[item.DisplayIndex].Values["EXAMID"].ToString() : "0");
                    int Id = Convert.ToInt32(lvExamStudent.DataKeys[item.DisplayIndex].Values["ID"].ToString().Trim() != "" ? lvExamStudent.DataKeys[item.DisplayIndex].Values["ID"].ToString() : "0");
                    var ExamReport = ExamDTO.GetExamReportById(Id);
                    if (ExamReport != null)
                    {
                        ExamReport.ObtainedMarks = Convert.ToByte(((TextBox)(item.FindControl("txtObtainedMarks"))).Text);
                        OLDEXAM_REPORT.Add(ExamReport);
                    }
                    else
                    {
                        MST_EXAM_REPORT NewExamReport = new MST_EXAM_REPORT();
                        NewExamReport.StudentId = Int32.Parse(ddlStudent.SelectedValue);
                        NewExamReport.ObtainedMarks = Convert.ToByte(((TextBox)(item.FindControl("txtObtainedMarks"))).Text);
                        NewExamReport.ExamId = ExamId;
                        NEWEXAM_REPORT.Add(NewExamReport);
                    }
                }
                foreach (var Exam in NEWEXAM_REPORT)
                {
                    if (!ExamDTO.Create(Exam))
                        throw new Exception();
                }
                foreach (var Exam in OLDEXAM_REPORT)
                {

                    if (!ExamDTO.Update(Exam))
                        throw new Exception();
                }
                //lvExamStudent.Items.Clear();
                uc_sucess1.SuccessMessage = "Saved Successfully!";
                uc_sucess1.Visible = true;
                lvExamStudent.DataSource = null;
                lvExamStudent.DataBind();
                lvExamStudent.DataSourceID = "SqlDataSource2";
                lvExamStudent.DataBind();
            }
            catch(Exception ex)
            {
                uc_sucess1.ErrorMessage = ex.Message;
                uc_sucess1.VisibleError = true;
            }
            }

        protected void lkbDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbDelete = (LinkButton)sender;
            string AllId = lkbDelete.CommandArgument;
            string[] AllIdSeperate = AllId.Split(',');
            int FinId = Convert.ToInt32(AllIdSeperate[0]);
            int ClassId = Convert.ToInt32(AllIdSeperate[1]);
            int ExamTypeId = Convert.ToInt32(AllIdSeperate[2]);
            if(!ExamDTO.Delete(FinId, ExamTypeId,ClassId))
            {
                uc_sucess2.ErrorMessage = "Cannot Delete Something went Wrong!";
                uc_sucess2.VisibleError = true;
            }
            else
            {
                uc_sucess2.SuccessMessage= "Successfully Deleted Record!";
                uc_sucess2.Visible = true;
                BindClassExam();
            }
            lvExam.DataBind();
        }
    }
}