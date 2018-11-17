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
    public partial class ClassManagement : System.Web.UI.Page
    {
        cls_ClassDTO _ClassDTO;
        cls_SectionDTO _SectionDTO;
        cls_SubjectDTO _SubjectDTO;
       
        CommonBindControl commonBindControl;
        public ClassManagement()
        {
            RefreshClasses();
        }

        private void RefreshClasses()
        {
            _ClassDTO = new cls_ClassDTO();
            _SectionDTO = new cls_SectionDTO();
            _SubjectDTO = new cls_SubjectDTO();
            commonBindControl = new CommonBindControl();
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                BindDDL();
                BindPromotedData();
            }
        }

        #region BindDDL
        private void BindDDL()
        {
            BindDDLSection();
            BindDDLSubject();
            BindDDLSubSubject();
        }

        private void BindDDLSection()
        {
            commonBindControl.BindMasterData(ddlClassName, EnumConstants.Masters.Class);
            commonBindControl.BindMasterData(ddlPramodClassFrom, EnumConstants.Masters.Class);
            commonBindControl.BindMasterData(ddlPromotedClassTo, EnumConstants.Masters.Class);
            BindSectionFilter(new DropDownList());
        }

        private void BindSectionFilter(DropDownList ddlControl)
        {
            if (ddlControl.SelectedIndex > -1)
            {
                var refreshData = new cls_SectionDTO();
                var data = refreshData.GetSection(Convert.ToInt32(ddlControl.SelectedValue.ToString()));
                if (ddlControl.ID == "ddlPramodClassFrom")
                {
                    ddlPramodSectionFrom.DataSource = data;
                    ddlPramodSectionFrom.DataTextField = "SectionName";
                    ddlPramodSectionFrom.DataValueField = "SectionId";
                    ddlPramodSectionFrom.DataBind();
                    ddlPramodSectionFrom.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                }
                else if (ddlControl.ID == "ddlPromotedClassTo")
                {
                    ddlPromotedSectionTo.DataSource = data;
                    ddlPromotedSectionTo.DataTextField = "SectionName";
                    ddlPromotedSectionTo.DataValueField = "SectionId";
                    ddlPromotedSectionTo.DataBind();
                    ddlPromotedSectionTo.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                }
            }
            else
            {
                if (ddlControl.ID == "ddlPramodClassFrom")
                {
                    ddlPramodSectionFrom.DataSource = null;
                    ddlPramodSectionFrom.DataBind();
                    ddlPramodSectionFrom.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                }
                else if (ddlControl.ID == "ddlPromotedClassTo")
                {
                    ddlPromotedSectionTo.DataSource = null;
                    ddlPromotedSectionTo.DataBind();
                    ddlPromotedSectionTo.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                }
                else
                {
                    ddlPramodSectionFrom.DataSource = null;
                    ddlPramodSectionFrom.DataBind();
                    ddlPramodSectionFrom.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                    ddlPromotedSectionTo.DataSource = null;
                    ddlPromotedSectionTo.DataBind();
                    ddlPromotedSectionTo.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
                }
            }
        }
        private void BindDDLSubject()
        {
            commonBindControl.BindMasterData(ddlSubClass, EnumConstants.Masters.Class);
        }

        private void BindDDLSubSubject()
        {
            commonBindControl.BindMasterData(ddlCClassName, EnumConstants.Masters.Class);
            ddlSubjectName.Items.Clear();
            ddlSubjectName.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));

        }
        #endregion

        #region Bind
        private void BindClass()
        {
            var classData = _ClassDTO.GetOrgClass();
            lvClass.DataSource = classData;
            lvClass.DataBind();
        }

        private void BindSection()
        {
            var section = _SectionDTO.GetSectionClass();
            lvSection.DataSource = section;
            lvSection.DataBind();
        }

        private void BindSubject()
        {
            var subject = _SubjectDTO.GetSubject();
            lvSubject.DataSource = subject;
            lvSubject.DataBind();
        }

        private void BindSubSubject()
        {
            var SubSubject = _SubjectDTO.GetSubSubject();
            lvSubSubject.DataSource = SubSubject;
            lvSubSubject.DataBind();
        }

        private void Bind()
        {
            BindClass();
            BindSubSubject();
            BindSubject();
            BindSection();
        }

        #endregion

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtClassName.Text.Trim()== "")
                {
                    uc_sucess1.VisibleError = true;
                    uc_sucess1.ErrorMessage = "Class name cannot be left empty!";
                    return;
                }
                MST_CLASS obj = new MST_CLASS();
                obj.ClassName = txtClassName.Text.Trim();
                obj.Org_Id = cls_Common.UserProfile.ORG_ID;
                obj.UserId = cls_Common.UserProfile.Id;
                obj.Status =(byte) EnumConstants.Status.Active;
                obj.CreatedBy = cls_Common.UserProfile.Id;
                obj.CreatedDate = DateTime.Now;   
                _ClassDTO.Save(obj);
                uc_sucess1.Visible = true;
                uc_sucess1.SuccessMessage = "Data Saved Successfully.";
                BindClass();
                txtClassName.Text = "";
            }
            catch (Exception ex)
            {
                uc_sucess1.VisibleError = true;
                uc_sucess1.ErrorMessage = "Error Occured!";
            }
        }

        protected void lkbSaveSection_Click(object sender, EventArgs e)
        {
            try
            {
                if(ddlClassName.SelectedIndex<1)
                {
                    uc_sucess.VisibleError = true;
                    uc_sucess.ErrorMessage = "Please Select Class Name First";
                    return;
                }
                if (txtSectionName.Text.Trim() == "")
                {
                    uc_sucess.VisibleError = true;
                    uc_sucess.ErrorMessage = "Section name cannot be left empty!";
                    return;
                }
                MST_SECTION obj = new MST_SECTION();
                obj.SectionName = txtSectionName.Text.Trim();
                obj.ClassId = Convert.ToInt32(ddlClassName.SelectedValue.ToString());
                obj.Status = (byte)EnumConstants.Status.Active;
                obj.CreatedBy = cls_Common.UserProfile.Id;
                obj.CreatedDate = DateTime.Now;
                _SectionDTO.Save(obj);
                uc_sucess.Visible = true;
                uc_sucess.SuccessMessage = "Data Saved Successfully.";
                RefreshClasses();
                BindSection();
                BindDDLSection();
                txtSectionName.Text = "";
                ddlClassName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                uc_sucess.VisibleError = true;
                uc_sucess.ErrorMessage = "Error Occured!";
            }
        }

        protected void lkbSubject_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSubClass.SelectedIndex < 1)
                {
                    uc_sucess2.VisibleError = true;
                    uc_sucess2.ErrorMessage = "Please Select Class Name First";
                    return;
                }
                if (txtSubjectName.Text.Trim() == "")
                {
                    uc_sucess2.VisibleError = true;
                    uc_sucess2.ErrorMessage = "Section name cannot be left empty!";
                    return;
                }
                MST_SUBJECT obj = new MST_SUBJECT();
                obj.SubjectName = txtSubjectName.Text.Trim();
                obj.ClassId = Convert.ToInt32(ddlSubClass.SelectedValue.ToString());
                obj.Status = (byte)EnumConstants.Status.Active;
                obj.CreatedBy = cls_Common.UserProfile.Id;
                obj.CreatedDate = DateTime.Now;
                RefreshClasses();
                _SubjectDTO.Save(obj);
                uc_sucess2.Visible = true;
                uc_sucess2.SuccessMessage = "Data Saved Successfully.";
                BindSubject();
                BindDDLSubject();
                txtSubjectName.Text = "";
                ddlSubClass.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                uc_sucess2.VisibleError = true;
                uc_sucess2.ErrorMessage = "Error Occured!";
            }
        }

        protected void lkbDeleteClass_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;

            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int classID = Convert.ToInt32(lkbItem.CommandArgument);
                _ClassDTO.DeleteClass(classID);
                uc_sucess1.SuccessMessage = "Data Deleted Successfully.";
                BindClass();
            }
        }
        protected void lkbDeleteSection_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;

            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int sectionID = Convert.ToInt32(lkbItem.CommandArgument);
                _ClassDTO.DeleteSection(sectionID);
                uc_sucess.SuccessMessage = "Data Deleted Successfully.";
                BindSection();
                BindDDLSection();
            }
        }

        protected void lkbSubjectDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;

            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int subjectID = Convert.ToInt32(lkbItem.CommandArgument);
                _ClassDTO.DeleteSubject(subjectID);
                uc_sucess2.SuccessMessage = "Data Deleted Successfully.";
                BindSubject();
                BindDDLSubject();
            }
        }

        protected void ddlCClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCClassName.SelectedIndex > 0)
            {
                var data = _SubjectDTO.GetSubject(Int32.Parse(ddlCClassName.SelectedValue));
                ddlSubjectName.DataSource = data.Select(x => new { x.SubjectId, x.SubjectName });
                ddlSubjectName.DataTextField = "SubjectName";
                ddlSubjectName.DataValueField = "SubjectId";
                ddlSubjectName.DataBind();
                ddlSubjectName.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }
        }

        protected void lkbSubjectSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlCClassName.SelectedIndex < 1)
                {
                    uc_sucess3.VisibleError = true;
                    uc_sucess3.ErrorMessage = "Please Select Class Name First";
                    return;
                }
                if (ddlSubjectName.SelectedIndex < 1)
                {
                    uc_sucess3.VisibleError = true;
                    uc_sucess3.ErrorMessage = "Please Select Subject Name First";
                    return;
                }
                if (txtSubSubjectName.Text.Trim() == "")
                {
                    uc_sucess3.VisibleError = true;
                    uc_sucess3.ErrorMessage = "Sub Subject cannot be left empty";
                    return;
                }
                MST_SUB_SUBJECT SubSubject = new MST_SUB_SUBJECT { SubjectId = Convert.ToInt32(ddlSubjectName.SelectedValue), subSubjectName = txtSubSubjectName.Text };
                if (_SubjectDTO.Create(SubSubject))
                {
                    uc_sucess3.SuccessMessage = "Sub-Subject Created Successfully";
                    uc_sucess3.Visible = true;
                    BindSubSubject();
                    BindDDLSubSubject();
                }
            }
            catch
            {
                uc_sucess3.VisibleError = true;
                uc_sucess3.ErrorMessage = "Error Occured!";
            }
        }

        protected void lkbSubSubjectDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbSubject = (LinkButton)sender;
            if (!string.IsNullOrEmpty(lkbSubject.CommandArgument.ToString()))
            {
                int subSubjectID = Convert.ToInt32(lkbSubject.CommandArgument);
                _SubjectDTO.Delete(subSubjectID);
                uc_sucess3.SuccessMessage = "Data Deleted Successfully.";
                uc_sucess3.Visible = true;
                lvSubSubject.DataSource = null;
                lvSubSubject.DataBind();
                BindSubSubject();
                BindDDLSubSubject();
            }
        }
        protected void ddlClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            BindSectionFilter(ddl);
        }

        protected void lkbSavePromotedData_Click(object sender, EventArgs e)
        {
            TRN_STUDENT_PROMOTED_SETTING obj = new TRN_STUDENT_PROMOTED_SETTING();
            obj.PromotedClassFromId = Convert.ToInt32(ddlPramodClassFrom.SelectedValue);
            obj.PromotedSectionFromId = Convert.ToInt32(ddlPramodSectionFrom.SelectedValue);
            obj.PromotedClassToId = Convert.ToInt32(ddlPromotedClassTo.SelectedValue);
            obj.PromotedSectionToId = Convert.ToInt32(ddlPromotedSectionTo.SelectedValue);
            cls_Promoted_Student repo = new cls_Promoted_Student();
            var isSaved = repo.Create(obj);
            if (isSaved)
            {
                uc_sucessPromoted.Visible = true;
                uc_sucessPromoted.SuccessMessage = "Save successfully.";
                BindPromotedData();
            }
            else
            {
                uc_sucessPromoted.VisibleError = true;
                uc_sucessPromoted.ErrorMessage = "Not saved.";
            }
        }

        private void BindPromotedData()
        {
            cls_Promoted_Student repo = new cls_Promoted_Student();
            lvPromoted.DataSource = repo.Filter(f => f.MST_CLASS.MST_ORGANIZATION.Org_Id == cls_Common.UserProfile.ORG_ID).ToList();
            lvPromoted.DataBind();
        }

        protected void lkbPSDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;
            cls_Promoted_Student repo = new cls_Promoted_Student();
            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int ID = Convert.ToInt32(lkbItem.CommandArgument);
                repo.Delete(d => d.PromotedId == ID);
                uc_sucessPromoted.Visible = true;
                uc_sucessPromoted.SuccessMessage = "Data Deleted Successfully.";
                BindPromotedData();
            }
        }

        protected void lvClass_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lvClass.EditIndex = e.NewEditIndex;
            BindClass();
        }

        protected void lvClass_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {

            String ClassName = e.NewValues["ClassName"].ToString();
            int classId = (int)e.Keys["ClassId"];
            MST_CLASS classItem = new MST_CLASS();
            classItem.ClassName = ClassName;
            classItem.ClassId = classId;
            classItem.UpdatedBy = cls_Common.UserProfile.Id;
            var isUpdate = _ClassDTO.Update(classItem);
            if (isUpdate)
            {
                _ClassDTO = new cls_ClassDTO();
                lvClass.EditIndex = -1;
                BindClass();
            }
        }

        protected void lvClass_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lvClass.EditIndex = -1;
            BindClass();
        }

        protected void lvSection_ItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            lvSection.EditIndex = -1;
            BindSection(); 
        }

        protected void lvSection_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            lvSection.EditIndex = e.NewEditIndex;
            BindSection();
        }

        protected void lvSection_ItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            String SectionName = e.NewValues["SectionName"].ToString();
            int SectionId = (int)e.Keys["SectionId"];
            MST_SECTION item = new MST_SECTION();
            item.SectionName = SectionName;
            item.SectionId = SectionId;
            item.UpdatedBy = cls_Common.UserProfile.Id;
            var isUpdate = _SectionDTO.Update(item);
            if (isUpdate)
            {
                _SectionDTO = new cls_SectionDTO();
                lvSection.EditIndex = -1;
                BindSection();
            }
        }
    }
}