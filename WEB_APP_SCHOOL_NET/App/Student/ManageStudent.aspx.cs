using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.App.Student
{
    public partial class ManageStudent : System.Web.UI.Page
    {
        cls_StudentDTO _obj = new cls_StudentDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            uc_ClassFrom.SectionEventHandler += uc_SectionFrom_selectedIndexChange;
            uc_ClassTo.SectionEventHandler += uc_SectionTo_selectedIndexChange;
            if (!IsPostBack)
            {

            }
        }

        private void uc_SectionFrom_selectedIndexChange(object sender, EventArgs e)
        {
            BindFromStudent();
        }

        private void uc_SectionTo_selectedIndexChange(object sender, EventArgs e)
        {
            BindToStudent();
        }

        private void BindFromStudent()
        {
            _obj = new cls_StudentDTO();
            var data = _obj.GetAllStudent(uc_finyearFrom.FinyearValue, uc_ClassFrom.SectionValue);
            lbFromStudent.DataSource = data.Select(s => new { s.StudentId, StudentName = string.Format("{0} - {1}", s.FormNumber, s.StudentName) });
            lbFromStudent.DataBind();
            lbFromStudent.DataTextField = "StudentName";
            lbFromStudent.DataValueField = "StudentId";
        }
        private void BindToStudent()
        {
            _obj = new cls_StudentDTO();
            var data = _obj.GetAllStudent(uc_finyearTo.FinyearValue,uc_ClassTo.SectionValue);
            lbToStudent.DataSource = data.Select(s => new { s.StudentId, StudentName = string.Format("{0} - {1}", s.FormNumber, s.StudentName) });
            lbToStudent.DataBind();
            lbToStudent.DataTextField = "StudentName";
            lbToStudent.DataValueField = "StudentId";
        }

        protected void btnMoveStudent_Click(object sender, EventArgs e)
        {

            var isSave = _obj.MoveStudentFromOneClassToAnother(GetStudentIds(), Convert.ToInt32(uc_ClassTo.ClassValue), uc_ClassTo.SectionValue);
            if (isSave)
            { BindFromStudent(); BindToStudent(); }
        }

        private List<long> GetStudentIds()
        {
            List<long> students = new List<long>();
            foreach (ListItem li in lbFromStudent.Items)
            {
                if (li.Selected)
                {
                    var sId = Convert.ToInt64(li.Value);
                    students.Add(sId);
                }
            }
            return students;
        }

        protected void btnStudentStatus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
           
            var selectedStudents=GetStudentIds();
            if (btn.CommandName == EnumConstants.StudentPromotedStatus.Passed.ToString())
            {
                var isSave = _obj.PromotedAuditTrailStudentsDetail(selectedStudents, uc_finyearFrom.FinyearValue, Convert.ToInt32(uc_ClassFrom.ClassValue), uc_ClassFrom.SectionValue, (byte)EnumConstants.StudentPromotedStatus.Passed);                  
                if (isSave)
                {
                    _obj.PromotedFromOneClassToAnother(selectedStudents, uc_finyearTo.FinyearValue, Convert.ToInt32(uc_ClassTo.ClassValue), uc_ClassTo.SectionValue);
                    _obj.PromotedStudentsDetail(selectedStudents, uc_finyearTo.FinyearValue, Convert.ToInt32(uc_ClassTo.ClassValue), uc_ClassTo.SectionValue, (byte)EnumConstants.StudentPromotedStatus.Passed);
                }
            }
            else if (btn.CommandName == EnumConstants.StudentPromotedStatus.Promoted.ToString())
            {
                var isSave = _obj.PromotedAuditTrailStudentsDetail(selectedStudents, uc_finyearFrom.FinyearValue, Convert.ToInt32(uc_ClassFrom.ClassValue), uc_ClassFrom.SectionValue, (byte)EnumConstants.StudentPromotedStatus.Promoted);
                if (isSave)
                {
                    _obj.PromotedFromOneClassToAnother(selectedStudents, uc_finyearTo.FinyearValue, Convert.ToInt32(uc_ClassTo.ClassValue), uc_ClassTo.SectionValue);
                    _obj.PromotedStudentsDetail(selectedStudents, uc_finyearTo.FinyearValue, Convert.ToInt32(uc_ClassTo.ClassValue), uc_ClassTo.SectionValue, (byte)EnumConstants.StudentPromotedStatus.Promoted);
                }
            }
            else if (btn.CommandName == EnumConstants.StudentPromotedStatus.DropOut.ToString())
            {
                var isSave = _obj.PromotedAuditTrailStudentsDetail(selectedStudents, uc_finyearFrom.FinyearValue, Convert.ToInt32(uc_ClassFrom.ClassValue), uc_ClassFrom.SectionValue, (byte)EnumConstants.StudentPromotedStatus.DropOut);
              
            }
            else if (btn.CommandName == EnumConstants.StudentPromotedStatus.Failed.ToDescription())
            {
                var isSave = _obj.PromotedAuditTrailStudentsDetail(selectedStudents, uc_finyearFrom.FinyearValue, Convert.ToInt32(uc_ClassFrom.ClassValue), uc_ClassFrom.SectionValue, (byte)EnumConstants.StudentPromotedStatus.Failed);
              
            }
            else
            { }
            BindFromStudent(); BindToStudent();
        }

        
    }
}