using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEB_APP_SCHOOL_NET.BAL;
using WEB_APP_SCHOOL_NET.Common;
using WEB_APP_SCHOOL_NET.DAL;

namespace WEB_APP_SCHOOL_NET.App.Student
{
    public partial class StudentManagement : System.Web.UI.Page
    {
        cls_StudentDTO _StudentDTO;
        CommonBindControl commonBindControl;
        cls_SectionDTO _sectionDTO;
        cls_City _cls_City;
        cls_ClassDTO _classDTO;
        cls_StudentSubjectDTO _StudentSubjectDTO;
        cls_SubjectDTO _SubjectDTO;

        public StudentManagement()
        {
            _StudentDTO = new cls_StudentDTO();
            commonBindControl = new CommonBindControl();
            _sectionDTO = new cls_SectionDTO();
            _cls_City = new cls_City();
            _classDTO = new cls_ClassDTO();
            _StudentSubjectDTO = new cls_StudentSubjectDTO();
            _SubjectDTO = new cls_SubjectDTO();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            uc_Student.BackButtonClicked += new EventHandler(BackButtonClicked);// EventHandler(uc_Student.BackButtonClicked);
                    //EventHandler(MyUserControl_UserControlButtonClicked);
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
                BindStudent();
               
               // txtDob.Attributes.Add("readonly", "readonly");
            }//ScriptManager.GetCurrent(this).RegisterPostBackControl(this.lkbSave);
        }

        private void BackButtonClicked(object sender, EventArgs e)
        {
            divSecondary.Visible = false;
            divMain.Visible = true; ;
          //  BindStudent();
        }

        public void ShowFormNo()
        {
            var tempdata = _StudentDTO.GetformData();
           // lblform.Text = tempdata.ToString();
           // ViewState["lblvalue"] = lblform.Text;
        }
        private void BindStudent()
        {
            lvStudent.DataSource = _StudentDTO.GetAllStudent();
            lvStudent.DataBind();
        }
       
       

        protected void lkbCreateNew_Click(object sender, EventArgs e)
        {
           
            ViewState["Student"] = null;
            //ClearControl();
            ShowFormNo();
            divSecondary.Visible = true;
            divMain.Visible = false;
        }

        protected void lkbBack_Click(object sender, EventArgs e)
        {
            divSecondary.Visible = false;
            divMain.Visible = true;
            ViewState["Student"] = null;
            //ClearControl();
           // BindStudent();
           // lkbSave.Text = "Add New Student";
           // lkbSave.CommandName = "AddNew";
        }

        protected void lkbDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;
            var studentId = lkbItem.CommandArgument.ToString();
            if (studentId != "" || studentId != null)
            {
                var result = _StudentDTO.Delete(Convert.ToInt32(studentId));
                if (result)
                { ShowMessage("Student deleted Successfully.",true); }
                else
                {
                    ShowMessage("Some error found..", false);
                }

                BindStudent();
            }


        }
        private void ShowMessage(string message, bool successMessage)
        {
            // UC.uc_sucess msg = new UC.uc_sucess();
            UC.uc_sucess msg = (UC.uc_sucess)Page.LoadControl("~/uc/uc_sucess.ascx");
            msg.ID = "msg_id_student";
            if (successMessage)
            {
                msg.Visible = true;

                msg.VisibleError = false;
                msg.SuccessMessage = message;
            }
            else
            {
                msg.VisibleError = true;
                msg.Visible = false;
                msg.ErrorMessage = message;
            }
           // litMessage.Controls.Add(msg);
        }
        public string ImageName
        {
            get
            {
                string result=string.Empty;

                if (ViewState["VisibleError"] != null)
                {
                    result = (string)ViewState["VisibleError"];
                }

                return result;
            }
            set
            {
                ViewState["VisibleError"] = value;
                
            }
        }
        //protected void AsyncFileUpload1_UploadedComplete(object sender,AsyncFileUploadEventArgs e)
        //{
        //    if (FileUpload11.HasFile)
        //    {
        //        HiddenField1.Value = FileUpload11.FileName;
        //        string path = Server.MapPath("~/App_Data/Student/");
        //        FileUpload11.SaveAs(path + FileUpload11.FileName);
        //    }
        //}
        protected void Upload_Click(object sender, EventArgs e)
        {
            //if (FileUpload1.HasFile)
            //{
            //    HiddenField1.Value = FileUpload1.FileName;
            //    FileUpload1.SaveAs(MapPath("~/App_Data/Student/" + FileUpload1.FileName));
            //    //System.Drawing.Image img1 = System.Drawing.Image.FromFile(MapPath("~/image/") + FileUpload1.FileName);
            //    imgUserImage.ImageUrl = "~/App_Data/Student/" + FileUpload1.FileName;
            //}
        }
        protected void btnAsyncUpload_Click(object sender, EventArgs e)
        {

        }

        protected void lkbEdit_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;
            uc_Student.GetEditStudentInfo(Convert.ToInt32(lkbItem.CommandArgument.ToString()));
            divSecondary.Visible = true;
            divMain.Visible = false;
        }
    }
}