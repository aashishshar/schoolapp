using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class Student : System.Web.UI.Page
    {
        cls_StudentDTO _StudentDTO;
        CommonBindControl commonBindControl;
        cls_SectionDTO _sectionDTO;
        cls_City _cls_City;
        cls_ClassDTO _classDTO;
        cls_StudentSubjectDTO _StudentSubjectDTO;

        public Student()
        {
            _StudentDTO = new cls_StudentDTO();
            commonBindControl = new CommonBindControl();
            _sectionDTO = new cls_SectionDTO();
            _cls_City = new cls_City();
            _classDTO = new cls_ClassDTO();
            _StudentSubjectDTO = new cls_StudentSubjectDTO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!IsPostBack)
            {
                Bind(); 
                BindCast();
                BindSection();
                BindClassSubject();
                ShowFormNo();
                txtDob.Attributes.Add("readonly", "true");

            }//ScriptManager.GetCurrent(this).RegisterPostBackControl(this.lkbSave);
        }

        public void ShowFormNo()
        {
            var tempdata = _StudentDTO.GetformData();
            lblform.Text = tempdata.ToString();
            // ViewState["lblvalue"] = lblform.Text;
        }
       
        private void Bind()
        {
            commonBindControl.BindMasterData(ddlClassName, EnumConstants.Masters.Class);
            //commonBindControl.BindMasterData(ddlSectionName, EnumConstants.Masters.Section);
            commonBindControl.BindMasterData(ddlStateName, EnumConstants.Masters.State);
            // commonBindControl.BindMasterData(ddlCityName, EnumConstants.Masters.City);
            commonBindControl.BindMasterData(ddlCasteType, EnumConstants.Masters.Cast);
            commonBindControl.BindMasterData(ddlReligionName, EnumConstants.Masters.Religion);
            commonBindControl.BindMasterData(ddlOccupation, EnumConstants.Masters.Occupation);
            commonBindControl.BindMasterData(ddlYear, EnumConstants.Masters.AcademicYear);
            BindCity();
        }

        private void BindClassSubject()
        {
            if (ddlClassName.SelectedIndex > -1)
            {
                cblListSubject.DataSource = _classDTO.GetClassSubject(Convert.ToInt32(ddlClassName.SelectedValue.ToString()));
                cblListSubject.DataBind();
            }
            else
            {
                cblListSubject.DataSource = null;
                cblListSubject.DataBind();
            }
        }

        private void BindCity()
        {

            if (ddlStateName.SelectedIndex > -1)
            {
                ddlCityName.DataSource = _cls_City.GetCity(Convert.ToInt32(ddlStateName.SelectedValue.ToString()));
                ddlCityName.DataTextField = "CityName";
                ddlCityName.DataValueField = "CityId";
                ddlCityName.DataBind();
                ddlCityName.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }
            else
            {
                ddlCityName.DataSource = null;
                ddlCityName.DataBind();
                ddlCityName.Items.Insert(0, new ListItem("[ SELECT ]", "-1"));
            }

        }

        protected void lkbSave_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Page.IsValid)
                //{
                if (ddlClassName.SelectedIndex == 0)
                {
                    ShowMessage("Kindly select Class Name.", false);
                    return;
                }

                if (ddlSectionName.SelectedIndex == 0)
                {
                    ShowMessage("Kindly select Section Name.", false);
                    return;
                }

                if (string.IsNullOrEmpty(txtStudentname.Text.Trim()))
                {
                    ShowMessage("Kindly Enter Student Name.", false);
                    return;
                }
                if (string.IsNullOrEmpty(txtFathername.Text.Trim()))
                {
                    ShowMessage("Kindly Enter Father Name.", false);
                    return;
                }
                if (string.IsNullOrEmpty(txtMothername.Text.Trim()))
                {
                    ShowMessage("Kindly Enter Mother Name.", false);
                    return;
                }
                if (string.IsNullOrEmpty(txtDob.Text.Trim()))
                {
                    ShowMessage("Kindly Enter Date Of Birth.", false);
                    return;
                }
                MST_STUDENT student = new MST_STUDENT();

                string fileName = "";

                //  string ima = HiddenField1.Value;
                if (FileUpload1.HasFile)
                {
                    // Read the file and convert it to Byte Array
                    //string filePath = FileUpload1.PostedFile.FileName;
                    //string filename = Path.GetFileName(filePath);
                    //string ext = Path.GetExtension(filename);
                    //string contenttype = String.Empty;
                    ////Set the contenttype based on File Extension 
                    //switch (ext)
                    //{
                    //    case ".jpg":
                    //    case ".JPG":
                    //        contenttype = "image/jpg";
                    //        break;
                    //    case ".png":
                    //    case ".PNG":
                    //        contenttype = "image/png";
                    //        break;
                    //    case ".jpeg":
                    //    case ".JPEG":
                    //        contenttype = "image/jpeg";
                    //        break;
                    //}
                    //if (contenttype != String.Empty)
                    //{
                    //    Stream fs = FileUpload1.PostedFile.InputStream;
                    //    BinaryReader br = new BinaryReader(fs);
                    //    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    //    System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                    //    decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);
                    //    if (size > 2048)
                    //    {
                    //        ShowMessage("Size of the image to be uploaded cannot exceed two mb.", false);

                    //        return;
                    //    }
                    //    ImgByte = bytes;
                    //}

                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(Path.GetFileName(FileUpload1.PostedFile.FileName));
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Images/") + fileName);
                    student.ImageUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ("/Images/") + fileName;
                }
                student.FormNumber = Convert.ToInt64(lblform.Text.ToString());
                student.RollNumber = txtRollNo.Text.Trim();
                student.SerialNumber = txtSerialNumber.Text.Trim();
                student.StudentName = txtStudentname.Text.Trim();
                student.FatherName = txtFathername.Text.Trim();
                student.MotherName = txtMothername.Text.Trim();
                if (!string.IsNullOrEmpty(txtDob.Text.Trim()))
                {
                    student.DOB = DateTime.ParseExact(txtDob.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);// Convert.ToDateTime(txtDob.Text.Trim());//
                }
                    student.Email = txtEmailId.Text.Trim();
                student.LastSchoolName = txtlastschool.Text.Trim();
                if (ddlOccupation.SelectedIndex > 0)
                    student.Occupation = Convert.ToInt32(ddlOccupation.SelectedItem.Value);//
                student.ResidingSince = txtresiding.Text.Trim();
                student.Gender = ddlGender.SelectedValue;// rdoMale.Checked;
                student.ReferredBy = txtReferred.Text.Trim();
                student.AadharNumber = txtAadharNo.Text.Trim();
                //student.Session = ddlYear.SelectedValue;// Convert.ToByte(EnumConstants.Session.Current);//
                student.ReferredMobileNumber = txtMobileNo.Text.Trim();
                student.CorrespondenceAddress = txtCorrespondenceAddress.Text.Trim();
                //student.PermanentAddress = txtPermanentAddress.Text.Trim();
                student.Village_Town = txtVillage.Text.Trim();
                student.ContactNumber = txtContactNo.Text.Trim();
                student.ZipCode = txtPincode.Text.Trim();
                student.Nationality = txtNationality.Text.Trim();
                student.WhatsAppNo = txtWhatsapNo.Text.Trim();
                if (ddlSectionName.SelectedIndex > 0)
                    student.SectionId = Convert.ToInt32(ddlSectionName.SelectedItem.Value);
                if (ddlStateName.SelectedIndex > 0)
                    student.StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);//
                if (ddlCityName.SelectedIndex > 0)
                    student.CityId = Convert.ToInt32(ddlCityName.SelectedItem.Value);//
                if (ddlCasteType.SelectedIndex > 0)
                    student.CasteType = Convert.ToByte(ddlCasteType.SelectedIndex);//
                if (ddlReligionName.SelectedIndex > 0)
                    student.ReligionId = Convert.ToInt32(ddlReligionName.SelectedItem.Value);//
                if (ddlCasteName.SelectedIndex > 0)
                    student.CasteId = Convert.ToInt32(ddlCasteName.SelectedItem.Value);//

                student.CreatedBy = cls_Common.UserProfile.Id;
                student.CreatedDate = DateTime.Now;

                student.ClassId = Convert.ToInt32(ddlClassName.SelectedValue);
                student.Fin_ID = Convert.ToInt32(ddlYear.SelectedValue);
                List<TRN_STUDENT_SUBJECT> subjects = new List<TRN_STUDENT_SUBJECT>();
                foreach (ListItem li in cblListSubject.Items)
                {
                    if (li.Selected)
                    {
                        TRN_STUDENT_SUBJECT item = new TRN_STUDENT_SUBJECT
                        {
                            SubjectId = Convert.ToInt32(li.Value)
                        };
                        subjects.Add(item);
                    }
                }
                student.TRN_STUDENT_SUBJECT = subjects;




                string studentid = Convert.ToString(ViewState["Student"]);
                if (studentid == "" || studentid == null)
                {
                    var result = _StudentDTO.Save(student);
                    if (result)
                    {
                        ShowMessage("Student Information Saved Successfully..", true);
                        ClearControl();
                        ShowFormNo();
                    }
                    else
                    {
                        ShowMessage("Some error found..", false);
                    }

                }
                else
                {
                    int exitstudentid = Convert.ToInt32(studentid);
                    var newdata = _StudentDTO.GetDataForEdit(exitstudentid);
                    newdata.ImageUrl = student.ImageUrl;
                    newdata.RollNumber = txtRollNo.Text.Trim();
                    newdata.SerialNumber = txtSerialNumber.Text.Trim();
                    newdata.StudentName = txtStudentname.Text.Trim();
                    newdata.FatherName = txtFathername.Text.Trim();
                    newdata.MotherName = txtMothername.Text.Trim();
                    newdata.DOB = DateTime.ParseExact(txtDob.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);// Convert.ToDateTime(txtDob.Text.Trim());
                    newdata.Email = txtEmailId.Text.Trim();
                    newdata.LastSchoolName = txtlastschool.Text.Trim();
                    if (ddlOccupation.SelectedIndex > 0)
                        newdata.Occupation = Convert.ToInt32(ddlOccupation.SelectedItem.Value);
                    newdata.ResidingSince = txtresiding.Text.Trim();
                    newdata.Gender = ddlGender.SelectedValue;// rdoMale.Checked;
                    newdata.ReferredBy = txtReferred.Text.Trim();
                    newdata.AadharNumber = txtAadharNo.Text.Trim();
                    newdata.Session = Convert.ToByte(EnumConstants.Session.Current);
                    newdata.ReferredMobileNumber = txtMobileNo.Text.Trim();
                    newdata.CorrespondenceAddress = txtCorrespondenceAddress.Text.Trim();
                    newdata.Village_Town = txtVillage.Text.Trim();
                    newdata.ContactNumber = txtContactNo.Text.Trim();
                    newdata.ZipCode = txtPincode.Text.Trim();
                    newdata.Nationality = txtNationality.Text.Trim();
                    newdata.WhatsAppNo = txtWhatsapNo.Text.Trim();
                    if (ddlSectionName.SelectedIndex > 0)
                        newdata.SectionId = Convert.ToInt32(ddlSectionName.SelectedItem.Value);
                    if (ddlStateName.SelectedIndex > 0)
                        newdata.StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
                    if (ddlCityName.SelectedIndex > 0)
                        newdata.CityId = Convert.ToInt32(ddlCityName.SelectedItem.Value);
                    if (ddlCasteName.SelectedIndex > 0)
                        newdata.CasteType = Convert.ToByte(ddlCasteType.SelectedIndex);
                    if (ddlReligionName.SelectedIndex > 0)
                        newdata.ReligionId = Convert.ToInt32(ddlReligionName.SelectedItem.Value);
                    if (ddlCasteName.SelectedIndex > 0)
                        newdata.CasteId = Convert.ToInt32(ddlCasteName.SelectedItem.Value);
                    newdata.CreatedBy = cls_Common.UserProfile.Id;
                    newdata.CreatedDate = DateTime.Now;

                    List<TRN_STUDENT_SUBJECT> subject = new List<TRN_STUDENT_SUBJECT>();
                    foreach (ListItem li in cblListSubject.Items)
                    {
                        if (li.Selected)
                        {
                            TRN_STUDENT_SUBJECT item = _StudentSubjectDTO.GetSubjectBy_StudentId_SubjectId(exitstudentid, Convert.ToInt32(li.Value));
                            if (item == null)
                                _StudentSubjectDTO.Save(new TRN_STUDENT_SUBJECT { StudentId = exitstudentid, SubjectId = Convert.ToInt32(li.Value) });
                        }
                        else
                        {
                            TRN_STUDENT_SUBJECT item = _StudentSubjectDTO.GetSubjectBy_StudentId_SubjectId(exitstudentid, Convert.ToInt32(li.Value));
                            if (item != null)
                                _StudentSubjectDTO.Delete(item);
                        }
                    }
                    _StudentDTO.Update(student);
                    var result = _StudentDTO.Save(newdata);
                    if (result)
                    {
                        ShowMessage("Student Information updated Successfully..", true);
                        lkbSave.Text = "Add New Student";
                        lkbSave.CommandName = "AddNew";
                        ClearControl();
                        ViewState["Student"] = null;
                        ShowFormNo();
                    }
                    else
                    {
                        ShowMessage("Some error found in update student info..", false);
                    }
                }

                // uc_sucess.Visible
                //BindStudent();
                //}
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, false);
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
            litMessage.Controls.Add(msg);
        }


        public void ClearControl()
        {
            txtRollNo.Text = "";
            txtSerialNumber.Text = "";
            txtStudentname.Text = "";
            txtFathername.Text = "";
            txtMothername.Text = "";
            txtDob.Text = "";
            txtEmailId.Text = "";
            txtlastschool.Text = "";
            txtresiding.Text = "";
            txtReferred.Text = "";
            txtAadharNo.Text = "";
            txtMobileNo.Text = "";
            txtCorrespondenceAddress.Text = "";
            txtVillage.Text = "";
            txtContactNo.Text = "";
            txtPincode.Text = "";
            txtNationality.Text = "";
            txtWhatsapNo.Text = "";

            Bind();
            BindSection();
            BindCity();
            BindCast();
            imgUserImage.ImageUrl = "";
        }
        protected void ddlCasteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCast();
        }

        private void BindCast()
        {
            if (ddlCasteType.SelectedIndex > -1)
            {
                string castetype = Convert.ToString(ddlCasteType.SelectedValue);

                ddlCasteName.DataSource = _StudentDTO.GetCastebycastetype(castetype);
                ddlCasteName.DataTextField = "CasteName";
                ddlCasteName.DataValueField = "CasteId";
                ddlCasteName.DataBind();
                ddlCasteName.Items.Insert(0, new ListItem(" [ SELECT ] ", "-1"));
            }
            else
            {
                ddlCasteName.DataSource = null;
                ddlCasteName.DataBind();
                ddlCasteName.Items.Insert(0, new ListItem(" [ SELECT ] ", "-1"));
            }
        }

        protected void ddlClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindClassSubject();
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

        protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCity();
        }

        protected void lkbEdit_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;

            if (!string.IsNullOrEmpty(lkbItem.CommandArgument.ToString()))
            {
                int studentID = Convert.ToInt32(lkbItem.CommandArgument);
                ViewState["Student"] = studentID;
                lkbSave.Text = "Update Student Info...";
                lkbSave.CommandName = "Update";
                var temdata = _StudentDTO.GetDataForEdit(studentID);
                if (temdata.ImageUrl != null)
                {
                    imgUserImage.ImageUrl = temdata.ImageUrl;
                }
                txtRollNo.Text = temdata.RollNumber;
                lblform.Text = temdata.FormNumber.ToString();
                txtSerialNumber.Text = temdata.SerialNumber;
                txtStudentname.Text = temdata.StudentName;
                txtFathername.Text = temdata.FatherName;
                txtMothername.Text = temdata.MotherName;
                if (temdata.DOB.HasValue)
                    txtDob.Text = (DateTime.ParseExact(temdata.DOB.Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)).ToString(); //temdata.DOB.Value.ToShortDateString();
                txtEmailId.Text = temdata.Email;
                txtlastschool.Text = temdata.LastSchoolName;
                if (temdata.Occupation.HasValue)
                    ddlOccupation.SelectedValue = Convert.ToString(temdata.Occupation);
                txtresiding.Text = temdata.ResidingSince;
                if (!string.IsNullOrEmpty(temdata.Gender))
                    ddlGender.SelectedValue = temdata.Gender;
                txtReferred.Text = temdata.ReferredBy;
                txtAadharNo.Text = temdata.AadharNumber;
                txtMobileNo.Text = temdata.ReferredMobileNumber;
                txtCorrespondenceAddress.Text = temdata.CorrespondenceAddress;
                txtVillage.Text = temdata.Village_Town;
                txtContactNo.Text = temdata.ContactNumber;
                txtPincode.Text = temdata.ZipCode;
                txtNationality.Text = temdata.Nationality;
                txtWhatsapNo.Text = temdata.WhatsAppNo;

                if (temdata.MST_SECTION.ClassId.HasValue)
                    ddlClassName.SelectedValue = Convert.ToString(temdata.MST_SECTION.ClassId);

                BindClassSubject();
                if (temdata.TRN_STUDENT_SUBJECT != null)
                {
                    foreach (TRN_STUDENT_SUBJECT subject in temdata.TRN_STUDENT_SUBJECT)
                    {
                        cblListSubject.SelectedValue = subject.SubjectId.ToString();
                    }
                }
                BindSection();
                if (temdata.SectionId.HasValue)
                    ddlSectionName.SelectedValue = Convert.ToString(temdata.SectionId);
                Bind();
                if (temdata.CasteType.HasValue)
                    ddlCasteType.SelectedIndex = Convert.ToInt32(temdata.CasteType);
                BindCast();
                if (temdata.ReligionId.HasValue)
                    ddlReligionName.SelectedValue = Convert.ToString(temdata.ReligionId);
                if (temdata.CasteId.HasValue)
                    ddlCasteName.SelectedValue = Convert.ToString(temdata.CasteId);
                if (temdata.StateId.HasValue)
                    ddlStateName.SelectedValue = Convert.ToString(temdata.MST_CITY.StateId);
                BindCity();
                if (temdata.CityId.HasValue)
                    ddlCityName.SelectedValue = Convert.ToString(temdata.CityId);

               
            }
        }

        protected void lkbCreateNew_Click(object sender, EventArgs e)
        {

            ViewState["Student"] = null;
            ClearControl();
            ShowFormNo();
           
        }

        protected void lkbBack_Click(object sender, EventArgs e)
        {
          
            ViewState["Student"] = null;
            ClearControl();
          
            lkbSave.Text = "Add New Student";
            lkbSave.CommandName = "AddNew";
        }

        protected void lkbDelete_Click(object sender, EventArgs e)
        {
            LinkButton lkbItem = (LinkButton)sender;
            var studentId = lkbItem.CommandArgument.ToString();
            if (studentId != "" || studentId != null)
            {
                var result = _StudentDTO.Delete(Convert.ToInt32(studentId));
                if (result)
                { ShowMessage("Student deleted Successfully.", true); }
                else
                {
                    ShowMessage("Some error found..", false);
                }

               
            }


        }
        public string ImageName
        {
            get
            {
                string result = string.Empty;

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
    }
}
