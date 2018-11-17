using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.App.Student
{
    public partial class StudentAttendance : System.Web.UI.Page
    {
        cls_StudentDTO _StudentDTO;
        cls_StudentAttendanceDTO _StudentAttendanceDTO;
        CommonBindControl commonBindControl;
        cls_SectionDTO _sectionDTO;
        public StudentAttendance()
        {
            _StudentDTO = new cls_StudentDTO();
            _StudentAttendanceDTO = new cls_StudentAttendanceDTO();
            commonBindControl = new CommonBindControl();
            _sectionDTO = new cls_SectionDTO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind(); 
                BindSection();
              //  BindStudentAttendance();
            }
        }
        private void Bind()
        {
            commonBindControl.BindMasterData(ddlClassName, EnumConstants.Masters.Class);
        }
        protected void ddlClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindSection();
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
        private void BindStudentAttendance()
        {
            var date = DateTime.ParseExact(txtAttandenceDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);// Convert.ToDateTime(txtAttandenceDate.Text);
            lvStudentAttendance.DataSource = _StudentAttendanceDTO.GetStudentAtt(Convert.ToInt32(ddlSectionName.SelectedValue), date);
            lvStudentAttendance.DataBind();
        }

        protected void ddlSectionName_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            var date = DateTime.ParseExact(txtAttandenceDate.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            foreach (ListViewDataItem item in lvStudentAttendance.Items)
            {
                CheckBox chkselect = (CheckBox)item.FindControl("selectone");
                //if (chkselect.Checked)
                // {
                MST_STUDENT_ATTENDANCE StudentAttend = new MST_STUDENT_ATTENDANCE();
                string studentdtlid = (lvStudentAttendance.DataKeys[item.DisplayIndex].Values["StudentAttendId"].ToString());
                int studentid = Convert.ToInt32(lvStudentAttendance.DataKeys[item.DisplayIndex].Values["StudentId"].ToString());
                StudentAttend.SectionId = Convert.ToInt32(ddlSectionName.SelectedValue);
                StudentAttend.StudentId = studentid;

                StudentAttend.IsPresent = chkselect.Checked;
                StudentAttend.PresentDate = date;
                StudentAttend.Attand_Status = chkselect.Checked ? "P" : "AB";
                StudentAttend.PresentDay = date.Day.ToString();

                StudentAttend.CreatedBy = cls_Common.UserProfile.Id;
                StudentAttend.CreatedDate = DateTime.Now;
                int exitstudentdtlid = Convert.ToInt32(studentdtlid);
                var existFeeDtl = _StudentAttendanceDTO.GetDataForEdit(exitstudentdtlid, date);

                if (existFeeDtl == null)
                {
                    var result = _StudentAttendanceDTO.Save(StudentAttend);
                    uc_sucess.SuccessMessage = "Attendance Save Successfully";
                }
                else
                {

                    //   existFeeDtl.StudentAttendId = exitstudentdtlid;
                    existFeeDtl.StudentId = studentid;
                    existFeeDtl.SectionId = Convert.ToInt32(ddlSectionName.SelectedValue);
                    existFeeDtl.IsPresent = chkselect.Checked;
                    existFeeDtl.PresentDate = date;
                    existFeeDtl.Attand_Status = chkselect.Checked ? "P" : "AB";
                    existFeeDtl.PresentDay = date.Day.ToString();

                    StudentAttend.UpdatedBy = cls_Common.UserProfile.Id;
                    StudentAttend.UpdatedDate = DateTime.Now;
                    var result = _StudentAttendanceDTO.Update(existFeeDtl);
                    uc_sucess.SuccessMessage = "Attendance Update Successfully";
                }

                //   }
            }
            BindStudentAttendance();
        }

        protected void lkbGetAttendance_Click(object sender, EventArgs e)
        {
            BindStudentAttendance();
        }
    }
}